using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using Zellis.HRSauce.Models;
using Newtonsoft.Json;
using Zellis.HRSauce.Models;
using Microsoft.AspNetCore.Http;
using System.Reflection;


namespace Zellis.HRSauce.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index() => View();

        #region Task 2
        public IActionResult Task2EmployeeDetails()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Task2EmployeeDetailsResult(string fullName)
        {

            List<EmployeeModel> employees = new List<EmployeeModel>();
            JSONReadWrite readWrite = new JSONReadWrite();
            employees = JsonConvert.DeserializeObject<List<EmployeeModel>>(readWrite.Read("Employees.json", "Data"));
            List<EmployeeModel> resultemployee = new List<EmployeeModel>();

            if (!string.IsNullOrWhiteSpace(fullName))
            {
                foreach (var employee in employees)
                {
                    foreach (var childemployee in employees)
                    {
                        if (employee.EmployeeIdentifier == childemployee.ParentEmployeeIdentifier)
                        {
                            employee.NumberofDirectReports++;
                        }
                    }

                    string employeename = employee.Forename + " " +employee.MiddleNames + " " + employee.Surname ;
                    string employeename1 = employee.Forename + employee.MiddleNames + employee.Surname;
                    if (employeename == fullName || employeename1 == fullName)
                    {
                        resultemployee.Add(employee);
                        return View("Task2EmployeeDetails", resultemployee);
                    }
                }
            }
            return View("Task2EmployeeDetails", null);
        }

        public class JSONReadWrite
        {
            public JSONReadWrite() { }

            public string Read(string fileName, string location)
            {
                string root = "";
                var path = Path.Combine(
                    Directory.GetCurrentDirectory(),
                    root,
                    location,
                    fileName);

                string jsonResult;

                using (StreamReader streamReader = new StreamReader(path))
                {
                    jsonResult = streamReader.ReadToEnd();
                }
                return jsonResult;
            }
        }


        public decimal total = 0;
        public int employeecnt = 0;
        public decimal childsalary(string parentIdentifer)
        {
            List<CalculateModel> remunerations = new List<CalculateModel>();
            List<EmployeeModel> employees = new List<EmployeeModel>();
            JSONReadWrite readWrite = new JSONReadWrite();
            remunerations = JsonConvert.DeserializeObject<List<CalculateModel>>(readWrite.Read("Remuneration.json", "Data"));
            employees = JsonConvert.DeserializeObject<List<EmployeeModel>>(readWrite.Read("Employees.json", "Data"));

            foreach (var employee in employees)
            {
                if (employee.ParentEmployeeIdentifier == parentIdentifer)
                {
                    foreach (var childremuneration in remunerations)
                    {
                        if (childremuneration.EmployeeIdentifier == employee.EmployeeIdentifier)
                        {
                            total += childremuneration.HourlyRate * childremuneration.HoursWeekly * 10863 / 2500;
                        }
                        else
                        {
                            total += 0;
                        }
                    }
                    employeecnt += 1;
                    childsalary(employee.EmployeeIdentifier);
                }
            }
            return total;
        }

        public IActionResult Task3Calculate()
        {
            return View();
        }
        #endregion
        #region Task 3
        [HttpPost]
        public IActionResult Task3CalculateResult(string employeeIdentifier)
        {
            var model = new CalculateModel() { LastSearch = employeeIdentifier };

            List<CalculateModel> remunerations = new List<CalculateModel>();
            List<EmployeeModel> employees = new List<EmployeeModel>();
            JSONReadWrite readWrite = new JSONReadWrite();
            remunerations = JsonConvert.DeserializeObject<List<CalculateModel>>(readWrite.Read("Remuneration.json", "Data"));
            employees = JsonConvert.DeserializeObject<List<EmployeeModel>>(readWrite.Read("Employees.json", "Data"));

            List<EmployeeModel> result = new List<EmployeeModel>();
            model.EmployeeCount = 0;
            
            //model.EmployeeCount += employeecount(employeeIdentifier);
            model.Total = childsalary(employeeIdentifier);
            foreach (var employee in employees)
            {

                if (employee.EmployeeIdentifier == employeeIdentifier)
                {
                    model.EmployeeFullName = employee.Forename + " " + employee.MiddleNames + " " + employee.Surname;
                }
            }

            model.EmployeeCount = employeecnt + 1;

            foreach (var remuneration in remunerations)
            {
                if(remuneration.EmployeeIdentifier == employeeIdentifier)
                {
                    model.Total += remuneration.HourlyRate * remuneration.HoursWeekly*10863 / 2500;
                }
            }

            return View("Task3Calculate", model);
        }

        public IActionResult Task4ChangeName()
        {
            return View();
        }
        #endregion

        #region Error Actions

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

        #endregion
    }
}