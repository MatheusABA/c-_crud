using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crud.Employees;

public class Employee
{
    // Guid = Generate an unique Id
    // init => not editable
    public Guid Id { get; init; }
    // private -> only editable using the Class
    public string Name { get; private set; } 
    
    // Job Area. Example = Function -> Civil Engineer
    public string Function { get; private set;}


    // class constructor
    public Employee(string name, string function)
    {
        Name = name;
        Id = Guid.NewGuid();
        Function = function;
    }
}
