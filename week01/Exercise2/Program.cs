using System;

class Program
{// Name: André Duarte Santos de Pina
 // Class: CSE 210: Programming with Classes
 // Exercise: C# Programming Exercise 2: If Statements
 // Write a program that determines the letter grade for a course according to the following scale:
 //A >= 90
 //B >= 80
 //C >= 70
 //D >= 60
 //F < 60
    static void Main(string[] args)
    {

        {
            Console.Write("Enter your grade percentage:");
            string answer = Console.ReadLine();
            int percentage = int.Parse(answer);

            string letterGrade = "";

            if (percentage >= 90)
            {
                letterGrade = "A";
            }
            else if (percentage >= 80)
            {
                letterGrade = "B";
            }
            else if (percentage >= 70)
            {
                letterGrade = "C";
            }
            else if (percentage >= 60)
            {
                letterGrade = "D";
            }
            else
            {
                letterGrade = "F";
            }

            Console.WriteLine($"Your letter grade is {letterGrade}.");

            if (percentage >= 70)
            {
                Console.WriteLine("You passed the course.");
            }
            else
            {
                Console.WriteLine("You failed the course.");
            }

        }
    }
}
// The program will ask for the user's grade percentage and print the letter grade and whether the user passed or failed the course.