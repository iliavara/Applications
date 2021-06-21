using System;
using System.Collections.Generic;

namespace ConsoleApp6
{
    public class DataStructure<T>
    {
        public DataStructure()
        {
            Elements = new List<T>();
            ElementIndexes = new Dictionary<T, int>();
        }

        public IList<T> Elements { get; set; }

        public IDictionary<T, int> ElementIndexes { get; set; }

        public void Add(T element)
        {
            if (ElementIndexes.ContainsKey(element))
            {
                return;
            }

            Elements.Add(element);

            ElementIndexes.Add(element, Elements.Count - 1);
        }

        public void Add(params T[] elements)
        {
            if (elements != null)
            {
                foreach (var element in elements)
                {
                    Add(element);
                }
            }
        }

        public void Remove(T element)
        {
            if (ElementIndexes.TryGetValue(element, out int index))
            {
                Elements[index] = Elements[Elements.Count - 1];

                Elements.RemoveAt(Elements.Count - 1);

                ElementIndexes.Remove(element);

                ElementIndexes[Elements[index]] = index;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var datas = new DataStructure<int>();

            datas.Add(1, 4, 5, 3, 2);

            Console.WriteLine(string.Join(", ", datas.Elements));

            datas.Remove(1);

            Console.WriteLine(string.Join(", ", datas.Elements));
        }
    }
}