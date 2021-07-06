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
                current = next;
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
                sum += (i >= 0) ?
                    a[i] - '0' : 0;

                sum += (j >= 0) ?
                    b[j] - '0' : 0;

                //Sum: 0, 1, 2 or 3
                total = (char) ((sum % 2) + '0') + total;
                sum = sum / 2;

                i--;
                j--;
            }

            // Last carry
            if (sum == 1)
            {
                total += '1';
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

    public class KSubArrarys : IMadLady
    {
        private int Find(int[] input, int limit)
        {
            if(input == null || input.Length == 0) return 0;

            int start = 0;
            int end = 0;
            int count = 0;
            int sum = input[0];

            while(start < input.Length && end < input.Length)
            {
                if(sum < limit)
                {
                    end++;

                    if(start < end)
                    {
                        count += end - start;
                    }

                    if(end < input.Length)
                    {
                        sum += input[end];
                    }
                }
                else
                {
                    sum -= input[start];
                    start++;
                }

                //Console.WriteLine(String.Format("start:{0} end:{1} count:{2}", start, end, count));
            }

            return count;
        }

        public void Run()
        {
            int[] input = {1, 11, 2, 3, 15};
            int limit = 10;
            int count = Find(input, limit);
            Console.WriteLine("Input: " + "{ 1, 11, 2, 3, 15 }");
            Console.WriteLine(String.Format("Total: {0} sub-arrays", count));

            int[] input2 = {3, 5, 2, 7, 8, 9, 11, 2, 5, 8, 3};
            int limit2 = 9;
            int count2 = Find(input2, limit2);
            Console.WriteLine("Input: " + "{3, 5, 2, 7, 8, 9, 11, 2, 5, 8, 3 }");
            Console.WriteLine(String.Format("Total: {0} sub-arrays", count2));
        }

    }
    public class InlineSortArrarys : IMadLady
    {
        public void Run()
        {
            int[] input = new int[] {-1, 1, 3, -2, 2, -3};

            int left = 0;
            int right = 0;
            int temp = 0;

            while(right < input.Length)
            {
                while(input[left] < 0) left++ ;
                
                right = left;

                while(right < input.Length && input[right] > 0) right++;

                if(right != input.Length)
                {
                    for(int i=right; i>left; i--)
                    {
                        temp = input[i-1];
                        input[i-1] = input[i];
                        input[i] = temp;
                    }
                }
            }

            Console.WriteLine(string.Join(",", input));
        }
    }

    public class MaxSubArray : IMadLady
    {
        private void Find(int[] input)
        {        
            int left = 0;
            int right = 0;
            int total = 0;
            int max = 0;
            int maxLeft = 0;
            int maxRight = 0;

            while(right < input.Length)
            {
                total += input[right];
                right++;

                if (total > max)
                {
                    max = total;
                    maxLeft = left;
                    maxRight = right;
                }

                if(total < 0)
                {
                    left = right;
                    total = 0;
                }

            }

            right--;
            int[] subArray = new int[right-left];
            Array.Copy(input, left, subArray, 0, right-left);

            Console.WriteLine("Max: " + max);
            Console.WriteLine("{" + String.Join(", ", subArray) + "}");
        }
        public void Run()
        {
            int[] input = new int[] {-2, -3, 4, -1, -2, 1, 5, -3};
            Find(input);
        }
    }

    public class FindLongestConseqSubseq : IMadLady
    {
        private int Find(int[] input)
        {
            HashSet<int> dict = new HashSet<int>();
            int maxCount = 0;
            int count = 0;
            int val;

            for(int i=0; i<input.Length; i++)
            {
                dict.Add(input[i]);
            }

            for(int j=0; j<input.Length; j++)
            {
                val = input[j];

                // Start of a seq?
                if(!dict.Contains(val-1))
                {
                    while(dict.Contains(val))
                    {
                        val++;
                        count++;
                    }
                }
                
                if(count > maxCount)
                {
                    maxCount = count;
                }

                count = 0;
            }

            return maxCount;
        }

        public void Run()
        {
            int[] input = new int[] {1, 9, 3, 10, 3, 4, 20, 2};
            Console.WriteLine("{1, 9, 3, 10, 3, 4, 20, 2}");
            Console.WriteLine("Count:" + Find(input));

            int[] input2 = new int[] {36, 41, 56, 35, 44, 33, 34, 92, 43, 32, 42};
            Console.WriteLine("{36, 41, 56, 35, 44, 33, 34, 92, 43, 32, 42}");
            Console.WriteLine("Count:" + Find(input2));
        }
    }

    public class ShuffleInteger : IMadLady
    {
        private void Shuffle(ref int[] input, int start, int end)
        {
            if((start > end) || (end == start + 1)) return;

            // mid = 3
            int mid = start + (end - start) / 2;

            // 0 1 2 3 || 4 5 6 7
            int leftStart = start + (mid - start) / 2 + 1;
            int rightStart = mid + 1;
            int temp;

            while(leftStart <= mid)
            {
                temp = input[leftStart];
                input[leftStart] = input[rightStart];
                input[rightStart] = temp;

                leftStart++;
                rightStart++;
            }
            Shuffle(ref input, start, mid);
            Shuffle(ref input, mid + 1, end);
        }

        static void Shuffle2(ref int[] a, int n)
        {
            // a1 a2 a3 a4 | b1 b2 b3 b4
            // a => (2 * i) - 1
            // b => (2 * i)

            int temp;
            n = n / 2;

            for (int start = n + 1,
                        j = n + 1,
                        done = 0,
                        i;
                done < 2 * n - 2;
                done++)
                {
                if (start == j) {
                    start--;
                    j--;
                }

                i = j > n ? j - n : j;
                j = j > n ? 2 * i : 2 * i - 1;
                temp = a[start];
                a[start] = a[j];
                a[j] = temp;
            }
        }

        public void Run()
        {
            // Expected: 1, 11, 2, 12, 3, 13, 4, 14
            int[] arr = new int[] {1, 2, 3, 4, 11, 12, 13, 14};
            
            // Quick sort - O(n logn)
            Shuffle(ref arr, 0, arr.Length-1);
            Console.WriteLine("   {1, 2, 3, 4, 11, 12, 13, 14}");
            Console.WriteLine("=> {" + String.Join(", ", arr) + "}");

            Shuffle2(ref arr, arr.Length-1);
        }
    }

    class Decoding : IMadLady
    {
        private HashSet<string> Decode(string prefix, string code)
        {
            HashSet<string> set = new HashSet<string>();
            HashSet<string> tempSet;
            char c1, c2;

            if(prefix == null || code == null) return set;
            if(code.Length == 0)
            {
                set.Add(prefix);
                return set;
            }

            c1 = (char) (Char.GetNumericValue(code[0]) - 1 + 'a');

            if(code[0] != '0')
            {
                tempSet = Decode(prefix + c1.ToString(), code.Substring(1));
                set.UnionWith(tempSet);
            }

            if(code.Length >= 2)
            {
                c2 = (char) (Char.GetNumericValue(code[1]) - 1 + 'a');

                if(Char.GetNumericValue(code[0]) == 1)
                {
                    tempSet = Decode(prefix + Convert.ToString(c1) + c2.ToString(),
                                    code.Substring(2));
                    set.UnionWith(tempSet);

                }

                if(Char.GetNumericValue(code[0]) == 2 &&
                    Char.GetNumericValue(code[1]) <= 6)
                {
                    tempSet = Decode(prefix + c1.ToString() + c2.ToString(),
                                    code.Substring(2));
                    set.UnionWith(tempSet);
                }
            }

            return set;
        }

        public void Run()
        {
            string code = "1123";
            HashSet<string> set = Decode("", code);

            Console.WriteLine("Code:" + code);
            foreach(string str in set)
            {
                Console.WriteLine(str);
            }
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
                "BinaryAdd",
                "KSubArrarys",
                "InlineSortArrarys",
                "MaxSubArray",
                "FindLongestConseqSubseq",
                "ShuffleInteger",
                "Decoding"
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
}
