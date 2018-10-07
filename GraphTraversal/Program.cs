using System;
using System.Collections.Generic;

namespace GraphTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0;
            var root = new BinaryNode<int>(i++);
            root.Left = new BinaryNode<int>(i++);
            root.Right = new BinaryNode<int>(i++);
            root.Left.Left = new BinaryNode<int>(i++);
            root.Left.Right = new BinaryNode<int>(i++);
            root.Right.Left = new BinaryNode<int>(i++);
            root.Right.Right = new BinaryNode<int>(i++);

            IBinaryTreeSearch dfs = new DepthFirstSearch();
            Console.WriteLine("Depth first search");
            dfs.Traverse(root);

            IBinaryTreeSearch bfs = new BredthFirstSearch();
            Console.WriteLine("Bredth first search");
            bfs.Traverse(root);

        }
    }

    public class BinaryNode<T>
    {
       public T Value {get;}
       public BinaryNode<T> Left {get; set;}
       public BinaryNode<T> Right {get; set;}
       
       public BinaryNode(T value )
       {
           Value = value;
       }

       public bool IsLeaf => this.Left == null && this.Right == null;
       public void Traverse(BinaryNode<T> node) {
           if (node.Left != null) {
               Traverse(node.Left);
           }

           if (node.Right != null) {
               Traverse(node.Right);
           }

           if (this.IsLeaf) {
               // do nothing
           }
       }
    }

    public class DepthFirstSearch : IBinaryTreeSearch {
        public void Traverse<T>(BinaryNode<T> root) {
            var stack = new Stack<BinaryNode<T>>();
            BinaryNode<T> thisNode = null;
            stack.Push(root);
            while (stack.Count > 0) {
                thisNode = stack.Pop();
                Console.WriteLine(thisNode.Value);
                if (thisNode.Right != null) {
                    stack.Push(thisNode.Right);
                }
                if (thisNode.Left != null) {
                    stack.Push(thisNode.Left);
                }
            }
        }
    }

    public class BredthFirstSearch : IBinaryTreeSearch {
        public void Traverse<T>(BinaryNode<T> root)
        {
            var queue = new Queue<BinaryNode<T>>();
            queue.Enqueue(root);
            BinaryNode<T> thisNode = null;
            while (queue.Count > 0) {
                thisNode = queue.Dequeue();
                Console.WriteLine(thisNode.Value);
                if (thisNode.Left != null) {
                    queue.Enqueue(thisNode.Left);
                }
                if (thisNode.Right != null) {
                    queue.Enqueue(thisNode.Right);
                }
            }
        }
    }

    public interface IBinaryTreeSearch {
        void Traverse<T>(BinaryNode<T> root);
    }
}
