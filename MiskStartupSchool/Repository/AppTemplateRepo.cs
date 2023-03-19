using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MiskStartupSchool.Context;
using MiskStartupSchool.DTO;
using MiskStartupSchool.Services;

namespace MiskStartupSchool.Repository
{
    public class AppTemplateRepo : IAppTemplate
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AppTemplateRepo(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<AppTemplateDto> GetTemplateAsync(string Id)
        {
            var data = await _context.application.FirstOrDefaultAsync(x => x.ApplicationId == Id);
            if (data == null) return null;

            var res = _mapper.Map<AppTemplateDto>(data);
            return res;
           
        }

        public async Task<bool> UpdateTemplateAsync(AppTemplateDto program, string Id)
        {
            var data = await _context.application.FirstOrDefaultAsync(x => x.ApplicationId == Id);

            if (data == null) return false;
            var res = _mapper.Map<AppTemplateDto>(data);

            _context.Update(data);
            return _context.SaveChanges() > 0;
        }
    }
}
