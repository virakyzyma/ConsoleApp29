using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        PrintQueue printQueue = new PrintQueue();

        printQueue.EnqueueDocument("Документ 1", Priority.Medium);
        printQueue.EnqueueDocument("Документ 2", Priority.High);
        printQueue.EnqueueDocument("Документ 3", Priority.Low);

        Console.WriteLine($"Есть ли документы в очереди: {printQueue.HasDocuments()}");

        string nextDocument = printQueue.DequeueDocument();
        Console.WriteLine($"Документ для печати: {nextDocument}");

        Console.WriteLine($"Есть ли документы в очереди: {printQueue.HasDocuments()}");
    }
}

public enum Priority
{
    Low,
    Medium,
    High
}

public class PrintQueue
{
    private Queue<(string Document, Priority Priority)> queue = new Queue<(string, Priority)>();
    public void EnqueueDocument(string document, Priority priority)
    {
        queue.Enqueue((document, priority));
    }    
    public string DequeueDocument()
    {
        if (queue.Any())
        {
            var document = queue.OrderBy(x => x.Priority).First();
            queue = new Queue<(string, Priority)>(queue.Where(x => x != document));
            return document.Document;
        }
        else
        {
            return null;
        }
    }
    public bool HasDocuments()
    {
        return queue.Any();
    }
}