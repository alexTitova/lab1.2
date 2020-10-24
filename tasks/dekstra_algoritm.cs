using lab1.classes;
using lab1.parts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace lab1.tasks
{
    class DekstraAlgoritm
    {

        // функция будет собирать путь
 /*       private static string GetPath(List<Vertex> vertexes, (Vertex,Vertex) path)
        {
            string result;
            List<Vertex> tmp = new List<Vertex>();
            Vertex current_vertex = path.Item2;
            tmp.Add(current_vertex);

            while(current_vertex!=vertexes[0])
            {
                tmp.Add(current_vertex.Dad);
                current_vertex = current_vertex.Dad;
            }

            tmp.Reverse();
            result = tmp.ToString();
            

            return result;
        }
 */



        // функция которая будет записывать в таблицу пути результат построчно
        // тоже надо залочить, потому что индекс j может быть в гонке
        private static void GetPathTable(List<Vertex> vertexes, int[,] path_table, int line)
        {
            vertexes.Sort(new Vertex_comparer());
            for(int j=0;j<vertexes.Count;j++)
            {
                if (vertexes[j].Mark != 1000000)
                    path_table[line, j] = vertexes[j].Mark;
                else
                    path_table[line, j] = 0;
                    
            }
        }


        // проходит как раз этот алгоритм
        // считает новые метки вершин, может быть как раз залочен из-за того, что граф один
        private static void OneStep(List<Vertex>vertexes, Graph graph)
        {
            List<Rib> outgoing_ribs = new List<Rib>();
            Vertex curret_min_mark_vertex = new Vertex();

            for (int ww=0;ww<vertexes.Count();ww++)
            {
                // вычисление непроверенной вершины с минимальной оценкой
                curret_min_mark_vertex = ExtraFuncListVertex.FindMinMark(vertexes);

                //поиск исходящих ребер
                 outgoing_ribs = graph.GetOutgoingRibs(curret_min_mark_vertex);
                foreach (Rib rib in outgoing_ribs)
                {
                    int i = ExtraFuncListVertex.FindIndexEndOfRib(vertexes, rib.End);
                        //vertexes.BinarySearch(rib.End, new Vertex_comparer());
                    // возвращается отрицательный индекс при ребре са при отсчете от вершины b

                    //вычисление новых меток
                    if (rib.Start == vertexes[0])
                    {
                        vertexes[i].Mark = rib.Value;
                        vertexes[i].Dad = curret_min_mark_vertex;
                    }
                    else
                    {
                        if (vertexes[i].Mark > curret_min_mark_vertex.Mark + rib.Value)
                        {
                            vertexes[i].Mark = curret_min_mark_vertex.Mark + rib.Value;
                            vertexes[i].Dad = curret_min_mark_vertex;

                        }
                    }

                }

                curret_min_mark_vertex.IsChecked = true;
            }
        }


        //все вычисления тут происходят параленьно 
        private static void OneStepDekstra(Graph graph, Vertex start, int[,] path_table, string path_vertex, (Vertex, Vertex) path)
        {
            List<Vertex> vertexes = new List<Vertex>();

            //инициализация списка вершин, чтобы не испортить список вершин другим потокам, нулевой элемент это начальная вершина.
            vertexes.Add(new Vertex(start.Name, 0)); 
            foreach (Vertex unit in graph.Vertexes)
            {
                // проверка чтобы начальная вершина была одна
                if (unit != start)
                    vertexes.Add(new Vertex(unit.Name));
            }

            //считает путь от начальной вершины до всех остальных
            OneStep(vertexes, graph);

//            if (start.Name==path.Item1.Name)
//                path_vertex = GetPath(vertexes, path);

            int line = graph.Vertexes.BinarySearch(start, new Vertex_comparer());
            GetPathTable(vertexes, path_table, line);
            

        }



        // функция где будет распарлеливаться вычисления и собераться вместе 
        // возврашать должна таблицу расстояний+последовательность вершин рути между указанными то  есть пару (int[,], string)
        public static (int[,],string) Algoritm(Graph graph,(Vertex,Vertex) path)
        {
            int[,] path_table = new int[graph.GetCountOfVertexes(), graph.GetCountOfVertexes()];
            string path_vertex = "0";

            foreach (Vertex vertex in graph.Vertexes)
            {
                // здесь проходит распралеливание на 3 потока нужен делегат на функцию OneStepDekstra
                OneStepDekstra(graph, vertex, path_table,path_vertex, path);;
            }


            return (path_table, path_vertex);
        }
    }
}
