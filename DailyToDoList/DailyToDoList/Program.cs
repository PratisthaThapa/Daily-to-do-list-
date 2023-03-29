using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

class Task
{
    public string Description { get; set; }
    public bool IsComplete { get; set; }
}
class TodoList : List<Task>
{
    public void AddTask(Task task)
    {
        this.Add(task);
    }

    public void DisplayTasks()
    {
        Console.WriteLine("\n Printing all tasks:");

        foreach (Task task in this)
        {
            string taskCompeted = " ";
            if (task.IsComplete)
            {
                taskCompeted = "X";
            }

            Console.WriteLine("{0} [{1}]", task.Description, taskCompeted);
        }
    }

    public void DisplayCompletedTasks()
    {
        var completedTasks = from task in this
                             where task.IsComplete == true
                             select task;
        Console.WriteLine("\nPrinting completed tasks:");

        foreach (Task task in completedTasks)
        {

            Console.WriteLine("{0} [{1}]", task.Description, task.IsComplete ? "X" : " ");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        TodoList todoList = new TodoList();

        // Adding tasks to the list
        Task task1 = new Task { Description = "Meeting", IsComplete = false };
        Task task2 = new Task { Description = "Work out", IsComplete = true };
        Task task3 = new Task { Description = "Finish project", IsComplete = false };
        todoList.AddTask(task1);
        todoList.AddTask(task2);
        todoList.AddTask(task3);

        List<string> completedTasks = new List<string>();
        todoList[0].IsComplete = true;

        //in a while loop
        //print type 1 to Add tasks, type 2 to mark task completed, type 3 to display all tasks, type 4 to display completed tasks, type 5 to quit -> break while loop
        //if 1
        //print enter task description
        //take user's input         Console.ReadLine();
        // mark isComplete = false
        // add the task to todoList
        //if 2
        //ask user for description of which task to mark complete
        // lowercase user's input and task descriptions from todoList and see if they match
        //if match
        //mark task IsComplete = true

        Console.WriteLine("type 1 to Add tasks, type 2 to mark task completed, type 3 to display all tasks, type 4 to display completed tasks, type 5 to quit \n");
        string UserInput = Console.ReadLine();
        int parsedInput = int.Parse(UserInput);

        while (parsedInput < 6)
        {

            if (parsedInput == 1)
            {
                Console.WriteLine("enter task description");
                string FourthTask = Console.ReadLine();
                Task task4 = new Task { Description = FourthTask, IsComplete = false };
                todoList.AddTask(task4);
                Console.WriteLine("Task added.");
                break;
            }

            else if (parsedInput == 2)
            {
                //    Console.WriteLine("Enter the index of task you want to mark as complete");
                //    Console.ReadLine();
                //    todoList.DisplayTasks();
                //    todoList[4].IsComplete = true;
                //    break;
                //}
                //Console.WriteLine("Enter index of task to mark as completed:");
                //int taskIndex = int.Parse(Console.ReadLine());
                //if (taskIndex >= 0 && taskIndex < todoList.Count)
                //{
                //    // Mark task as completed and move it to the completedTasks list
                //    string completedTask = todoList(taskIndex);
                //    todoList.RemoveAt(taskIndex);
                //    completedTasks.Add(completedTask);
                //    Console.WriteLine("Task marked as completed.");
                //}

            }

            else if (parsedInput == 3)
            {
                Console.WriteLine("All tasks displayed");
                todoList.DisplayTasks();
                break;
            }

            else if (parsedInput == 4)
            {
                Console.WriteLine("Completed tasks displayed");
                todoList.DisplayCompletedTasks();
                break;
            }

            else if (parsedInput == 5)
            {
                break;
            }

            else
            {
                Console.WriteLine("Invalid input.");
                break;
            }
            
            }
       
        }
}