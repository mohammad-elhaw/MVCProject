using Project.DAL.Entities.EmployeeEntity;
using Project.DAL.Entities.Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.DTO.Employee
{
    public record EmployeeForCreationDto : EmployeeForManipulationDto
    {
        
    }
}
