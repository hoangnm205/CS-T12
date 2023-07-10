using System;
using T12;

namespace T12
{
	public class Screen
	{
        EmployeeManager manager;
		public Screen()
		{
            manager = new EmployeeManager();
            // manager.OnLoginIn = XuLyLogin
        }

        // public void XuLyLogin(Employee emp)
        // {
        //   if (employee == null)
//                {
//                    Console.WriteLine("Login fail! Wrong uname or password");
//                } else
//                {
//                    checkLogin = true;
//                    Console.WriteLine("Login success!");
//                    // Dieu huong
//                    if (employee.Role == EmployeeRole.MANAGER)
//                    {
//                        PrintManagerScreen();
//}
//                    else if (employee.Role == EmployeeRole.USER)
//{
//    PrintUserScreen();
//}
//                }
        // }

        public void PrintManagerScreen()
		{
            int selected = 0;

            do
            {
                Console.WriteLine("***EMPLOYEE MANAGER***");
                Console.WriteLine("\t1.Search Employee by Name or EmpNo");
                Console.WriteLine("\t2.Add New Employee");
                Console.WriteLine("\t3.Update Employee");
                Console.WriteLine("\t4.Remove Employee");
                Console.WriteLine("\t5.Export Data");
                Console.WriteLine("\t6.Import Data");
                Console.WriteLine("\t7.Exit");
                Console.Write("Select (1-7): ");
                selected = Convert.ToInt16(Console.ReadLine());


                switch (selected)
                {
                    case 1:
                        PrintFindScreen();
                        break;
                    case 2:
                        PrintAddScreen();
                        break;
                    case 3:
                        //manager.Update();
                        break;
                    case 4:
                        //manager.Remove();
                        break;
                    case 5:
                        //manager.Export();
                        break;
                    case 6:
                        //manager.Import();
                        break;
                    case 7:
                        Console.WriteLine("------------END----------");
                        break;
                    default:
                        Console.WriteLine("Invalid");
                        break;
                }
            } while (selected != 7);
        }

        private void PrintAddScreen()
        {
            Console.Write("Name: ");
            String name = Console.ReadLine();
            Console.Write("Email: ");
            String email = Console.ReadLine();
            Console.Write("Is Manger y/n:");
            EmployeeRole role = EmployeeRole.USER;
            if (Console.ReadLine().ToUpper() == "Y")
            {
                role = EmployeeRole.MANAGER;
            }
            Console.Write("Password:");
            String password = Console.ReadLine();
            manager.AddNew(new Employee(0, name, email, password, role));
        }

        private void PrintFindScreen()
        {
            Console.WriteLine("***EMPLOYEE SEARCHING***");
            Console.Write("enter Id or name/email: ");
            string key = Console.ReadLine();

            List<Employee> employees = manager.Find(key);
            if (employees.Count > 0)
            {
                DisplayEmployees(employees);
            }
            else
            {
                Console.WriteLine("Data not found!");
            }
        }

        public void PrintUserScreen()
        {
            PrintFindScreen();
        }

        private void DisplayEmployees(List<Employee> employees)
        {
            foreach (Employee emp in employees)
            {
                Console.WriteLine(emp);
            }
        }

		public void PrintLoginScreen()
		{
            bool checkLogin = false;
            do
            {
                Console.WriteLine("===== EMPLOYEE MANAGE =====");
                Console.WriteLine("=====       LOGIN     =====");
                Console.Write("Username: ");
                string uname = Console.ReadLine();
                Console.Write("Password: ");
                string pwd = Console.ReadLine();

                // --> Check Login
                Employee? employee = manager.Login(uname, pwd);
                if (employee == null)
                {
                    Console.WriteLine("Login fail! Wrong uname or password");
                }
                else
                {
                    checkLogin = true;
                    Console.WriteLine("Login success!");
                    // Dieu huong
                    if (employee.Role == EmployeeRole.MANAGER)
                    {
                        PrintManagerScreen();
                    }
                    else if (employee.Role == EmployeeRole.USER)
                    {
                        PrintUserScreen();
                    }
                }
            } while (!checkLogin);
        }
    }
}

