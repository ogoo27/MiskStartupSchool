using Microsoft.AspNetCore.Mvc;
using MiskStartupSchool.DTO;

namespace MiskStartupSchool.Services
{
    public interface IApplicationRepo
    {
        Task<ProgramDto> GetProgramAsync(string Id);
        Task<List<ApplicationDto>> GetAllProgramAsync();
        Task<bool> UpdateProgramAsync(ProgramDto program, string Id);
        Task<string> AddAsync(ApplicationDto application);
        Task<bool> Remove(string Id);
    }
}
