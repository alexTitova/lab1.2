using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1.classes
{
    class Vertex
    {
        private int name;
        private int mark;
        private Vertex dad;
        private bool isChecked;

        public Vertex() { }

        public Vertex(int name)
        {
            this.name = name;
            this.mark = 1000000;
            this.isChecked = false;
            this.dad = new Vertex();
           
        }

        public int Name
        {
            get { return this.name; }

            set { this.name = value; }
        }

        public int Mark
        {
            get { return this.mark; }

            set { this.mark = value; }
        }

        public Vertex Dad
        {
            get { return this.dad; }

            set { this.dad = value; }
        }

        public bool IsChecked
        {
            get { return this.isChecked; }

            set { this.isChecked = value; }
        }



        public override string ToString()
        {
            return this.name.ToString()+" mark - "+ this.mark.ToString();
        }


        public static bool operator >(Vertex x, Vertex y)
        {
            return x.Name > y.Name;
        }
        public static bool operator <(Vertex x, Vertex y)
        {
            return x.Name < y.Name;
        }

        public static bool operator >=(Vertex x, Vertex y)
        {
            return x.Name >= y.Name;
        }
        public static bool operator <=(Vertex x, Vertex y)
        {
            return x.Name <= y.Name;
        }

        public static bool operator ==(Vertex x, Vertex y)
        {
            return x.Name == y.Name;
        }

        public static bool operator !=(Vertex x, Vertex y)
        {
            return x.Name != y.Name;
        }
    }



    class Vertex_comparer : IComparer<Vertex>
    {
        public int Compare(Vertex x,Vertex y)
        {
            if (x.Name < y.Name)
                return -1;
            else
            {
                if (x.Name > y.Name)
                    return 1;
                else
                    return 0;
            }    
        }
    }



}
