using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using OfficeOpenXml;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace ERPReportApp
{
    public class ReportGenerator
    {
        private readonly DatabaseConnector dbConnector;

        public ReportGenerator()
        {
            dbConnector = new DatabaseConnector();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="procedureName">Stored Procedure</param>
        /// <param name="parameters">Params</param>
        /// <param name="filePath">path to excel file</param>
        public void GenerateExcelReport(string procedureName, string filePath, params SqlParameter[] parameters)
        {
            DataTable data = dbConnector.ExecuteStoredProcedure(procedureName, parameters);
            using (ExcelPackage excel = new ExcelPackage())
            {
                ExcelWorksheet sheet = excel.Workbook.Worksheets.Add("Report");
                sheet.Cells["A1"].LoadFromDataTable(data, true);

                FileInfo file = new FileInfo(filePath);
                excel.SaveAs(file);
            }
        }

        /// <summary>
        /// <param name="procedureName">Stored Procedure</param>
        /// <param name="parameters">Params</param>
        /// <param name="filePath">path to PDF file</param>
        public void GeneratePdfReport(string procedureName, string filePath, params SqlParameter[] parameters)
        {
            DataTable data = dbConnector.ExecuteStoredProcedure(procedureName, parameters);

            Document doc = new Document();
            PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));
            doc.Open();

            PdfPTable table = new PdfPTable(data.Columns.Count);
            foreach (DataColumn column in data.Columns)
            {
                table.AddCell(new PdfPCell(new Phrase(column.ColumnName)));
            }

            foreach (DataRow row in data.Rows)
            {
                foreach (var item in row.ItemArray)
                {
                    table.AddCell(new PdfPCell(new Phrase(item.ToString())));
                }
            }

            doc.Add(table);
            doc.Close();
        }
    }
}
