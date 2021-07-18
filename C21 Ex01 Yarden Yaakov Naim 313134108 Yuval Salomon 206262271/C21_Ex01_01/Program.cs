﻿//using System.Text;
using System;

namespace C21_Ex01_01
{
    public class Program
    {
        private static int s_Num1, s_Num2, s_Num3;
        private static float s_AvgNumOfZeroes,
                             s_AvgNumOfOnes;
        private static int s_NumOfPowTwo = 0,
                           s_MaxNum, s_MinNum,
                           s_NumOfAscendingSeries = 0;
        public static void Main()
        {
            string binaryStr1 = string.Empty , binaryStr2 = string.Empty, binaryStr3 = string.Empty;
            getInputFromUser(ref binaryStr1,ref binaryStr2,ref binaryStr3);
            convertNumbers(binaryStr1, binaryStr2, binaryStr3);
            getStatistics(binaryStr1, binaryStr2, binaryStr3);
            printStatisticsResult();
        }
        //Print all the statistics 
        private static void printStatisticsResult()
        {
            string outputMessage = string.Format(
                @"The numbers in decimal are: {0}, {1}, {2}.
The average number of 0s is: {3}.
The average number of 1s is: {4}.
There are {5} powers of two.
The number of ascending series is {6}.
The maximum number is {7}, and the minimum is {8}.",
                s_Num1,
                s_Num2,
                s_Num3,
                s_AvgNumOfZeroes,
                s_AvgNumOfOnes,
                s_NumOfPowTwo,
                s_NumOfAscendingSeries,
                s_MaxNum,
                s_MinNum);

            Console.WriteLine(outputMessage);
        }

        //Wrapper method to convert 3 binary numbers from string to integer
        private static void convertNumbers(string i_BinaryNum1, string i_BinaryNum2, string i_BinaryNum3)
        {
            s_Num1 = convertBinaryStrToInteger(i_BinaryNum1);
            s_Num2 = convertBinaryStrToInteger(i_BinaryNum2);
            s_Num3 = convertBinaryStrToInteger(i_BinaryNum3);
        }

        //Convert each one of the 3 binary numbers to integer
        private static int convertBinaryStrToInteger(string i_binaryStr)
        {
            int resultNum = 0, currentDigit;
            for (int i = 0; i < 9; i++)
            {
                currentDigit = i_binaryStr[i] - '0';
                if (currentDigit == 0)
                {
                    resultNum *= 2;
                }
                else
                {
                    resultNum = (resultNum * 2) + 1;
                }
            }
            return resultNum;
        }

        //Get Input from user - 3 binary numbers - 9 digit each
        private static void getInputFromUser(ref string io_binaryStr1, ref string io_binaryStr2, ref string io_binaryStr3)
        {
            string currentBinaryNumberStr;
            int numberOfVaildNumbers = 0;
            System.Console.WriteLine("Please enter three binary numbers - 9 digits each (and press 'enter' after each one):\n");
            while (numberOfVaildNumbers < 3)
            {
                currentBinaryNumberStr = System.Console.ReadLine();

                if (!isValidInput(currentBinaryNumberStr))
                {
                    System.Console.WriteLine("The input you entered is invalid. Please try again.\n");
                    continue;
                }

                switch (numberOfVaildNumbers)
                {
                    case 0:
                        {
                            io_binaryStr1 = currentBinaryNumberStr;
                            break;
                        }

                    case 1:
                        {
                            io_binaryStr2 = currentBinaryNumberStr;
                            break;
                        }

                    case 2:
                        {
                            io_binaryStr3 = currentBinaryNumberStr;
                            break;
                        }
                }
                numberOfVaildNumbers++;
            }
        }

        //Check validity of input - return true if 9 binary digits
        private static bool isValidInput(string i_binaryNum)
        {
            bool result = true;
            if (i_binaryNum.Length != 9)
            {
                result = false;
            }
            else
            {
                for (int i = 0; i < 9 && result; i++)
                {
                    if (i_binaryNum[i] != '0' && i_binaryNum[i] != '1')
                    {
                        result = false;
                    }
                }
            }
            return result;
        }

