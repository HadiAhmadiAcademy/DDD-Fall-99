using System.Threading.Tasks;

namespace Framework.Application
{
    public interface ICommandBus
    {
        Task Dispatch<T>(T command);
    }
}
