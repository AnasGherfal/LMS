using Infrastructure.HrModels;
 using System;
using System.Collections.Generic;
using System.Threading.Tasks;

     namespace Infrastructure.Services.Department

{
    public interface IDepartmentService  
    {
     //   public Task<IQueryable<AdminEntity>> GetAllDeparmentAsync();
        Task<IReadOnlyList<AdminEntity>> GetAllDeparmentAsync( );

    }
}
