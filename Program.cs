using System;

namespace catus
{
    class Program
    {
        static void Ephemeral(Action action)
        {
            action();
        }

        private static Action _action;

        static void Persistent(Action action)
        {
            _action = action;
            action();
        }

        static void InnerScope()
        {
            var obj1 = new TrackedObject("Obj1");
            var obj2 = new TrackedObject("Obj2");

            Ephemeral(() => Console.WriteLine("{0} {1}", obj1.Name, obj2.Name));
            Persistent(() => Console.WriteLine(obj2.Name));
        }

        static void Main(string[] args)
        {
            InnerScope();

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            Console.ReadLine();
        }
    }
}
