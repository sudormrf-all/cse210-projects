using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Video> videos = new List<Video>
        {
            new Video("C# Quick Tricks", "TechieTom", 380),
            new Video("Understanding OOP", "SaraDev", 540),
            new Video("Web API Essentials", "CodeNina", 615)
        };

        // Randomized and varied names/comments
        var nameCommentPairs = new List<(string, string)>
        {
            ("Bob", "Great web dev content"),
            ("Alice", "Clear explanation!!"),
            ("Fiona", "Waiting for MVC tutorial"),
            ("Charlie", "Very practical examples"),
            ("Ian", "Helped me fix my code"),
            ("Evan", "Loved the examples :)"),
            ("Hannah", "Where's part 2?"),
            ("George", "Perfect for beginners"),
            ("Diana", "Best OOP overview!!")
        };

        // Assign comments to videos in a unique way
        videos[0].AddComment(new Comment(nameCommentPairs[0].Item1, nameCommentPairs[0].Item2));
        videos[0].AddComment(new Comment(nameCommentPairs[1].Item1, nameCommentPairs[1].Item2));
        videos[0].AddComment(new Comment(nameCommentPairs[2].Item1, nameCommentPairs[2].Item2));

        videos[1].AddComment(new Comment(nameCommentPairs[3].Item1, nameCommentPairs[3].Item2));
        videos[1].AddComment(new Comment(nameCommentPairs[4].Item1, nameCommentPairs[4].Item2));
        videos[1].AddComment(new Comment(nameCommentPairs[5].Item1, nameCommentPairs[5].Item2));

        videos[2].AddComment(new Comment(nameCommentPairs[6].Item1, nameCommentPairs[6].Item2));
        videos[2].AddComment(new Comment(nameCommentPairs[7].Item1, nameCommentPairs[7].Item2));
        videos[2].AddComment(new Comment(nameCommentPairs[8].Item1, nameCommentPairs[8].Item2));

        // Display video info and comments
        foreach (var video in videos)
        {
            Console.WriteLine("Title: " + video.Title);
            Console.WriteLine("Author: " + video.Author);
            Console.WriteLine("Length (seconds): " + video.LengthSeconds);
            Console.WriteLine("Number of comments: " + video.GetCommentCount());
            Console.WriteLine("Comments:");
            foreach (var comment in video.GetComments())
            {
                Console.WriteLine("   " + comment.CommenterName + ": " + comment.Text);
            }
            Console.WriteLine("------------------------");
        }
    }
}
