namespace ScriptureMemorizer
{
    /// <summary>
    /// Represents a scripture reference (e.g., "1 Nephi 3:7" or "John 3:16-17")
    /// </summary>
    public class Reference
    {
        // Private fields
        private readonly string _book;
        private readonly int _chapter;
        private readonly int _verse;
        private readonly int _endVerse;

        /// <summary>
        /// Constructor for single-verse references
        /// </summary>
        public Reference(string book, int chapter, int verse)
        {
            _book = book;
            _chapter = chapter;
            _verse = verse;
            _endVerse = verse; // No verse range
        }

        /// <summary>
        /// Constructor for verse ranges (e.g., Proverbs 3:5-6)
        /// </summary>
        public Reference(string book, int chapter, int startVerse, int endVerse)
        {
            _book = book;
            _chapter = chapter;
            _verse = startVerse;
            _endVerse = endVerse;
        }

        /// <summary>
        /// Returns formatted reference string
        /// </summary>
        public string GetDisplayText()
        {
            return _verse == _endVerse
                ? $"{_book} {_chapter}:{_verse}"          // Single verse
                : $"{_book} {_chapter}:{_verse}-{_endVerse}";  // Verse range
        }
    }
}
