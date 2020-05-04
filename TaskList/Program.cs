using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace TaskList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Task> ListOfTasks = new List<Task>();
            ListOfTasks.Add(new Task(1, "Shawn", "Design the best tasklist program.", new DateTime(2020, 5, 11), false));
            ListOfTasks.Add(new Task(2, "Sally", "Design the best tasklist program.", new DateTime(2020, 5, 12), false));
            ListOfTasks.Add(new Task(3, "Joe", "Design the best tasklist program.", new DateTime(2020, 5, 13), false));
            ListOfTasks.Add(new Task(4, "Carmen", "Design the best tasklist program.", new DateTime(2020, 5, 14), false));
            ListOfTasks.Add(new Task(5, "Franklin", "Design the best tasklist program.", new DateTime(2020, 5, 15), false));

            bool runProgram = true;

            //--------------------------------------------------------------------------------------------------------------------------------------------
            //Program Logic starts Here

            GreetingPrompt();

            while (runProgram)
            {
                int menuSelection = 0;
                MenuInstructions();

                try
                {
                    menuSelection = int.Parse(ReadAndReturnInput());

                    if (menuSelection > 5)
                    {
                        Console.WriteLine("The number you entered is greater than allowed. Try again.");
                    }

                    switch (menuSelection)
                    {
                        case 1:
                            ListTasks(ListOfTasks);
                            break;
                        case 2:
                            AddTaskToList(ListOfTasks);
                            break;
                        case 3:
                            Deletetask(ListOfTasks);
                            break;
                        case 4:
                            MarkTaskComplete(ListOfTasks);
                            break;
                        case 5:
                            runProgram = false;
                            Console.WriteLine("Thank you for using the Grand Circus Task Manager!");
                            break;
                        case 227:
                            break;
                    }
                }
                catch (FormatException format)
                {
                    Console.WriteLine("Invalid entry. Please input number between 1 and 5.\n");
                }
                catch (StackOverflowException stackO)
                {
                    menuSelection = 227;
                    Console.WriteLine("The number you entered is greater than allowed. Try again.");
                }


            }
        }

        public static void GreetingPrompt()
        {
            Console.WriteLine("Welcome to the Grand Circus Task Manager.");
        }

        public static void MenuInstructions()
        {
            Console.WriteLine("This is the main menu of the Grand Circus Task Manager\n" +
                "----Press 1 to List All Tasks\n" +
                "----Press 2 to Add A New Task To The List\n" +
                "----Press 3 to Delete A Task From The List\n" +
                "----Press 4 to Mark A Task Complete\n" +
                "----Press 5 to Quit The Manager");
        }
        public static string ReadAndReturnInput()
        {
            return Console.ReadLine();
        }

        public static bool ValidateNumInput(string toBeValidated)
        {
            bool isANum = false;
            int confirmedInt;
            if (int.TryParse(toBeValidated, out confirmedInt))
            {
                isANum = true;
                return isANum;
            }
            return isANum;
        }

        public static bool ValidateDateTime(string toBeValidated)
        {
            bool isADateTime = false;
            DateTime confirmedDate = new DateTime();

            if (DateTime.TryParse(toBeValidated, out confirmedDate))
            {
                isADateTime = true;
                return isADateTime;
            }
            return isADateTime;
        }

        public static DateTime ReturnDateTime(string toBeConverted)
        {
            bool isStringConverted = false;
            DateTime convertedDate = new DateTime();
            while (!isStringConverted)
            {
                if (ValidateDateTime(toBeConverted))
                {
                    convertedDate = DateTime.Parse(toBeConverted);
                    isStringConverted = true;
                    return convertedDate;
                }
                else
                {
                    Console.WriteLine("\nThe text you entered is not in the valid format of: Jan 1, 2020\nTry Again.");
                    toBeConverted = ReadAndReturnInput();
                }
            }
            return convertedDate;
        }

        public static bool ReturnBool(string toBeConverted)
        {
            bool boolReturnValue = false;
            bool isValidInput = false;

            while (!isValidInput)
            {

                if (toBeConverted == "1")
                {
                    boolReturnValue = true;
                    isValidInput = true;
                    return boolReturnValue;
                }
                else if (toBeConverted == "0")
                {
                    boolReturnValue = false;
                    isValidInput = true;
                    return boolReturnValue;
                }
                else
                {
                    Console.WriteLine("\nThe input you entered was not in the correct formart.");
                    Console.WriteLine("----------------------------------------------------");
                    AskTaskCompletedPromt();
                    toBeConverted = ReadAndReturnInput();
                }
            }
            return boolReturnValue;
        }

        public static void AskTaskCompletedPromt()
        {
            Console.WriteLine("\nWould you like to mark the Task as completed?\n----Type 0 for No\n----Type 1 for Yes");
        }

        public static void ListTasks(List<Task> taskList)
        {
            foreach (Task task in taskList)
            {
                task.DispayTaskProperties();
            }
        }

        public static int ReturnNextTaskNumber(List<Task> taskList)
        {
            int nextTaskNumer = 0;

            foreach (Task task in taskList)
            {
                nextTaskNumer++;
            }
            nextTaskNumer++;
            return nextTaskNumer;
        }

        public static void ReNumberTasks(List<Task> taskList)
        {
            int counter = 1;

            foreach (Task task in taskList)
            {
                task.TaskNumber = counter;
                counter++;
            }
        }

        public static void AddTaskToList(List<Task> taskList)
        {
            Task addingTask = new Task();

            addingTask.TaskNumber = ReturnNextTaskNumber(taskList);
            Console.WriteLine("Who would you like to assign this task to?");
            addingTask.TeamMemberName = ReadAndReturnInput();
            Console.WriteLine("\nWrite a brief descprition of the task.");
            addingTask.Description = ReadAndReturnInput();
            Console.WriteLine("\nWhat is the due date for this task? (Example: Jan 1, 2020)");
            addingTask.DueDate = ReturnDateTime(ReadAndReturnInput());
            AskTaskCompletedPromt();
            addingTask.HasBeenCompleted = ReturnBool(ReadAndReturnInput());


            taskList.Add(addingTask);
            ReNumberTasks(taskList);
            Console.WriteLine("The new Task has been successfully added!\n");
        }

        public static void Deletetask(List<Task> taskList)
        {
            if (taskList.ToArray().Length > 0)
            {

                ListTasks(taskList);
                Console.WriteLine("Enter in the Task Number that you would like to delete:");

                string input = ReadAndReturnInput();
                int validInt = 0;
                bool isStringParsed = false;
                bool isAnswerConfirmed = false;

                while (!isStringParsed)
                {
                    if (ValidateNumInput(input))
                    {
                        if (int.Parse(input) <= taskList.ToArray().Length)
                        {
                            validInt = int.Parse(input);
                            isStringParsed = true;
                        }
                        else
                        {
                            if (taskList.ToArray().Length > 0)
                            {
                                Console.WriteLine($"\nThe number you entered is out of range. Please enter a number between 1 and {taskList.ToArray().Length}.");
                                input = ReadAndReturnInput();
                            }
                        }
                    }
                    else
                    {
                        ListTasks(taskList);
                        Console.WriteLine("The text you enter is not a number.\nPlease enter a corresponding to a listed task.");
                    }
                }


                foreach (Task task in taskList.ToArray())
                {
                    if (validInt == task.TaskNumber)
                    {
                        while (!isAnswerConfirmed)
                        {
                            Console.WriteLine("\n");
                            task.DispayTaskProperties();
                            Console.WriteLine("Are you sure you want to delete this task? (y/n)");

                            string confirmDeleteString = ReadAndReturnInput().ToLower();

                            if (confirmDeleteString == "y")
                            {

                                taskList.Remove(task);
                                ReNumberTasks(taskList);
                                isAnswerConfirmed = true;
                                Console.WriteLine("The Task has been deleted.\n");
                            }
                            else if (confirmDeleteString == "n")
                            {
                                isAnswerConfirmed = true;
                            }
                            else
                            {
                                Console.WriteLine("\n*****You entered an invalid response. Please try again.*****");
                            }
                        }

                    }
                }
            }
            else
            {
                Console.WriteLine("There are no tasks in the Task List");
            }
        }

        public static void MarkTaskComplete(List<Task> taskList)
        {
            if (taskList.ToArray().Length > 0)
            {
                ListTasks(taskList);
                Console.WriteLine("Enter in the Task Number that you would like to mark as complete:");

                // Get user's data so that it can be Validated to be a Num and then parsed
                string input = ReadAndReturnInput();
                int selectedTaskInt = 0;
                bool isStringParsed = false;
                bool isAnswerConfirmed = false;

                while (!isStringParsed)
                {
                    if (ValidateNumInput(input))
                    {
                        if (int.Parse(input) <= taskList.ToArray().Length)
                        {
                            selectedTaskInt = int.Parse(input);
                            isStringParsed = true;
                        }
                        else
                        {
                            if (taskList.ToArray().Length > 0)
                            {
                                Console.WriteLine($"\nThe number you entered is out of range. Please enter a number between 1 and {taskList.ToArray().Length}.");
                                input = ReadAndReturnInput();
                            }
                        }
                    }
                    else
                    {
                        ListTasks(taskList);
                        Console.WriteLine("The text you enter is not a number.\nPlease enter a corresponding to a listed task.");
                        input = ReadAndReturnInput();
                    }
                }

                foreach (Task task in taskList)
                {
                    if (task.TaskNumber == selectedTaskInt)
                    {
                        while (!isAnswerConfirmed)
                        {
                            Console.WriteLine("\n");
                            task.DispayTaskProperties();
                            Console.WriteLine("Are you sure you want to mark this task complete? (y/n)");

                            string confirmMarkTaskCompleted = ReadAndReturnInput().ToLower();

                            if (confirmMarkTaskCompleted == "y")
                            {
                                task.HasBeenCompleted = true;
                                task.HasBeenCompleted = true;
                                isAnswerConfirmed = true;
                                Console.WriteLine("The Task has been marked completed.\n");
                            }
                            else if (confirmMarkTaskCompleted == "n")
                            {
                                isAnswerConfirmed = true;
                            }
                            else
                            {
                                Console.WriteLine("\n*****You entered an invalid response. Please try again.*****");
                            }
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("There are no tasks in the Task List");
            }

        }
    }
}
