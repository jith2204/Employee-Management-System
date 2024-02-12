using Employee_BAL.Exceptions;
using Employee_BAL.Interfaces;
using Employee_DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Employee_BAL.Service
{
    public class ValidationService : IValidationService
    {
        

        DateTime dob;
        decimal output;
        int result;
        IDepartmentRepository _departmentRepository;
        IEmployeeRepository _employeeRepository;
        IProjectRepository _projectRepository;

        public ValidationService(IDepartmentRepository departmentRepository, IEmployeeRepository employeeRepository, IProjectRepository projectRepository)
        {
            _departmentRepository = departmentRepository;
            _employeeRepository = employeeRepository;
            _projectRepository = projectRepository;
        }


        public int IsValidChoice(string input, int min, int max)
        {
            while (!(int.TryParse(input, out result)) || result < min || result > max)
            {
                Console.WriteLine("Invalid choice!");
                Console.Write("Enter valid choice : ");
                input = Console.ReadLine();
                return IsValidChoice(input, min, max);  //input for recursive ftn
            }
            return result;
        }
        public int ChooseToContinue()
        {
            Console.Write("\nEnter 1 to continue, 0 to go back : ");
            var choice = Console.ReadLine();
            return IsValidChoice(choice,0,1);
        }

        public string IsValidString(string input)
        {
            while (String.IsNullOrEmpty(input))
            {
                Console.WriteLine("Data cannot be empty");
                Console.Write("Enter valid data : ");
                input = Console.ReadLine();
                return IsValidString(input);
            }
            return input;
        }

       
            public string IsValidEmail(string email)
            {
                while (!(Regex.Match(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").Success))
                {
                    throw new BadInputException("Enter a valid email");
                }
                return email;
            }
        


        public DateTime IsValidDateOfBirth(string date)
        {
            while (!(DateTime.TryParse(date, out dob)))
            {
                Console.Write("Enter valid date : ");
                date = Console.ReadLine();
                return IsValidDateOfBirth(date);
            }
            return dob;
        }

        public DateTime IsValidDate(string date)
        {
            while (!(DateTime.TryParse(date, out dob)))
            {
                Console.Write("Enter valid date : ");
                date = Console.ReadLine();
                return IsValidDateOfBirth(date);
            }
            return dob;
        }





        public decimal IsValidSalary(string salary)
        {
            while (!(decimal.TryParse(salary, out output)) || output < 0)
            {
                Console.Write("Enter valid salary amount : ");
                salary = Console.ReadLine();
                return IsValidSalary(salary);
            }
            return output;
        }

        public decimal IsValidScore(string score)
        {
            while (!decimal.TryParse(score, out output) || output <= 0 || output >= 100)
            {
                Console.Write("Enter valid score : ");
                score = Console.ReadLine();
                return IsValidScore(score);
            }
            return output;
        }

        public string IsValidPhoneNumber(string phone)
        {
            while (!Regex.Match(phone, "[0-9]{10}").Success)
            {

                throw new BadInputException("Enter a valid Phone Number");
            }
            return phone;
        }

      

        public int IsValidGender(int gender)
        {
            while (gender != 0 && gender != 1)
            {
                Console.Write("Enter 0 for Male,1 for Female : ");
                gender = Convert.ToInt32(Console.ReadLine());
                return IsValidGender(gender);
            }
            return gender;
        }

     

       
    }
}
