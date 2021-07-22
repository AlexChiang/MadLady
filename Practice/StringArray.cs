using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Text;
using MadLady;

namespace MadLady
{
    public class StringArray : IMadLady
    {
 /*
"Given an array nums of n integers where n > 1,
return an array output such that output[i] is
equal to the product of all the elements of nums except nums[i]."
*/
        private void OtherProducts()
        {
            int[] nums1 = new int[] {1, 2, 3, 4, 5, 6};
            int[] nums2 = new int[] {1, 0, 3};
            
            int[] output1 = Calculate(nums1);
            int[] output2 = Calculate(nums2);
            
            for(int i=0; i<output1.Length; i++)
            {
                Console.Write(output1[i] + ", ");
            }
            Console.WriteLine();
            
            for(int j=0; j<output2.Length; j++)
            {
                Console.Write(output2[j] + ", ");
            }
            Console.WriteLine();
        }

       // For OtherProducts
        private int[] Calculate(int[] input)
        {
            if(input == null || input.Length == 0)
            {
                return new int[0];
            }
            
            int[] output = new int[input.Length];
            int zeroCount = 0;
            int total = 1;

            // Get the total of all nums product (excluding 0s)
            for(int i=0; i<input.Length; i++)
            {
                if(input[i] == 0)
                {
                    zeroCount++;
                }
                else
                {
                    total = total * input[i];
                }
            }
            
            for(int j=0; j<input.Length; j++)
            {
                if(zeroCount == 0)
                {
                    output[j] = total / input[j];
                }
                else if(input[j] == 0 && zeroCount == 1)
                {
                    output[j] = total;
                }
                else
                {
                    output[j] = 0;                    
                }
            }
            
            return output;  
        }

/*
Given a non-empty string s,you may delete at most one character.
Judge whether you can make it a palindrome.
*/
        public void Palindrome2()
        {
            string str1 = "abcdbbdcba";
            string str2 = "aXbcdbbdcba";
            string str3 = "abAcdbbdcba";
            string str4 = "abXXcdbbdcba";
            
            Console.WriteLine(str1 + ": " + IsPalindrome(str1, 0, str1.Length-1, true).ToString());
            Console.WriteLine(str2 + ": " + IsPalindrome(str2, 0, str2.Length-1, true).ToString());
            Console.WriteLine(str3 + ": " + IsPalindrome(str3, 0, str3.Length-1, true).ToString());  
            Console.WriteLine(str4 + ": " + IsPalindrome(str4, 0, str4.Length-1, true).ToString());            
        }
        
        private bool IsPalindrome(string input, int start, int end, bool loop)
        {
            if(String.IsNullOrEmpty(input))
            {
                return false;
            }
           
            while (start <= end)
            {
                if(input[start] == input[end])
                {
                    start++;
                    end--;
                }
                else if(loop == false)
                {
                    return false;
                }
                else
                {
                    if(IsPalindrome(input, start+1, end, false) ||
                      IsPalindrome(input, start, end-1, false))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                    
                }
            }
            
            return true;
        }

        public void NextPermutation()
        {
            int[] input = {0, 1, 2, 5, 3, 3, 0};
            
            bool result = Permutation(ref input);
            
            Console.Write(result.ToString() + ": ");
            for(int i=0; i<input.Length; i++)
            {
                Console.Write(input[i].ToString() + ", ");
            }
            
            Console.WriteLine();
        }
  
        public bool Permutation(ref int[] nums)
        {
            int permStart = nums.Length-1;
            int permSwapIndex = nums.Length-1;
/*
0, 1, 2, 5, 3, 3, 0
         ^^^^^^^^^^
      K        S

0, 1, 3, 5, 3, 2, 0
         ^^^^^^^^^^

0, 1, 3, 0, 2, 3, 5

*/        
            while(permStart > 0 &&
                nums[permStart-1] >= nums[permStart])
            {
                permStart--;
            }

            if(permStart <= 0)
            {
                return false;
            }
            
            while(nums[permSwapIndex] <= nums[permStart-1])
            {
                permSwapIndex--;
            }

            Swap(ref nums, permStart-1, permSwapIndex);
            Reverse(ref nums, permStart, nums.Length-1);

            return true;
        }

        private void Swap(ref int[] input, int a, int b)
        {
            int temp = input[a];
            input[a] = input[b];
            input[b] = temp;
        }
        
        private void Reverse(ref int[] input, int start, int end)
        {
            int temp = -1;
            
            while(start <= end)
            {
                temp = input[start];
                input[start] = input[end];
                input[end] = temp;
                start++;
                end--;
            }
        }

    public string Substring(string source, string target)
     {
         const int ASCII_SIZE = 256;      

         int minStart = 0;
         int min = Int32.MaxValue;
         
         int matchCount = 0;         
         int start = 0;
         char c;
         
         int[] charS = new int[ASCII_SIZE];
         int[] charT = new int[ASCII_SIZE];      
         
         for(int i=0; i<target.Length; i++)
         {
             c = target[i];
             charT[c]++;
         }
         
         for(int j=0; j<source.Length; j++)
         {
             c = source[j];
             
             if(charT[c] > 0)
             {      
                 if(charS[c] < charT[c])
                 {
                     matchCount++;
                 }
                 charS[c]++;
             }
             
             if(matchCount == target.Length)
             {
                 while(charS[source[start]] > charT[source[start]] ||
                      charT[source[start]] == 0)
                 {
                     if(charS[source[start]] > charT[source[start]])
                     {
                         charS[source[start]]--;
                     }
                     start++;
                 }
                 
                 int winSize = j - start + 1;
                 
                 if(min > winSize)
                 {
                     min = winSize;
                     minStart = start;

                     charS[source[start]]--;
                     start++;
                     matchCount--;
                 }
             }
         }
         
         if(min == 0)
         {
             return String.Empty;
         }
         
         return source.Substring(minStart, min);
     }

        public void SubstringRunner()
        {
        string source = "this is a test string";
         string target = "tist";
         
         string result = Substring(source, target);
         Console.WriteLine(result);  
        }


        public void Run()
        {
            Console.WriteLine("[OtherProducts]");
            OtherProducts();

            Console.WriteLine("[Palindrome2]");
            Palindrome2();

            Console.WriteLine("[NextPermutation]");
            NextPermutation();

            Console.WriteLine("[Substring]");
            SubstringRunner();
        }

    }
}