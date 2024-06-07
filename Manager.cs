using System;

namespace EvaProject
{
    internal class Manager
    {
        static int size = 10;
        public static String[][] accounts = new String[size][];
        static int capacity = 0;
        public static List<String>[] posts = new List<String>[size];
        public static List<String>[] informstionsAboutSchool = new List<String>[size];

        static Manager()
        {
            InitializeAccounts();
        }

        public static void InitializeAccounts()
        {

            accounts[capacity] = new String[] { "m001", "Salem", "1234567890", "001" };
            posts[capacity] = new List<String>();
            informstionsAboutSchool[capacity] = new List<String>();
            capacity++;
            accounts[capacity] = new String[] { "m002", "Manager Two", "0987654321", "002" };
            posts[capacity] = new List<String>();
            informstionsAboutSchool[capacity] = new List<String>();
            capacity++;
        }

        public static void push(String[] data)
        {
            if (capacity == size)
            {
                size += 5;
                Array.Resize(ref accounts, size);
                Array.Resize(ref posts, size);
                Array.Resize(ref informstionsAboutSchool, size);
            }
            accounts[capacity] = data;
            informstionsAboutSchool[capacity] = new List<string>();
            posts[capacity] = new List<string>();
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
            Console.WriteLine("Manager not found");
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
            Console.WriteLine("Manager not found");
            return new List<String>();
        }
        public static void AddInf(String id, String post)
        {
            for (int i = 0; i < capacity; i++)
            {
                if (accounts[i] != null && accounts[i][0] == id)
                {
                    informstionsAboutSchool[i].Add(post);
                    Console.WriteLine("inf added");
                    return;
                }
            }
            Console.WriteLine("Manager not found");
        }
        public static List<String> GetInf(String id)
        {
            for (int i = 0; i < capacity; i++)
            {
                if (accounts[i] != null && accounts[i][0] == id)
                {
                    return informstionsAboutSchool[i];
                }
            }
            Console.WriteLine("Manager not found");
            return new List<String>();
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

        public static List<String> GetAllInformationsWithPublishers()
        {
            List<String> allInformations = new List<String>();
            for (int i = 0; i < capacity; i++)
            {
                if (accounts[i] != null)
                {
                    String teacherName = accounts[i][1];
                    foreach (String inf in informstionsAboutSchool[i])
                    {
                        allInformations.Add($"{teacherName}: {inf}");
                    }
                }
            }
            return allInformations;
        }
        public static List<string> GetAllBusesWithStudents()
        {
            List<string> allBusesWithStudents = new List<string>();
            for (int i = 0; i < Bus.capacity; i++)
            {
                if (Bus.buses[i] != null)
                {
                    String busData = String.Join(", ", Bus.buses[i]);
                    List<string> students = Bus.GetStudentsInBus(Bus.buses[i][0]);
                    String studentsData = String.Join(", ", students);
                    allBusesWithStudents.Add($"{busData} - Students: [{studentsData}]");
                }
            }
            return allBusesWithStudents;
        }
        public static List<string> GetAllGroupsWithStudents()
        {
            List<string> allGroupsWithStudents = new List<string>();
            for (int i = 0; i < Group.capacity; i++)
            {
                if (Group.groupes[i] != null)
                {
                    String groupId = Group.groupes[i][0];
                    String groupName = Group.groupes[i][1];
                    List<string> students = Group.GetStudentsInGroup(groupId);
                    String studentsData = String.Join(", ", students);
                    allGroupsWithStudents.Add($"{groupName} ({groupId}) - Students: [{studentsData}]");
                }
            }
            return allGroupsWithStudents;
        }


    }
}
