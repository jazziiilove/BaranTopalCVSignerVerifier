// Type: iTextSharp.text.pdf.security.CertificateVerifier
// Assembly: itextsharp, Version=5.5.10.0, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// Assembly location: C:\Users\Baran.Topal\Downloads\itextsharp-all-5.5.10\itextsharp-dll-core\itextsharp.dll

using Org.BouncyCastle.X509;
using System;
using System.Collections.Generic;

namespace iTextSharp.text.pdf.security
{
    public class CertificateVerifier
    {
        /// The previous CertificateVerifier in the chain of verifiers.
        protected CertificateVerifier verifier;

        /// Indicates if going online to verify a certificate is allowed.
        protected bool onlineCheckingAllowed;

        /// Creates the CertificateVerifier in a chain of verifiers.
        ///             @param verifier	the previous verifier in the chain
        public CertificateVerifier(CertificateVerifier verifier);

        /// Checks the validity of the certificate, and calls the next
        ///             verifier in the chain, if any.
        ///             @param signCert	the certificate that needs to be checked
        ///             @param issuerCert	its issuer
        ///             @param signDate		the date the certificate needs to be valid
        ///             @return a list of
        /// <code>
        /// VerificationOK
        /// </code>
        /// objects.
        ///             The list will be empty if the certificate couldn't be verified.
        ///             @throws GeneralSecurityException
        ///             @throws IOException
        public virtual List<VerificationOK> Verify(X509Certificate signCert, X509Certificate issuerCert, DateTime signDate);

        /// Decide whether or not online checking is allowed.
        ///             @param onlineCheckingAllowed
        public virtual bool OnlineCheckingAllowed { set; }
    }
}
