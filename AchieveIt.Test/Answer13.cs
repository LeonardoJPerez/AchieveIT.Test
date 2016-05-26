using System;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Dapper;

namespace AchieveIt.Test
{
    [TestFixture]
    public class Answer13
    {
        [Test]
        public void PrintEmployees()
        {
            using (var conn = new SqlConnection("Server=sqlinstance.cr39h6nxoxnt.us-east-1.rds.amazonaws.com;Database=AchieveIT;User Id=achieveit;Password=987;"))
            {
                conn.Open();

                var employees = conn.Query<Employee>("SELECT e.name as 'EmployeeName', mngr.name as 'ManagerName' FROM employee e LEFT JOIN employee mngr on e.mgr_id = mngr.id;").ToList();
                var sb = new StringBuilder();

                sb.AppendLine("<table>");
                sb.AppendLine("\t<thead>\n\t\t<tr>");
                sb.AppendLine("\t\t\t<th>Employee Name</th>");
                sb.AppendLine("\t\t\t<th>Manager Name</th>");
                sb.AppendLine("\t\t</tr>\n\t</thead>");

                sb.AppendLine("\t<tbody>");
                foreach (var emp in employees)
                {
                    var headOfDepartment = string.IsNullOrEmpty(emp.ManagerName) ? "<b>Head of Department</b>" : emp.ManagerName;

                    sb.AppendLine("\t\t<tr>");
                    sb.AppendLine($"\t\t\t<td>{emp.EmployeeName}</td>");
                    sb.AppendLine($"\t\t\t<td>{headOfDepartment}</td>");
                    sb.AppendLine("\t\t</tr>");                     
                }
                sb.AppendLine("\t</tbody>");
                sb.AppendLine("</table>");
                conn.Close();

                Console.Write(sb.ToString());
            }
        }
    }

    public class Employee
    {
        public string EmployeeName { get; set; }

        public string ManagerName { get; set; }
    }
}
