/* 
 * Programmer: Baran Topal                   *
 * Solution name: BaranTopalCVSigner         * 
 * Project name: BaranTopalCVSigner          *
 * File name: Sign.cs                        *
 *                                           *      
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 *	                                                                                         *
 *  LICENSE: This source file is subject to have the protection of GNU General               *
 *	Public License. You can distribute the code freely but storing this license information. *
 *	Contact Baran Topal if you have any questions. barantopal@barantopal.com                 *
 *	                                                                                         *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Org.BouncyCastle.Pkcs;
using Org.BouncyCastle.X509;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.security;


/*
 * Unfortunately, jks store is not really recognized in .NET implementation of itext so we need to convert it to pfx as follows:
 * Note that the jks store I used before has a certificate which has expired, so I regenerate the certificate in jks, THEN I convert the jks file to pfx
 * 
 * 
 * C:\Program Files\Java\jdk1.8.0_121\bin>keytool -importkeystore -srckeystore "C:\Users\Baran.Topal\Desktop\BaranTopalCVSigner\BaranTopalCVSigner\BaranTopalCVSigner\keystore2.jks" -srcstoretype JKS -srcstorepass barantopal -destkeystore "C:\Users\Baran.Topal\Desktop\BaranTopalCVSigner\BaranTopalCVSigner\BaranTopalCVSigner\keystore2.pfx" -deststoretype PKCS12 -deststorepass barantopal
 * Entry for alias another_selfsigned successfully imported.
 *  Import command completed:  1 entries successfully imported, 0 entries failed or cancelled
 *  
 * We sign with our private key and verification is done by our public key (the certificate). We need to generate a .der file for this need as follows:
 * PS C:\Users\Baran.Topal\Desktop\BaranTopalCVSigner\BaranTopalCVSigner\BaranTopalCVSigner> Get-PfxCertificate -FilePath keystore2.pfx | 

 * Export-Certificate -FilePath OutputCert.der -Type CERT
 * Enter password: 


 *   Directory: C:\Users\Baran.Topal\Desktop\BaranTopalCVSigner\BaranTopalCVSigner\BaranTopalCVSigner


Mode                LastWriteTime         Length Name                                                                                                                    
----                -------------         ------ ----                                                                                                                    
-a----       2017-07-07     16:03            928 OutputCert.der                                                                                                          

 */

namespace BaranTopalCVSigner
{
    class Sign
    {

        public static string SourceFilePath = "MyFirstPDF.pdf";
        public static string DestinationFilePath = "MyFirstPDF_signed.pdf";
        readonly private List<X509Certificate> _certificates = new List<X509Certificate>();
        public void VerifySignature()
        {

            var parser = new X509CertificateParser();

            var fileStream = new FileStream("../../OutputCert.der", FileMode.Open, FileAccess.Read);
            var certificate = parser.ReadCertificate(fileStream);
            _certificates.Add(certificate);
            fileStream.Flush();
            fileStream.Close();

            var reader = new PdfReader(DestinationFilePath);
            var af = reader.AcroFields;
            var names = af.GetSignatureNames();

            if (names.Count == 0)
            {
                Console.WriteLine("No Signature present in pdf file.");
            }
            foreach (var name in names)
            {
                Console.WriteLine("Name: " + name);
            }

            foreach (string name in names)
            {
                if (!af.SignatureCoversWholeDocument(name))
                {
                    throw new InvalidOperationException(string.Format("The signature: {0} does not covers the whole document.", name));
                }

                var pk = af.VerifySignature(name);

                var cal = pk.SignDate;
                var certs = pk.Certificates;
                // certs = pk.SignCertificateChain;                

                if (!pk.Verify())
                {
                    Console.WriteLine("The signature is not valid.");
                }
                else
                {
                    Console.WriteLine("The signature is valid.");
                }

                try
                {
                    /*
                    String s = CertificateVerification.VerifyCertificate(certs[0], null, cal);

                    if(s == null)
                    {
                        Console.WriteLine("OK!");
                    }
                    else
                    {
                        Console.WriteLine("S: " + s);
                    }
                    */
                    /*
                    IList<VerificationException> errors = CertificateVerification.VerifyCertificates(certs, certificates, null, cal);

                    if (errors == null)
                    {
                        Console.WriteLine("Certificates are verified against the keyStore");
                    }
                    else
                    {
                        Console.WriteLine("Certificates are not verified because ");
                        foreach (object error in errors)
                        {
                            Console.WriteLine(error);
                        }
                    }
                     * */

                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                }

            }
        }

