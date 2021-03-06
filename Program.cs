﻿using System;
using System.Collections.Generic;

namespace MadLady
{
    public class TwoSums : IMadLady
    {
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
            Console.Write(String.Format("Answer: {0} and {1}\n", idx[0], idx[1]));
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
            Console.Write(String.Format("{0}\n",num));
        }
    }

    public class Palindrome : IMadLady
    {
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
            Console.Write(String.Format("List 1: {0}\nList 2: {1}\n", commonPrefix1, commonPrefix2));

        }
    }

    public class ValidParentheses : IMadLady
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
                "SearchInsertPosition"
            };

            foreach(string name in names)
            {
                Type t = Type.GetType("MadLady." + name);
                IMadLady o = Activator.CreateInstance(t) as IMadLady;

                Console.Write(string.Format("<<{0}>>\n", name));
                o.Run();
            }

        }
    }

    public interface IMadLady
    {
        void Run();
    }
}
