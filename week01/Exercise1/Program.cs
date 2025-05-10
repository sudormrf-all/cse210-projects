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
        // The message should be: "Hello, [first name] [last name]! Welcome to C# programming."
        Console.WriteLine($"Your name is {lastName}, {firstName} {lastName}");


    }
}