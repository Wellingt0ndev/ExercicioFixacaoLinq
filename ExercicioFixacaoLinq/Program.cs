using ExercicioFixacaoLinq.Entities;
using System.Globalization;


Console.Write("Enter full file path: ");
string path = Console.ReadLine();

List<Employee> employees = new List<Employee>();
try
{
    using (StreamReader sr = File.OpenText(path))
    {
        while (!sr.EndOfStream)
        {
            string[] lines = sr.ReadLine().Split(",");
            string name = lines[0];
            string email = lines[1];
            double salary = double.Parse(lines[2], CultureInfo.InvariantCulture);
            employees.Add(new Employee(name, email, salary));
        }

        Console.Write("Enter salary: ");
        double limit = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

        var emails = employees.Where(obj => obj.Salary > limit).OrderBy(obj => obj.Email).Select(obj => obj.Email);
        Console.WriteLine("Email of people whose salary is more than " + limit.ToString("F2", CultureInfo.InvariantCulture));
        foreach (string email in emails)
        {
            Console.WriteLine(email);
        }

        Console.WriteLine();
        var SumSalary = employees.Where(obj => obj.Name[0] == 'M').Sum(obj => obj.Salary);
        Console.WriteLine("Sum of salary of people whose name starts with 'M': " + SumSalary.ToString("F2", CultureInfo.InvariantCulture));

    }
}
catch(IOException e)
{
    Console.WriteLine("An Error occurred");
    Console.WriteLine(e.Message);
}
