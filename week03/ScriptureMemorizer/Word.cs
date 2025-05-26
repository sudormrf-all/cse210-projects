namespace ScriptureMemorizer
{
    /// <summary>
    /// Represents a single word in a scripture with hide/show capability
    /// </summary>
    public class Word
    {
        // Fields
        private readonly string _text;
        private bool _isHidden;

        /// <summary>
        /// Creates a new visible word
        /// </summary>
        public Word(string text)
        {
            _text = text;
            _isHidden = false;
        }

        /// <summary>
        /// Hides the word
        /// </summary>
        public void Hide()
        {
            _isHidden = true;
        }

        /// <summary>
        /// Reveals the word
        /// </summary>
        public void Show()
        {
            _isHidden = false;
        }

        /// <summary>
        /// Returns current visibility status
        /// </summary>
        public bool IsHidden()
        {
            return _isHidden;
        }

        /// <summary>
        /// Returns the word text or underscores if hidden
        /// </summary>
        public string GetDisplayText()
        {
            return _isHidden
                ? new string('_', _text.Length)  // Hidden representation
                : _text;                         // Visible text
        }
    }
}
