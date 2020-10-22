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


        public Vertex() { }

        public Vertex(int name)
        {
            this.name = name;
            this.mark = 1000000;
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
