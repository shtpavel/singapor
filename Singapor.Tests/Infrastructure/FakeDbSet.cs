using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Singapor.Tests
{
	public class FakeDbSet<T> : IDbSet<T> where T : class
	{
		#region Fields

		private readonly IQueryable _query;
		protected readonly HashSet<T> Data;

		#endregion

		#region Properties

		public ObservableCollection<T> Local
		{
			get { return new ObservableCollection<T>(Data); }
		}

		public Type ElementType
		{
			get { return _query.ElementType; }
		}

		public Expression Expression
		{
			get { return _query.Expression; }
		}

		public IQueryProvider Provider
		{
			get { return new AsyncQueryProviderWrapper<T>(_query.Provider); }
		}

		#endregion

		#region Constructors

		public FakeDbSet()
		{
			Data = new HashSet<T>();
			_query = Data.AsQueryable();
		}

		#endregion

		#region Public methods

		public T Add(T entity)
		{
			lock (Data)
				Data.Add(entity);
			return entity;
		}

		public void AddOrUpdate(Expression<Func<T, object>> identifierExpression, params T[] entities)
		{
			AddOrUpdate(entities);
		}

		public void AddOrUpdate(params T[] entities)
		{
			foreach (var entity in entities)
			{
				Add(entity);
			}
		}

		public T Attach(T entity)
		{
			lock (Data) Data.Add(entity);
			return entity;
		}

		public TDerivedEntity Create<TDerivedEntity>() where TDerivedEntity : class, T
		{
			throw new NotImplementedException();
		}

		public T Create()
		{
			return Activator.CreateInstance<T>();
		}

		public virtual T Find(params object[] keyValues)
		{
			throw new NotImplementedException("Use FakeFindableDbSet");
		}

		public IEnumerator<T> GetEnumerator()
		{
			return Data.GetEnumerator();
		}

		public T Remove(T entity)
		{
			lock (Data) Data.Remove(entity);
			return entity;
		}

		#endregion

		#region Private methods

		IEnumerator IEnumerable.GetEnumerator()
		{
			return Data.GetEnumerator();
		}

		#endregion
	}

	internal class AsyncQueryProviderWrapper<T> : IDbAsyncQueryProvider
	{
		#region Fields

		private readonly IQueryProvider _inner;

		#endregion

		#region Constructors

		internal AsyncQueryProviderWrapper(IQueryProvider inner)
		{
			_inner = inner;
		}

		#endregion

		#region Public methods

		public IQueryable CreateQuery(Expression expression)
		{
			return new AsyncEnumerableQuery<T>(expression);
		}

		public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
		{
			return new AsyncEnumerableQuery<TElement>(expression);
		}

		public object Execute(Expression expression)
		{
			return _inner.Execute(expression);
		}

		public TResult Execute<TResult>(Expression expression)
		{
			return _inner.Execute<TResult>(expression);
		}

		public Task<object> ExecuteAsync(Expression expression, CancellationToken cancellationToken)
		{
			return Task.FromResult(Execute(expression));
		}

		public Task<TResult> ExecuteAsync<TResult>(Expression expression, CancellationToken cancellationToken)
		{
			return Task.FromResult(Execute<TResult>(expression));
		}

		#endregion
	}

	public class AsyncEnumerableQuery<T> : EnumerableQuery<T>, IDbAsyncEnumerable<T>
	{
		#region Constructors

		public AsyncEnumerableQuery(IEnumerable<T> enumerable)
			: base(enumerable)
		{
		}

		public AsyncEnumerableQuery(Expression expression)
			: base(expression)
		{
		}

		#endregion

		#region Public methods

		public IDbAsyncEnumerator<T> GetAsyncEnumerator()
		{
			return new AsyncEnumeratorWrapper<T>(this.AsEnumerable().GetEnumerator());
		}

		#endregion

		#region Private methods

		IDbAsyncEnumerator IDbAsyncEnumerable.GetAsyncEnumerator()
		{
			return GetAsyncEnumerator();
		}

		#endregion
	}

	public class AsyncEnumeratorWrapper<T> : IDbAsyncEnumerator<T>
	{
		#region Fields

		private readonly IEnumerator<T> _inner;

		#endregion

		#region Properties

		public T Current
		{
			get { return _inner.Current; }
		}

		object IDbAsyncEnumerator.Current
		{
			get { return Current; }
		}

		#endregion

		#region Constructors

		public AsyncEnumeratorWrapper(IEnumerator<T> inner)
		{
			_inner = inner;
		}

		#endregion

		#region Public methods

		public void Dispose()
		{
			_inner.Dispose();
		}

		public Task<bool> MoveNextAsync(CancellationToken cancellationToken)
		{
			return Task.FromResult(_inner.MoveNext());
		}

		#endregion
	}
}