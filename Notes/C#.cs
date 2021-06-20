using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace MadLady{
class Foo{
public void Bar()
{
    int[] arr = new int[] {0, 0};
    int[] arr1 = {1, 2, 3};
    int c, count, min, max;

    String str = String.Empty;
    c = str.IndexOf('x');
    str = str.Substring(0, 1);

    StringBuilder sb = new StringBuilder();
    sb.Append("x");
    sb.ToString();

    List<string> list = new List<string>();
    count = list.Count;
    list.Add("");
    list.Contains("");
    list.Reverse();
    list.ToArray();

    Dictionary<int, int> dict = new Dictionary<int, int>();
    dict.Add(0, 0);
    dict.Remove(0);
    count = dict.Count;
    foreach(KeyValuePair<int, int> kvp in dict){};
    bool b1 = dict.ContainsKey(0);
    bool b2 = dict.TryGetValue(0, out int val);

    OrderedDictionary odict = new OrderedDictionary();
    //odict.Add(obj, obj); //Only obj type allows :(

    SortedDictionary<string, string> sdict =
        new SortedDictionary<string, string>(
            StringComparer.CurrentCultureIgnoreCase
        );
    
    Queue<int> q = new Queue<int>();
    c = q.Count;
    q.Enqueue(0);
    c = q.Dequeue();
    c = q.Peek();
    q.TryPeek(out int val0);
    q.TryDequeue(out int val1);
    q.ToArray();

    Stack<int> s = new Stack<int>();
    c = s.Count;
    s.Push(0);
    c = s.Pop();
    c = s.Peek();
    s.TryPeek(out int val2);
    s.TryPop(out int val3);
    s.ToArray();

    SortedSet<int> ss = new SortedSet<int>();
    c = ss.Count;
    ss.Add(0);
    ss.Contains(0);
    min = ss.Min;
    max = ss.Max;

}
}

class Car{
    int year;

    Car()
    {
        year = DateTime.Now.Year;
    }

    class MyComparerClass : IComparer
    {
        int IComparer.Compare(object a, object b)
        {
            Car c1 = a as Car;
            Car c2 = b as Car;

            if (c1.year > c2.year)
                return 1;
            if (c1.year < c2.year)
                return -1;
            else
                return 0;
        }

        //public static IComparer MyComparer() {
        //    return (IComparer) new MyComparerClass();
        //}

    }

}

} //Namespace

