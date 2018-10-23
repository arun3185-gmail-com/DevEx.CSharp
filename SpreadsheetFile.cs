using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;

using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

namespace DevEx.OOXml.Spreadsheet
{
    public class Sheet
    {
        private DocumentFormat.OpenXml.Packaging.WorksheetPart worksheetPart = null;
        private DocumentFormat.OpenXml.Spreadsheet.Worksheet worksheet = null;
        private DocumentFormat.OpenXml.Spreadsheet.SheetData sheetData = null;
        private DocumentFormat.OpenXml.Spreadsheet.Sheet sheet = null;

        public DocumentFormat.OpenXml.Packaging.WorksheetPart WorksheetPart
        {
            get { return this.worksheetPart; }
        }

        public DocumentFormat.OpenXml.Spreadsheet.Worksheet Worksheet
        {
            get { return this.worksheet; }
        }

        public DocumentFormat.OpenXml.Spreadsheet.SheetData SheetData
        {
            get { return this.sheetData; }
        }
        
        public uint SheetId
        {
            get { return this.sheet.SheetId; }
        }

        public DocumentFormat.OpenXml.StringValue Id
        {
            get { return this.sheet.id; }
        }

        public DocumentFormat.OpenXml.StringValue Name 
        {
            get { return this.sheet.Name; } 
        }

        internal Sheet(ref DocumentFormat.OpenXml.Spreadsheet.Worksheet worksheetPart, ref DocumentFormat.OpenXml.Spreadsheet.Sheet sheet)
        {
            this.worksheetPart = worksheetPart;
            this.worksheet = this.worksheetPart.worksheet;
            this.sheetData = this.worksheet.GetFirstChild<DocumentFormat.OpenXml.Spreadsheet.SheetData>();
            this.sheet = sheet;
        }
    }

    public class SheetCollection : IEnumerable<Spreadsheet.Sheet>
    {
        private DocumentFormat.OpenXml.Packaging.WorkbookPart workbookPart;
        private DocumentFormat.OpenXml.Spreadsheet.Sheets sheets = null;
        private List<Spreadsheet.Sheet> list = null;

        internal SheetCollection(ref DocumentFormat.OpenXml.Packaging.WorkbookPart workbookPart)
        {
            this.workbookPart = workbookPart;
            sheets = this.workbookPart.Workbook.AppendChild(new DocumentFormat.OpenXml.Spreadsheet.Sheets());
            this.list = new List<Spreadsheet.Sheet>();
        }

        internal SheetCollection(ref DocumentFormat.OpenXml.Packaging.WorkbookPart workbookPart, IList<Spreadsheet.Sheet> list) : this(ref workbookPart)
        {
            using (IEnumerator<Spreadsheet.Sheet> enumerator = list.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    this.Add(enumerator.Current);
                }
            }
        }

        public int Count
        {
            get { return this.list.Count; }
        }

        public bool IsReadOnly
        {
            get { return true; }
        }

        internal void Add(Spreadsheet.Sheet item)
        {
            this.list.Add(item);
        }

        internal void Clear()
        {
            this.list.Clear();
        }

        public bool Contains(Spreadsheet.Sheet item)
        {
            return this.list.Contains(item);
        }

        public void CopyTo(Spreadsheet.Sheet[] array, int arrayIndex)
        {
            this.list.CopyTo(array, arrayIndex);
        }

        public IEnumerator<Spreadsheet.Sheet> GetEnumerator()
        {
            return this.list.GetEnumerator();
        }

        internal bool Remove(Spreadsheet.Sheet item)
        {
            return this.list.Remove(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.list.GetEnumerator();
        }
    }

    public class Workbook
    {
        private SpreadsheetDocument spreadsheetDocument;
        private DocumentFormat.OpenXml.Packaging.WorkbookPart workbookPart;
        private Spreadsheet.SheetCollection sheetCollection;

