using lab1.classes;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using _Excel = Microsoft.Office.Interop.Excel;

namespace lab1.parts
{
    class Excel
    {

        private string path;
        private _Application excel;
        private Workbook wb;
        private Worksheet ws;


        public Excel() 
        {
            excel = new _Excel.Application();
        }

        public Excel(string path, int sheet)
        {
            this.path = path;
            excel = new _Excel.Application();
            wb = excel.Workbooks.Open(path);
            ws = wb.Worksheets[sheet];
        }
        

        public void CreatFile()
        {
            this.wb = this.excel.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
            this.ws = this.wb.Worksheets[1];
        }

        public void CreateNewSheet()
        {
            Worksheet new_sheet = wb.Worksheets.Add(After: this.ws);
            this.ws = wb.Worksheets[1];
        }

        public object ReadCell(int row, int column)
        {
            row++;
            column++;

            if (ws.Cells[row, column] != null)
                return ws.Cells[row, column].Value2;
            else
                return null;
        }


        public string[,] ReadRange(int row, int column_start, int column_end)
        {
            Range range = (Range)ws.Range[ws.Cells[row, column_start], ws.Cells[row, column_end]];
            object[,] tmp = range.Value2;
            string[,] result = new string[1,column_end - column_start+1];
            for(int i=1;i< tmp.Length;i++)
                result[0,i - 1] = tmp[1,i].ToString();

            return result;
        }

        public void WriteToCell(int row, int column, int data)
        {
            row++;
            column++;
            this.ws.Cells[row, column].Value2 = data;
        }

        public void WriteToCell(int row, int column, Vertex data)
        {
            row++;
            column++;
            ws.Cells[row, column].Value2 = data.Name;
        }

        public void WriteRange(int row_start, int column_start, int row_end, int column_end, int[,]data)
        {
            Range range = (Range)ws.Range[ws.Cells[row_start, column_start], ws.Cells[row_end, column_end]];
            range.Value2 = data;
        }


        public void Save()
        {
            wb.Save();
        }

        public void SaveAs(string path)
        {
            wb.SaveAs(path);
        }

        public void Close()
        {
            wb.Close();
        }
    }

}
