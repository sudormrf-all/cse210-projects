using System;

class Program
{
    static void Main(string[] args)
    {
        // Name: André Duarte Santos de Pina
        // Class: CSE 210: Programming with Classes
        // Exercise: C# Programming Exercise 1: Input and Output
        // This program will ask for the user's first name and print a greeting message.
        Console.Write("What is your first name? ");
        string firstName = Console.ReadLine();

        Console.Write("What is your last name? ");
        string lastName = Console.ReadLine();

        // Print a greeting message using the user's first and last name
        // The message should be like a reference to James Bond, where the last name is first and the first name is last.
        // For example: "Your name is Bond, James Bond"
        Console.WriteLine($"Your name is {lastName}, {firstName} {lastName}");


    }
}