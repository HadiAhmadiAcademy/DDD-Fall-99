using System.Threading.Tasks;

namespace LoanApplications.Application.Framework
{
    public interface ICommandHandler<T>
    {
        Task Handle(T command);
    }
}