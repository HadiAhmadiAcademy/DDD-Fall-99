namespace Framework.Core.Specifications
{
    public class AndSpecification<T> : CompositeSpecification<T>
    {
        public AndSpecification(ISpecification<T> right, ISpecification<T> left) : base(right, left)
        {
        }

        public override bool IsSatisfiedBy(T value)
        {
            return Right.IsSatisfiedBy(value) &&
                   Left.IsSatisfiedBy(value);
        }
    }
}