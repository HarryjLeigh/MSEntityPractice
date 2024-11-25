using System;
using System.Linq;
using MsEntityPracticeProject.Models;

using var db = new BloggingContext();

// Note: This sample requires the database to be created before running.
Console.WriteLine($"Database path: {db.DbPath}.");

//Create
Console.WriteLine("Inserting a new blog.");
db.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
db.SaveChanges();

// Read
Console.WriteLine("Querying for a blog.");
var blog = db.Blogs
    .OrderBy(b => b.BlogId)
    .FirstOrDefault();


if (blog != null)
{
    Console.WriteLine($"Blog ID: {blog.BlogId}.");
    Console.WriteLine($"Url: {blog.Url}.");

    // Update the blog
    Console.WriteLine("Updating the blog and adding a post.");
    blog.Url = "https://devblogs.microsoft.com/dotnet";
    blog.Posts.Add(
        new Post { Title = "Hello World!", Content = "I wrote an app using EF Core!" });
    db.SaveChanges();
    Console.WriteLine($"New Blog Url: {blog.Url}");
    Console.WriteLine("------------------------------------------------------------------------------------");
    Console.WriteLine("Post Added");
    Console.WriteLine($"Post Title: {blog.Posts[0].Title}.");
    Console.WriteLine($"Post Title: {blog.Posts[0].Content}.");
    

    // Delete the blog
    Console.WriteLine("Deleting the blog.");
    db.Remove(blog);
    db.SaveChanges();
}
else
{
    Console.WriteLine("No blog found.");
}

