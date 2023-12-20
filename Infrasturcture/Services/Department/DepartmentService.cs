  using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
 using Infrastructure.HrModels;
using Microsoft.Extensions.Hosting;

namespace Infrastructure.Services.Department
{
    public class DepartmentService : IDepartmentService
    {
        private readonly HRMSContext _db;

        public DepartmentService(HRMSContext db)  
        {
            _db = db;
        }

        public async Task<IReadOnlyList<AdminEntity>> GetAllDeparmentAsync( )
        {
            List<AdminEntity> alldepartments = new List<AdminEntity>();
            alldepartments = await _db.AdminEntities.ToListAsync();
            return alldepartments;
        }

       
    }

}

   
 