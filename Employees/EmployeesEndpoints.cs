using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crud.Employees;

public static class EmployeesEndpoints
{ 
    
    public static void AddEmployeesEndpoints(this WebApplication app)
    {
        app.MapGet("employees",
            () => new Employee("Matheus","Dev"));
    }

}
