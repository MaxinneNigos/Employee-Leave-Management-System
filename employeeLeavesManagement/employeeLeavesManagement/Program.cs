using employeeLeaveManagement;
using employeeLeavesManagement;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static employeeLeaveManagement.admin;

namespace LeaveSystem
{
    class Program
    {
        static List<string> actions = new List<string>()
            { "Enter 1 - Leave Request", "Enter 2 - Login as Admin", "Enter 3 - Exit" };

        static List<string> LeaveType = new List<string>()
        { "Enter 1 - Sick Leave", "Enter 2 - Vacation Leave" };
        

        public static void Main(string[] args)
        {
            Console.WriteLine("\n*** Welcome to Employee Leave Management System *** ");


            for (int useraction = GetUserAction();
     useraction != actions.IndexOf("3 - Exit");
     useraction = GetUserAction())
            {
                switch (useraction)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine(leaveApplication());
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine(Login());
                        break;
                    case 3:
                        Console.WriteLine("Application exiting...");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid! Please try again.");
                        break;
                }
                Console.WriteLine();
            }

        }
        static int GetUserAction()
        {
            ShowOptions();
            Console.Write("User Input: ");
            int n1 = Convert.ToInt32(Console.ReadLine());

            switch (n1)
            {
                case 1:
                    Console.WriteLine("\nYou have chosen Leave Request. Press ANY key to continue");
                    Console.ReadKey();
                    break;
                case 2:
                    Console.WriteLine("\nYou have chosen Login Admin. Press ANY key to continue");
                    Console.ReadKey();
                    break;
            }
            return n1;
        }

        static void ShowOptions()
        {
            Console.WriteLine("Select from MENU to proceed.");

            foreach (var action in actions)
            {
                Console.WriteLine(action);
            }
        }

 // 2 - LOGIN AS ADMIN
        public static string Login()
        {
            Console.WriteLine("\a \n *** Admin Login ***\n ");

            admin user = new admin();
            Console.Write("Username: ");
            user.Username = Console.ReadLine();

            admin pass = new admin();
            Console.Write("Password: ");
            pass.Password = Console.ReadLine();

            if (user.Username != "admin" || pass.Password == "admin")
            {
                Console.WriteLine("\n Login Successful!");

                //after login, display employee menu 
                string adminSelection = EmployeeMenu();

                //lipat sa admin.cs
                switch (adminSelection)
                {
                    case "1":
                        Console.WriteLine("Viewing the list of employees and their information...");
                        EmployeeInfoTextFileStream.ReadFile(true);
                        break;
                    case "2":
                        Console.WriteLine("Adding new employee/s to list...");
                        EmployeeInfoTextFileStream.CreateUpdateFile(false);
                        break;
                    case "3":
                        Console.WriteLine("Creates a new list and deletes the exisiting list...");
                        EmployeeInfoTextFileStream.CreateUpdateFile(true);
                        break;
                    default:
                        break;
                }  
            }
            else
            {
                Console.WriteLine("Your username or password is incorrect! Returning to Menu...");
                Console.ReadKey();

            Console.Clear();
                Console.WriteLine("\n*** Welcome to Employee Leave Management System *** ");

            }

            return "";
        }

        //lilipat sa admin.cs 
        private static string EmployeeMenu()
        {
            Console.WriteLine("\n ***Employees Data *** \nSelect from MENU:");
            Console.WriteLine("Enter 1 - View List of employees");
            Console.WriteLine("Enter 2 - Add new employee/s");
            Console.WriteLine("Enter 3 - Create and Update list of employee/s");
            Console.WriteLine("Enter 4 - Delete list");

            Console.WriteLine();
            Console.Write("User Input: ");
            string adminMenuSelection = Console.ReadLine();
            Console.WriteLine();

            return adminMenuSelection;
        }

        static string leaveApplication()
        {
            Console.WriteLine("\n \a \a*** Leave Application ***");
            Console.WriteLine("\n You have requested for a leave. Enter the all details needed below:");

            Console.WriteLine(GetLeaveType());

            leaveApplication ID = new leaveApplication();
            Console.Write("\nEmployee ID number: ");
            ID.EmployeeIDNumber = Console.ReadLine();

            leaveApplication EmployeeName = new leaveApplication();
            Console.Write("Name: ");
            EmployeeName.name = Console.ReadLine();

            leaveApplication LvDay = new leaveApplication();
            Console.Write("Days of leave: ");
            LvDay.LeaveDay = Console.ReadLine();

            leaveApplication LvReason = new leaveApplication();
            Console.Write("Reason for leave: ");
            LvReason.Reason = Console.ReadLine();

            Console.WriteLine("\n*** Leave Request recorded. ***");
            
            Console.WriteLine("Press ANY key to return to Menu.");
            Console.ReadKey();
            
            Console.Clear();
            Console.WriteLine("\n*** Welcome to Employee Leave Management System *** ");
            return "";
        }

        static void ShowLeaveType()
        {
            Console.WriteLine("Choose your Leave Type:");

            foreach (var LeaveType in LeaveType)
            {
                Console.WriteLine(LeaveType);
            }
        }
        static int GetLeaveType()
        {
            ShowLeaveType();
            Console.Write("Input Leave Type: ");
            int n2 = Convert.ToInt32(Console.ReadLine());
            switch (n2)
            {
                case 1:
                    Console.Write("\nYou have applied for a Sick Leave - ");
                    break;
                case 2:
                    Console.Write("\nYou have applied for a Vacation Leave - ");
                    break;
                default:
                    Console.Write("\nInvalid input: ");
                    break;
            }
            return n2;
        }

    }

}


