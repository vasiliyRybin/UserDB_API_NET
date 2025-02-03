using System.Text.RegularExpressions;
using UserDB_API_NET.Models;

namespace UserDB_API_NET.Validation
{
    public static class UserValidation
    {
        /// <summary>
        /// Validation of input user.
        /// Returns KeyValuePair with bool value as key and string as comment.
        /// In case when validation fails, will be returned false and description of what's wrong
        /// </summary>
        /// <param name="userInput"></param>
        /// <returns></returns>
        public static KeyValuePair<bool, string> CheckUserInput(User userInput)
        {
            string phonePattern = "^\\+\\d{9}$";
            string emailPattern = "^\\S{1,40}@\\w{1,20}.\\w{1,3}$";
            string passPattern = "^[A-Za-zŹŻĆŚŁÓŃ]{3}\\d{6}$";


            if (string.IsNullOrWhiteSpace(userInput.FirstName)) return new KeyValuePair<bool, string>(false, "FirstName is null or whitespaced");
            if (string.IsNullOrWhiteSpace(userInput.LastName)) return new KeyValuePair<bool, string>(false, "LastName is null or whitespaced");
            
            if (userInput.TaxId == null || userInput.TaxId < 0) return new KeyValuePair<bool, string>(false, "TaxId is null or having invalid value");
            else if (userInput.TaxId < 1000000000 || userInput.TaxId > 9999999999) userInput.Comment = "O kurwa! Popierdolony numer podatnika";
            else if (userInput.TaxId >= 1000000000 && userInput.TaxId <= 9999999999) userInput.Comment = string.Empty;

            if (string.IsNullOrWhiteSpace(userInput.PassNumber)) return new KeyValuePair<bool, string>(false, "PassNumber is null or whitespaced");
            else
            {
                var match = MatchFinder(userInput.PassNumber, passPattern);
                if (!match) return new KeyValuePair<bool, string>(match, "Wrong PassNumber input");
            }

            if (!string.IsNullOrWhiteSpace(userInput.Email))
            {
                var match = MatchFinder(userInput.Email, emailPattern);
                if(!match) return new KeyValuePair<bool, string>(match, "Email incorrect format");
            }
            else return new KeyValuePair<bool, string>(false, "Email is null or whitespaced");
            
            if (string.IsNullOrWhiteSpace(userInput.PhoneNumber)) return new KeyValuePair<bool, string>(false, "PhoneNumber is null or whitespaced");
            else 
            {
                var match = MatchFinder(userInput.PhoneNumber, phonePattern);
                if (!match) return new KeyValuePair<bool, string>(match, "PhoneNumber incorrect format");
            }

            return new KeyValuePair<bool, string>(true, string.Empty);
        }

        private static bool MatchFinder(string value, string pattern)
        {
            return Regex.Match(value, pattern).Success;
        }
    }
}
