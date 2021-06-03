using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
class Foo{
public void Bar(){
    int[] arr = new int[] {0, 0};
    int[] arr1 = {1, 2, 3};
    int c, count;

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
    SortedDictionary<int, int> sdict = new SortedDictionary<int, int>();
    dict.Add(0, 0);
    dict.Remove(0);
    count = dict.Count;
    foreach(KeyValuePair<int, int> kvp in dict){};
    bool b1 = dict.ContainsKey(0);
    bool b2 = dict.TryGetValue(0, out int val);

    Queue<int> q = new Queue<int>();
    c = q.Count;
    q.Enqueue(0);
    c = q.Dequeue();
    c = q.Peek();
    q.TryPeek(out int val1);
    q.TryDequeue(out int val2);
    q.ToArray();

    Stack<int> s = new Stack<int>();
    c = s.Count;
    s.Push(0);
    c = s.Pop();
    c = s.Peek();
    s.TryPeek(out int val3);
    s.TryPop(out int val4);
    s.ToArray();

    SortedSet<int> ss = new SortedSet<int>();
    c = ss.Count;
    ss.Add(0);
    ss.Contains(0);


}
}