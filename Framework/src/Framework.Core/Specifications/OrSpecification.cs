namespace Framework.Core.Specifications
{
    public class OrSpecification<T> : CompositeSpecification<T>
    {
        public OrSpecification(ISpecification<T> right, ISpecification<T> left) : base(right, left)
        {
        }

        public override bool IsSatisfiedBy(T value)
        {
            return Right.IsSatisfiedBy(value) ||
                   Left.IsSatisfiedBy(value);
        }
    }
}