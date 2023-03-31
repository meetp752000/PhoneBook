using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phase2
{
    class BinaryTree
    {
        public Node Root { get; set; }

        //this fuction adds values to the tree, by comparing the strings and then creating a node which is then place of either the left or right side of the parent node.
        public bool Add(String value)
        {
            Node before = null, after = this.Root;

            while (after != null)
            {
                before = after;
                //value < after.Data
                if (value.CompareTo(after.Data) == 1) //Is new node in left tree? 
                    after = after.LeftNode;

                //value > after.Data
                else if (value.CompareTo(after.Data) == -1) //Is new node in right tree?
                    after = after.RightNode;
                else
                {
                    //Exist same value
                    return false;
                }
            }

            Node newNode = new Node();
            newNode.Data = value;

            if (this.Root == null)//Tree ise empty
                this.Root = newNode;
            else
            {
                if (value.CompareTo(before.Data) == 1)
                    before.LeftNode = newNode;
                else
                    before.RightNode = newNode;
            }

            return true;
        }
        public void DisplayTree()
        {
            if (this.Root != null)
            {
                Console.WriteLine("Display contacts through binary tree in an alphabetical order:\n");
                DisplayTree(Root);
            }
        }

        //Using recursive method the Function prints all the right nodes then all the left nodes.
        private void DisplayTree(Node root)
        {
            if (root == null) return;
            DisplayTree(root.RightNode);
            Console.Write(root.Data + " \n");
            DisplayTree(root.LeftNode);
        }

        public Node Find(String value)
        {
  
            return this.Find(value, this.Root);
        }

        //This function using the recursive method finds a node that is == value. 
        private Node Find(String value, Node parent)
        {
            if (parent != null)
            {
                if (value.CompareTo(parent.Data) == 0) return parent;
                if (value.CompareTo(parent.Data) == 1)
                    return Find(value, parent.LeftNode);
                else
                    return Find(value, parent.RightNode);
            }

            return null;
        }

        //This function removes the Node by replacing it with the next smaller from left side and lager then right side.
        public void Remove(String value)
        {
            this.Root = Remove(this.Root, value);
    
        }

        private Node Remove(Node parent, String key)
        {
            if (parent == null) return parent;

            if (key.CompareTo(parent.Data) == 1) parent.LeftNode = Remove(parent.LeftNode, key);
            else if (key.CompareTo(parent.Data) == -1)
                parent.RightNode = Remove(parent.RightNode, key);

            // if value is same as parent's value, then this is the node to be deleted  
            else
            {
                // node with only one child or no child  
                if (parent.LeftNode == null)
                    return parent.RightNode;
                else if (parent.RightNode == null)
                    return parent.LeftNode;

                // node with two children: Get the inorder successor (smallest in the right subtree)  
                parent.Data = MinValue(parent.RightNode);

                // Delete the inorder successor  
                parent.RightNode = Remove(parent.RightNode, parent.Data);
            }

            return parent;
        }

        //finds the min value which can be used to replace the removed node.
        private String MinValue(Node node)
        {
            String minv = node.Data;

            while (node.LeftNode != null)
            {
                minv = node.LeftNode.Data;
                node = node.LeftNode;
            }

            return minv;
        }
    }
}
