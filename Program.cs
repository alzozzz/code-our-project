using EvaProject;
using System;
using System.Collections.Generic;

class Program
{
    public static void Main()
    {
        Console.WriteLine("Welcome to EVA school!");
        
        Intro();
    }

    public static void Intro()
    {
        Console.WriteLine("1-Login\n2-Register");
        String choice = Console.ReadLine();
        if (choice == "1")
        {
            LogIn();
        }
        else if (choice == "2")
        {
            register();
        }
        else
        {
            Console.WriteLine("Choose between 1 and 2 ");
            Intro();
        }
    }

    public static void LogIn()
    {
        Console.WriteLine("Enter Your Id: ");
        String id = Console.ReadLine();
        Console.WriteLine("Enter Your Password: ");
        String password = Console.ReadLine();
        String[] dataRetrieved = new String[0];

        if (id.Length > 0 && (id[0] == 's' || id[0] == 'S'))
        {
            dataRetrieved = Student.Check(id, password);
        }
        else if (id.Length > 0 && (id[0] == 'm' || id[0] == 'M'))
        {
            dataRetrieved = Manager.Check(id, password);
        }
        else if (id.Length > 0 && (id[0] == 't' || id[0] == 'T'))
        {
            dataRetrieved = Teacher.Check(id, password);
        }
        else
        {
            Console.WriteLine("Wrong id, try again");
            LogIn();
            return;
        }

        if (dataRetrieved.Length == 0)
        {
            Console.WriteLine("Please try again");
            LogIn();
        }
        else
        {
            Console.WriteLine("Welcome {0}", dataRetrieved[1]);
            Activities(id);
        }
    }

    public static void register()
    {
        Console.WriteLine("Enter your id: ");
        String id = Console.ReadLine();
        Console.WriteLine("Enter your name: ");
        String name = Console.ReadLine();
        Console.WriteLine("Enter your phone: ");
        String phoneNumber = Console.ReadLine();
        Console.WriteLine("Enter your password: ");
        String password = Console.ReadLine();

        if (id.Length > 0 && (id[0] == 's' || id[0] == 'S'))
        {
            Student.push(new String[] { id, name, phoneNumber, password });
        }
        else if (id.Length > 0 && (id[0] == 'm' || id[0] == 'M'))
        {
            Manager.push(new String[] { id, name, phoneNumber, password });
        }
        else if (id.Length > 0 && (id[0] == 't' || id[0] == 'T'))
        {
            Teacher.push(new String[] { id, name, phoneNumber, password });
        }
        else
        {
            Console.WriteLine("Wrong id, try again");
            register();
            return;
        }

        Console.WriteLine("Now you can log in (*_^): ");
        LogIn();
    }

    public static void Activities(String id)
    {
        if (id.Length > 0 && (id[0] == 's' || id[0] == 'S'))
        {
            studintActivities(id);
        }
        else if (id.Length > 0 && (id[0] == 'm' || id[0] == 'M'))
        {
            managerActivities(id);
        }
        else if (id.Length > 0 && (id[0] == 't' || id[0] == 'T'))
        {
            if (id[1] == 'm' || id[1] == 'M')
            {
                musicTeacherActivities(id);
            }
            else { teacherActivities(id); }
        }
    }

