using System;
using System.Collections.Generic;

namespace EvaProject
{
    internal class Teacher
    {
        static int size = 10;
        public static String[][] accounts = new String[size][];
        static int capacity = 0;
        public static List<String>[] posts = new List<String>[size];
        public static List<String>[] homeworks = new List<String>[size];
        public static List<String>[] instruments = new List<String>[size];
        public static List<String>[] links = new List<String>[size];


        static Teacher()
        {
            InitializeAccounts();
        }
        public static void InitializeAccounts()
        {
            accounts[capacity] = new String[] { "t001", "Teacher One", "1234567890", "001" };
            posts[capacity] = new List<String>();
            homeworks[capacity] = new List<String>();
            links[capacity] = new List<String>();
            instruments[capacity] = new List<String>();
            capacity++;

            accounts[capacity] = new String[] { "t002", "Teacher Two", "0987654321", "002" };
            posts[capacity] = new List<String>();
            homeworks[capacity] = new List<String>();
            links[capacity] = new List<String>();
            instruments[capacity] = new List<String>();
            capacity++;
        }

        public static void push(String[] data)
        {
            if (capacity == size)
            {
                size += 5;
                Array.Resize(ref accounts, size);
                Array.Resize(ref posts, size);
                Array.Resize(ref homeworks, size);
                Array.Resize(ref instruments, size);
                Array.Resize(ref links, size);
            }
            accounts[capacity] = data;
            posts[capacity] = new List<String>();
            homeworks[capacity] = new List<string>();
            instruments[capacity] = new List<string>();
            links[capacity] = new List<string>();
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
            Console.WriteLine("Teacher not found");
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
            Console.WriteLine("Teacher not found");
            return new List<String>();
        }

        public static void AddHomework(String id, String post)
        {
            for (int i = 0; i < capacity; i++)
            {
                if (accounts[i] != null && accounts[i][0] == id)
                {
                    homeworks[i].Add(post);
                    Console.WriteLine("Post added");
                    return;
                }
            }
            Console.WriteLine("Teacher not found");
        }

        public static List<String> GetHomeworks(String id)
        {
            for (int i = 0; i < capacity; i++)
            {
                if (accounts[i] != null && accounts[i][0] == id)
                {
                    return homeworks[i];
                }
            }
            Console.WriteLine("Teacher not found");
            return new List<String>();
        }

