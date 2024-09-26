using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using crud.Data;

namespace crud.Employees;

public static class EmployeesEndpoints
{ 

    public static void AddEmployeesEndpoints(this WebApplication app)
    {
        // grouping the endpoints by the prefix 
        var employeesEndpoints = app.MapGroup(prefix: "employees");

        // creating users
        employeesEndpoints.MapPost("", 
            async (AddEmployeeRequest request, AppDbContext context) =>
        {  
            var newEmployee = new Employee(request.Name, request.Function);

            // add the received fields in the body 
            await context.Employees.AddAsync(newEmployee);

            // save the fields on db
            await context.SaveChangesAsync();

        });

    }

}