        public SheetCollection Sheets
        {
            get { return sheets; }
        }

        internal Workbook(ref SpreadsheetDocument spreadsheetDocument)
        {
            this.spreadsheetDocument = spreadsheetDocument;
            this.workbookPart = this.spreadsheetDocument.AddWorkbookPart();
            this.workbookPart.Workbook = new DocumentFormat.OpenXml.Spreadsheet.Workbook();
            
            this.sheetCollection = new Spreadsheet.SheetCollection(ref this.workbookPart);
        }

        public void AddSheet(string name)
        {
            DocumentFormat.OpenXml.Packaging.WorksheetPart wsPart = wbPart.AddNewPart<DocumentFormat.OpenXml.Packaging.WorksheetPart>();
            wsPart.Worksheet = new DocumentFormat.OpenXml.Spreadsheet.Worksheet(new DocumentFormat.OpenXml.Spreadsheet.SheetData());
            
            DocumentFormat.OpenXml.Spreadsheet.Sheet sheet = new DocumentFormat.OpenXml.Spreadsheet.Sheet();
            sheet.Id = workbookPart.GetIdOfPart(wsPart);
            sheet.SheetId = sheetId;
            sheet.Name = sheetName;
            
            Spreadsheet.Sheet newSheet = new Spreadsheet.Sheet(ref wsPart, ref sheet);
            this.sheets.Add(newSheet);
        }

        public bool RemoveSheet(Spreadsheet.Sheet item)
        {
            bool pkgSheetRemoved = false;

            return (this.sheets.Remove(item) & pkgSheetRemoved);
        }
    }
}

namespace DevEx.OOXml
{
    public class SpreadsheetFile : IDisposable
    {
        static char[] alphas = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

        private FileInfo fileSystemInfo = null;
        private SpreadsheetDocument documentXmlPackage = null;
        private Spreadsheet.Workbook workbook = null;

        public FileInfo FileSystemInfo { get => this.fileSystemInfo; }
        public SpreadsheetDocument DocumentXmlPackage { get => this.documentXmlPackage; }
        public Spreadsheet.Workbook Workbook { get => this.workbook; }

        private SpreadsheetFile(string filePath)
        {
            this.fileSystemInfo = new FileInfo(filePath);
        }

        public static SpreadsheetFile NewSpreadsheetFile(string filePath, SpreadsheetDocumentType documentType)
        {
            try
            {
                SpreadsheetFile newFile = new SpreadsheetFile(filePath);
                if (newFile.fileSystemInfo.Exists)
                {
                    throw new Exception("file already exist in the given path");
                }
                newFile.documentXmlPackage = SpreadsheetDocument.Create(filePath, documentType);
                newFile.AddWorkbook();

                return newFile;
            }
            catch { throw; }
        }

        public static SpreadsheetFile LoadSpreadsheetFile(string filePath, bool isEditable)
        {
            try
            {
                SpreadsheetFile newFile = new SpreadsheetFile(filePath);
                if (newFile.fileSystemInfo.Exists)
                {
                    newFile.documentXmlPackage = SpreadsheetDocument.Open(filePath, isEditable);
                }
                else
                {
                    throw new Exception("file does not exist in the given path");
                }
                

                return newFile;
            }
            catch { throw; }
        }

        private void AddWorkbook()
        {
            if (this.workbook == null)
            {
                this.workbook = new Spreadsheet.Workbook(ref this.documentXmlPackage);
            }
        }

        public void Save()
        {
            this.documentXmlPackage.WorkbookPart.Workbook.Save();
        }

        public void Close()
        {
            this.documentXmlPackage.Close();
        }

        public static string ConvertColumnNumberToName(int number)
        {
            if (number < 1) { throw new ArgumentOutOfRangeException("number", "value must be greater than or equal to 1"); }
            
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

        #region IDisposable Support

        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    documentXmlPackage.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~SpreadsheetFile()
        // {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }

        #endregion
    }
}
