using System;

namespace Auth
{
    class Program
    {
        static void Main(string[] args)
        {
            /* REQUIREMENTS->
             * EMAIL:
             *  is case sensitive in the local portion of the address (left of the rightmost @ character)
             *  Has non-alphanumeric characters in the local-part (including + and @)
             *  Has zero or more labels
             *  Check for presence of at least one @ symbol in the address
             * 
             * PASSWORD:
             * Data Type validation
             * Format validation
             * That the password has at least 10 characters, 1 upper case, 1 lower case, 1 number between 1 and 20.
             * That it doesn't use semicolons or quotes
             */

            //Global Variable
            string email;
            string password = "";
            bool isValidEmail = false;
            bool isValidPassword = false;

            //Prompt
            Console.WriteLine("Enter your email: ");
            email = Console.ReadLine();

            Console.WriteLine("Enter you password: ");

            //User enters password
            do
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                // Backspace Should Not Work
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    password += key.KeyChar;
                    Console.Write("*");
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                    {
                        password = password.Substring(0, (password.Length - 1));
                        Console.Write("\b \b");
                    }
                    else if (key.Key == ConsoleKey.Enter)
                    {
                        break;
                    }
                }
            } while (true);



            //Check the email
            CheckEmail(email,ref isValidEmail);

            //Check the password
            CheckPassword(password, ref isValidPassword);

            //Show email
            Console.WriteLine("\n\nWelcome {0}!", email);

        }


        //Methods
        static void CheckEmail(string e,ref bool isValid)
        {
            bool hasAtSign = false;
            bool hasLowerCase = false;
            bool hasUpperCase = false;
            bool hasSpecialChar = false;
            int atSignIndex = 0;

            Console.WriteLine("\n\nValidating Email...");

            //Find the @ character
            for(int i = 0;i < e.Length; i++)
            {
                if(e[i] == '@')
                {
                    hasAtSign = true;
                    atSignIndex = i;
                    Console.WriteLine("Has @ sign at index {0}", atSignIndex);
                }
            }

            if (!hasAtSign)
            {
                Console.WriteLine("Missing @ sign...");
            }

            //Check if its case sensitive and do not contain special characters
            for(int i = 0; i < atSignIndex; i++)
            {
                char c = e[i];

                if (char.IsLower(c))
                {
                    hasLowerCase = true;
                }
                else if (char.IsUpper(c)){
                    hasUpperCase = true;
                }

                if (!char.IsLetterOrDigit(c))
                {
                    hasSpecialChar = true;
                    Console.WriteLine("Contains special character: {0}", c);
                }

            }

            if (hasLowerCase)
            {
                Console.WriteLine("Contains lower case letters.");
            }
            if (hasUpperCase)
            {
                Console.WriteLine("Contains upper case letters.");
            }

            //Finalize test
            if (hasAtSign && (hasLowerCase || hasUpperCase) && !hasSpecialChar)
            {
                isValid = true;
                Console.WriteLine("Email is valid!\n\n");
            }
            else
            {
                Console.WriteLine("Email is Invalid...");
            }
          
        }

        static void CheckPassword(string p, ref bool isValid)
        {
            bool isProperLength = false;
            bool hasLowerCase = false;
            bool hasUpperCase = false;
            bool hasNumber = false;
            bool hasSpecialChar = false;

            Console.WriteLine("\n\nValidating Password...");

            //Check the lenght of the password
            if(p.Length >= 10)
            {
                isProperLength = true;
                Console.WriteLine("Password is correct length...");
            }
            else
            {
                Console.WriteLine("Password is too short...");
            }

            //Check case and numbers
            for(int i = 0; i < p.Length; i++)
            {
                char c = p[i];

                if (char.IsLower(c))
                {
                    hasLowerCase = true;
                }
                else if (char.IsUpper(c))
                {
                    hasUpperCase = true;
                }
                else if (char.IsDigit(c))
                {
                    hasNumber = true;
                }
                //No semicolons or quotes
                else if (c == ';' || c == '"')
                {
                    hasSpecialChar = true;
                }
            }

            if(isProperLength && hasLowerCase && hasUpperCase && hasNumber && !hasSpecialChar)
            {
                isValid = true;
                Console.WriteLine("Password is valid!");
            }
            else
            {
                Console.WriteLine("Password is invalid...");
            }
        }


    }
}
        