    public static void teacherActivities(String id)
    {
        Console.WriteLine("0-log out\n1-Post\n2-Show Your Posts\n3-make a homework\n4-show your homeworks\n5-Get all managers posts\n6-Get All Informations");
        Console.WriteLine("7-add link\n8-get all links\n9-add new bus\n10-get bus data\n11-add students to bus\n12-students in bus");
        Console.WriteLine("13-add new Groub\n14-get bus groub\n15-add students to groub\n16-students in groub"); 
        String choice = Console.ReadLine();

        switch (choice)
        {
            case "0":
                Intro();
                break;
            case "1":
                Console.WriteLine("Enter your post: ");
                String post = Console.ReadLine();
                Teacher.AddPost(id, post);
                break;
            case "2":
                List<String> posts = Teacher.GetPosts(id);
                Console.WriteLine("Your Posts: ");
                foreach (var p in posts)
                {
                    Console.WriteLine(p);
                }
                break;
            case "3":
                Console.WriteLine("Enter your Homework: ");
                String homework = Console.ReadLine();
                Teacher.AddHomework(id, homework);
                break;
            case "4":
                List<String> homeworks = Teacher.GetHomeworks(id);
                Console.WriteLine("Your Homeworks: ");
                foreach (var h in homeworks)
                {
                    Console.WriteLine(h);
                }
                break;
            case "5":
                List<String> allManagersPosts = Manager.GetAllPostsWithPublishers();
                Console.WriteLine("All Posts with Publishers:");
                foreach (String p in allManagersPosts)
                {
                    Console.WriteLine(p);
                }
                break ;
            case "6":
                List<String> allManagersInformations = Manager.GetAllInformationsWithPublishers();
                Console.WriteLine("All Posts with Publishers:");
                foreach (String inf in allManagersInformations)
                {
                    Console.WriteLine(inf);
                }
                break;
            case "7":
                Console.WriteLine("Enter your link: ");
                String link = Console.ReadLine();
                Teacher.AddLink(id, link);
                break;
            case "8":
                List<String> links = Teacher.GetLinks(id);
                Console.WriteLine("Your Posts: ");
                foreach (var l in links)
                {
                    Console.WriteLine(l);
                }
                break;
            case "9":
                Teacher.AddNewBus();
                Activities(id);
                break;
            case "10":
                Teacher.GetBusData();
                Activities(id);
                break;
            case "11":
                Console.WriteLine("inter bus id : ");
                String busId = Console.ReadLine();
                Teacher.AddStudentToBus(busId);
                Activities(id);
                break;
            case "12":
                Console.WriteLine("inter bus id : ");
                String busid = Console.ReadLine();
                List<String> allStudentsOnBus = Bus.GetStudentsInBus(busid);
                Console.WriteLine("All stidents in bus:");
                foreach (String s in allStudentsOnBus)
                {
                    Console.WriteLine(s);
                }
                break;
            case "13":
                Teacher.AddNewGroub();
                Activities(id);
                break;

            case "14":
                Teacher.GetGroupData();
                Activities(id);
                break;
            case "15":
                Console.WriteLine("inter Group id : ");
                String GroupID = Console.ReadLine();
                Teacher.AddStudentToBus(GroupID);
                Activities(id);
                break;

            case "16":
                Console.WriteLine("inter bus id : ");
                String groupid = Console.ReadLine();
                List<String> allStudentsOnGroup = Bus.GetStudentsInBus(groupid);
                Console.WriteLine("All stidents in Groub:");
                foreach (String s in allStudentsOnGroup)
                {
                    Console.WriteLine(s);
                }
                break;
            default:
                Console.WriteLine("Invalid option, try again");
                teacherActivities(id);
                break;
        }
        Activities(id);
    }

