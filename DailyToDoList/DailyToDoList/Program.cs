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
        Task[] newlist = this.ToArray();
        for (int index = 0; index <newlist.Length;index++)
        {
            
            string taskCompeted = " ";
            if (newlist[index].IsComplete)
            {
                taskCompeted = "X";
            }
            Console.WriteLine("index={0} {1} [{2}]",index, newlist[index].Description, taskCompeted);
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
    public void ErrorLogging(Exception ex)
    {
        string strPath = @"\Log.txt";
        if (!File.Exists(strPath))
        {
            File.Create(strPath).Dispose();
        }
        using (StreamWriter sw = File.AppendText(strPath))
        {
            sw.WriteLine("=============Error Logging ===========");
            sw.WriteLine("===========Start============= " + DateTime.Now);
            sw.WriteLine("Error Message: " + ex.Message);
            sw.WriteLine("Stack Trace: " + ex.StackTrace);
            sw.WriteLine("===========End============= " + DateTime.Now);

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

     

        while ( true) 
      
        
        {
            Console.WriteLine("type 1 to Add tasks, type 2 to mark task completed, type 3 to display all tasks, type 4 to display completed tasks, type 5 to quit \n");
            string UserInput = Console.ReadLine();
            int parsedInput = 0;
            try
            {
                parsedInput = int.Parse(UserInput);
            }
            catch(Exception error)
            {
                //write to file
                todoList.ErrorLogging(error);

            }
            if (parsedInput == 1)
            {
                Console.WriteLine("enter task description");
                string NextTask = Console.ReadLine();
                Task task4 = new Task { Description = NextTask, IsComplete = false };
                todoList.AddTask(task4);
                Console.WriteLine("Task added.");
                
            }

            else if (parsedInput == 2)
            {
                todoList.DisplayTasks();
                Console.WriteLine("Enter the index of task you want to mark as complete");
                var indexInput = Console.ReadLine();
                int parsedindexInput = int.Parse(indexInput);
                todoList[parsedindexInput].IsComplete = true;
               
            }

            else if (parsedInput == 3)
        {
                Console.WriteLine("All tasks displayed");
                todoList.DisplayTasks();
        }

            else if (parsedInput == 4)
            {

                todoList.DisplayCompletedTasks();
            }

            else if (parsedInput == 5)
            {
                Console.WriteLine("Exiting the while loop");
                break;

            }

          

        }
       
        }
}