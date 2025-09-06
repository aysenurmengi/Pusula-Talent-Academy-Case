using System.Security.Cryptography;
using System.Text.Json;
using System.Xml.Linq;

namespace Algorithms;

public class Q4FilterEmployees
{
    public static string FilterEmployees(IEnumerable<(string Name, int Age, string Department, decimal Salary, DateTime HireDate)> employees)
    {
        if (employees == null) return "[]";

        var filtered = employees
            .Where(e => e.Age > 25 && e.Age <= 40
                        && (e.Department == "IT" || e.Department == "Finance")
                        && (e.Salary > 5000m && e.Salary <= 9000m)
                        && (e.HireDate.Year > 2017))
            .ToList();
        
        var names = filtered
            .Select(e => e.Name)
            .OrderByDescending(n => n.Length)
            .ThenBy(n => n, StringComparer.InvariantCulture)
            .ToArray();

        int count = filtered.Count;
        decimal totalSalary = filtered.Sum(e => e.Salary);
        decimal averageSalary = count > 0 ? totalSalary / count : 0m;
        decimal minSalary = count > 0 ? filtered.Min(e => e.Salary) : 0m;
        decimal maxSalary = count > 0 ? filtered.Max(e => e.Salary) : 0m;

        var result = new
        {
            Names = names,
            TotalSalary = totalSalary,
            AverageSalary = averageSalary,
            MinSalary = minSalary,
            MaxSalary = maxSalary,
            Count = count,
        };

        return JsonSerializer.Serialize(result);
    }
}