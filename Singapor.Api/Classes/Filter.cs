using System;

namespace Singapor.Api.Classes
{
	public class Filter
	{
		#region Properties

		public int Top { get; set; }
		public SingleFilter SingleFilter { get; set; }

		#endregion
	}

	public class SingleFilter
	{
		#region Properties

		public string Field { get; private set; }
		public ComparisonOperator Comparison { get; private set; }
		public string Data { get; set; }

		#endregion

		#region Constructors

		public SingleFilter(string field, ComparisonOperator op, string data)
		{
			Field = field;
			Comparison = op;
			Data = data;
		}

		#endregion
	}

	[Flags]
	public enum ComparisonOperator
	{
		/// <summary>
		/// the value of the search indicator is false
		/// </summary>
		None = 0,

		/// <summary>
		/// equal
		/// </summary>
		Eq = 1,

		/// <summary>
		/// not equal
		/// </summary>
		Ne = 2,

		/// <summary>
		/// less than
		/// </summary>
		Lt = 3,

		/// <summary>
		/// less or equal
		/// </summary>
		Le = 4,

		/// <summary>
		/// greater than
		/// </summary>
		gt = 5,

		/// <summary>
		/// greater or equal
		/// </summary>
		Ge = 6,

		/// <summary>
		/// begins with
		/// </summary>
		Bw = 7,

		/// <summary>
		/// does not begin with
		/// </summary>
		Bn = 8,

		/// <summary>
		/// is in
		/// </summary>
		In = 9,

		/// <summary>
		/// is not in
		/// </summary>
		Ni = 10,

		/// <summary>
		/// ends with
		/// </summary>
		Ew = 11,

		/// <summary>
		/// does not end with
		/// </summary>
		En = 12,

		/// <summary>
		/// contains
		/// </summary>
		Cn = 13,

		/// <summary>
		/// does not contain
		/// </summary>
		Nc = 14
	}
}