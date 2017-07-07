// Type: iTextSharp.text.pdf.security.CertificateVerification
// Assembly: itextsharp, Version=5.5.10.0, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// Assembly location: C:\Users\Baran.Topal\Downloads\itextsharp-all-5.5.10\itextsharp-dll-core\itextsharp.dll

using Org.BouncyCastle.Ocsp;
using Org.BouncyCastle.Tsp;
using Org.BouncyCastle.X509;
using System;
using System.Collections.Generic;

namespace iTextSharp.text.pdf.security
{
    /// This class consists of some methods that allow you to verify certificates.
    public static class CertificateVerification
    {
        /// Verifies a single certificate.
        ///             @param cert the certificate to verify
        ///             @param crls the certificate revocation list or <CODE>null</CODE>@param calendar the date or <CODE>null</CODE>for the current date
        ///             @return a <CODE>String</CODE>with the error description or <CODE>null</CODE>if no error
        public static string VerifyCertificate(X509Certificate cert, ICollection<X509Crl> crls, DateTime calendar);

        /// Verifies a certificate chain against a KeyStore.
        ///             @param certs the certificate chain
        ///             @param keystore the <CODE>KeyStore</CODE>@param crls the certificate revocation list or <CODE>null</CODE>@param calendar the date or <CODE>null</CODE>for the current date
        ///             @return <CODE>null</CODE>if the certificate chain could be validated or a
        ///             <CODE>Object[]{cert,error}</CODE>where <CODE>cert</CODE>is the
        ///             failed certificate and <CODE>error</CODE>is the error message
        public static IList<VerificationException> VerifyCertificates(ICollection<X509Certificate> certs, ICollection<X509Certificate> keystore, ICollection<X509Crl> crls, DateTime calendar);

        /// Verifies a certificate chain against a KeyStore.
        ///             @param certs the certificate chain
        ///             @param keystore the <CODE>KeyStore</CODE>@param calendar the date or <CODE>null</CODE>for the current date
        ///             @return <CODE>null</CODE>if the certificate chain could be validated or a
        ///             <CODE>Object[]{cert,error}</CODE>where <CODE>cert</CODE>is the
        ///             failed certificate and <CODE>error</CODE>is the error message
        public static IList<VerificationException> VerifyCertificates(ICollection<X509Certificate> certs, ICollection<X509Certificate> keystore, DateTime calendar);

        /// Verifies an OCSP response against a KeyStore.
        ///             @param ocsp the OCSP response
        ///             @param keystore the <CODE>KeyStore</CODE>@param provider the provider or <CODE>null</CODE>to use the BouncyCastle provider
        ///             @return <CODE>true</CODE>is a certificate was found
        public static bool VerifyOcspCertificates(BasicOcspResp ocsp, ICollection<X509Certificate> keystore);

        /// Verifies a time stamp against a KeyStore.
        ///             @param ts the time stamp
        ///             @param keystore the <CODE>KeyStore</CODE>@param provider the provider or <CODE>null</CODE>to use the BouncyCastle provider
        ///             @return <CODE>true</CODE>is a certificate was found
        public static bool VerifyTimestampCertificates(TimeStampToken ts, ICollection<X509Certificate> keystore);
    }
}
