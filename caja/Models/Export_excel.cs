using System;
using System.Data;
using System.Diagnostics;
using System.IO;

namespace caja.Models
{
	public class Export_excel
	{
		public void ExportToExcel(DataTable table, string path) {
			Microsoft.Office.Interop.Excel.Application objexcelapp = new Microsoft.Office.Interop.Excel.Application();
			objexcelapp.Application.Workbooks.Add(Type.Missing);
			objexcelapp.Columns.AutoFit();
			for (int i = 1; i < table.Columns.Count + 1; i++) {
				Microsoft.Office.Interop.Excel.Range xlRange = (Microsoft.Office.Interop.Excel.Range)objexcelapp.Cells[1, i];
				xlRange.Font.Bold = -1;
				xlRange.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
				xlRange.Borders.Weight = 1d;
				xlRange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
				objexcelapp.Cells[1, i] = table.Columns[i - 1].ColumnName;
			}

			for (int i = 0; i < table.Rows.Count; i++) {
				for (int j = 0; j < table.Columns.Count; j++) {
					if (table.Rows[i][j] != null) {
						Microsoft.Office.Interop.Excel.Range xlRange = (Microsoft.Office.Interop.Excel.Range)objexcelapp.Cells[i + 2, j + 1];
						xlRange.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
						xlRange.Borders.Weight = 1d;
						objexcelapp.Cells[i + 2, j + 1] = table.Rows[i][j].ToString();
					}
				}
			}

			objexcelapp.Columns.AutoFit(); // Auto fix the columns size
			System.Windows.Forms.Application.DoEvents();
			
			objexcelapp.ActiveWorkbook.SaveCopyAs( path + ".xlsx");
			
			objexcelapp.ActiveWorkbook.Saved = true;
			System.Windows.Forms.Application.DoEvents();
			foreach (Process proc in System.Diagnostics.Process.GetProcessesByName("EXCEL"))
			{
				proc.Kill();
			}
		}
	}
}
