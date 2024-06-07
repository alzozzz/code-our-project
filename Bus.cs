using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaProject
{
    internal class Bus
    {
        static int size = 10;
        public static String[][] buses = new String[size][];
        public static Dictionary<string, List<string>> busStudents = new Dictionary<string, List<string>>();
        public static int capacity = 0;

        static Bus()
        {
            InitializeAccounts();
        }

        public static void InitializeAccounts()
        {

            buses[capacity] = new String[] { "b001" ,"driver one" , "01234567891" , "giza" , "cairo"};
            capacity++;

            buses[capacity] = new String[] { "b002", "driver two", "09876543219", "kafr-eldawar", "kafr-saqr" };    
            capacity++;
        }

        public static void AddBus(String[] data)
        {
            if (capacity == size)
            {
                size += 5;
                Array.Resize(ref buses, size);
            }
            buses[capacity] = data;
            capacity++;
            Console.WriteLine("Added");
        }

        public static String[] GetBusData(String id)
        {
            String[] retriveData = new String[0];
            for (int i = 0; i < capacity; i++)
            {
                if (buses[i] != null && buses[i][0] == id)
                {
                    retriveData = buses[i];
                    break;
                }
            }
            return retriveData;
        }

        public static void AddStudentToBus(string busId, string studentId)
        {
            if (!Student.StudentExists(studentId))
            {
                Console.WriteLine("Student not found");
                return;
            }

            if (!busStudents.ContainsKey(busId))
            {
                busStudents.Add(busId, new List<string>());
            }

            busStudents[busId].Add(studentId);
            Console.WriteLine("Student added to the bus successfully.");
        }

        public static List<string> GetStudentsInBus(string busId)
        {
            if (busStudents.ContainsKey(busId))
            {
                return busStudents[busId];
            }
            return new List<string>();
        }
    }
}
