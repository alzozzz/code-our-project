using System;
using System.Collections.Generic;

namespace EvaProject
{
    internal class Student
    {
        static int size = 10;
        public static String[][] accounts = new String[size][];
        static int capacity = 0;
        public static List<String>[] posts = new List<String>[size];

        static Student()
        {
            InitializeAccounts();
        }
        public static void InitializeAccounts()
        {
            accounts[capacity] = new String[] { "s001", "std One", "1234567890", "001" };
            posts[capacity] = new List<String>();
            capacity++;

            accounts[capacity] = new String[] { "s002", "std Two", "0987654321", "002" };
            posts[capacity] = new List<String>();
            capacity++;
        }
        public static void push(String[] data)
        {
            if (capacity == size)
            {
                size += 5;
                Array.Resize(ref accounts, size);
                Array.Resize(ref posts, size); // Ensure resizing posts array
            }
            accounts[capacity] = data;
            posts[capacity] = new List<String>(); // Initialize the posts array
            capacity++;
            Console.WriteLine("Registered");
        }
        public static String[] Check(String id, String password)
        {
            String[] retriveData = new String[0];
            for (int i = 0; i < capacity; i++)
            {
                if (accounts[i] != null && accounts[i][0] == id && accounts[i][3] == password)
                {
                    retriveData = accounts[i];
                    break;
                }
            }
            return retriveData;
        }
        public static void AddPost(String id, String post)
        {
            for (int i = 0; i < capacity; i++)
            {
                if (accounts[i] != null && accounts[i][0] == id)
                {
                    posts[i].Add(post);
                    Console.WriteLine("Post added");
                    return;
                }
            }
            Console.WriteLine("Student not found");
        }
        public static List<String> GetPosts(String id)
        {
            for (int i = 0; i < capacity; i++)
            {
                if (accounts[i] != null && accounts[i][0] == id)
                {
                    return posts[i];
                }
            }
            Console.WriteLine("Student not found");
            return new List<String>();
        }
        public static List<String> GetAllStudents()
        {
            List<String> allStudents = new List<String>();
            foreach (String[] account in accounts)
            {
                if (account != null)
                {
                    allStudents.Add(account[1]);
                }
            }
            return allStudents;
        }
        public static List<String> GetAllPostsWithPublishers()
        {
            List<String> allPosts = new List<String>();
            for (int i = 0; i < capacity; i++)
            {
                if (accounts[i] != null)
                {
                    String teacherName = accounts[i][1];
                    foreach (String post in posts[i])
                    {
                        allPosts.Add($"{teacherName}: {post}");
                    }
                }
            }
            return allPosts;
        }
        public static List<String> GetHomeworksByTeacherId(String teacherId)
        {
            return Teacher.GetHomeworksByTeacherId(teacherId);
        }
        public static bool StudentExists(String studentId)
        {
            for (int i = 0; i < capacity; i++)
            {
                if (accounts[i] != null && accounts[i][0] == studentId)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
