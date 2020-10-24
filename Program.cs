using lab1.classes;
using lab1.tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Vertex a = new Vertex(101);
            Vertex b = new Vertex(102);
            Vertex c = new Vertex(103);
            Vertex d = new Vertex(104);
            Vertex e = new Vertex(105);
            Vertex h = new Vertex(106);

            List<Vertex> vertexes = new List<Vertex>() { b, a, c, d, h,e };

            Rib ab = new Rib((a, b), 7);
            Rib ad = new Rib((a, d), 1);
            Rib ae = new Rib((a, e), 3);

            Rib bc = new Rib((b, c), 2);
            Rib be = new Rib((b, e), 37);

            Rib ca = new Rib((c,a), 20);
            Rib cd = new Rib((c,d), 1);

            Rib dc = new Rib((d,c), 1);
            Rib de = new Rib((d,e), 10);
            Rib db = new Rib((d,b), 5);

            Rib ea = new Rib((e,a), 3);
            Rib ec = new Rib((e,c), 1);


            List<Rib> ribs = new List<Rib> { ab, ad, ae, bc, be, ca, cd, dc, de, db, ea, ec };

             Graph graph = new Graph(vertexes, ribs);

            
                        (int[,], string) dekstra = DekstraAlgoritm.Algoritm(graph,(c,a));


                      //  int[,] tab = dekstra.Item1;

                        Console.WriteLine(dekstra.Item2);
            

            Console.WriteLine("okk");
            




            Console.ReadKey();

        
        }
    }
}
