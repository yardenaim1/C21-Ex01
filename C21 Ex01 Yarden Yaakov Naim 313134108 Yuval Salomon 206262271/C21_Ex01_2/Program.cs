namespace C21_Ex01_2
{
    using System;
    using System.Text;

    public class Program
    {
        public static void Main()
        {
            RecursiveHourGlass(5, 0, true);
        }

        public static void RecursiveHourGlass(int i_NumOfAsterisks, int i_NumOfSpaces, bool i_UpperPart)
        {
            // Middle of the hour glass
            if (i_NumOfAsterisks <= 1) 
            {
                i_UpperPart = false;
            }

            for (int i = 0; i < i_NumOfSpaces; i++)
            {
                System.Console.Write(" ");
            }

            for (int i = 0; i < i_NumOfAsterisks; i++)
            {
                System.Console.Write("*");
            }

            System.Console.Write("\n");

            // End of hour glass
            if (i_NumOfSpaces == 0 && i_UpperPart == false)
            {
                return;
            }

            if (i_UpperPart == true)
            {
                RecursiveHourGlass(i_NumOfAsterisks - 2, i_NumOfSpaces + 1, i_UpperPart);
            }

            // Bottom part
            else
            {
                RecursiveHourGlass(i_NumOfAsterisks + 2, i_NumOfSpaces - 1, i_UpperPart);
            }
        }
    }
}