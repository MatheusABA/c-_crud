using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crud.Employees
{
    public record EmployeeDto(Guid Id, string Name, string Function);
    
}