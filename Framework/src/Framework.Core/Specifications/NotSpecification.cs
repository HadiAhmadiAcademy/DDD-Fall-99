namespace Framework.Core.Specifications
{
    public class NotSpecification<T> : Specification<T>
    {
        private readonly ISpecification<T> _target;
        public NotSpecification(ISpecification<T> target)
        {
            _target = target;
        }
        public override bool IsSatisfiedBy(T value)
        {
            return !_target.IsSatisfiedBy(value);
        }
    }
}