using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace employeeLeavesManagement
{
    internal class EmployeeInfoTextFileStream
    {
            public static string fileName = $"{DateTime.Today.Date.Day.ToString()}_EmployeeList.txt";
            internal static void CreateUpdateFile(bool isNewFile)
            {
                if (isNewFile)
                {
                    using (StreamWriter file = File.CreateText(fileName))
                    {
                        WriteDataInFile(file);
                    }
                }
                else
                {
                    using (StreamWriter file = File.AppendText(fileName))
                    {
                        WriteDataInFile(file);
                    }
                }
            }

            private static void WriteDataInFile(StreamWriter file)
            {
                string line;
                do
                {
                    Console.Write("Enter Employee Number: ");
                    line = Console.ReadLine();
                    
                //Add new class for Data validator
                    if (line.Length != 0 && line.EndsWith("PH"))
                    {
                        file.WriteLine(line);
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input.");
                    }
                }
                while (line.Length != 0);

                Console.WriteLine("Exit Input Mode. Closing application..");
            }

            internal static void ReadFile(bool v)
            {
                using (StreamReader sr = new StreamReader(fileName))
                {
                    Console.WriteLine("*** List of Employees ***");
                    string line = sr.ReadLine();

                    while (line != null)
                    {
                        Console.WriteLine($"Employee ID no.: {line.ToUpper()}");
                        line = sr.ReadLine();
                    }
                }

            }
            static string EmployeeMenu()
            {
                Console.WriteLine("EMPLOYEE ID Numbers Data - Select from MENU:");
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
    }
}

