using System;
using System.IO;

namespace CyberSecurity.Data
{
    public class PasswordGenerator
    {
        private const string FILE_NAME = "GeneratedPassword.txt";
        public string GeneratePassword() //generate a password
        {
            var pass = string.Empty;

            var characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghigklmnopqrstuvwxyz0123456789()+=><;|%&£$#!?".ToCharArray(); //a string of upper and lower case letters, numbers and symbols

            var rand = new Random();
            do
            {
                for (var i = 0; i < rand.Next(15, 30); i++) //this will loop at a random rate between the range of 15 and 30. meaning the password will always be of or between these lengths
                {
                    var randomIndex = rand.Next(0, characters.Length); //get a random character from the strength
                    pass += characters[randomIndex]; //add it to the password
                }
            } while (DetermineStrength(pass) != PasswordStrength.Strong); //ensure we generate a strong password

            return pass; //return our random password
        }

        //assess password strength
        public PasswordStrength DetermineStrength(string pass)
        {
            var passStrength = 0;

            var specialChars = 0;
            var lowerCase = 0;
            var upperCase = 0;
            var numberChars = 0;

            if (pass.Length >= 15) //if the length on the password is above or equal to 15, increase the strength score
            {
                passStrength++;
            }

            //check each character in the password string in order to asses the strength. check if character is
            //a number, lowercase,uppercase or a special character
            foreach (var c in pass.ToCharArray())
            {
                if (Char.IsNumber(c))
                {
                    numberChars++;
                }
                else if (Char.IsUpper(c))
                {
                    upperCase++;
                }
                else if (Char.IsLower(c))
                {
                    lowerCase++;
                }
                else
                {
                    specialChars++;
                }
            }

            passStrength = numberChars + upperCase + lowerCase + specialChars; //calculate the strength

            var strength = CheckAgainstPhrases(pass);//set a default value

            //evaluate the strength
            if (passStrength <= 10)
            {
                strength = PasswordStrength.Weak;
            }
            else if (passStrength >= 11 && passStrength <= 20)
            {
                strength = PasswordStrength.Medium;
            }
            else
            {
                strength = PasswordStrength.Strong;
            }

            //check the password against a list of the top passwords of 2016
            return strength;

        }

        //save the generated password to a text file. the password is generated randomly, thus we must tell the user what is in some way
        //in a "non-prototype" this would be sent to a users email address or via a text message to their personal contact address'
        public void SavePasswordToFile(string password, string username)
        {
            using (var outputFile = new StreamWriter(username + ".txt"))
            {
                outputFile.WriteLine(password);
            }
        }

        //we check the similarities between the old password and the new one
        public int CheckPasswordSimilarities(string oldPass, string newPass)
        {
            var score = 0;

            if (oldPass.Length == newPass.Length)
            {
                for (var i = 0; i < oldPass.ToCharArray().Length; i++) //the new and old passwords are the same length, we can loop through either without worry of an out of bounds exception
                {
                    if (newPass.ToCharArray()[i] == oldPass.ToCharArray()[i]) //see if the characters match
                    {
                        score++;
                    }
                }
            }
            else
            {
                //check which string as longer, and loop according to the length value of the shortest. this is to avoid out of array bounds exception
                var oldPassLonger = oldPass.Length > newPass.Length ? true : false;

                for (var i = 0; !oldPassLonger ? i < oldPass.ToCharArray().Length : i < newPass.ToCharArray().Length; i++)
                {
                    if (newPass.ToCharArray()[i] == oldPass.ToCharArray()[i])
                    {
                        score++;
                    }
                }
            }

            return score; //return the score. 
        }

        //method checks password against top passwords of 2016. passwords are stored in a text file, to make 
        //the list easily update-able for all employees etc 
        public PasswordStrength CheckAgainstPhrases(string newPassword)
        {
            int counter = 0;
            string line;

            var file = new System.IO.StreamReader("most_common_passwords.txt"); //load in the list

            while ((line = file.ReadLine()) != null)
            {
                counter++;
                if (line == newPassword) //check each password
                {
                    file.Close();
                    return PasswordStrength.Weak; //if any match is found, immediately return "weak"
                }
            }

            file.Close();

            return PasswordStrength.Medium; //if no match is found, return the current strength value as determined by the algorithm in an earlier stage
        }
    }
}
