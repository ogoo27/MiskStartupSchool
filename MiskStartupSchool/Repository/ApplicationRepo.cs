using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MiskStartupSchool.Context;
using MiskStartupSchool.DTO;
using MiskStartupSchool.Entities;
using MiskStartupSchool.Enums;
using MiskStartupSchool.Services;
using static System.Net.Mime.MediaTypeNames;

namespace MiskStartupSchool.Repository
{
    public class ApplicationRepo : IApplicationRepo
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ApplicationRepo(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<string> AddAsync(ApplicationDto application)
        {
            if (application == null) return null;

            ;

            try
            {
                var data = _mapper.Map<ApplicationForm>(application);
                await _context.AddAsync(data);
                var newdata = await _context.SaveChangesAsync();

                return newdata.ToString();
            }
            catch (DbUpdateException ex)
            {
                
               return ex.InnerException?.Message;
                
            }
        }

        public async Task<ProgramDto> GetProgramAsync(string Id)
        {
            var data = await _context.application.FirstOrDefaultAsync(x => x.ApplicationId == Id);
            if (data == null) return null;

           
            var res = _mapper.Map<ProgramDto>(data);
            return res;
        }

        public async Task<List<ApplicationDto>> GetAllProgramAsync()
        {
            var data = _context.application.Select(x => x).ToList();

            var res = _mapper.Map<List<ApplicationDto>>(data);

            return res;
        }
        public  Task<bool> Remove(string Id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateProgramAsync(ProgramDto program, string Id)
        {
            var data = await _context.application.FirstOrDefaultAsync(x => x.ApplicationId == Id);

            if (data == null) return false;

            var res = _mapper.Map<ProgramDto>(data);

            _context.Update(data);
            return _context.SaveChanges() > 0;
        }

        
        
    }
}
