using System;
using System.Collections.Generic;

namespace ScriptureMemorizer
{
    /// <summary>
    /// Provides access to approved scriptures from KJV Bible and Book of Mormon
    /// </summary>
    public static class ScriptureRepository
    {
        // Each tuple: (Book, Chapter, Verse, Text, Source)
        private static readonly List<(string Book, int Chapter, int Verse, string Text, string Source)> _scriptures = new()
        {
            // KJV Bible
            ("Genesis", 1, 1, "In the beginning God created the heaven and the earth.", "KJV"),
            ("Proverbs", 3, 5, "Trust in the LORD with all thine heart; and lean not unto thine own understanding.", "KJV"),
            ("John", 3, 16, "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.", "KJV"),
            ("Philippians", 4, 13, "I can do all things through Christ which strengtheneth me.", "KJV"),
            ("Psalms", 23, 1, "The LORD is my shepherd; I shall not want.", "KJV"),
            ("Jeremiah", 29, 11, "For I know the thoughts that I think toward you, saith the LORD, thoughts of peace, and not of evil, to give you an expected end.", "KJV"),

            // Book of Mormon
            ("1 Nephi", 3, 7, "And it came to pass that I, Nephi, said unto my father: I will go and do the things which the Lord hath commanded, for I know that the Lord giveth no commandments unto the children of men, save he shall prepare a way for them that they may accomplish the thing which he commandeth them.", "Book of Mormon"),
            ("Mosiah", 2, 17, "And behold, I tell you these things that ye may learn wisdom; that ye may learn that when ye are in the service of your fellow beings ye are only in the service of your God.", "Book of Mormon"),
            ("Alma", 32, 21, "And now as I said concerning faith—faith is not to have a perfect knowledge of things; therefore if ye have faith ye hope for things which are not seen, which are true.", "Book of Mormon"),
            ("Moroni", 10, 4, "And when ye shall receive these things, I would exhort you that ye would ask God, the Eternal Father, in the name of Christ, if these things are not true; and if ye shall ask with a sincere heart, with real intent, having faith in Christ, he will manifest the truth of it unto you, by the power of the Holy Ghost.", "Book of Mormon"),
            ("Ether", 12, 27, "And if men come unto me I will show unto them their weakness. I give unto men weakness that they may be humble; and my grace is sufficient for all men that humble themselves before me; for if they humble themselves before me, and have faith in me, then will I make weak things become strong unto them.", "Book of Mormon"),
            ("3 Nephi", 11, 10, "Behold, I am Jesus Christ, whom the prophets testified shall come into the world.", "Book of Mormon")
        };

        /// <summary>
        /// Retrieves a random scripture from approved sources
        /// </summary>
        public static (string Book, int Chapter, int Verse, string Text, string Source) GetRandomScripture()
        {
            Random rnd = new Random();
            int index = rnd.Next(_scriptures.Count);
            return _scriptures[index];
        }
    }
}


