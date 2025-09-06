using System.Linq;
using System.Text.Json;
using System.Xml.Linq;

namespace Algorithms;

public class Q3FilterPeopleFromXml
{
    public static string FilterPeopleFromXml(string xmlData)
    {
        if (xmlData == null) return "[]";

        var xDocument = XDocument.Parse(xmlData);

        var person = xDocument.Descendants("Person")
            .Select(p => new
            {
                Name = (string?)p.Element("Name"),
                Age = (int?)p.Element("Age"),
                Department = (string?)p.Element("Department"),
                Salary = (int?)p.Element("Salary"),
                HireDate = (string?)p.Element("HireDate")
            })
            .Where(p => p.Age.HasValue && p.Age > 30
                        && p.Department == "IT"
                        && p.Salary.HasValue && p.Salary > 5000
                        && DateTime.TryParse(p.HireDate, out var hireDate)
                        && hireDate.Year < 2019)
            .ToList();


        var names = person
            .Select(p => p.Name)
            .OrderBy(n => n, StringComparer.InvariantCulture)
            .ToArray();

        int count = person.Count;
        int totalSalary = person.Sum(p => p.Salary ?? 0);
        int maxSalary = count > 0 ? person.Max(p => p.Salary ?? 0) : 0;
        int averageSalary = count > 0 ? totalSalary / count : 0;

        var result = new
        {
            Names = names,
            TotalSalary = totalSalary,
            AverageSalary = averageSalary,
            MaxSalary = maxSalary,
            Count = count,
        };

        return JsonSerializer.Serialize(result);
  
    }
}