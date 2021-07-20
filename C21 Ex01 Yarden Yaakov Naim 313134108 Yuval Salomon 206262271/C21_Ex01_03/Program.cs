namespace C21_Ex01_03
{
    using System;
    using C21_Ex01_02;
    class Program
    {
        public static void Main()
        {
            int heightOfHourglass = getInputFromUser();

            if(heightOfHourglass % 2 == 0) // We chose to subtract by 1 if the number is even 
            {
                heightOfHourglass--;
            }

            C21_Ex01_02.Program.RecursiveHourGlass(heightOfHourglass, 0, true); // The height of the hourglass is the same to the number of asterisks in the first line
        }

        private static int getInputFromUser()
        {
            int height;
            System.Console.WriteLine("Please enter the height of the required hourglass (positive number of lines) and then press 'enter':");
            string InputHeighOfHourglass = System.Console.ReadLine();

            while (!isValidInput(InputHeighOfHourglass, out height))
            {
                System.Console.WriteLine("Invalid input.\nPlease enter the height of the required hourglass (positive number of lines) and then press 'enter':");
                InputHeighOfHourglass = System.Console.ReadLine();
            }
            return height;
        }

        // If the input is valid, the method returns the hieght in 'o_Height'
        private static bool isValidInput(string i_HeightOfHourglass, out int o_Height)
        {
            bool ParseSuccessful = int.TryParse(i_HeightOfHourglass, out o_Height);
            return ParseSuccessful && o_Height >= 0;
        }
    }
}
