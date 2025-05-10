using System;

class Program
{
    static void Main(string[] args)
    {// Name: André Duarte Santos de Pina
     // Class: CSE 210: Programming with Classes
     // Exercise: C# Programming Exercise 3: Loops
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 101);

        int guess = -1;

        // We could also use a do-while loop here...
        while (guess != magicNumber)
        {
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());

            if (magicNumber > guess)
            {
                Console.WriteLine("Go Higher!");
            }
            else if (magicNumber < guess)
            {
                Console.WriteLine("Lower!");
            }
            else
            {
                Console.WriteLine("You guessed it, Congrats!!!");
            }

        }
    }
}