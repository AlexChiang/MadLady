using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MadLady
{
    public class TwoSums : IMadLady
    {
        private int[] Resolution(int[] input, int target)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();

            foreach (int i in input){
                if(dict.TryGetValue(i, out int comp) &&
                    comp == (target-i))
                {
                    return new int[] {i, comp};
                }
                else
                {
                    dict.Add(i, target-i);
                }
            }

            return new int []{};
        }

        public void Run(){
            int[] arr = new int[] {2, 7, 11, 2};
            int[] idx = Resolution(arr, 9);
            Console.WriteLine(String.Format("Answer: {0} and {1}", idx[0], idx[1]));
        }
    }

    public class ReverseInteger : IMadLady
    {

        private int Reverse(int input)
        {
            Boolean neg = false;
            int output = 0;
            if(input < 0)
            {
                neg = true;
                input = 0 - input;
            }

            while(input > 0)
            {
                output = (output * 10) + (input % 10);
                input = input / 10;
            }

            if(neg)
            {
                output = 0 - output;
            }

            return output;
        }

        public void Run(){
            int num = Reverse(-12345);
            Console.WriteLine(String.Format("{0}",num));
        }
    }

    public class Palindrome : IMadLady
    {
        private Boolean Check(int input){

            string inputStr = input.ToString();
            int start = 0;
            int end = inputStr.Length - 1;

            while (start < end)
            {
                if(inputStr[start] == inputStr[end])
                {
                    return true;
                }
                start++;
                end--;
            }

            return false;
        }

        public void Run()
        {
            int input = 123454321;

            Console.Write(String.Format("{0} is{1} a Palindrome.\n", input, (Check(input) ? "" : " not" )));

            input = 876543;
            Console.Write(String.Format("{0} is{1} a Palindrome.\n", input, (Check(input) ? "" : " not" )));

        }
    }

    public class RomanToInt : IMadLady
    {
        /*
        Symbol       Value
        I             1
        V             5
        X             10
        L             50
        C             100
        D             500
        M             1000

        IV  4
        IX  9
        XL  40
        XC  90
        CD  400
        CM  900

        */

        private int LookUp(char c)
        {
            if(c == 'I') return 1;
            if(c == 'V') return 5;
            if(c == 'X') return 10;
            if(c == 'L') return 50;
            if(c == 'C') return 100;
            if(c == 'D') return 500;
            if(c == 'M') return 1000;

            return -1;
        }
        
        private int Convert(string input)
        {
            int output = 0;
            int valCur = 0;
            int valNext = 0;

            for(int i=0; i<input.Length; i++)
            {
                valCur = LookUp(input[i]);
                valNext = (i < input.Length-1) ? LookUp(input[i+1]) : 0;

                if (valCur >= valNext)
                {
                    output += valCur;
                }
                else
                {
                    output += (valNext - valCur);
                    i++;
                }
            }
            
            return output;
        }

        public void Run()
        {
            string roman = "XXVIII";
            int integer;
            
            integer = Convert(roman);
            Console.Write(String.Format("{0}: {1}\n", roman, integer));

            roman = "LVIII";
            integer = Convert(roman);
            Console.Write(String.Format("{0}: {1}\n", roman, integer));

            roman = "MCMXCIV";
            integer = Convert(roman);
            Console.Write(String.Format("{0}: {1}\n", roman, integer));

        }

    }

    public class LongestCommonPrefix : IMadLady
    {
        private string FindHorizonal(string[] input)
        {
            string prefix = String.Empty;
            if (null == input || 0 == input.Length) return prefix;

            prefix = input[0];
            for(int i=1; i<input.Length; i++)
            {
                while(input[i].IndexOf(prefix) != 0)
                {
                    prefix = prefix.Substring(0, prefix.Length - 1);
                }

                if(String.IsNullOrEmpty(prefix)) return String.Empty;
            }

            return prefix;
        }

        private string FindVertical(string[] input)
        {
            if(null == input || 0 == input.Length) return String.Empty;
            
            char c;
            for(int i=0; i<input[0].Length; i++)
            {
                c = input[0][i];
                for(int j=1; j<input.Length; j++)
                {
                    if(c != input[j][i] || i == input[j].Length)
                    {
                        return input[0].Substring(0, i);
                    }
                }
            }

            return String.Empty;
        }

        public void Run()
        {
            string[] list1 = new string[] {"flower", "flow", "flight"};
            string[] list2 = new string[] {"dog", "racecar", "car"};
            string commonPrefix1 = String.Empty;
            string commonPrefix2 = String.Empty;

            commonPrefix1 = FindHorizonal(list1);
            commonPrefix2 = FindHorizonal(list2);
            Console.Write(String.Format("List 1: {0}\nList 2: {1}\n", commonPrefix1, commonPrefix2));

        }
    }

    public class ValidParentheses : IMadLady
    {

        private bool Validate(string input)
        {
            Dictionary<char, char> dict = new Dictionary<char, char>();
            dict.Add(')', '(');
            dict.Add(']', '[');
            dict.Add('}', '{');

            char c;

            Stack<char> s = new Stack<char>();
            for(int i=0; i<input.Length; i++)
            {
                c = input[i];
                if(dict.ContainsKey(c))
                {
                    char c1 = s.Pop();
                    if(dict[c] != c1) return false;
                }
                else
                {
                    s.Push(c);
                }
            }

            if(0 < s.Count) return false;

            return true;
        }

        public void Run()
        {
            string str1 = "()[{}]";
            string str2 = "([)]";
            
            Console.Write(String.Format("{0} is {1}valid", str1, Validate(str1)? String.Empty : "not "));
            Console.Write("\n");

            Console.Write(String.Format("{0} is {1}valid", str2, Validate(str2)? String.Empty : "not "));
            Console.Write("\n");
        }
    }

    public class MergeSortedArray : IMadLady
    {

        private void Merge(ref int[] x, ref int[] y)
        {
            int c;
            int y0;

            for(int i=0; i<x.Length; i++)
            {
                if(y[0] < x[i])
                {
                    //Swap
                    c = x[i];
                    x[i] = y[0];
                    y[0] = c;

                    //re-sort y
                    y0 = y[0];
                    int j;

                    for(j=1; j<y.Length && y[j] < y0; j++)
                    {
                        y[j-1] = y[j];
                    }
                    
                    y[j-1] = y0;
                }
            }

        }

        public void Run()
        {
            int[] x = new int[] {1, 4, 7, 8, 10};
            int[] y = new int[] {2, 3, 9};

            Merge(ref x, ref y);

            Console.Write("X: {0}\n",string.Join(", ", x));
            Console.Write("Y: {0}\n",string.Join(", ", y));
        }

    }

    public class RemoveDupsInArray : IMadLady
    {

        private int Dedupe(ref int[] input)
        {        
            if(0 == input.Length) return 0;
            
            int start = 0;
            int end = 1;

            while(end < input.Length)
            {
                while(input[start] == input[end])
                {
                    end++;
                }
                input[++start] = input[end++];
            }

            Array.Resize<int>(ref input, start+1);

            return start+1;
        }
        public void Run()
        {
            int[] arr = new int[] {0,0,1,1,1,2,2,3,4,5,5,6,7};

            int newCount = Dedupe(ref arr);
            Console.Write("{0}: {1}\n", newCount, string.Join(", ", arr));
        
        }
    }

    public class RemoveElement : IMadLady
    {
        private int Remove(ref int[] input, int val)
        {
            int start = 0;

            for(int end = 0; end < input.Length; end++)
            {
                if(input[end] != val)
                {
                    input[start] = input[end];
                    start++;
                }

            }

            Array.Resize<int>(ref input, start);
            return start;
        }

        public void Run()
        {
            int[] arr = new int[] {2,1,2,2,3,0,4,2,3};
            int element = 2;
            
            int newCount = Remove(ref arr, element);
            Console.Write("{0}: {1}\n", newCount, string.Join(", ", arr));      
        }
    }

    public class StrStr : IMadLady
    {
        private int Match(string source, string target)
        {
            if(source == null || target == null) return -1;
            if(source.Length < target.Length) return -1;

            for(int i=0; i <= (source.Length - target.Length); i++)
            {
                int j;
                for(j=0; j < target.Length; j++)
                {
                    if(source[i+j] != target[j]) break;
                }

                if(j == target.Length) return i;          
            }

            return -1;
        }

        public void Run()
        {
            string source = "Delight";
            string target = "light";

            int idx = Match(source, target);
            Console.Write("{0}: \"{1}\" | \"{2}\"\n", idx, source, target);
        }
    }

    public class SearchInsertPosition : IMadLady
    {
        private int Search(int[] input, int target)
        {
            for(int i=0; i< input.Length; i++)
            {
                if(input[i] > target)
                {
                    return (input[i] == target) ? (i-1) : i;
                }
            }
            
            return 0;
        }

        public void Run()
        {
            int[] arr = new int[] {1,3,5,6};
            int target;
            int idx;
            
            target = 5;
            idx = Search(arr, target);
            Console.Write("{0}: \"{1}\" | \"{2}\"\n", idx, String.Join<int>(",", arr), target);
            
            target = 1;
            idx = Search(arr, target);
            Console.Write("{0}: \"{1}\" | \"{2}\"\n", idx, String.Join<int>(",", arr), target);
            
            target = 4;
            idx = Search(arr, target);
            Console.Write("{0}: \"{1}\" | \"{2}\"\n", idx, String.Join<int>(",", arr), target);
            
            target = 0;
            idx = Search(arr, target);
            Console.Write("{0}: \"{1}\" | \"{2}\"\n", idx, String.Join<int>(",", arr), target);
            
        }
    }

    public class SemaphoreDemo: IMadLady
    {
        public class Printer
        {
            public void Print(int docNumber)
            {
                Console.Write(String.Format("Printing document: {0}\n", docNumber));
                Thread.Sleep(1000);
            }
        }
        public void Run()
        {
            Printer printer = new Printer();
            Semaphore s = new Semaphore(3, 3, "Printer App");
            for(int i=0; i<20; ++i)
            {
                int j = i;
                Task.Factory.StartNew(() =>
                    {
                        s.WaitOne();
                        printer.Print(j);
                        s.Release();
                    }
                );
            }
        }
    }

    class ActionAndFunc : IMadLady
    {
        private void DoSomething(int i)
        {
            Console.Write(String.Format("Dosomething: {0}\n",i));
        }

        private double CalcSomething(int i)
        {
            return i/2;
        }
        public void Run()
        {
            Action<int> myAction = new Action<int>(DoSomething);
            myAction (123);

            Func<int, double> myFunc = new Func<int, double>(CalcSomething);
            Console.Write("CalcSomething: " + myFunc(10) + "\n");
        }
    }

    public class SemaphoreDemo2 : IMadLady
    {
        private int n;
        Action PrintFoo = new Action(() => Console.Write("Foo"));
        Action PrintBar = new Action(() => Console.Write("Bar"));
        Semaphore s_foo;
        Semaphore s_bar;
        
        private void Foo(Action printFoo)
        {
            s_foo.WaitOne();
            for(int i=0; i<n; i++)
            {
                printFoo();
            }
            s_bar.Release();
            
        }

        private void Bar(Action printBar)
        {
            s_bar.WaitOne();
            for(int i=0; i<n; i++)
            {
                printBar();
            }
            s_foo.Release();
        }

        public void Run()
        {
            this.n = 10;
            s_foo = new Semaphore(1, 1);
            s_bar = new Semaphore(0, 1);
            Task.Run(() => Foo(PrintFoo));
            Task.Run(() => Bar(PrintBar));
        }
    }

    public class ZeroEvenOdd : IMadLady
    {
        int number;
        Semaphore sZero;
        Semaphore sEven;
        Semaphore sOdd;

        Action<int> PrintNumber = new Action<int> ((x) => Console.Write(x));
        
        public void Run()
        {
            this.number = 10;
            sZero = new Semaphore(1, 1);
            sEven = new Semaphore(0, 1);
            sOdd = new Semaphore(0, 1);

        }
        public void Zero(Action<int> printNumber)
        {
            for(int i=0; i< number; i++)
            {
                sZero.WaitOne();
                printNumber(0);
                if(i%2 == 0)
                    sOdd.Release();
                else
                    sEven.Release();
            }
        }

        public void Even(Action<int> printNumber)
        {
            for(int i=2; i< number; i=i+2)
            {
                sEven.WaitOne();
                printNumber(i);
                sZero.Release();
            }
        }

        public void Odd(Action<int> printNumber)
        {
            for(int i=1; i< number; i=i+2)
            {
                sOdd.WaitOne();
                printNumber(i);
                sZero.Release();
            }
        }
        
    }

    public class ZipLinkedList : IMadLady {

        public Node head;

        public class Node
        {
            public int Value;
            public Node Next;

            public Node(int val)
            {
                Value = val;
                Next = null; 
            }
        }

        private Node Reverse(Node node)
        {
            Node prev = null;
            Node next;
            Node current = node;

            while(current != null)
            {
                next = current.Next;
                current.Next = prev;
                prev = current;
                current  = next;
            }
            
            node = prev;
            return node;
        }

        private void Zip(Node node)
        {   
            Node slowRunner = node; // Pointer to the node
            Node fastRunner = slowRunner.Next; // pointer to "faster" runner;
            
            while(slowRunner != null && fastRunner != null)
            {
                slowRunner = slowRunner.Next;
                if(fastRunner.Next != null)
                {
                    fastRunner = fastRunner.Next.Next;
                }
                else
                {
                    fastRunner = fastRunner.Next;
                }
            }

            // Cut the LL into two, with middle node as breaking point
            // 1 2 3 4 5 6 => (1 2 3) and (4 5 6)
            Node nodeFistHalf = node;
            Node nodeSecondHalf = slowRunner.Next;
            slowRunner.Next = null;

            //Print(nodeFistHalf);
            //Print(nodeSecondHalf);

            nodeSecondHalf = Reverse(nodeSecondHalf); // (4 5 6) => (6 5 4)

            Node newHead = new Node(-1);
            while(nodeFistHalf != null && nodeSecondHalf != null)
            {
                if(nodeFistHalf != null) // Adding (1) (2) (3) in each iteration
                {
                    newHead.Next = nodeFistHalf;
                    newHead = newHead.Next;
                    nodeFistHalf = nodeFistHalf.Next;
                }

                if(nodeSecondHalf != null) // Adding (6) (5) (4) in each iteration
                {
                    newHead.Next = nodeSecondHalf;
                    newHead = newHead.Next;
                    nodeSecondHalf = nodeSecondHalf.Next;
                }
            }

            // Pick up the left over in the first half
            if(nodeFistHalf != null)
            {
                newHead.Next = nodeFistHalf;
                newHead = newHead.Next;
                nodeFistHalf = nodeFistHalf.Next;
            }

            node = newHead.Next;
        }

        public void Print(Node head)
        {
            if(head == null) return;

            while(head != null)
            {
                Console.Write(head.Value + " -> ");
                head = head.Next;
            }
            Console.Write("nil");
            Console.WriteLine();
        }


        public void Run() {

            // Old: 1 2 3 4 5 6
            // Final: 1 6 2 5 4 3
            
            ZipLinkedList LL = new ZipLinkedList();
            Node node = new Node(1);
            Node head = node;

            int[] input = {2, 3, 4, 5, 6};

            for(int i=0; i<input.Length; i++)
            {
                node.Next = new Node(input[i]);
                node = node.Next;
            }

            Console.WriteLine("BEFORE");
            LL.Print(head);

            LL.Zip(head);

            Console.WriteLine("AFTER");
            LL.Print(head);

        }
    }

    public class LookSay : IMadLady
    {
        public void Solution(string input, int lines)
        {
            if(input == null || lines == 0) return;

            char c;
            int index = 0;
            int count = 0;
            string say = String.Empty;
            string all = String.Empty;

            while(index < input.Length)
            {
                c = input[index];

                while(index < input.Length && c == input[index])
                {
                    index++;
                    count++;
                }

                say = count + c.ToString();
                all += say;
                count = 0;
                Console.Write(say);
            }

            Console.WriteLine();
            Solution(all, lines-1);
        }

        public void Run()
        {
            Solution("ab", 5);
        }
    }

    public class BinaryAdd : IMadLady
    {
        private string Add(string a, string b)
        {
            if(a == null || b == null ) return String.Empty;

            string total = String.Empty;
            int sum = 0;
            int i = a.Length - 1;
            int j = b.Length - 1;

            while(i >= 0 || j >= 0)
            {
                if(i >= 0)
                {
                    sum += a[i] - '0';
                }
                else
                {
                    sum = 0;
                }

                if(j >= 0)
                {
                    sum += b[j] - '0';
                }
                else
                {
                    sum = 0;
                }

                //Sum: 0, 1, 2 or 3
                total = (char) ((sum % 2) + '0') + total;
                sum = sum / 2;

                i--;
                j--;
            }

            // Last carry
            if(sum == 1)
            {
                total = sum + total;
            }

            return total;
        }

        public void Run()
        {
            string a = "101101";
            string b = "111101";

            string sum = Add(a, b);
            Console.WriteLine(String.Format("{0} + {1} = {2}", a, b, sum));
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = new List<string>
            {
                "TwoSums",
                "ReverseInteger",
                "Palindrome",
                "RomanToInt",
                "LongestCommonPrefix",
                "ValidParentheses",
                "MergeSortedArray",
                "RemoveDupsInArray",
                "RemoveElement",
                "StrStr",
                "SearchInsertPosition",
                "SemaphoreDemo",
                "ActionAndFunc",
                "SemaphoreDemo2",
                "ZeroEvenOdd",
                "ZipLinkedList",
                "LookSay",
                "BinaryAdd"
            };

            foreach(string name in names)
            {
                Console.Write(string.Format("<<{0}>>\n", name));
                Type t = Type.GetType("MadLady." + name);

                try{
                    IMadLady o = Activator.CreateInstance(t) as IMadLady;
  
                    o.Run();
                }
                catch(ArgumentNullException e)
                {
                    Console.Write(e.ToString());
                }


            }

        }
    }

    public interface IMadLady
    {
        void Run();
    }
}
