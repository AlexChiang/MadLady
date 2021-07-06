using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MadLady;

namespace MadLady
{
    public class Node
    {
        public int value;
        public Node left;
        public Node right;
        
        public Node(int val)
        {
            value = val;
            left = null;
            right = null;
        }
    }

    public class BST : IMadLady
    {
        public Node root;

        public void Run()
        {
            root = null;
            int[] vals = new int[] {15, 10, 20, 8, 12, 16, 25};

            foreach(int i in vals)
            {
                Insert(ref root, i);
            }

            InOrder(root);
            Console.WriteLine();

            bool result = Delete(ref root, 16);
            Console.WriteLine("Delecting 16: " + result.ToString());
            InOrder(root);
            Console.WriteLine();

            result = Delete(ref root, 88);
            Console.WriteLine("Delecting 88: " + result.ToString());
            InOrder(root);
            Console.WriteLine();
        }
	
        public void InOrder(Node node)
        {
            if(node == null)
            {
                return;
            }
            
            if(node.left != null) InOrder(node.left);
            Console.Write(node.value + "|");
            if(node.right != null) InOrder(node.right);
        }
	
        public void Insert(ref Node root, int val)
        {
            Node curr;
            
            if(root == null)
            {
                root = new Node(val);
                return;
            }

            curr = root;
            
            while(curr != null)
            {
                if(val < curr.value)
                {
                    if(curr.left == null)
                    {
                        curr.left = new Node(val);
                        return;
                    }
                    else
                    {
                        curr = curr.left;
                    }
                }
                else
                {
                    if(curr.right == null)
                    {
                        curr.right = new Node(val);
                        return;
                    }
                    else
                    {
                        curr = curr.right;
                    }
                }
            }
        }

        public bool Delete(ref Node root, int val)
        {
            Node curr = root;
            Node parent = curr;

            while(curr != null)
            {
                if(val < curr.value)
                {
                    parent = curr;
                    curr = curr.left;
                }
                else if(val > curr.value)
                {
                    parent = curr;
                    curr = curr.right;
                }
                else
                {
                    if(curr.left != null && curr.right != null)
                    {
                        Console.WriteLine("1");
                        Node rightSmallest = curr.right;
                        while(rightSmallest.left != null) rightSmallest = rightSmallest.left;

                        curr.value = rightSmallest.left.value;
                        rightSmallest.left = null;

                    }
                    else if(curr.left != null)
                    {
                        Console.WriteLine("curr.left = null");
                        int tempVal = curr.left.value;
                        curr.left = null;
                        curr.value = tempVal;
                    }
                    else if(curr.right != null)
                    {
                        Console.WriteLine("curr.right = null");
                        int tempVal = curr.right.value;
                        curr.right = null;
                        curr.value = tempVal;
                    }
                    else
                    {
                        if(curr.value < parent.value)
                        {
                            Console.WriteLine("parent.left = null");
                            parent.left = null;
                        }
                        else
                        {
                            Console.WriteLine("parent.right = null");
                            parent.right = null;
                        }
                    }
                    return true;;
                }
            }
            return false;
        }
    }

    public class LowestCommonAncestor : IMadLady
    {
        public void Run()
        {
            BST bst = new BST();
            int[] vals = new int[] {15, 10, 20, 8, 12, 16, 25};

            /*
      15
     /   \
    10   20
   / \   / \
  8  12 16  25

            */

            foreach(int i in vals)
            {
                bst.Insert(ref bst.root, i);
            }

            //bst.InOrder(root);
            Node node = Find(bst.root, 8, 12);
            string ancester = (node == null) ? "none" : node.value.ToString();
            Console.WriteLine("Ancester (8, 12): " + ancester);

            node = Find(bst.root, 8, 25);
            ancester = (node == null) ? "none" : node.value.ToString();
            Console.WriteLine("Ancester (8, 25): " + ancester);
        }

        public Node Find(Node root, int a, int b)
        {
            Node ancester = null;

            while(root != null)
            {
                if(root.value > a && root.value > b)
                {
                    root = root.left;
                }
                else if(root.value < a && root.value < b)
                {
                    root = root.right;
                }
                else
                {
                    return root;
                }               
            }

            return ancester;
        }
    }

    public class FindNSmallest : IMadLady
    {
        private int count;

        public void Run()
        {
            BST bst = new BST();
            int[] vals = new int[] {15, 10, 20, 8, 12, 16, 25};

            /*
      15
     /   \
    10   20
   / \   / \
  8  12 16  25

            */

            foreach(int i in vals)
            {
                bst.Insert(ref bst.root, i);
            }

            count = 0;
            Node node = Find(bst.root, 3);
            string smallest = (node == null) ? "none" : node.value.ToString();
            Console.WriteLine("Smallest (3): " + smallest);

            count = 0;
            node = Find(bst.root, 5);
            smallest = (node == null) ? "none" : node.value.ToString();
            Console.WriteLine("Smallest (5): " + smallest);
        }

        private Node Find(Node root, int n)
        {
            if(root == null)
            {
                return null;
            }

            Node left = Find(root.left, n);

            if(left != null)
            {
                return left;
            }

            count++;
            if(count == n)
            {
                return root;
            }

            return Find(root.right, n);
        }
    }
    public class HeightBST : IMadLady
    {
        public void Run()
        {
            BST bst = new BST();
            int[] vals = new int[] {6, 4, 9, 2, 5, 8, 14, 10, 16};
            /*
       6
     /   \
    4     9
   / \   / \
  2  5  8  14
          /  \
         10  16

            */

            foreach(int i in vals)
            {
                bst.Insert(ref bst.root, i);
            }

            bst.InOrder(bst.root);
            int height = getMaxHeight(bst.root, 0);
            Console.WriteLine("Max height: " + height.ToString());
        }

        private int getMaxHeight(Node node, int height)
        {
            if(node == null)
            {
                return height;
            }

            int leftHeight = getMaxHeight(node.left, height + 1);
            int rightHeight = getMaxHeight(node.right, height + 1);

            return (leftHeight > rightHeight) ? leftHeight : rightHeight;
        }
    }

    public class KDistanceFromRoot : IMadLady
    {

        public void Run()
        {
            BST bst = new BST();
            int[] vals = new int[] {6, 4, 9, 2, 5, 8, 14, 10, 16};
            /*
       6
     /   \
    4     9
   / \   / \
  2  5  8  14
          /  \
         10  16

            */

            foreach(int i in vals)
            {
                bst.Insert(ref bst.root, i);
            }

            //bst.InOrder(bst.root);
            List<Node> list = new List<Node>();
            getNodes(bst.root, 2, 0, ref list);
            Console.Write("Distance (2): ");
            foreach(Node n in list)
            {
                Console.Write(n.value.ToString() + ", ");
            }
            Console.WriteLine();
        }

        private void getNodes(Node root, int distance, int height, ref List<Node> list)
        {
            if(root == null)
            {
                return;
            }

            if(height == distance)
            {
                list.Add(root);
                return;
            }

            getNodes(root.left, distance, height + 1, ref list);
            getNodes(root.right, distance, height + 1, ref list);

        }
    }
}

