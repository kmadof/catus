using System;

namespace catus
{
    public  class TrackedObject
    {
        public string Name { get; }

        public TrackedObject(string name)
        {
            Name = name;
        }

        ~TrackedObject() => Console.WriteLine("Finalizing " + Name);
    }    
}