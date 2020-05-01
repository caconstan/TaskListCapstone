using System;
using System.Collections.Generic;

namespace CapstoneTaskList
{
    class Program
    {
        static List<Task> myTasks = new List<Task>();
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To The Task Manager!");
            int menuSelection = 0;

            while (menuSelection == 0)
            {
                Console.WriteLine("\n1. List Tasks");
                Console.WriteLine("2. Add Task");
                Console.WriteLine("3. Delete Task");
                Console.WriteLine("4. Mark Task Complete");
                Console.WriteLine("5. Quit");

                Console.WriteLine("What would you like to do?");
                string inputString = Console.ReadLine();

                bool gotInt = int.TryParse(inputString, out menuSelection);
                if (!gotInt || menuSelection > 5 || menuSelection < 1)
                {
                    Console.WriteLine("I'm sorry I didn't understand.  Please make another selection.");
                    menuSelection = 0;
                }

                switch (menuSelection)
                {
                    case 1:
                        ListTasks();
                        menuSelection = 0;
                        break;
                    case 2:
                        AddTask();
                        menuSelection = 0;
                        break;
                    case 3:
                        DeleteTask();
                        menuSelection = 0;
                        break;
                    case 4:
                        MarkComplete();
                        menuSelection = 0;
                        break;
                    case 5:
                        break;
                    default: // case 0
                        break;
                }
            }

            Console.WriteLine("Have a great day!");
        }

        public static void ListTasks()
        {
            if (myTasks.Count == 0)
            {
                Console.WriteLine("\nTASK LIST IS CURRENTLY EMPTY");
            } else
            {
                Console.WriteLine("\nLIST TASKS");
                Console.WriteLine("{0,-3}\t{1,-10}\t{2,-10}\t{3,-10}\t{4,-10}", "Num", "Team Member", "Description","Due Date","Completed");
                Console.WriteLine("{0,-3}\t{1,-10}\t{2,-10}\t{3,-10}\t{4,-10}", "---", "-----------", "-----------","--------", "--------");

            }

            for (int i=0; i<myTasks.Count; i++)
            {
                Task mytask = myTasks[i];
                Console.WriteLine("{0,-3}\t{1,-10}\t{2,-10}\t{3,-10}\t{4,-10}",
                    i+1, mytask.TeamMember, mytask.Description, mytask.DueDate.ToString("MM/dd/yyyy"), mytask.Completed);
            }

            Console.WriteLine("");
        }

        public static void AddTask()
        {
            Console.WriteLine("\nADD TASK");
            
            try
            {
                Task myTask = new Task();

                Console.Write("Team Member Name: ");
                myTask.TeamMember = Console.ReadLine();

                Console.Write("Task Description: ");
                myTask.Description = Console.ReadLine();

                Console.Write("Due Date (MM/DD/YYYY): ");
                myTask.DueDate = DateTime.Parse(Console.ReadLine());

                myTasks.Add(myTask);

                Console.WriteLine("Task entered!");
            }
            catch
            {
                Console.WriteLine("I'm sorry I didn't understand.  Returning to the Main Menu...");
            }
        }

        public static void DeleteTask()
        {
            Console.WriteLine("\nDELETE TASK");

            if (myTasks.Count == 0)
            {
                Console.Write("Task list is empty.  No tasks to delete.\n");
                return;
            }

            Console.Write("Please enter the number of the task you would like to delete: ");
            try
            {
                int taskNumber = int.Parse(Console.ReadLine());
                Task myTask = myTasks[taskNumber - 1];

                Console.WriteLine("\nTeam Member Name: " + myTask.TeamMember);
                Console.WriteLine("Task Description: "+ myTask.Description);
                Console.WriteLine("Due Date: " + myTask.DueDate.ToString("MM/dd/yyyy"));

                Console.WriteLine("\nAre you sure you want to delete this task? (y/n)");
                string inputString = Console.ReadLine();

                if (inputString == "y")
                {
                    myTasks.RemoveAt(taskNumber - 1);
                    Console.WriteLine("Task deleted!");
                } else
                {
                    Console.WriteLine("Task delete cancelled.");
                }
            }
            catch
            {
                Console.WriteLine("I'm sorry I didn't understand.  Returning to the Main Menu...");
            }
        }

        public static void MarkComplete()
        {
            Console.WriteLine("\nMARK COMPLETE");

            if (myTasks.Count == 0)
            {
                Console.Write("Task list is empty.  No tasks to mark complete.\n");
                return;
            }

            Console.Write("Please enter the number of the task you would like to mark complete: ");

            int taskNumber = 0;

            while (taskNumber == 0)
            {
                bool check = int.TryParse(Console.ReadLine(), out taskNumber);
                if (!check || taskNumber > myTasks.Count || taskNumber < 1)
                {
                    taskNumber = 0;
                    Console.Write("I'm sorry that is not a valid task number.  Please enter the number of the task you would like to mark complete: ");
                }
            }

            Task myTask = myTasks[taskNumber - 1];

            Console.WriteLine("\nTeam Member Name: " + myTask.TeamMember);
            Console.WriteLine("Task Description: " + myTask.Description);
            Console.WriteLine("Due Date: " + myTask.DueDate.ToString("MM/dd/yyyy"));

            Console.WriteLine("\nAre you sure you want to mark this task complete? (y/n)");
            string inputString = Console.ReadLine();

            if (inputString == "y")
            {
                myTasks[taskNumber - 1].Completed = true;

                Console.WriteLine("Task marked complete!");
            }
            else
            {
                Console.WriteLine("Mark complete cancelled.");
            }
        }
    }
}
