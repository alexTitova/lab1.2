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
            this.vertexes.Sort(new Vertex_comparer());
        }

        public List<Vertex> Vertexes
        {
            get { return this.vertexes; }

            set 
            { 
                this.vertexes = value;
                this.vertexes.Sort(new Vertex_comparer());
            }
        }

        public List<Rib> Ribs
        {
            get { return this.ribs; }

            set { this.ribs = value; }
        }

        public void AddVertex(Vertex vertex)
        {
            if (this.vertexes.BinarySearch(vertex, new Vertex_comparer())>=0)
            {
                this.vertexes.Add(vertex);
                this.vertexes.Sort(new Vertex_comparer());
            }
            else
                throw new ExceptionAlreadyExist("Vertex " + vertex.ToString() + " has already exist");
        }


        public void AddRib(Rib rib)
        {
            if (this.vertexes.BinarySearch(rib.Start, new Vertex_comparer()) >=0 && this.vertexes.BinarySearch(rib.End, new Vertex_comparer())>=0)
            {
                if (this.ribs.BinarySearch(rib, new Rib_Comparer())<0)
                    this.ribs.Add(rib);
                else
                    throw new ExceptionAlreadyExist("Rib " + rib.ToString() + " has already exist");
            }
            else
                throw new ExceptionDoesNotExist("One of vertexes does not exist");
        }

        public int GetCountOfVertexes()
        {
            return this.vertexes.Count();
        }


        public int GetCountOfRibs()
        {
            return this.ribs.Count();
        }


        public int[,] GetMatrixAdjacency()
        {
            int[,] result = new int[this.vertexes.Count(), this.vertexes.Count()];

            if (this.vertexes != null && this.ribs != null)
            {
                int i = 0;
                int j = 0;

                foreach (Rib rib in ribs)
                {
                    i = this.vertexes.BinarySearch(rib.Start, new Vertex_comparer());
                    j = this.vertexes.BinarySearch(rib.End, new Vertex_comparer());

                    result[i, j] = rib.Value;
                }
            }
            else
                throw new ExceptionDoesNotExist("Graph does not exist");

            return result;
        }
    }
}