    public static void managerActivities(String id)
    {
        Console.WriteLine("0-log out\n1-Post\n2-Show Your Posts\n3-show all student\n4-show all Teachers");
        Console.WriteLine("5-show all teachers posts\n6-show all teachers homeowrks\n7-Get all instruments");
        Console.WriteLine("8-get all important links\n9-add information\n10-get all information\n11-get all buses information\n12-get all group information");
        String choice = Console.ReadLine();
        switch (choice)
        {
            case "0":
                Intro();
                break;
            case "1":
                Console.WriteLine("Enter your post: ");
                String post = Console.ReadLine();
                Manager.AddPost(id, post);
                break;
            case "2":
                List<String> posts = Manager.GetPosts(id);
                Console.WriteLine("Your Posts: ");
                foreach (var p in posts)
                {
                    Console.WriteLine(p);
                }
                break;
            case "3":
                List<String> allStudents = Student.GetAllStudents();
                Console.WriteLine("All Students:");
                for (int i = 0; i < allStudents.Count; i++)
                {
                    Console.WriteLine(allStudents[i]);
                }
                break;
            case "4":
                List<String> allTeachers = Teacher.GetAllTeacher();
                Console.WriteLine("All Teachers:");
                for (int i = 0; i < allTeachers.Count; i++)
                {
                    Console.WriteLine(allTeachers[i]);
                }
                break;
            case "5":
                List<String> allTeacherPostsWithPublishers = Teacher.GetAllPostsWithPublishers();
                Console.WriteLine("All Posts with Publishers:");
                foreach (String p in allTeacherPostsWithPublishers)
                {
                    Console.WriteLine(p);
                }
                break;
            case "6":
                List<String> allTeachersHomework = Teacher.GetAllHomeworksWithPublishers();
                Console.WriteLine("All Posts with Publishers:");
                foreach (String h in allTeachersHomework)
                {
                    Console.WriteLine(h);
                }
                break;
            case "7":
                List<String> allTeachersInstroments = Teacher.GetAllInstrumentWithPublishers();
                Console.WriteLine("All Posts with Publishers:");
                foreach (String h in allTeachersInstroments)
                {
                    Console.WriteLine(h);
                }
                break;
            case "8":
                List<String> allTeacherslinks = Teacher.GetAllLinksWithPublishers();
                Console.WriteLine("All Posts with Publishers:");
                foreach (String l in allTeacherslinks)
                {
                    Console.WriteLine(l);
                }
                break;
            case "9":
                Console.WriteLine("Enter your information: ");
                String inf = Console.ReadLine();
                Manager.AddInf(id, inf);
                break;
            case "10":
                List<String> infs = Manager.GetInf(id);
                Console.WriteLine("Your informations: ");
                foreach (var i in infs)
                {
                    Console.WriteLine(i);
                }
                break;
            case "11":
                List<string> allBusesWithStudents = Manager.GetAllBusesWithStudents();
                Console.WriteLine("All Buses with Students:");
                foreach (String busInfo in allBusesWithStudents)
                {
                    Console.WriteLine(busInfo);
                }
                break;
            case "12":
                List<string> allGroupesWithStudents = Manager.GetAllGroupsWithStudents();
                Console.WriteLine("All Groupes with Students:");
                foreach (String GroupInfo in allGroupesWithStudents)
                {
                    Console.WriteLine(GroupInfo);
                }
                break;
            default:
                Console.WriteLine("Invalid option, try again");
                teacherActivities(id);
                break;
        }
        Activities(id);
    }

    public static void studintActivities(String id)
    {
        Console.WriteLine("0log out\n1-Post\n2-Show Your Posts\n3-show all teachers\n4-get homework\n5-Get all instruments");
        Console.WriteLine("6-get all information\n7-get all links\n8-all teachers posts\n9-all managers posts");

        String choice = Console.ReadLine();

        switch (choice)
        {
            case "0":
                Intro();
                break;
            case "1":
                Console.WriteLine("Enter your post: ");
                String post = Console.ReadLine();
                Student.AddPost(id, post);
                break;
            case "2":
                List<String> posts = Student.GetPosts(id);
                Console.WriteLine("Your Posts: ");
                foreach (var p in posts)
                {
                    Console.WriteLine(p);
                }
                break;
            case "3":
                List<String> allTeachers = Teacher.GetAllTeacher();
                Console.WriteLine("All Teachers:");
                for (int i = 0; i < allTeachers.Count; i++)
                {
                    Console.WriteLine(allTeachers[i]);
                }
                break;
            case "4":
                Console.WriteLine("Enter Teacher Id: ");
                String teacherId = Console.ReadLine();
                List<String> homeworks = Student.GetHomeworksByTeacherId(teacherId);
                Console.WriteLine("Homeworks from Teacher {0}:", teacherId);
                foreach (var hw in homeworks)
                {
                    Console.WriteLine(hw);
                }
                break;
            case "5":
                List<String> allTeachersInstroments = Teacher.GetAllInstrumentWithPublishers();
                Console.WriteLine("All Posts with Publishers:");
                foreach (String h in allTeachersInstroments)
                {
                    Console.WriteLine(h);
                }
                break;
            case "6":
                List<String> allManagersInformations = Manager.GetAllInformationsWithPublishers();
                Console.WriteLine("All Posts with Publishers:");
                foreach (String inf in allManagersInformations)
                {
                    Console.WriteLine(inf);
                }
                break;
            case "7":
                List<String> allLinks = Teacher.GetAllLinksWithPublishers();
                Console.WriteLine("All Posts with Publishers:");
                foreach (String l in allLinks)
                {
                    Console.WriteLine(l);
                }
                break;
            case "8":
                List<String> allTeacherPostsWithPublishers = Teacher.GetAllPostsWithPublishers();
                Console.WriteLine("All Posts with Publishers:");
                foreach (String p in allTeacherPostsWithPublishers)
                {
                    Console.WriteLine(p);
                }
                break;
            case "9":
                List<String> allManagerPostsWithPublishers = Manager.GetAllPostsWithPublishers();
                Console.WriteLine("All Posts with Publishers:");
                foreach (String p in allManagerPostsWithPublishers)
                {
                    Console.WriteLine(p);
                }
                break;
            default:
                Console.WriteLine("Invalid option, try again");
                teacherActivities(id);
                break;
        }
        Activities(id);
    }

