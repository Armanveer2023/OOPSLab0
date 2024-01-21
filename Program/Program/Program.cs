using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        int startNum;
        int endNum;

        // Get the starting number
        do
        {
            Console.Write("Enter the starting number: ");
        } while (!int.TryParse(Console.ReadLine(), out startNum) || startNum <= 0);

        // Get the last Number 
        do
        {
            Console.Write("Enter the ending number (must be greater than the starting number): ");
        } while (!int.TryParse(Console.ReadLine(), out endNum) || endNum <= startNum);

        List<double> numbersList = GenerateNumbersList(startNum, endNum);
        WriteNumbersToFile(numbersList, "numbers.txt");

        Console.WriteLine("Numbers saved in 'numbers.txt' in reverse order.");

        List<double> readNumbersList = ReadNumbersFromFile("numbers.txt");
        double sum = CalculateSum(readNumbersList);
        Console.WriteLine($"Sum of numbers: {sum}");

        PrintPrimeNumbers(startNum, endNum);
    }

    // function to generate number list 
    static List<double> GenerateNumbersList(int startNum, int endNum)
    {
        List<double> numbersList = new List<double>();

        for (int i = endNum; i >= startNum; i--)
        {
            numbersList.Add((double)i);
        }

        return numbersList;
    }

    // function to print all numbers in numbers.txt file 
    static void WriteNumbersToFile(List<double> numbers, string fileName)
    {
        File.WriteAllLines(fileName, numbers.Select(x => x.ToString()));
    }

    // function to read the numbers 
    static List<double> ReadNumbersFromFile(string fileName)
    {
        return File.ReadAllLines(fileName).Select(double.Parse).ToList();
    }

    //function to calculate the sum 
    static double CalculateSum(List<double> numbers)
    {
        return numbers.Sum();
    }

    // function to check if it is prime or not 
    static bool IsPrime(double number)
    {
        if (number <= 1)
            return false;

        for (double i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0)
                return false;
        }
        return true;
    }

    // function to print all the prime numbers 
    static void PrintPrimeNumbers(int startNum, int endNum)
    {
        Console.WriteLine($"Prime numbers between {startNum} and {endNum}:");
        for (int i = startNum; i <= endNum; i++)
        {
            double currentNum = (double)i;
            if (IsPrime(currentNum))
                Console.Write(currentNum + " ");
        }
        Console.WriteLine();
    }
}
