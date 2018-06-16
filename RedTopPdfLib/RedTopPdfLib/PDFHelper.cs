using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;

namespace RedTopPdfLib
{
    /// <summary>
    /// PDF form filler
    /// </summary>
    public class PDFHelper
    {
        /// <summary>
        /// Replaces the PDF macros. Also known as AcroFields.
        /// </summary>
        /// <param name="pdfTemplate">The PDF template.</param>
        /// <param name="targetPdfPath">The target PDF path.</param>
        /// <param name="keyValuePairs">The key value pairs. It contains the AcroField Key and What its value needs to be</param>
        /// <exception cref="ApplicationException">Source PDF template is not available. Please verify</exception>
        public void ReplacePdfMacros(string pdfTemplate,string targetPdfPath, Dictionary<string, string> keyValuePairs)
        {
            if (!File.Exists(pdfTemplate))
            {
                throw new ApplicationException("Source PDF template is not available. Please verify");
            }
            string fileNameExisting = pdfTemplate;
            using (FileStream newFileStream = new FileStream(targetPdfPath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                using (var existingFileStream = new FileStream(fileNameExisting, FileMode.Open))
                {
                    // Open existing PDF template
                    var pdfReader = new PdfReader(existingFileStream);

                    // PdfStamper, which will create
                    var stamper = new PdfStamper(pdfReader, newFileStream);

                    var form = stamper.AcroFields;
                    var fieldKeys = form.Fields.Keys;

                    foreach (var item in keyValuePairs)
                    {
                        form.SetField(item.Key, item.Value);
                    }

                    // "Flatten" the form so it wont be editable/usable anymore
                    stamper.FormFlattening = true;

                    stamper.Close();
                    pdfReader.Close();
                }
            }            
        }       
    }
}
