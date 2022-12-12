using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * 1 example
             * 
             * Task task1 = new Task(() => Console.WriteLine("first task"));

            task1.Start();

            Task task2 = Task.Run(() => Console.WriteLine("second task"));
            Task task3 = Task.Factory.StartNew(()=> Console.WriteLine("third task"));

            task1.Wait();
            task2.Wait();
            task3.Wait();*/

            /*
             * Example 2
             * 
             * Console.WriteLine("Main Start");

              Task task = new Task(() => {
                  Console.WriteLine("Task Start");
                  Thread.Sleep(1000);    
                  Console.WriteLine("Task End");
              } );

              *//*  task.Start();*//*

              task.RunSynchronously();
              Console.WriteLine("Main End");

              *//*     task.Wait();*/


           /*
            * Example 3 
            * 
            * Task task = new Task(() => {
                Console.WriteLine($"Task {Task.CurrentId} Start");
                Thread.Sleep(1000);
                Console.WriteLine($"Task {Task.CurrentId} End");
            });
            task.Start();



            Console.WriteLine($"task ID:{task.Id} ");
            Console.WriteLine($"task is Compleated: {task.IsCompleted}");
            Console.WriteLine($"task status:  {task.Status} ");


            task.Wait();
*/

            var outer = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Outer task is starting....");

                var inner = Task.Factory.StartNew(() => {
                    Console.WriteLine("Inner task is starting....");
                    Thread.Sleep(1000);
                    Console.WriteLine("Inner task is ended....");
                },TaskCreationOptions.AttachedToParent);
            });
            outer.Wait();
            Console.WriteLine("End of Main");
            
        }
    }
}