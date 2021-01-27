using System.Threading.Tasks;
using MassTransit;
using Scoring.Application.Contracts.Rules;

namespace Scoring.Application.EventHandlers.External
{
    public class EmployeeProfileCompletedHandler : IConsumer<EmployeeProfileCompleted>
    {
        public Task Consume(ConsumeContext<EmployeeProfileCompleted> context)
        {
            return Task.CompletedTask;
        }
    }
}