using MiskStartupSchool.DTO;

namespace MiskStartupSchool.Services
{
    public interface IAppTemplate
    {
        Task<AppTemplateDto> GetTemplateAsync(string Id);
        Task<bool> UpdateTemplateAsync(AppTemplateDto program, string Id);
    }
}
