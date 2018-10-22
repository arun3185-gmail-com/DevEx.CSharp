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
        private string name;
        private uint sheetId;
        private string id;

        public string Name { get { return this.name; } }
        public uint SheetId { get { return this.sheetId; } }
        public string Id { get { return this.id; } }

        internal Sheet(string name, uint sheetId, string id)
        {
            this.name = name;
            this.sheetId = sheetId;
            this.id = id;
        }
    }

    public class SheetCollection : IEnumerable<Spreadsheet.Sheet>
    {
        private List<Spreadsheet.Sheet> list = null;

        internal SheetCollection()
        {
            this.list = new List<Sheet>();
        }

        internal SheetCollection(IList<Sheet> list) : this()
        {
            using (IEnumerator<Sheet> enumerator = list.GetEnumerator())
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

        internal void Add(Sheet item)
        {
            this.list.Add(item);
        }

        internal void Clear()
        {
            this.list.Clear();
        }

        public bool Contains(Sheet item)
        {
            return this.list.Contains(item);
        }

        public void CopyTo(Sheet[] array, int arrayIndex)
        {
            this.list.CopyTo(array, arrayIndex);
        }

        public IEnumerator<Sheet> GetEnumerator()
        {
            return this.list.GetEnumerator();
        }

        internal bool Remove(Sheet item)
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
        private SheetCollection sheets;

        public SheetCollection Sheets
        {
            get { return sheets; }
        }

        internal Workbook(ref SpreadsheetDocument spreadsheetDocument)
        {
            this.sheets = new SheetCollection();
        }

        public void AddSheet(Sheet item)
        {


            this.sheets.Add(item);
        }

        public bool RemoveSheet(Sheet item)
        {
            bool pkgSheetRemoved = false;

            return this.sheets.Remove(item) & pkgSheetRemoved;
        }
    }
}

namespace DevEx.OOXml
{
    public class SpreadsheetFile : IDisposable
    {
        private FileInfo fileSystemInfo = null;
        private SpreadsheetDocument documentXmlPackage = null;
        private Spreadsheet.Workbook workBook = null;

        public FileInfo FileSystemInfo { get => fileSystemInfo; }
        public SpreadsheetDocument DocumentXmlPackage { get => documentXmlPackage; }
        public Spreadsheet.Workbook WorkBook { get => workBook; }

        private SpreadsheetFile(string filePath)
        {
            this.fileSystemInfo = new FileInfo(filePath);
        }

        public static SpreadsheetFile NewSpreadsheetFile(string filePath, SpreadsheetDocumentType documentType)
        {
            try
            {
                SpreadsheetFile newFile = new SpreadsheetFile(filePath);
                newFile.documentXmlPackage = SpreadsheetDocument.Create(filePath, documentType);
                WorkbookPart wbPart = newFile.documentXmlPackage.AddWorkbookPart();
                wbPart.Workbook = new Workbook();

                newFile.workBook = new Spreadsheet.Workbook(ref newFile.documentXmlPackage);

                return newFile;
            }
            catch { throw; }
        }

        public static SpreadsheetFile LoadSpreadsheetFile(string filePath, bool isEditable)
        {
            try
            {
                SpreadsheetFile newFile = new SpreadsheetFile(filePath);
                newFile.documentXmlPackage = SpreadsheetDocument.Open(filePath, isEditable);

                return newFile;
            }
            catch { throw; }
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
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~SpreadsheetFile() {
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
