using System;
using System.Collections.Generic;
using System.Text;

namespace BinarySearchTreeSolution
{
    public class BinarySearchTree
    {

        private Node _head;
        
        public void Add(int value)
        {
            if (_head == null)
            {
                _head = new Node(value);
            }
            else
            {
                AddRecursive(_head, value);
            }
        }

        private void AddRecursive(Node node, int value)
        {
            if (value < node.Value)
            {
                if (node.Left == null)
                {
                    node.Left = new Node(value);
                }
                else
                {
                    AddRecursive(node.Left, value);
                }
            }
            if (value > node.Value)
            {
                if (node.Right == null)
                {
                    node.Right = new Node(value);
                }
                else
                {
                    AddRecursive(node.Right, value);
                }
            }
        }

        public void Remove(int value)
        {
            _head = RemoveRecursive(_head, value);
        }

        private Node RemoveRecursive(Node node, int value)
        {
            if (node == null)
            {
                return null;
            }
            if (node.Value == value)
            {
                if (node.Left == null && node.Right == null)
                {
                    // No children (leaf)
                    return null;
                }
                else if(node.Right != null && node.Left != null)
                {
                    // Two children
                    Node replacement = FindMin(node.Right);
                    int replacementValue = replacement.Value;
                    RemoveRecursive(node, replacementValue);
                    node.Value = replacementValue;
                    return node;
                }
                else
                {
                    // One child
                    if (node.Left != null)
                    {
                        return node.Left;
                    }
                    else
                    {
                        return node.Right;
                    }
                }
            }
            else
            {
                if (value < node.Value && node.Left != null)
                {
                    node.Left = RemoveRecursive(node.Left, value);
                    return node;
                }
                else if (value > node.Value && node.Right != null)
                {
                    node.Right = RemoveRecursive(node.Right, value);
                    return node;
                }
                else
                {
                    return null;
                }
            }
            
        }

        private Node FindMin(Node node)
        {
            while (node.Left != null)
            {
                node = node.Left;
            }

            return node;
        }

        public bool Contains(int value)
        {
            Node current = _head;
            while (current != null)
            {
                if (value < current.Value)
                {
                    current = current.Left;
                }else if (value > current.Value)
                {
                    current = current.Right;
                }
                else if (value == current.Value)
                {
                    return true;
                }
            }

            return false;
        }

        public override string ToString()
        {
            return GetString(Order.INORDER);
        }

        public string GetString(Order order)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append('[');
            switch (order)
            {
                case Order.INORDER:
                    InOrderRecursive(_head, sb);
                    break;
                case Order.PREORDER:
                    PreOrderRecursive(_head, sb);
                    break;
                case Order.POSTORDER:
                    PostOrderRecursive(_head, sb);
                    break;
                case Order.LEVELORDER:
                    LevelOrderRecursive(_head, sb);
                    break;
            }
            sb.Remove(sb.Length - 2, 2);
            sb.Append(']');
            return sb.ToString();
        }

        private void InOrderRecursive(Node node, StringBuilder sb)
        {
            if (node != null)
            {
                if (node.Left != null)
                {
                    InOrderRecursive(node.Left, sb);
                }
                sb.Append(node.Value);
                sb.Append(", ");
                if (node.Right != null)
                {
                    InOrderRecursive(node.Right, sb);
                }
            }
        }

        private void PreOrderRecursive(Node node, StringBuilder sb)
        {
            if (node != null)
            {
                sb.Append(node.Value);
                sb.Append(", ");
                if (node.Left != null)
                {
                    PreOrderRecursive(node.Left, sb);
                }
                if (node.Right != null)
                {
                    PreOrderRecursive(node.Right, sb);
                }
            }
        }

        private void PostOrderRecursive(Node node, StringBuilder sb)
        {
            if (node != null)
            {
                if (node.Left != null)
                {
                    PostOrderRecursive(node.Left, sb);
                }
                if (node.Right != null)
                {
                    PostOrderRecursive(node.Right, sb);
                }
                sb.Append(node.Value);
                sb.Append(", ");
            }
        }
        
        private void LevelOrderRecursive(Node node, StringBuilder sb)
        {
            if (node != null)
            {
                Queue<Node> queue = new Queue<Node>();
                queue.Enqueue(node);

                while (queue.Count > 0)
                {
                    node = queue.Dequeue();
                    
                    sb.Append(node.Value);
                    sb.Append(", ");
                    
                    if (node.Left != null)
                    {
                        queue.Enqueue(node.Left);
                    }
                    if (node.Right != null)
                    {
                        queue.Enqueue(node.Right);
                    }
                }
            }
        }
    }
}