using System;
using System.Diagnostics;

namespace BinarySearchTreeSolution
{
    class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree binarySearchTree = new BinarySearchTree();
            
            binarySearchTree.Add(8);
            binarySearchTree.Add(3);
            binarySearchTree.Add(10);
            binarySearchTree.Add(1);
            binarySearchTree.Add(6);
            binarySearchTree.Add(14);
            binarySearchTree.Add(4);
            binarySearchTree.Add(7);
            binarySearchTree.Add(13);

            Console.WriteLine("In-Order Test: " 
                              + ((binarySearchTree.GetString(Order.INORDER) == "[1, 3, 4, 6, 7, 8, 10, 13, 14]")
                              ? "PASSED" : "FAILED"));
            Console.WriteLine("Pre-Order Test: " 
                              + ((binarySearchTree.GetString(Order.PREORDER) == "[8, 3, 1, 6, 4, 7, 10, 14, 13]")
                              ? "PASSED" : "FAILED"));
            Console.WriteLine("Post-Order Test: " 
                              + ((binarySearchTree.GetString(Order.POSTORDER) == "[1, 4, 7, 6, 3, 13, 14, 10, 8]")
                              ? "PASSED" : "FAILED"));
            Console.WriteLine("Level-Order Test: "
                              + ((binarySearchTree.GetString(Order.LEVELORDER) == "[8, 3, 10, 1, 6, 14, 4, 7, 13]")
                              ? "PASSED" : "FAILED"));
            
            Console.WriteLine("Contains Test: " 
                              + ((binarySearchTree.Contains(4) 
                              && binarySearchTree.Contains(8) && !binarySearchTree.Contains(2))
                              ? "PASSED" : "FAILED"));
            
            binarySearchTree.Remove(8);
            binarySearchTree.Remove(3);
            binarySearchTree.Remove(6);
            Console.WriteLine("Deletion Test: "
                              + ((binarySearchTree.GetString(Order.INORDER) == "[1, 4, 7, 10, 13, 14]")
                                  ? "PASSED" : "FAILED"));

        }
    }
}