using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using crud.Data;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;

namespace crud.Employees;

public static class EmployeesEndpoints
{ 

    // REST Endpoint
    // CREATE - POST
    // READ - GET
    // UPDATE - PUT
    // DELETE - DELETE
    public static void REST_EmployeesEndpoints(this WebApplication app) // 
    {
        // grouping the endpoints by the prefix 
        var employeesEndpoints = app.MapGroup(prefix: "employees");



        // --------------------------------------- POST METHOD - CREATING EMPLOYEE
        employeesEndpoints.MapPost(pattern: "",
            handler: async (AddEmployeeRequest request, AppDbContext context) =>
            {  
                    // check if email already exists
                    var employeeExist = await context.Employees.AnyAsync(employee => employee.Email == request.Email);

                    if (employeeExist) return Results.Conflict("Email already exists!");    // return the error
                    
                    
                    var newEmployee = new Employee(request.Name, request.Email, request.Function);

                    // add the received fields in the body 
                    await context.Employees.AddAsync(newEmployee); 
                    // save the fields on db
                    await context.SaveChangesAsync();

                    // check dto
                    var employeeResponse = new EmployeeDto(newEmployee.Id, newEmployee.Name, newEmployee.Function);

                    // return only not sensitive data
                    return Results.Ok(employeeResponse);

            }
        );



        // -------------------------------  GET METHOD - SHOW ALL EMPLOYEES
        employeesEndpoints.MapGet(pattern: "",
            handler: async (AppDbContext context) =>
            {
                var employees = await context
                                    .Employees
                                    .Where(employee => employee.Function == ("Developer"))         // filter
                                    .Select(employee => new EmployeeDto(employee.Id, employee.Name, employee.Function))
                                    .ToListAsync();  // return all as a list

                return employees;
            }
        );



        // ------------------------------- UPDATE EMPLOYEE
        employeesEndpoints.MapPut(pattern:"{id:guid}",
            handler: async (Guid id, UpdateEmployeeRequest request, AppDbContext context) =>
            {
                var employee = await context.Employees
                                            .SingleOrDefaultAsync(employee => employee.Id == id);

                if (employee == null) return Results.NotFound();

                employee.UpdateEmployee(request.Function);

                await context.SaveChangesAsync();
                return Results.Ok(new EmployeeDto(employee.Id, employee.Name, employee.Function)); 
            }   
        );



        // -------------------------------- DELETE EMPLOYEE
        employeesEndpoints.MapDelete(pattern:"{id:guid}",
            handler: async(Guid id, AppDbContext context) =>
            {
                var employee = await context.Employees
                                            .SingleOrDefaultAsync(employee => employee.Id == id);

                if (employee == null) return Results.NotFound();

                employee.DisableEmployee(); // set employee as disabled 

                await context.SaveChangesAsync();
                return Results.Ok();
            }
        );
    }

}
