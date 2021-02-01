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

    public class RomanToInt()
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
        */

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

        }
    }
}
