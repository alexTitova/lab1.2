using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1.classes
{
    class Rib
    {
        private Vertex start;
        private Vertex end;
        private int value;

        public Rib() { }

        public Rib((Vertex,Vertex) path, int value)
        {
            this.start = path.Item1;
            this.end = path.Item2;
            this.value = value;
        }

        public Vertex Start
        { 
            get { return this.start; }

            set { this.start = value; }
        }

        public Vertex End
        {
            get { return this.end; }

            set { this.end = value; }
        }


        public int Value
        {
            get { return this.value; }

            set { this.value = value; }
        }

    }
}
