using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_BAL.Interfaces
{
    public interface IValidationService 
    {
        int IsValidChoice(string input,int min,int max);
        int ChooseToContinue();

       

       
        string IsValidString(string input);

        public string IsValidEmail(string input);
        int IsValidGender(int gender);
        DateTime IsValidDateOfBirth(string date);
        DateTime IsValidDate(string date);
        string IsValidPhoneNumber(string phone);
        
        decimal IsValidSalary(string salary);
        decimal IsValidScore(string score);
    }
}
