namespace C21_Ex01_06
{
    using System;

    class Program
    {
        public static void Main()
        {
            string strInput = GetInputFromUser();
            getStatistics(strInput);
        }

        private static void getStatistics(string i_strInput)
        {
            int biggestDigit = getBiggestDigit(i_strInput);
            int smallestDigit = getSmallestDigit(i_strInput);
            int numOfDividedByThree = numOfDigitsDividedByThree(i_strInput);
            int greaterThenUnityDigit = howManyGreaterThenUnityDigit(i_strInput);

            string msg = string.Format(
                @"The number you entered is: {0}
The biggest digit: {1}
The smallest digit: {2}
{3} digits are divided by three
There are {4} digits greater then the unity digit.
", i_strInput, biggestDigit, smallestDigit, numOfDividedByThree, greaterThenUnityDigit);

            Console.WriteLine(msg);
        }

        private static int howManyGreaterThenUnityDigit(string i_NumberStr)
        {
            int resultNumber = 0;
            char unityDigit = i_NumberStr[i_NumberStr.Length - 1];
            for (int i = 0; i < 8; i++)
            {
                if (i_NumberStr[i] > unityDigit)
                {
                    resultNumber++;
                }

            }

            return resultNumber;
        }

        private static int numOfDigitsDividedByThree(string i_NumberStr)
        {
            int resultNumber = 0;
            for (int i = 0; i < 9; i++)
            {
                if ((i_NumberStr[i] - '0') % 3 == 0)
                {
                    resultNumber++;
                }

            }

            return resultNumber;
        }

        private static int getSmallestDigit(string i_NumberStr)
        {
            int smallestDigit = i_NumberStr[0] - '0';
            for (int i = 1; i < 9; i++)
            {
                if (i_NumberStr[i] - '0' < smallestDigit)
                {
                    smallestDigit = i_NumberStr[i] - '0';
                }
            }

            return smallestDigit;
        }

        private static int getBiggestDigit(string i_NumberStr)
        {
            int biggestDigit = i_NumberStr[0] - '0';
            for (int i = 1; i < 9; i++)
            {

                if (i_NumberStr[i] - '0' > biggestDigit)
                {
                    biggestDigit = i_NumberStr[i] - '0';
                }
            }

            return biggestDigit;
        }

        public static string GetInputFromUser()
        {
            Console.WriteLine("Please enter a positive complete number(with 9 digits) and then press 'enter':");
            string strFromUser = Console.ReadLine();

            while (!isValidInput(strFromUser))
            {
                Console.WriteLine("Invalid input,please try again");
                strFromUser = Console.ReadLine();
            }

            return strFromUser;
        }

        private static bool isValidInput(string i_StrFromUser)
        {
            return (i_StrFromUser.Length == 9) && int.TryParse(i_StrFromUser, out int o_number);
        }
    }
}