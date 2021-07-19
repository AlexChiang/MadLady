using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Text;
using MadLady;

namespace MadLady
{
    public class TrieNode
    {
        private const int maxChar = 26;
        public TrieNode[] children = new TrieNode[maxChar];
        public bool isEndWord;

        public TrieNode()
        {
            isEndWord = false;
            for(int i=0; i<maxChar; i++)
            {
                children[i] = null;
            }
        }
    }

    public class Trie : IMadLady
    {
        public TrieNode root;

        public void Run()
        {
            Console.WriteLine(">>Creating: The");
            Insert("The");

            Console.WriteLine(">>Creating: Theater");
            Insert("Theater");

            bool result = Search("th");
            Console.WriteLine("Search (th): " + result.ToString());
            
            result = Search("the");
            Console.WriteLine("Search (the): " + result.ToString());

            result = Search("them");
            Console.WriteLine("Search (them): " + result.ToString());

            result = Search("theater");
            Console.WriteLine("Search (theater): " + result.ToString());

            result = Search("theaters");
            Console.WriteLine("Search (theaters): " + result.ToString());

            //
            Delete("theaters", root, 0);
            Delete("theat", root, 0);
            Delete("the", root, 0);
            Delete("theater", root, 0);
        }

        public Trie()
        {
            root = new TrieNode();
        }

        public int GetIndex(char c)
        {
            return c - 'a';
        }

        public void PrintChildren(TrieNode node)
        {
            StringBuilder sb = new StringBuilder();

            for(int i=0; i<26; i++)
            {
                sb.Clear();
                sb.Append((char) (i + 'a'));
                sb.Append(": ");
                sb.Append((node.children[i] != null) ? "exists" : "null");
                Console.WriteLine(sb.ToString());
            }
        }

        public bool Search(string key)
        {
            if(key == null) return false;
            
            char c;
            key = key.ToLower();
            TrieNode curr = root;

            for(int i=0; i<key.Length; i++)
            {
                c = key[i];
                TrieNode child = curr.children[GetIndex(c)];

                if(child == null)
                {
                    return false;
                }

                curr = child;
            }

            if(curr != null && curr.isEndWord == true)
            {
                return true;
            }

            return false;
        }

        public void Insert(string key)
        {
            if(key == null) return;
            
            key = key.ToLower();
            TrieNode curr = root;
            TrieNode child;
            char c;

            for(int i=0; i<key.Length; i++)
            {
                c = key[i];
                child = curr.children[GetIndex(c)];

                if(child == null)
                {
                    child = new TrieNode();
                    curr.children[GetIndex(c)] = child;
                    //Console.WriteLine("Inserted: " + c.ToString());
                }

                if(i == key.Length-1)
                {
                    child.isEndWord = true;
                    //Console.WriteLine("End word: " + c.ToString());
                }

                curr = child;
            }
        }

        private bool HasChildrean(TrieNode node)
        {
            for(int i=0; i<26; i++)
            {
                if(node.children[i] != null)
                {
                    return true;
                }
            }

            return false;
        }

        public bool Delete(string key, TrieNode node, int level)
        {
/*
 0 T
 1 H
 2 E*
 3 A
 4 T
 5 E
 6 R*

*/
            bool deleteMe = false;

            if(node == null || string.IsNullOrEmpty(key))
            {
                Console.WriteLine("Key not found (" + key +")");
                return false;   
            }

            if(key.Length == level)
            {
                if(node.isEndWord)
                {
                    node.isEndWord = false;
                    Console.WriteLine("Key deleted (" + key +")");
                }

                if(!HasChildrean(node))
                {
                    node = null;
                    deleteMe = true;
                }
                
                return deleteMe;
            }

            char c = key[level];
            TrieNode n = node.children[GetIndex(c)];
            bool deleteChild = Delete(key, n, level+1);

            if(deleteChild)
            {
                node.children[GetIndex(c)] = null;

                if(node.isEndWord)
                {
                    deleteMe = false;
                }
                else if(HasChildrean(node))
                {
                    deleteMe = false;
                }
                else
                {
                    deleteMe = true;
                    node = null;
                }
            }

            return deleteMe;
        }

    }
}