using System;
using System.Collections.Generic;
using System.Linq;
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

            /* var outer = Task.Factory.StartNew(() =>
             {
                 Console.WriteLine("Outer task is starting....");

                 var inner = Task.Factory.StartNew(() => {
                     Console.WriteLine("Inner task is starting....");
                     Thread.Sleep(1000);
                     Console.WriteLine("Inner task is ended....");
                 },TaskCreationOptions.AttachedToParent);
             });
             outer.Wait();
             Console.WriteLine("End of Main");*/

            /*  Task[] task = new Task[4]
              {
                  new Task(()=>Console.WriteLine("Task 1")),
                  new Task(()=>Console.WriteLine("Task 2")),
                  new Task(()=>Console.WriteLine("Task 3")),
                  new Task(()=>Console.WriteLine("Task 4"))
              };*/

            /* foreach(var t in task){
                 t.Start();
             }*/

            /*  int j = 1;
  *//*
              for(int i = 0; i<task.Length; i++)
              {
                  task[i] = Task.Factory.StartNew(() => Console.WriteLine($"Task{i+1}"));
              }*/



            /* Task[] task = new Task[3];


             for (int i = 0; i < task.Length; i++)
             {
                 int j = i;
                 *//*  j = i;*//*
                 task[i] = new Task(() => {
                     Thread.Sleep(1000);
                     Console.WriteLine($"Task{j} is finished");
                 } );

                 task[i].Start();

             }

             Console.WriteLine("Finish Main");

             Task.WaitAny(task);*/

            /*  int a = 1;
              int b = 2;

              Task<int> sum = new Task<int>(() => Sum(a, b));

              sum.Start();

              int c = sum.Result;

              Console.WriteLine($"{a}+{b}={c}");
  */

            /*  Task<Person> personTask = new Task<Person>(() => new Person("Aisulu Orynbayeva", 18));

              personTask.Start();

              Person person = personTask.Result;

              Console.WriteLine($"Fullname: {person.name}, Age: {person.age}");*/


            /* Task task = new Task(() => Console.WriteLine($"Id task: {Task.CurrentId}"));

             Task task2 = task.ContinueWith(PrintTasks);

             task.Start();

             task2.Wait();

             Console.WriteLine($"End of Main");*/


            /*  int a = 4;
              int b = 5;

              Task<int> task = new Task<int>(() => Sum(a, b));

              Task task2 = task.ContinueWith(task => Print(task.Result));

              task.Start();

              task2.Wait();

              Console.WriteLine($"End of Main");*/

            /*
             *  Continuation TAsk
             * Task task = new Task(() => Console.WriteLine($"Current task:{Task.CurrentId}"));

              Task task2 = task.ContinueWith(t => Console.WriteLine($"Current task:{Task.CurrentId} Previous task:{t.Id}"));

              Task task3 = task2.ContinueWith(t => Console.WriteLine($"Current task:{Task.CurrentId} Previous task:{t.Id}"));

              Task task4 = task3.ContinueWith(t => Console.WriteLine($"Current task:{Task.CurrentId} Previous task:{t.Id}"));


              task.Start();

              task4.Wait();*/


            /* Parallel.Invoke(
             Print, 
               () =>
               {
                   Console.WriteLine($"Current ID = {Task.CurrentId}");
                   Thread.Sleep(2000);

               },
               () => Square(100)
               );
*/

            /* Parallel.For(1,5,Square);*/
            /*  ParallelLoopResult result = Parallel.ForEach<int>(
                  new List<int>() { 1, 2, 3, 4, 5, 5, 6, 7, 8, 9 },
                  Square
                  );*/


            /* ParallelLoopResult result = Parallel.For(1, 10, Square);

             if (!result.IsCompleted)
             {
                 Console.WriteLine($"Executing loop is finished: {result.LowestBreakIteration}");
             }*/


            /* 
             *  Без исключении
             * 
             * CancellationTokenSource cancellationToken = new CancellationTokenSource();
             CancellationToken token = cancellationToken.Token;

             Task task = new Task(() =>
             {
                 for(int i =0; i< 10; i++)
                 {
                     if (token.IsCancellationRequested)
                     {
                         Console.WriteLine("Operation interrupted");
                         return;
                     }
                     Console.WriteLine($"Square  of {i} equal to {i*i}");
                 }

             }, token);

             task.Start();

             Thread.Sleep(1000);

             cancellationToken.Cancel();

             Thread.Sleep(1000);

             Console.WriteLine($"Task status: {task.Status}");

             cancellationToken.Dispose();*/
            /*
                        CancellationTokenSource cancellationToken = new CancellationTokenSource();
                        CancellationToken token = cancellationToken.Token;

                        Task task = new Task(() => 
                        {
                            int i = 1;
                            token.Register(() =>
                            {
                                Console.WriteLine("Operation finished");
                                i = 10;
                            });
                            for (; i < 10; i++)
                            {   
                                Console.WriteLine($"Square of {i} equal to {i * i}");
                                Thread.Sleep(200);
                            }

                            *//*PrintCancel(token);*//*
                        }, token);

                        task.Start();

                        cancellationToken.Cancel();

                        Thread.Sleep(100);*/


            /*try
            {
                task.Start();
                Thread.Sleep(1000);
                cancellationToken.Cancel();
                task.Wait();
            }
            catch (AggregateException ae)
            {
                foreach (Exception e in ae.InnerExceptions)
                {
                    if (e is TaskCanceledException)
                    {
                        Console.WriteLine("Operation finished");
                    }
                    else
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }

            finally {
                cancellationToken.Dispose();
            }
            
            Console.WriteLine($"Task Status {task.Status}");

            cancellationToken.Dispose();
            
             */
            /*

                        CancellationTokenSource cancellationToken = new CancellationTokenSource();
                        CancellationToken token = cancellationToken.Token;


                        new Task(() =>
                        {
                            Thread.Sleep(400);
                            cancellationToken.Cancel();
                        }).Start();

                        try {
                            //Parallel.ForEach<int>(new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, new ParallelOptions { CancellationToken = token }, Square);
                            Parallel.For(1, 9, new ParallelOptions { CancellationToken = token }, Square);
                        }
                        catch (OperationCanceledException)
                        {
                            Console.WriteLine("Operation finished");
                        }
                        finally
                        {
                            cancellationToken.Dispose();
                        }*/

            /*--------------------------------------------------------------------------------------*/
            /* PLINQ - Parallel language integrated query*/

            /*int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9};

            *//*var square = numbers.AsParallel().AsOrdered().Select(x => Square(x));*//*
            var square = from n in numbers.AsParallel() orderby n select Square(n);

            var query = from n in square.AsUnordered() where n > 5 select n;
            *//*numbers.AsParallel().Select(x => Square(x)).ForAll(Console.WriteLine);*/

            /*  (from n in numbers.AsParallel() select Square(n)).ForAll(Console.WriteLine);*//*

            foreach (var n in query)
            {
                Console.WriteLine(n);
            }*/

            CancellationTokenSource cancellationToken = new CancellationTokenSource();
            CancellationToken token = cancellationToken.Token;

            new Task(() =>
            {
                Thread.Sleep(400);
                cancellationToken.Cancel();
            }).Start();

            


            try
            {
                int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9};
                var square = from n in numbers.AsParallel().WithCancellation(cancellationToken.Token) select Square(n);
                square.ForAll(n=>Console.WriteLine(n));
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Operation finished");
            }
            catch (AggregateException ex)
            {
                if (ex.InnerExceptions != null) {

                    foreach (Exception e in ex.InnerExceptions)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            
            }
               

            finally
            {
                cancellationToken.Dispose();
            }

            
        }

        static int Square(int n)
        {
            /*Thread.Sleep(400);*/
            /*  Console.WriteLine($"Square of {n} = {n * n}");*/

            int result = n * n;
            Console.WriteLine($"Square of {n} = {result}");
            Thread.Sleep(1000);
            return result;
        }


        /*static void PrintCancel(CancellationToken token)
        {
            for (int i = 1; i < 10; i++)
            {
                if (token.IsCancellationRequested)
                {
                    token.ThrowIfCancellationRequested();
                }
                Console.WriteLine($"Square of {i} equal to {i * i}");
                Thread.Sleep(200);
            }

        } */



        /*   static void Print()
           {
               Console.WriteLine($"Current ID = {Task.CurrentId}");
               Thread.Sleep(2000);
           }*/

        /* static void Square(int n, ParallelLoopState pls)
         {
             if (n == 7)
             {
                 pls.Break();
             }
             Console.WriteLine($"Square = {n * n}");
             Thread.Sleep(2000);
         }
 */

        /*  static void PrintTasks(Task t)
          {
              Console.WriteLine($"Id task: {Task.CurrentId}");
              Console.WriteLine($"Id previous task: {t.Id}");
              Thread.Sleep(2000);
          }*/

        /* static int Sum(int a, int b) => a + b;
         static void Print (int sum) => Console.WriteLine($"Sum: {sum}");*/

    }

   
}

