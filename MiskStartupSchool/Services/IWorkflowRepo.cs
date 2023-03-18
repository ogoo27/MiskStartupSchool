using MiskStartupSchool.DTO;

namespace MiskStartupSchool.Services
{
    public interface IWorkflowRepo
    {
        Task<WorkflowDto> GetWorkflowAsync(string Id);
        Task<bool> UpdateWorkflowAsync(WorkflowDto program, string Id);
    }
}
