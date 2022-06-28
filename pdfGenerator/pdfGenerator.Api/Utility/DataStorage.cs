using pdfGenerator.Models;

namespace pdfGenerator.Utility;

public static class DataStorage
{
    public static List<Employee> GetAllEmployees() =>
        new()
        {
            new Employee { Name = "Nick", LastName = "Minaj", Age = 35, Gender = "Male"},
            new Employee { Name = "Sonja", LastName = "Markus", Age = 22, Gender = "Female"},
            new Employee { Name = "Luck", LastName = "Martins", Age = 40, Gender = "Male" },
            new Employee { Name = "Sofia", LastName = "Parker", Age = 55, Gender = "Female" },
            new Employee { Name = "John", LastName = "Doe", Age = 18, Gender = "Male" }
        };
}