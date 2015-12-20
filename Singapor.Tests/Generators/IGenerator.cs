using Singapor.Services.Abstract;

namespace Singapor.Tests.Generators
{
    public interface IGenerator<T> where T : ModelBase
    {
        T Get();
    }
}