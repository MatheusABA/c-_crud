using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crud.Employees;

// using primary constructor
public class Employee(string name, string email, string function)
{
    // Guid = Generate an unique Id
    // init => not editable
    public Guid Id { get; init; } = Guid.NewGuid();
    // private -> only editable using the Class
    public string Name { get; private set; } = name;

    // email -> unique
    public string Email { get; private set; } = email;

    // Job Area. Example = Function -> Civil Engineer
    public string Function { get; private set; } = function;



    // CLASS METHODS
    public void UpdateEmployee(string function)
    {
        Function = function;
    }

    public void DisableEmployee()
    {
        Function = "disabled";
    }
}
