// Type: Org.BouncyCastle.X509.X509CertificateParser
// Assembly: itextsharp, Version=5.5.10.0, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// Assembly location: C:\Users\Baran.Topal\Downloads\itextsharp-all-5.5.10\itextsharp-dll-core\itextsharp.dll

using Org.BouncyCastle.Asn1.X509;
using System.Collections;
using System.IO;

namespace Org.BouncyCastle.X509
{
    /// class for dealing with X509 certificates.
    ///             <p>At the moment this will deal with "-----BEGIN CERTIFICATE-----" to "-----END CERTIFICATE-----"
    ///             base 64 encoded certs, as well as the BER binaries of certificates and some classes of PKCS#7
    ///             objects.</p>
    public class X509CertificateParser
    {
        public X509CertificateParser();
        protected virtual X509Certificate CreateX509Certificate(X509CertificateStructure c);

        /// <summary>
        /// Create loading data from byte array.
        /// 
        /// </summary>
        /// <param name="input"/>
        public X509Certificate ReadCertificate(byte[] input);

        /// <summary>
        /// Create loading data from byte array.
        /// 
        /// </summary>
        /// <param name="input"/>
        public ICollection ReadCertificates(byte[] input);

        /// Generates a certificate object and initializes it with the data
        ///             read from the input stream inStream.
        public X509Certificate ReadCertificate(Stream inStream);

        /// Returns a (possibly empty) collection view of the certificates
        ///             read from the given input stream inStream.
        public ICollection ReadCertificates(Stream inStream);
    }
}