        public void SignIt()
        {

            var fileStream = new FileStream("../../keystore2.pfx", FileMode.Open, FileAccess.Read);

            var pk12 = new Pkcs12Store(fileStream, "barantopal".ToCharArray());
            fileStream.Flush();
            fileStream.Close();

            string alias = null;
            // a loop is not super need here but well because we have 1 certificate entry that corresponds to a private key
            foreach (string tAlias in pk12.Aliases)
            {
                if (pk12.IsKeyEntry(tAlias))
                {
                    alias = tAlias;
                    break;
                }
            }
            var pk = pk12.GetKey(alias).Key;

            // reader and stamper
            var reader = new PdfReader(SourceFilePath);
            using (var fout = new FileStream(DestinationFilePath, FileMode.Create, FileAccess.ReadWrite))
            {
                using (PdfStamper stamper = PdfStamper.CreateSignature(reader, fout, '\0'))
                {
                    // appearance
                    PdfSignatureAppearance appearance = stamper.SignatureAppearance;
                    //appearance.Image = new iTextSharp.text.pdf.PdfImage();
                    appearance.Reason = "I've written this.";
                    appearance.Location = "Foobar";
                    appearance.SetVisibleSignature(new iTextSharp.text.Rectangle(20, 10, 170, 60), 1, "Icsi-Vendor");
                    // digital signature
                    IExternalSignature es = new PrivateKeySignature(pk, "SHA-256");
                    MakeSignature.SignDetached(appearance, es, new X509Certificate[] { pk12.GetCertificate(alias).Certificate }, null, null, null, 0, CryptoStandard.CMS);

                    stamper.Close();
                }
            }
        }
        public void CreatePDF()
        {
            var doc = new Document(PageSize.A4);
            var output = new FileStream(SourceFilePath, FileMode.Create);
            var writer = PdfWriter.GetInstance(doc, output);

            doc.Open();

            var logo = iTextSharp.text.Image.GetInstance("../../hal.gif");

            logo.SetAbsolutePosition(430, 770);
            logo.ScaleAbsoluteHeight(30);
            logo.ScaleAbsoluteWidth(70);
            doc.Add(logo);

            PdfPTable table1 = new PdfPTable(2);
            table1.DefaultCell.Border = 0;
            table1.WidthPercentage = 80;


            PdfPCell cell11 = new PdfPCell();
            cell11.Colspan = 1;

            Font titleFont = new Font();
            titleFont.SetFamily("Blablablabla");

            Font subTitleFont = new Font();
            subTitleFont.SetFamily("Times New Roman");

            cell11.AddElement(new Paragraph("Baran Topal", titleFont));

            cell11.AddElement(new Paragraph("Thanks for looking at Baran Topal's CV, here you can see below", subTitleFont));


            cell11.VerticalAlignment = Element.ALIGN_LEFT;

            PdfPCell cell12 = new PdfPCell();


            cell12.VerticalAlignment = Element.ALIGN_CENTER;


            table1.AddCell(cell11);

            table1.AddCell(cell12);


            PdfPTable table2 = new PdfPTable(3);

            //One row added

            PdfPCell cell21 = new PdfPCell();

            cell21.AddElement(new Paragraph("Education"));

            PdfPCell cell22 = new PdfPCell();

            cell22.AddElement(new Paragraph("Year"));

            PdfPCell cell23 = new PdfPCell();

            cell23.AddElement(new Paragraph("Grade"));


            table2.AddCell(cell21);

            table2.AddCell(cell22);

            table2.AddCell(cell23);


            //New Row Added

            PdfPCell cell31 = new PdfPCell();

            cell31.AddElement(new Paragraph("KTH"));

            cell31.FixedHeight = 300.0f;

            PdfPCell cell32 = new PdfPCell();

            cell32.AddElement(new Paragraph("ICSS"));

            cell32.FixedHeight = 300.0f;

            PdfPCell cell33 = new PdfPCell();

            cell33.AddElement(new Paragraph("Well done"));

            cell33.FixedHeight = 300.0f;

            table2.AddCell(cell31);

            table2.AddCell(cell32);

            table2.AddCell(cell33);

            PdfPCell cell2A = new PdfPCell(table2);

            cell2A.Colspan = 2;

            table1.AddCell(cell2A);

            PdfPCell cell41 = new PdfPCell();

            cell41.AddElement(new Paragraph("School : " + "SU"));

            cell41.AddElement(new Paragraph("Dept : " + "SBS"));

            cell41.VerticalAlignment = Element.ALIGN_LEFT;

            table1.AddCell(cell41);

            doc.Add(table1);

            doc.Close();

        }
    }
}
