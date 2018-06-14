using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace drzewo_binarne
{
    class BSTSort
    {
        Node[] sortowanie;
        
        public BSTSort(int num)
        {
         
            sortowanie = new Node[num];
            Console.WriteLine("podaj " + num + "liczb");
            for (int i = 0; i < num; i++)
            {
                sortowanie[i] = new Node(Int32.Parse(Console.ReadLine()));
            }
        }
        public void Pokaz()
        {
            foreach(var s in sortowanie)
            {
                Console.Write(s.Value+" ");
            }
            Console.WriteLine();
        }
        public void Sortuj()
        {
            BST tree = new BST();
            foreach(Node s in sortowanie)
            {
                tree.Add(s);
            }
            tree.InOrder(tree.Root);
        }

    }
}
