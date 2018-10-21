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
    class Sheet
    {
        private string name;
        private uint sheetId;
        private string id;

        public string Name { get { return this.name; } }
        public uint SheetId { get { return this.sheetId; } }
        public string Id { get { return this.id; } }

        public Sheet(string name, uint sheetId, string id)
        {
            this.name = name;
            this.sheetId = sheetId;
            this.id = id;
        }
    }

    class SheetCollection : ReadOnlyCollection<Spreadsheet.Sheet>
    {
        public SheetCollection(IList<Spreadsheet.Sheet> list) : base(list)
        {


        }

        internal void AddSheet(Spreadsheet.Sheet sheet)
        {
            
        }
    }

    class Workbook
    {
        private SheetCollection sheets;

        public Workbook()
        {
            this.sheets = new SheetCollection(new List<Spreadsheet.Sheet>());
            
        }
    }
}

namespace DevEx.OOXml
{
    class SpreadsheetFile : IDisposable
    {
        private FileInfo fileSystemInfo = null;
        private SpreadsheetDocument documentXmlPackage = null;

        public FileInfo FileSystemInfo { get => fileSystemInfo; }
        public SpreadsheetDocument DocumentXmlPackage { get => documentXmlPackage; }

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
