using System;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using static System.Runtime.InteropServices.JavaScript.JSType;

// delegate HandleLoggedIn
namespace T12
{
	public class EmployeeManager
	{
        //event LoggedIn(HandleLoggedIn)
        //event LoggedOut



        EmployeeDAL employeeDAL;
		public EmployeeManager()
		{
			employeeDAL = new EmployeeDAL();

        }

		public Employee? Login(string username, string password)
		{
            return employeeDAL.SelectByUsernameAndPassword(username, password);

            // if login
            // LoggedIn()
		}

		public List<Employee> Find(string key)
		{
			// 1. key - id
			// 2. key - name | email
			int id;
            bool success = int.TryParse(key, out id);
			if (success)
			{
                List<Employee> employees = new List<Employee>();
                Employee? employee = employeeDAL.SelectById(id);
				employees.Add(employee);
				return employees;
            }
			else
			{
                return employeeDAL.SelectByKey(key);
            }
        }

		public void Import(string filePath)
		{
            StreamReader reader = new StreamReader(filePath);
            try
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    //tách chuỗi gán vào mảng 
                    string[] tokens = line.Split(',');
                    string name = tokens[0];
                    string email = tokens[1];
                    string password = tokens[2];
                    EmployeeRole role = (EmployeeRole) Convert.ToInt32(tokens[3]);
                    employeeDAL.Insert(new Employee(0, name, email, password, role));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                reader.Close();
            }
        }

        public void Export(string filePath)
        {

        }

        public int AddNew(Employee emp )
		{
			return employeeDAL.Insert(emp);
		}

        public int Update(Employee emp)
        {
            return employeeDAL.Update(emp);
        }

        public int Delete(Employee emp)
        {
            return employeeDAL.Delete(emp.Id);
        }
    }
}

