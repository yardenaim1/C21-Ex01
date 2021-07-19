namespace C21_Ex01_03
{
    using System;
    using C21_Ex01_02;
    class Program
    {
        public static void Main()
        {
            int numOfAsterisksInFirstLine;
            getInputFromUser(out string heighOfHourglass);

            int.TryParse(heighOfHourglass, out int height);
            if(height % 2 == 0) // We chose to subtract by 1 if the number is even 
            {
                height--;
            }

            numOfAsterisksInFirstLine = height;
            C21_Ex01_02.Program.RecursiveHourGlass(numOfAsterisksInFirstLine, 0, true);
        }

        private static void getInputFromUser(out string o_HeighOfHourglass)
        {
            System.Console.WriteLine("Please enter the height of the required hourglass (positive number of lines) and then press 'enter':");
            o_HeighOfHourglass = System.Console.ReadLine();

            while (!isValidInput(o_HeighOfHourglass))
            {
                System.Console.WriteLine("Invalid input.\nPlease enter the height of the required hourglass (positive number of lines) and then press 'enter':");
                o_HeighOfHourglass = System.Console.ReadLine();
            }
        }

        private static bool isValidInput(string i_HeightOfHourglass)
        {
            bool result = int.TryParse(i_HeightOfHourglass, out int height);
            return result && height >= 0;
        }
    }
}
