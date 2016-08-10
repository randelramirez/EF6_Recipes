using System;
using System.Linq;

namespace FindingAMasterThatHasDetail
{
    /*
        You have two entities in a one-to-many association (aka Master-Detail), and you want to find all the master entities
        that have at least one associated detail entity.
     */

    class Program
    {
        static void Main(string[] args)
        {
            // initialize and seed the database
            using (var context = new DataContext())
            {
                var post1 = new BlogPost
                {
                    Title = "The Joy of LINQ",
                    Description = "101 things you always wanted to know about LINQ"
                };
                var post2 = new BlogPost
                {
                    Title = "LINQ as Dinner Conversation",
                    Description = "What wine goes with a Lambda expression?"
                };
                var post3 = new BlogPost
                {
                    Title = "LINQ and our Children",
                    Description = "Why we need to teach LINQ in High School"
                };

                var comment1 = new Comment
                {
                    Content = "Great post, I wish more people would talk about LINQ"
                };
                var comment2 = new Comment
                {
                    Content = "You're right, we should teach LINQ in high school!"
                };

                post1.Comments.Add(comment1);
                post3.Comments.Add(comment2);
                context.Blogs.Add(post1);
                context.Blogs.Add(post2);
                context.Blogs.Add(post3);
                context.SaveChanges();
            }

            // query the database, return only the blogs that have comments
            using (var context = new DataContext())
            {
                Console.WriteLine("Blog Posts with comments...(LINQ)");

                // query syntax
                //var posts = from post in context.Blogs
                //            where post.Comments.Any()
                //            select post;

                // method syntax
                var posts = context.Blogs.Where(c => c.Comments.Any());

                foreach (var post in posts)
                {
                    Console.WriteLine("Blog Post: {0}", post.Title);
                    foreach (var comment in post.Comments)
                    {
                        Console.WriteLine("\t{0}", comment.Content);
                    }
                }
            }

            Console.ReadKey();
        }
    }
}
