using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TorontoMap
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var getter = new Models.Getter("foo");
            // var task = new Task(getter.Directions);

            // task.Start();
            // Console.WriteLine("Starting");
            // task.Wait(-1);
            // Console.WriteLine("Finished");

            getter.ReadFile();
            getter.Lines();
        }
    }
}
