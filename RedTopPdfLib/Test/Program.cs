using RedTopDev.EmailHelper;
using RedTopPdfLib;
using System.Collections.Generic;
namespace Test
{
    /// <summary>
    /// Test program to check the pdf and email helpers.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        static void Main(string[] args)
        {
            //we can use adobe acrobat or freeware
            //https://www.pdfescape.com to edit and add acrofields to the pdf template.

            string pdfTemplate = @"Source File Location/CAHE_Form_NYC.pdf";

            string newFile = @"TargetFileLocation\PDFName.pdf";
         
            //create a key value pairs for replacing the AcroFields defined in the template.
            //A
            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
            keyValuePairs.Add("NYCID", "S     U     J     A     Y");
            keyValuePairs.Add("Sex_Male", "Yes");
            keyValuePairs.Add("ChildLastName", "TestChLastName");
            keyValuePairs.Add("FirstName", "TestFirstName");
            keyValuePairs.Add("MiddleName", "TestLastName");
            PDFHelper helper = new PDFHelper();
            helper.ReplacePdfMacros(pdfTemplate, newFile, keyValuePairs);

            Mail mail = new Mail();
            // from email address.
            mail.From = new System.Net.Mail.MailAddress ("sujaykondanekar@gmail.com");
            mail.To = new System.Net.Mail.MailAddressCollection();
            // to address 
            mail.To.Add("sujaykondanekar@gmail.com");
            mail.Host = "smtp.gmail.com"; //currently using gmail for testing purposes.
            mail.Port = 587; //gmail smtp default port.
            mail.Attachments = new List<string>() { newFile } ; //Attach the newly filled pdf file.          
            mail.EnableSSL = true;
            mail.Authenticate = true;
            mail.UserName = "sujaykondanekar"; // your gmail username
            mail.Password = ""; // gmail password or app password
            Email email = new Email();
            email.SendEmail(mail);

        }
    }
}