        //Wrapper method to calculate all wanted statistics
        private static void getStatistics(string i_BinaryNum1, string i_BinaryNum2, string i_BinaryNum3)
        {
            getAvgNumOfZeroes(i_BinaryNum1, i_BinaryNum2, i_BinaryNum3);
            getAvgNumOfOnes(i_BinaryNum1, i_BinaryNum2, i_BinaryNum3);
            getNumOfPowTwo(i_BinaryNum1, i_BinaryNum2, i_BinaryNum3);
            getNumAscendingSeries();
            getMaxNum();
            getMinNum();
        }

        //Calculates the average number of zeroes and updates member accordingly
        private static void getAvgNumOfZeroes(string i_BinaryNum1,string i_BinaryNum2,string i_BinaryNum3)
        {
            int numOfZeroes = getNumOfZeroes(i_BinaryNum1);
            numOfZeroes += getNumOfZeroes(i_BinaryNum2);
            numOfZeroes += getNumOfZeroes(i_BinaryNum3);
            s_AvgNumOfZeroes = (numOfZeroes / 3f);    
        }

        //Calculates the average number of ones and updates member accordingly
        private static void getAvgNumOfOnes(string i_BinaryNum1, string i_BinaryNum2, string i_BinaryNum3)
        {
            int numOfOnes = getNumOfOnes(i_BinaryNum1);
            numOfOnes += getNumOfOnes(i_BinaryNum2);
            numOfOnes += getNumOfOnes(i_BinaryNum3);
            s_AvgNumOfOnes = (numOfOnes / 3f);
        }

        //Returns the number of one digits in a string representing a binary number
        private static int getNumOfOnes(string i_BinaryNum)
        {
            int numOfOnes = 0;
            for (int i = 0; i < i_BinaryNum.Length; i++)
            {
                if (i_BinaryNum[i] == '1')
                {
                    numOfOnes++;
                }
            }
            return numOfOnes;
        }

        //Returns the number of zero digits in a string representing a binary number
        private static int getNumOfZeroes(string i_BinaryNum)
        {
            int numOfZeroes = 0;
            for (int i = 0; i < i_BinaryNum.Length; i++)
            {
                if (i_BinaryNum[i] == '0')
                {
                    numOfZeroes++;
                }
            }
            return numOfZeroes;
        }

        //Returns the number of binary numbers which are powers of two - if there is only one '1' in the string means power by 2
        private static void getNumOfPowTwo(string i_BinaryNum1, string i_BinaryNum2, string i_BinaryNum3)
        {
            if(getNumOfOnes(i_BinaryNum1) == 1)
            {
                s_NumOfPowTwo++;
            }
            if (getNumOfOnes(i_BinaryNum2) == 1)
            {
                s_NumOfPowTwo++;
            }
            if (getNumOfOnes(i_BinaryNum3) == 1)
            {
                s_NumOfPowTwo++;
            }
        }

        //Checks if a number is an ascending series - true if ascending series
        private static bool isAscendingSeries(int i_Num)
        {
            bool result = true;
            int lastDigit = i_Num % 10;

            while (result && i_Num / 10 != 0)
            {
                i_Num = i_Num / 10;
                if (i_Num % 10 >= lastDigit)
                {
                    result = false;
                }
                else
                {
                    lastDigit = i_Num % 10;
                }
            }
            return result;
        }

        //Returns number of ascending series
        private static void getNumAscendingSeries()
        {
            if( isAscendingSeries(s_Num1))
            {
                s_NumOfAscendingSeries++;
            }
            if (isAscendingSeries(s_Num2))
            {
                s_NumOfAscendingSeries++;
            }
            if (isAscendingSeries(s_Num3))
            {
                s_NumOfAscendingSeries++;
            }
        }

        //Get maximum number
        private static void getMaxNum()
        {
            s_MaxNum = Math.Max(Math.Max(s_Num1, s_Num2), s_Num3);
        }

        //Get minimum number
        private static void getMinNum()
        {
            s_MinNum = Math.Min(Math.Min(s_Num1, s_Num2), s_Num3);
        }
    }
}
