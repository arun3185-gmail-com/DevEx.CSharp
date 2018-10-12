using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

public class ExcelHelper
{
    static char[] alphas = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
    DocumentFormat.OpenXml.Packaging.SpreadsheetDocument xlDoc = null;
    DocumentFormat.OpenXml.Packaging.WorkbookPart wbPart = null;

    public void CreateExcel(string xlFilePath)
    {
        FileInfo xlFileInfo = new FileInfo(xlFilePath);
        if (xlFileInfo.Exists) xlFileInfo.Delete();

        xlDoc = SpreadsheetDocument.Create(xlFilePath, SpreadsheetDocumentType.Workbook);
        wbPart = xlDoc.AddWorkbookPart();
        wbPart.Workbook = new Workbook();
    }

    public void LoadData(string sheetName, uint sheetId, DataTable dt)
    {
        DocumentFormat.OpenXml.Packaging.WorksheetPart wsPart = null;
        DocumentFormat.OpenXml.Spreadsheet.SheetData sheetData = null;
        DocumentFormat.OpenXml.Spreadsheet.Sheets sheets = null;
        DocumentFormat.OpenXml.Spreadsheet.Sheet sheet = null;
        uint rowIndex = 1;
        uint colIndex = 1;
        string collName = string.Empty;
        Row row = null;
        Cell cell = null;

        sheetData = new SheetData();

        // Header Row
        row = new Row() { RowIndex = rowIndex };
        sheetData.Append(row);

        // Header Row cellls
        foreach (DataColumn dc in dt.Columns)
        {
            collName = ExcelHelper.ConvertColumnNumberToName((int)colIndex);

            cell = new Cell() { CellReference = collName + rowIndex };
            row.AppendChild(cell);

            Text txt = new Text();
            txt.Text = dc.ColumnName;
            InlineString inStr = new InlineString();
            inStr.AppendChild(txt);

            cell.DataType = CellValues.InlineString;
            cell.AppendChild(inStr);

            colIndex++;
        }
        rowIndex++;

        foreach (DataRow dr in dt.Rows)
        {
            row = new Row() { RowIndex = rowIndex };
            sheetData.Append(row);

            colIndex = 1;
            foreach (DataColumn dc in dt.Columns)
            {
                collName = ExcelHelper.ConvertColumnNumberToName((int)colIndex);
                cell = new Cell() { CellReference = collName + rowIndex };
                row.AppendChild(cell);

                Text txt = new Text();
                txt.Text = dr[dc.ColumnName].ToString();
                InlineString inStr = new InlineString();
                inStr.AppendChild(txt);

                cell.DataType = CellValues.InlineString;
                cell.AppendChild(inStr);

                colIndex++;
            }

            rowIndex++;
        }

        wsPart = wbPart.AddNewPart<WorksheetPart>();
        wsPart.Worksheet = new Worksheet(sheetData);

        sheet = new Sheet();
        sheet.Id = wbPart.GetIdOfPart(wsPart);
        sheet.SheetId = sheetId;
        sheet.Name = sheetName;

        sheets = wbPart.Workbook.AppendChild(new Sheets());
        sheets.Append(sheet);
    }

    public void Save()
    {
        if (wbPart != null)
        {
            wbPart.Workbook.Save();
        }

        if (xlDoc != null)
        {
            xlDoc.Close();
            xlDoc.Dispose();
        }
    }

    public static string ConvertColumnNumberToName(int number)
    {
        if (number < 1) { throw new ApplicationException("number must be greater than or equal to 1"); }

        int mod = number % 26;
        int coefOf26 = (number - mod) / 26;
        int coefOf676 = (number - (26 * coefOf26) - mod) / 676;
        StringBuilder colNameBuilder = new StringBuilder(3);

        if (coefOf676 == 0) colNameBuilder.Append(alphas[25]);
        else if (coefOf676 > 0) colNameBuilder.Append(alphas[mod - 1]);

        if (coefOf26 == 0) colNameBuilder.Append(alphas[25]);
        else if (coefOf26 > 0) colNameBuilder.Append(alphas[mod - 1]);

        if (mod == 0) colNameBuilder.Append(alphas[25]);
        else if (mod > 0) colNameBuilder.Append(alphas[mod - 1]);

        return colNameBuilder.ToString();
    }

    public static int ConvertColumnNameToNumber(string name)
    {
        int colNameLength = name.Length;
        int number = 0;

        if (colNameLength >= 1) number += Array.IndexOf(alphas, name[colNameLength - 1]) + 1;
        if (colNameLength >= 2) number += 26 * (Array.IndexOf(alphas, name[colNameLength - 2]) + 1);
        if (colNameLength >= 3) number += 676 * (Array.IndexOf(alphas, name[colNameLength - 3]) + 1);

        return number;
    }
}