using System;

namespace ScriptureMemorizer
{
    /// <summary>
    /// Main program class that handles user interaction and controls memorization flow
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize program display
            Console.WriteLine("===== Scripture Memorization Helper =====");
            Console.WriteLine("Official Sources: Bible (KJV) & Book of Mormon\n");

            // Get a random scripture from approved sources
            var scriptureData = ScriptureRepository.GetRandomScripture();

            // Create reference and scripture objects
            Reference reference = new Reference(
                book: scriptureData.Book,
                chapter: scriptureData.Chapter,
                verse: scriptureData.Verse
            );

            Scripture scripture = new Scripture(
                reference: reference,
                text: scriptureData.Text
            );

            // Main memorization loop
            while (!scripture.IsCompletelyHidden())
            {
                Console.Clear();

                // Display current scripture state with source
                Console.WriteLine($"[{scriptureData.Source}] {scripture.GetDisplayText()}");

                // User instructions
                Console.WriteLine("\nPress Enter to hide more words | Type 'quit' to exit");
                string input = Console.ReadLine();

                // Exit condition check
                if (input.Equals("quit", StringComparison.OrdinalIgnoreCase))
                    break;

                // Hide 3 random words each iteration
                scripture.HideRandomWords(numberToHide: 3);
            }

            // Final display and exit
            Console.WriteLine("\nMemorization session ended. Press any key to exit...");
            Console.ReadKey();
        }
    }
}



