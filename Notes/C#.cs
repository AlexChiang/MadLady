using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
class Foo{
public void Bar(){
    int[] arr = new int[] {0, 0};
    int[] arr1 = {1, 2, 3};

    StringBuilder sb = new StringBuilder();
    sb.Append("x");
    sb.ToString();

    Dictionary<int, int> dict = new Dictionary<int, int>();
    dict.Add(0, 0);
    dict.Remove(0);
    bool b1 = dict.ContainsKey(0);
    bool b2 = dict.TryGetValue(0, out int val);
}
}