using System;
using System.Collections.Generic;
using System.Linq;

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

        // Marking task 1 as complete
        //todoList[0].IsComplete = true;
        //todoList.DisplayTasks();

        // Displaying completed tasks
        //todoList.DisplayCompletedTasks();

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

        Console.Writeline("type 1 to Add tasks, type 2 to mark task completed, type 3 to display all tasks, type 4 to display completed tasks, type 5 to quit -> break while loop\n");
        integer UserInput = Console.ReadLine ();
        if (UserInput = 1)
        {
            Console.WriteLine("enter task description");
        }

        else if (UserInput = 2)
        {
            Console.WriteLine("enter the task you want to mark as complete");
        }
        else if (UserInput = 3)
        {
            Console.WriteLine("All tasks displayed");
        }

        else if (UserInput = 4)
        {
            Console.WriteLine("Completed tasks displayed");
        }

        else if (UserInput = 5)
        {

        }
    }
}
