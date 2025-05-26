using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureMemorizer
{
    /// <summary>
    /// Represents a scripture with its text and hidden state management
    /// </summary>
    public class Scripture
    {
        // Fields
        private readonly Reference _reference;
        private readonly List<Word> _words;

        /// <summary>
        /// Initializes a new scripture with the given reference and text
        /// </summary>
        public Scripture(Reference reference, string text)
        {
            _reference = reference;

            // Split text into individual Word objects
            _words = text.Split(' ')
                        .Select(word => new Word(word))
                        .ToList();
        }

        /// <summary>
        /// Hides the specified number of random visible words
        /// </summary>
        public void HideRandomWords(int numberToHide)
        {
            // Get only visible words
            List<Word> visibleWords = _words
                .Where(word => !word.IsHidden())
                .ToList();

            // Ensure we don't try to hide more words than available
            numberToHide = Math.Min(numberToHide, visibleWords.Count);

            Random rnd = new Random();

            for (int i = 0; i < numberToHide; i++)
            {
                // Randomly select and hide a word
                int randomIndex = rnd.Next(visibleWords.Count);
                visibleWords[randomIndex].Hide();

                // Remove hidden word from visible list
                visibleWords.RemoveAt(randomIndex);
            }
        }

        /// <summary>
        /// Returns the formatted scripture text with hidden words
        /// </summary>
        public string GetDisplayText()
        {
            string referenceText = _reference.GetDisplayText();
            string wordsText = string.Join(" ", _words.Select(word => word.GetDisplayText()));

            return $"{referenceText} - {wordsText}";
        }

        /// <summary>
        /// Checks if all words in the scripture are hidden
        /// </summary>
        public bool IsCompletelyHidden()
        {
            return _words.All(word => word.IsHidden());
        }
    }
}
