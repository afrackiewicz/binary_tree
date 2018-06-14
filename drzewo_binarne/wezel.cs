using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace drzewo_binarne
{
class Node
    {

        protected Node left;// lewy syn
        protected Node right; // prawy syn
        protected int key;
     
        public Node() : this(0) { }
        public Node(int data) : this(data, null, null) { }
        public Node(int data, Node left, Node right)
        {
            this.key = data;
            this.left = left;
            this.right = right;
        }
      
        public int Value
        {
            get
            {
                return key;
            }
            set
            {
                key = value;
            }
        }

        public Node Left
        {
            get
            {
                return left;
            }
            set
            {
                left = value;
            }
        }

        public Node Right
        {
            get
            {
                return right;
            }
            set
            {
                right = value;
            }
        }
       
        public virtual int Less(Node x)
        {
            if (this.Value > x.Value) return -1; 
            else if (this.Value < x.Value) return 1;
            else return 0;

        }
        public virtual void Show()
        {
            Console.Write(this.key + " ");
        }
    }
    class OtherNode : Node
    {
        int value2;
        public int Value2
        {
            get { return value2; }
            set { value2 = value; }
        }

        public OtherNode(int x, int y) : base(x)
        {
            this.value2 = y;
        }

        public override void Show()
        {
            Console.Write(this.key + " ");
            Console.WriteLine(this.value2);
        }

        
        public override int Less(Node x)
        {
            if (this.Value > x.Value) return -1; 
            else if (this.Value < x.Value) return 1;
            else
            {

                if (this.value2> (x as OtherNode).value2)  return -1; 
                else if (this.value2 < (x as OtherNode).value2) return 1;
                else return 0;
            }
        }

    }
  
}
