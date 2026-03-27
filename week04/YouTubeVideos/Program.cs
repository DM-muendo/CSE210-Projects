using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the YouTubeVideos Project.");
        // Create videos
        var videos = new List<Video>();

        var video1 = new Video("C# Tutorial", "Alice", 600);
        video1.AddComment(new Comment("Bob", "Great tutorial!"));
        video1.AddComment(new Comment("Carol", "Very helpful, thanks!"));
        video1.AddComment(new Comment("Dave", "I learned a lot."));

        var video2 = new Video("Cooking Pasta", "Chef John", 480);
        video2.AddComment(new Comment("Eve", "Yummy!"));
        video2.AddComment(new Comment("Frank", "Easy to follow."));
        video2.AddComment(new Comment("Grace", "Delicious recipe!"));

        var video3 = new Video("Travel Vlog: Japan", "Mia", 900);
        video3.AddComment(new Comment("Hank", "Beautiful scenery!"));
        video3.AddComment(new Comment("Ivy", "I want to visit now."));
        video3.AddComment(new Comment("Jack", "Great video!"));

        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        // Display videos and comments
        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds");
            Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");
            Console.WriteLine("Comments:");
            foreach (var comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.Name}: {comment.Text}");
            }
            Console.WriteLine();
        }
    }
}