        public static List<String> GetAllTeacher()
        {
            List<String> allTeachers = new List<String>();
            foreach (String[] account in accounts)
            {
                if (account != null)
                {
                    allTeachers.Add(account[1]);
                }
            }
            return allTeachers;
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

        public static List<String> GetAllHomeworksWithPublishers()
        {
            List<String> allHomeworks = new List<String>();
            for (int i = 0; i < capacity; i++)
            {
                if (accounts[i] != null)
                {
                    String teacherName = accounts[i][1];
                    foreach (String h in homeworks[i])
                    {
                        allHomeworks.Add($"{teacherName}: {h}");
                    }
                }
            }
            return allHomeworks;
        }

        public static List<String> GetHomeworksByTeacherId(String teacherId)
        {
            for (int i = 0; i < capacity; i++)
            {
                if (accounts[i] != null && accounts[i][0] == teacherId)
                {
                    return homeworks[i];
                }
            }
            Console.WriteLine("Teacher not found");
            return new List<String>();
        }
        public static void AddInstrument(String id, String instrument)
        {
            for (int i = 0; i < capacity; i++)
            {
                if (accounts[i] != null && accounts[i][0] == id)
                {
                    instruments[i].Add(instrument);
                    Console.WriteLine("instrument added");
                    return;
                }
            }
            Console.WriteLine("Teacher not found");
        }
        public static List<String> GetInstroments(String id)
        {
            for (int i = 0; i < capacity; i++)
            {
                if (accounts[i] != null && accounts[i][0] == id)
                {
                    return instruments[i];
                }
            }
            Console.WriteLine("Teacher not found");
            return new List<String>();
        }
        public static List<String> GetAllInstrumentWithPublishers()
        {
            List<String> allInstroments = new List<String>();
            for (int i = 0; i < capacity; i++)
            {
                if (accounts[i] != null)
                {
                    String teacherName = accounts[i][1];
                    foreach (String instrument in instruments[i])
                    {
                        allInstroments.Add($"{teacherName}: {instrument}");
                    }
                }
            }
            return allInstroments;
        }
        public static void AddLink(String id, String link)
        {
            for (int i = 0; i < capacity; i++)
            {
                if (accounts[i] != null && accounts[i][0] == id)
                {
                    if (links[i] == null)
                    {
                        links[i] = new List<String>();  
                    }
                    links[i].Add(link);
                    Console.WriteLine("Link added");
                    return;
                }
            }
            Console.WriteLine("Teacher not found");
        }

        public static List<String> GetLinks(String id)
        {
            for (int i = 0; i < capacity; i++)
            {
                if (accounts[i] != null && accounts[i][0] == id)
                {
                    return links[i] ?? new List<String>();  
                }
            }
            Console.WriteLine("Teacher not found");
            return new List<String>();
        }

        public static List<String> GetAllLinksWithPublishers()
        {
            List<String> allLinks = new List<String>();
            for (int i = 0; i < capacity; i++)
            {
                if (accounts[i] != null)
                {
                    String teacherName = accounts[i][1];
                    foreach (String link in links[i])  
                    {
                        allLinks.Add($"{teacherName}: {link}");
                    }
                }
            }
            return allLinks;
        }

        public static void AddNewBus()
        {
            Console.WriteLine("Enter Bus ID: ");
            String busId = Console.ReadLine();
            Console.WriteLine("Enter Driver Name: ");
            String driverName = Console.ReadLine();
            Console.WriteLine("Enter Driver Phone Number: ");
            String driverPhone = Console.ReadLine();
            Console.WriteLine("Enter Start Location: ");
            String startLocation = Console.ReadLine();
            Console.WriteLine("Enter Destination: ");
            String destination = Console.ReadLine();

            Bus.AddBus(new String[] { busId, driverName, driverPhone, startLocation, destination });
            Console.WriteLine("Bus added successfully.");
        }

        public static void GetBusData()
        {
            Console.WriteLine("Enter Bus ID: ");
            String busId = Console.ReadLine();

            String[] busData = Bus.GetBusData(busId);

            if (busData.Length > 0)
            {
                Console.WriteLine("Bus ID: {0}", busData[0]);
                Console.WriteLine("Driver Name: {0}", busData[1]);
                Console.WriteLine("Driver Phone: {0}", busData[2]);
                Console.WriteLine("Start Location: {0}", busData[3]);
                Console.WriteLine("Destination: {0}", busData[4]);
            }
            else
            {
                Console.WriteLine("Bus not found.");
            }
        }

        public static void AddStudentToBus(string busId)
        {
            Console.WriteLine("Enter Student ID to add to the bus or 'done' to finish:");
            string studentId = Console.ReadLine();

            if (studentId.ToLower() == "done")
            {
                return;
            }
            Bus.AddStudentToBus(busId, studentId);
            AddStudentToBus(busId);
        }
        public static void AddNewGroub()
        {
            Console.WriteLine("Enter group ID: ");
            String groupId = Console.ReadLine();
            Console.WriteLine("Enter group subject: ");
            String subject = Console.ReadLine();
            

            Bus.AddBus(new String[] { groupId , subject });
            Console.WriteLine("groub added successfully.");
        }

        public static void GetGroupData()
        {
            Console.WriteLine("Enter group ID: ");
            String groupId = Console.ReadLine();

            String[] busData = Bus.GetBusData(groupId);

            if (busData.Length > 0)
            {
                Console.WriteLine("Group ID: {0}", busData[0]);
                Console.WriteLine("subject Name: {0}", busData[1]);
            }
            else
            {
                Console.WriteLine("group not found.");
            }
        }

        public static void AddStudentToGroup(string GroupId)
        {
            Console.WriteLine("Enter Student ID to add to the Group or 'done' to finish:");
            string studentId = Console.ReadLine();

            if (studentId.ToLower() == "done")
            {
                return;
            }
            Group.AddStudentToGroup(GroupId, studentId);
            AddStudentToGroup(GroupId);
        }

    }
}
