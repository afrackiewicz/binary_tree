using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace drzewo_binarne
{
    class BST
    {
        private Node root = null;
        int count = 0;
        public int Count { get { return count; } }
        public Node Root
        {
            get
            {
                return root;
            }
            set
            {
                root = value;
            }
        }
        public BST() { }
        public void Make_empty() //	Spowodowanie, że reprezentowane drzewo jest puste
        {
            root = null;
        }
        public void Is_empty() //Sprawdzenie, czy reprezentowane drzewo jest puste
        {
            if (root == null) Console.WriteLine("drzewo puste");
            else Console.WriteLine("drzewo nie jest puste");
        }
  
        public virtual void Add(Node n) // dodanie elementu x
        { 
            int result;

         // wstawiamy n, szukamy w drzewie az nie trafimy na null
            Node current = root, parent = null;
            while (current != null)
            {
                result = current.Less(n);
                if (result == 0)
                    // jezeli juz istnieje takie cos, to nie mozemy wstawic drugi raz
                    return;
                else if (result == -1)
                {
                   // jezeli -1 to current jest mniejsze niz x wiec dodajemy w lewe poddrzewo
                    parent = current;
                    current = current.Left;
                }
                else if (result == 1)
                {
                    // rowne 1 czyli current jest wieksze niz x dodajemy do prawego poddrzewa
                    parent = current;
                    current = current.Right;
                }
            }

            

            if (parent == null)
                // jezeli drzewo bylo puste 
                root = n;
            else
            {
                result = parent.Less(n);
                if (result == -1) parent.Left = n;
                else if (result == 1) parent.Right = n;
            }
            count++;
        }

        public void Delete(int x, int y) //Usunięcie danego elementu xX z reprezentowanego drzewa
        {
            Node current = root, parent = null;
            Node n = new OtherNode(x,y);
            int result = current.Less(n);
            while (result != 0 && current != null)
            {
                if (result == -1)
                {
                    //n musi byc dodane do current.left poddrzewa
                    parent = current;
                    current = current.Left;
                }
                else if (result == 1)
                {
                    //tutaj na odwrót, do prawego
                    parent = current;
                    current = current.Right;

                }
                if (current != null) result = current.Less(n);

            }
            if (current == null) throw new Exception("nie istnieje taki element");

            // przypadek gdzu current nie ma prawego dziecka, to lewe staje sie ojcem
            if (current.Right == null)
            {
                if (parent == null) root = current.Left;
                else
                {
                    result = parent.Less(current);
                    if (result == -1)
                        parent.Left = current.Left;
                    else if (result == 1)
                        parent.Right = current.Left;
                }
            }
            //przypadek 2 jak nie ma lewego dziecka dla prawego dziecka
            else if (current.Right.Left == null)
            {
                if (parent == null) root = current.Right;
                else
                {
                    result = parent.Less(current);
                    if (result == -1) parent.Left = current.Right;
                    else if (result == 1) parent.Right = current.Right;
                }
            }
            //przypadek 3 jak prawe ma lewego syna
            else
            {
                //szukamy prawego najabardziej lewe dziecko
                Node leftm = current.Right.Left, lmPar = current.Right;
                while (leftm.Left != null)
                {
                    lmPar = leftm;
                    leftm = leftm.Left;
                }
                lmPar.Left = leftm.Right;
                leftm.Left = current.Left;
                leftm.Right = current.Right;

                if (parent == null) root = leftm;
                else
                {
                    result = parent.Less(current);
                    if (result == -1) parent.Left = leftm;
                    else if (result == 1) parent.Right = leftm;
                }
            }
            count--;
        }

        public  void PreOrder(Node current) //odwiedzamy korzeń poddrzewa, a następnie przechodzimy kolejno lewe i prawe poddrzewo
            {
            current.Show();
            if (current.Left != null) PreOrder(current.Left);
            if (current.Right != null) PreOrder(current.Right);
          
            }

        public void InOrder(Node current) //przechodzimy lewe poddrzewo danego węzła, następnie odwiedzamy węzeł i na koniec przechodzimy prawe poddrzewo.
            {
            if (current != null)
            {
                InOrder(current.Left);
                current.Show();
                InOrder(current.Right);
                    }
         
        }
        public void PostOrder(Node current) //najpierw przechodzimy lewe poddrzewo, następnie prawe, a dopiero na końcu przetwarzamy węzeł.
            {
            if(current != null)
            {
                PostOrder(current.Left);
                PostOrder(current.Right);
                current.Show();
            }
         
        }


        }
    
    }

