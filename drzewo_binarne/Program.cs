using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace drzewo_binarne
{
   
    class Program
    {
        void Pokaz(Node v)
        {
            
        }
        static void Main(string[] args)
        {
            BST tree = new BST();
            //tree.Root = new OtherNode(8, 5);
            //tree.Add(new OtherNode(4, 5));
            //tree.Add(new OtherNode(9, 5));
            //tree.Add(new OtherNode(10, 7));
            //tree.Add(new OtherNode(11, 8));
            //tree.Add(new OtherNode(13, 2));
            //tree.Add(new OtherNode(2, 13));
            //tree.Add(new OtherNode(9, 0));
            tree.Root = new Node(8);
            tree.Add(new Node(5));
            tree.Add(new Node(10));
            tree.Add(new Node(11));
            tree.Add(new Node(20));
            tree.Add(new Node(6));
            tree.Add(new Node(1));
            tree.Add(new Node(7));

            Console.WriteLine("przeszukiwanie pre order");
            tree.PreOrder(tree.Root);
            Console.WriteLine();
            Console.WriteLine("przeszukiwanie in order");
            tree.InOrder(tree.Root);
            Console.WriteLine();
            Console.WriteLine("przeszukiwanie post order");
            tree.PostOrder(tree.Root);
            Console.WriteLine();
            tree.Is_empty();
            tree.Make_empty();
            tree.Is_empty();
            BSTSort drzewko = new BSTSort(10);
            drzewko.Pokaz();
            drzewko.Sortuj();
            Console.ReadKey();

        }
    }
}
