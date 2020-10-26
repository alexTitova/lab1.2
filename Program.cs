using lab1.classes;
using lab1.parts;
using lab1.tasks;
using Microsoft.Office.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    class Program
    {
        
        

        static void Main(string[] args)
        {

                      Graph graph = parts.CreateG.CreateGraph();
                      (int[,], List<Vertex>) dekstra = tasks.DekstraAlgoritm.Algoritm(graph, (new Vertex(103),new Vertex(101)));


                      Excel excel = new Excel();
                      excel.CreatFile();

            excel.WriteRange(1, 1, 6, 6, dekstra.Item1);
                      excel.SaveAs(@"DataLab2.xlsx");  
            excel.Close();

            Console.WriteLine("okk");
            Console.ReadKey();

        
        }
    }
}