    public static void musicTeacherActivities(String id)
    {
        Console.WriteLine("music");
        Console.WriteLine("0-log out\n1-Post\n2-Show Your Posts\n3-make a homework\n4-show your homeworks");
        Console.WriteLine("5-Add instrument\n6-Get instruments\n7-manager posts\n8-all informations\n9-add link\n10-get links");
        Console.WriteLine("11-add new Groub\n12-get bus groub\n13-add students to groub\n14-students in groub");
        String choice = Console.ReadLine();

        switch (choice)
        {
            case "0":
                Intro();
                break;
            case "1":
                Console.WriteLine("Enter your post: ");
                String post = Console.ReadLine();
                Teacher.AddPost(id, post);
                break;
            case "2":
                List<String> posts = Teacher.GetPosts(id);
                Console.WriteLine("Your Posts: ");
                foreach (var p in posts)
                {
                    Console.WriteLine(p);
                }
                break;
            case "3":
                Console.WriteLine("Enter your Homework: ");
                String homework = Console.ReadLine();
                Teacher.AddHomework(id, homework);
                break;
            case "4":
                List<String> homeworks = Teacher.GetHomeworks(id);
                Console.WriteLine("Your Homeworks: ");
                foreach (var h in homeworks)
                {
                    Console.WriteLine(h);
                }
                break;
            case "5":
                Console.WriteLine("Enter your instrument: ");
                String instrument = Console.ReadLine();
                Teacher.AddInstrument(id, instrument);
                break;
            case "6":
                List<String> instruments = Teacher.GetInstroments(id);
                Console.WriteLine("Your instruments: ");
                foreach (var i in instruments)
                {
                    Console.WriteLine(i);
                }
                break;
            case "7":
                List<String> allManagersPosts = Manager.GetAllPostsWithPublishers();
                Console.WriteLine("All Posts with Publishers:");
                foreach (String p in allManagersPosts)
                {
                    Console.WriteLine(p);
                }
                break;
            case "8":
                List<String> allManagersInformations = Manager.GetAllInformationsWithPublishers();
                Console.WriteLine("All Posts with Publishers:");
                foreach (String inf in allManagersInformations)
                {
                    Console.WriteLine(inf);
                }
                break;
            case "9":
                Console.WriteLine("Enter your link: ");
                String link = Console.ReadLine();
                Teacher.AddLink(id, link);
                break;
            case "10":
                List<String> links = Teacher.GetLinks(id);
                Console.WriteLine("Your Posts: ");
                foreach (var l in links)
                {
                    Console.WriteLine(l);
                }
                break;
            case "11":
                Teacher.AddNewGroub();
                Activities(id);
                break;

            case "12":
                Teacher.GetGroupData();
                Activities(id);
                break;
            case "13":
                Console.WriteLine("inter Group id : ");
                String GroupID = Console.ReadLine();
                Teacher.AddStudentToBus(GroupID);
                Activities(id);
                break;

            case "14":
                Console.WriteLine("inter bus id : ");
                String groupid = Console.ReadLine();
                List<String> allStudentsOnGroup = Bus.GetStudentsInBus(groupid);
                Console.WriteLine("All stidents in Groub:");
                foreach (String s in allStudentsOnGroup)
                {
                    Console.WriteLine(s);
                }
                break;
            default:
                Console.WriteLine("Invalid option, try again");
                musicTeacherActivities(id);
                break;
        }
        Activities(id);
    }

}
