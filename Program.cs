using System;
using System.Collections.Generic;

namespace MadLady
{

    public class TwoSums{
        private int[] Resolution(int[] input, int target)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();

            foreach (int i in input){
                if(dict.TryGetValue(i, out int comp) && comp == (target-i))
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
            //int[] arr =; 
            int[] idx = Resolution(new int[] {2, 7, 11, 2}, 9);
            Console.Write(String.Format("Answer: {0} and {1}", idx[0], idx[1]));
        }
    }

    public class ReverseInteger{

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
                output = (output * 10) + input % 10;
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
            Console.Write(num);
        }
    }

    public class Palindrome{
        private Boolean Check(int input){

            string inputStr = input.ToString();
            int start=0;
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

            Console.Write(String.Format("{0} is{1} a Palindrome", input, (Check(input) ? "" : " not" )));
            Console.Write("\n");

            input = 876543;
            Console.Write(String.Format("{0} is{1} a Palindrome", input, (Check(input) ? "" : " not" )));

        }
    }

    public class RomanToInt
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
            Console.Write(String.Format("{0}: {1}", roman, integer));
            Console.Write("\n");

            roman = "LVIII";
            integer = Convert(roman);
            Console.Write(String.Format("{0}: {1}", roman, integer));
            Console.Write("\n");

            roman = "MCMXCIV";
            integer = Convert(roman);
            Console.Write(String.Format("{0}: {1}", roman, integer));
            Console.Write("\n");

        }

    }

    public class LongestCommonPrefix
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
                    prefix = prefix.Substring(0, prefix.Length -1);
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
            Console.Write(String.Format("List 1: {0}\nList 2: {1}", commonPrefix1, commonPrefix2));
            Console.Write("\n");

            commonPrefix1 = FindVertical(list1);
            commonPrefix2 = FindVertical(list2);
            Console.Write(String.Format("List 1: {0}\nList 2: {1}", commonPrefix1, commonPrefix2));
            Console.Write("\n");


        }
    }

    public class ValidParentheses
    {

        private bool Validate(string input)
        {
            Dictionary<char, char> p = new Dictionary<char, char>();
            p.Add(')', '(');
            p.Add(']', '[');
            p.Add('}', '{');

            char c;

            Stack<char> s = new Stack<char>();
            for(int i=0; i<input.Length; i++)
            {
                c = input[i];
                if(p.ContainsKey(c))
                {
                    char c1 = s.Pop();
                    if(p[c] != c1) return false;
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

public class MergeSortedArray
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

    class Program
    {

        static void Main(string[] args)
        {
            TwoSums ts = new TwoSums();
            ts.Run();
            Console.Write("\n===========\n");

            ReverseInteger ri = new ReverseInteger();
            ri.Run();
            Console.Write("\n===========\n");

            Palindrome p = new Palindrome();
            p.Run();
            Console.Write("\n===========\n");

            RomanToInt rti = new RomanToInt();
            rti.Run();

            LongestCommonPrefix lcp = new LongestCommonPrefix();
            lcp.Run();

            ValidParentheses vp = new ValidParentheses();
            vp.Run();

            MergeSortedArray msa = new MergeSortedArray();
            msa.Run();

        }
    }
}
