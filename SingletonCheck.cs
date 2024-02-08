using Design_Patterns;
using System;

DatabaseManager? instanceT1 = null;
DatabaseManager? instanceT2 = null;

// Initialize two threads and print their instances
Thread t1 = new Thread(() =>
{
    instanceT1 = DatabaseManager.Instance;
    Console.WriteLine($"Instance obtained by Thread 1: {instanceT1}");
});

Thread t2 = new Thread(() =>
{
    instanceT2 = DatabaseManager.Instance;
    Console.WriteLine($"Instance obtained by Thread 2: {instanceT2}");
});

// Start threads and pause the execution of the main thread until t1 and t2 completes it's execution
t1.Start();
t2.Start();

t1.Join();
t2.Join();

// Comparing instances obtained by each thread
if (ReferenceEquals(instanceT1, instanceT2))
{
    Console.WriteLine("Both threads obtained the same instance. Singleton pattern confirmed.");
}
else
{
    Console.WriteLine("Instances obtained by threads are different.");
}

Console.WriteLine("Threads completed.");