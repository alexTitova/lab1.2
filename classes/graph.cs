using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1.classes
{
    class Graph
    {
        private List<Vertex> vertexes;
        private List<Rib> ribs;

        public Graph() { }

        public Graph (List<Vertex> vertexes, List<Rib> ribs)
        {
            this.ribs = ribs;
            this.vertexes = vertexes;
        }

        public List<Vertex> Vertexes
        {
            get { return this.vertexes; }

            set { this.vertexes = value; }
        }

        public List<Rib> Ribs
        {
            get { return this.ribs; }

            set { this.ribs = value; }
        }
    }
}
