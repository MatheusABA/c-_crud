using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crud.Employees
{
    // record => create all the crud endpoints
    public record AddEmployeeRequest(string Name, string Function);
    
}