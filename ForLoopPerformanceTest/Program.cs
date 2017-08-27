using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForLoopPerformanceTest
{
    class Program
    {
        static List<Person> _people = new List<Person>();
        static void Main(string[] args)
        {
            StartTest();
        }
        static void StartTest()
        {
            for(int i = 0; i <= 1000000; i++)
            {
                Person person = new Person();
                person.Name = string.Format("Anderson {0}", i);
                person.Age = DateTime.Now;
                _people.Add(person);
            }
            IterateForOnList();
            IterateForeachOnList();
        }
        static void IterateForOnList()
        {
            Stopwatch watch = Stopwatch.StartNew();
            for(int i = 0; i < _people.Count; i++)
            {
                //var person = _people[i];
                _people[i].Name = string.Format("John {0}", _people[i].GetHashCode());
                _people[i].Age = DateTime.Now;
            }
            watch.Stop();
            Console.WriteLine(string.Format("For on list (ms): {0}", watch.ElapsedMilliseconds.ToString()));
        }

        static void IterateForeachOnList()
        {
            Stopwatch watch = Stopwatch.StartNew();
            foreach(var person in _people)
            {
                person.Name = string.Format("John {0}", person.GetHashCode());
                person.Age = DateTime.Now;
            }
            watch.Stop();
            Console.WriteLine(string.Format("Foreach on list (ms): {0}", watch.ElapsedMilliseconds.ToString()));
        }
    }

    class Person
    {
        public string Name { get; set; }
        public DateTime Age { get; set; }
    }
}
