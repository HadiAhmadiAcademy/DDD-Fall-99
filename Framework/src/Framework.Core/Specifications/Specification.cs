namespace Framework.Core.Specifications
{
    public abstract class Specification<T> : ISpecification<T>
    {
        public abstract bool IsSatisfiedBy(T value);
        public Specification<T> And(ISpecification<T> left)
        {
            return new AndSpecification<T>(this, left);
        }
        public Specification<T> Or(ISpecification<T> left)
        {
            return new OrSpecification<T>(this, left);
        }
        public Specification<T> Not()
        {
            return new NotSpecification<T>(this);
        }
    }
}