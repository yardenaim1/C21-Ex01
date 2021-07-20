namespace C21_Ex01_04
{
    using System;
    class Program
    {
        public static void Main()
        {
            string strFromUser = getInputFromUser();
            printDetails(strFromUser);          
        }

        private static void printDetails(string i_strFromUser)
        {
            Console.WriteLine(
                isPalindrom(i_strFromUser)
                    ? "The string is a palindrome."
                    : "The string is not a palindrome.");

            if (isNumber(i_strFromUser, out int number) == true)
            {
                Console.Write("The string is a number,");
                if (isDividedByFour(number) == true)
                {
                    Console.WriteLine("is dividable by 4.");
                }

                else
                {
                    Console.WriteLine("is not dividable by 4.");
                }
            }
            else
            {
                int numOfUpper = numUpperCase(i_strFromUser);
                Console.WriteLine("There are {0} uppercase letters in the string", numOfUpper);
            }

        }
        private static bool isEnglishLetterString(string i_StrFromUser)
        {
            return !(isNumber(i_StrFromUser,out int num));
        }

        private static int numUpperCase(string i_Str)
        {
            int numOfUpperCase = 0;
            for(int i = 0; i<i_Str.Length;i++)
            {
                if(i_Str[i] >='A' && i_Str[i]<='Z')
                {
                    numOfUpperCase++;
                }    
            }
            return numOfUpperCase;
        }

        private static bool isNumber(string i_StrFromUser, out int number)
        {
            return int.TryParse(i_StrFromUser, out number);
        }

        private static bool isDividedByFour(int i_number)
        {
            return i_number % 4 == 0;
        }

        private static bool isPalindromRec(string i_StrFromUser, int i_StartLoc, int i_EndLoc)
        {
            bool result = true;
            if (i_StartLoc == i_EndLoc)
            {
                result = true;
            }
            else if (i_StrFromUser[i_StartLoc] != i_StrFromUser[i_EndLoc])
            {
                result =false;
            }
            if (i_StartLoc < i_EndLoc)
            {
                result =  isPalindromRec(i_StrFromUser, i_StartLoc + 1, i_EndLoc - 1) && result;
            }
            return result;
        }

        private static bool isPalindrom(string i_StrFromUser)
        {
            int lenOfStr = i_StrFromUser.Length;
            return isPalindromRec(i_StrFromUser, 0, lenOfStr - 1);
        }

        private static string getInputFromUser()
        {
            Console.WriteLine("Please enter a 8 character string ( digits only or English letter only ) and then press 'enter':");
            string strFromUser = Console.ReadLine();

            while (!isValidStr(strFromUser))
            {
                Console.WriteLine("Invalid input, try again");
                strFromUser = Console.ReadLine();

            }
            return strFromUser;
        }

        private static bool isValidStr(string i_StringFromUser)
        {
            bool result = false;
            bool validLength = i_StringFromUser.Length == 8;
            int numeriNum;
            if (validLength == true)
            {
                if (int.TryParse(i_StringFromUser, out numeriNum) == true)
                {
                    result = true;
                }
                if (result == false)
                {
                    result = true;
                    for(int i=0; i<i_StringFromUser.Length && result; i++)
                    {
                        // not betewwn 'a' - 'z' or 'A'-'Z'
                        if(!((i_StringFromUser[i] <= 'z' && i_StringFromUser[i] >= 'a') || (i_StringFromUser[i] <= 'Z' && i_StringFromUser[i] >= 'A')))
                        {
                            result = false;
                        }
                    }
                }
            }
            return result;
        }
    }
}

