﻿namespace Assignment
{
    public static class ArrayReplicator
    {
        /// <summary>
        /// Replicates (deep copies) the incoming array
        /// </summary>
        /// <param name="original">The array to be replicated</param>
        /// <returns>A deep copy of the original array</returns>
        public static int[] ReplicateArray(int[] original)
        {
             int size = original.Length;
            int[] copyArray = new int[size];
            // LINQ -> map
            for (int i = 0; i < size; ++i)
            {
                copyArray[i] = original[i];
            }
            return copyArray;
        }

        /// <summary>
        /// Asks the user for a number. Will crash if the user input is not convertible to an int (throw exception?)
        /// </summary>
        /// <param name="text">Text to prompt the user</param>
        /// <returns>The user input as an integer</returns>
        public static int AskForNumber(string text)
        {
            {
    while (true) // Loop until a valid input is provided
    {
        Console.Write(text);

        try
        {
            string userInput = Console.ReadLine();
            int number = Convert.ToInt32(userInput);
            return number;
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
        catch (OverflowException)
        {
            Console.WriteLine("The entered number is too large or too small.");
        }
    }
}
        }

        /// <summary>
        /// Asks the user for a number within a certain range [min, max]. If the number is not in the range, re-prompt the user for a new number.
        /// Will crash if the user input is not convertible to an int (throw exception?)
        /// </summary>
        /// <param name="text">Text to prompt the user</param>
        /// <param name="min">Smallest permissible value</param>
        /// <param name="max">Largest permissible value</param>
        /// <returns>The user input as an integer</returns>
        public static int AskForNumberInRange(string text, int min, int max)
        {
            int userInput= AskForNumber(text);
            while (userInput< min || userInput> max)
            {
                userInput=AskForNumber("Your previous input is not valid , please try again");
            }
            return userInput;
        }
    }

    static class Program
    {
        static void Main()
        {
            const int Min = 0;
            const int Max = 10;
            const int PrintOffset = 4;

            int size = ArrayReplicator.AskForNumberInRange("Enter the array size: ", Min, Max);
            int[] original = new int[size];

            // Fill the original array with user specified integers
            for (int item = 0; item < size; ++item)
            {
                original[item] = ArrayReplicator.AskForNumber("Enter a number: ");
            }

            int[] copy = ArrayReplicator.ReplicateArray(original);
            // Verify original and replicated array are the same
            for (int index = 0; index < size; ++index)
                Console.WriteLine($"Original {original[index],-PrintOffset}  {copy[index],4} Copy");
        }
    }
}
