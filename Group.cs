using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaProject
{
    internal class Group
    {
        static int size = 10;
        public static String[][] groupes = new String[size][];
        public static Dictionary<string, List<string>> GroupStudents = new Dictionary<string, List<string>>();
        public static int capacity = 0;

        static Group()
        {
            InitializeAccounts();
        }

        public static void InitializeAccounts()
        {

            groupes[capacity] = new String[] { "g001", "math",};
            capacity++;

            groupes[capacity] = new String[] { "g002", "programming",};
            capacity++;
        }

        public static void AddGroup(String[] data)
        {
            if (capacity == size)
            {
                size += 5;
                Array.Resize(ref groupes, size);
            }
            groupes[capacity] = data;
            capacity++;
            Console.WriteLine("Added");
        }

        public static String[] GetGroupData(String id)
        {
            String[] retriveData = new String[0];
            for (int i = 0; i < capacity; i++)
            {
                if (groupes[i] != null && groupes[i][0] == id)
                {
                    retriveData = groupes[i];
                    break;
                }
            }
            return retriveData;
        }

        public static void AddStudentToGroup(string GroupId, string studentId)
        {
            if (!Student.StudentExists(studentId))
            {
                Console.WriteLine("Student not found");
                return;
            }

            if (!GroupStudents.ContainsKey(GroupId))
            {
                GroupStudents[GroupId] = new List<string>();
            }

            GroupStudents[GroupId].Add(studentId);
            Console.WriteLine("Student added to the group successfully.");
        }

        public static List<string> GetStudentsInGroup(string GroupId)
        {
            if (GroupStudents.ContainsKey(GroupId))
            {
                return GroupStudents[GroupId];
            }
            return new List<string>();
        }
    }
}
