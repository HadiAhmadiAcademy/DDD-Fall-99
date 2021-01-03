using System.Threading.Tasks;

namespace Framework.Application
{
    public interface ICommandHandler<in T>
    {
        Task Handle(T command);
    }
}
