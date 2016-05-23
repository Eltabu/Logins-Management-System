using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LoginsManagementSystem.Utilities
{
    /// <summary>
    /// Public static class provides the logic for the verification of complexity of string
    /// </summary>
    public static class ComplexityVerification
    {

        public static Score CheckStrength(string password)
        {
            int score = 1;

            if (password.Length < 1)
                return Score.Blank;
            if (password.Length < 4)
                return Score.VeryWeak;

            if (password.Length >= 6)
                score++;
            if (password.Length >= 12)
            {
                score++;
            }
            if (Regex.Match(password, @"/\d+/", RegexOptions.ECMAScript).Success)
            {
                score++;
            }
                
            if (Regex.Match(password, @"/[a-z]/", RegexOptions.ECMAScript).Success)
            {
                score++;
            }
            if (Regex.Match(password, @"/[A-Z]/", RegexOptions.ECMAScript).Success)
            {
                score++;
            }
            if (Regex.Match(password, @"/.[!,@,#,$,%,^,&,*,?,_,~,-,£,(,)]/", RegexOptions.ECMAScript).Success)
            {
                score++;
            }

            return (Score)score;
        }
    }
}

