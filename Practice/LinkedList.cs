using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Text;
using MadLady;

namespace MadLady
{
    public class LLNode
    {
        public int value;
        public LLNode Next;
        public LLNode(int val)
        {
            value = val;
            Next = null;
        }
    }

    public class MyLinkedList : IMadLady
    {
        public static LLNode head;

        public void Run()
        {
            MyLinkedList ll = new MyLinkedList();
            Add(1);
            Add(2);
            Add(3);
            Revert();
            Print(head);

            Delete(2);
            Delete(1);
            Print(head);

            Add(4);
            Add(5);
            Add(6);
            Print(head);

            Revert();
            Print(head);
        }

        public void Print(LLNode node)
        {
            while(node != null)
            {
                Console.Write(node.value + " -> ");
                node = node.Next;
            }

            Console.Write("nil\n");
        }

        public void Add(int val)
        {
            LLNode n = new LLNode(val);

            if(head == null)
            {
                head = n;
                return;
            }

            LLNode curr = head;
            while(curr.Next != null)
            {
                curr = curr.Next;
            }

            curr.Next = n;
        }

        public bool Delete(int val)
        {
            LLNode prev = null;
            LLNode curr = head;

            if(curr != null && curr.value == val)
            {
                head = curr.Next;
                return true;
            }

            while(curr !=null && curr.value != val)
            {
                prev = curr;
                curr = curr.Next;
            }

            if(curr != null)
            {
                prev.Next = curr.Next;
                return true;
            }

            return false;
        }

        public void Revert()
        {
            LLNode prev = null;
            LLNode curr = null;
            LLNode next = head;
/*
      pcn
   12345
*/
            while(next != null)
            {
                prev = curr;
                curr = next;
                curr.Next = prev;
                next = next.Next;
            }

            head = curr;
        }

    }
}