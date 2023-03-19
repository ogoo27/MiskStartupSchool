using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MiskStartupSchool.Context;
using MiskStartupSchool.DTO;
using MiskStartupSchool.Entities;
using MiskStartupSchool.Services;

namespace MiskStartupSchool.Repository
{
    public class WorkflowRepo : IWorkflowRepo
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public WorkflowRepo(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        
        public async Task<WorkflowDto> GetWorkflowAsync(string Id)
        {
            var data = await _context.application.FirstOrDefaultAsync(x => x.ApplicationId == Id);
            if (data == null) return null;

            var res = _mapper.Map<WorkflowDto>(data);
            return res;


        }
        
        public async Task<bool> UpdateWorkflowAsync(WorkflowDto program, string Id)
        {
            var data = await _context.application.FirstOrDefaultAsync(x => x.ApplicationId == Id);

            if (data == null) return false;
            var res = _mapper.Map<WorkflowDto>(data);

            //data.stages = program.stages;

            _context.Update(data);
            return _context.SaveChanges() > 0;
        }
    }
}
