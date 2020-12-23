namespace Framework.Core.Specifications
{
    public interface ISpecification<T>
    {
        bool IsSatisfiedBy(T value);
    }
}