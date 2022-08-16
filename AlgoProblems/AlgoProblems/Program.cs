using AlgoProblems.SimpleLinkedList;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoProblems
{
    class Depreciation
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Tag { get; set; }
        public int Value { get; set; }
    }
    class Program
    {
        public static IEnumerable<Depreciation> depreciations => _depreciations;
        private static ISet<Depreciation> _depreciations = new HashSet<Depreciation>();
        static void Main(string[] args)
        {
            var list = new List<Depreciation> {
                new Depreciation { FirstName = "Ben", LastName = "Ede", Tag = "J", Value = 90 },
                new Depreciation { FirstName = "Ben", LastName = "Ede", Tag = "J", Value = 90 },
                new Depreciation { FirstName = "BenK", LastName = "EdeK", Tag = "K", Value = 90 },
                new Depreciation { FirstName = "BenK", LastName = "EdeK", Tag = "K", Value = 90 },
                new Depreciation { FirstName = "BenP", LastName = "EdeP", Tag = "P", Value = 90 },
                new Depreciation { FirstName = "BenP", LastName = "EdeP", Tag = "P", Value = 90 }
            };
            foreach (var item in list)
            {
                _depreciations.Add(item);
            }
            var items = _depreciations.Where(x => x.Tag == "K");

            foreach (var item in items)
            {
                _depreciations.Remove(item);
            }
            list.RemoveAll(x=>x.Tag=="K");


            foreach (var item in _depreciations)
            {
                Console.WriteLine(item.Tag);
            }

            Console.WriteLine("Hello World!");

            var myLinkedList = new MyLinkedList<String>();
            var testLinkedList = new TestLinkedList<String>();
            

            myLinkedList.AddFirst("One");
            myLinkedList.AddFirst("Two");
            myLinkedList.AddLast("LastAll");

            myLinkedList.AddFirst("Three");
            myLinkedList.AddLast("Last");


            testLinkedList.AddToTop("One");
            testLinkedList.AddLast("LastAll");
            testLinkedList.AddToTop("Two");
            testLinkedList.AddLast("last");

            var allNodes = myLinkedList.GetAll();
            var allTestNodes = testLinkedList.GetAll();

            foreach (var item in allNodes)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("==================================");

            foreach (var item in allTestNodes)
            {
                Console.WriteLine(item.ToString());
            }
        }
        public static void Reflection()
        {

        }
    }
}
