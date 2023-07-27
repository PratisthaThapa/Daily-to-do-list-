using System;
using System.Collections.Generic;
using System.IO;

//  Generic Class
public class TodoItem<T>
{
    public T Id { get; set; }
    public string Task { get; set; }
    public bool IsCompleted { get; set; }
}
public class TodoList
{
    //  List to store the todo items
    private List<TodoItem<int>> todos;
    private string logFilePath;

    public TodoList(string logFilePath)
    {
        todos = new List<TodoItem<int>>();
        this.logFilePath = logFilePath;
    }

    // Add a todo item to the list
    public void AddTodoItem(int id, string task)
    {
        // SRP - Creating a separate function to validate input
        if (string.IsNullOrEmpty(task))
        {
            LogEvent($"Invalid task: '{task}'");
            return;
        }

        // OCP - Adding a new feature without changing existing code
        var todoItem = new TodoItem<int> { Id = id, Task = task, IsCompleted = false };
        todos.Add(todoItem);
    }

    // Mark a todo item as completed
    public void MarkAsCompleted(int id)
    {
        var todoItem = todos.Find(item => item.Id == id);
        if (todoItem == null)
        {
            LogEvent($"Invalid ID: '{id}'");
            return;
        }

        todoItem.IsCompleted = true;
    }

    // Retrieve all todo items
    public List<TodoItem<int>> GetAllTodoItems()
    {
        return todos;
    }

    //  Implementing log
    private void LogEvent(string message)
    {
        try
        {
            using (var writer = new StreamWriter(logFilePath, true))
            {
                writer.WriteLine($"{DateTime.Now}: {message}");
            }
        }
        catch (Exception ex)
        {
            // In case of any error while logging, print to console
            Console.WriteLine($"Error while writing to log: {ex.Message}");
        }
    }
}

//  Making the application an API
public class TodoListAPI
{
    private TodoList todoList;

    public TodoListAPI(string logFilePath)
    {
        todoList = new TodoList(logFilePath);
    }

    // Add a todo item
    public void AddTodoItem(int id, string task)
    {
        todoList.AddTodoItem(id, task);
    }

    // Mark a todo item as completed
    public void MarkAsCompleted(int id)
    {
        todoList.MarkAsCompleted(id);
    }

    // Retrieve all todo items
    public List<TodoItem<int>> GetAllTodoItems()
    {
        return todoList.GetAllTodoItems();
    }

    // Get the next available ID for a new task
    public int GetNextId()
    {
        return todoList.GetAllTodoItems().Count + 1;
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to Daily To-Do List!");
        var api = new TodoListAPI("log.txt");

        while (true)
        {
            Console.Write("Enter task (or 'exit' to quit): ");
            var task = Console.ReadLine();

            if (task.ToLower() == "exit")
                break;

            api.AddTodoItem(api.GetNextId(), task);
        }

