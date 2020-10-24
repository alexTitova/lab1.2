using lab1.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1.parts
{
    class ExtraFuncListVertex
    {

        // возвращает непроверенную вершину isChecked=false с минимальной mark
        public static Vertex FindMinMark(List<Vertex> data)
        {
            Vertex result = new Vertex(0,int.MaxValue);

            for(int i=0;i<data.Count();i++)
            {
                if (result.Mark > data[i].Mark && !data[i].IsChecked)
                    result = data[i];
            }

            return result;
        }


        //заменяет встроенный бинарный поиск
        public static int FindIndexEndOfRib(List<Vertex> data, Vertex unit)
        {
            int result = -1;

            foreach(Vertex vertex in data)
            {
                result++;

                if (vertex == unit)
                    break;
            }

            return result;
        }
    }
}
