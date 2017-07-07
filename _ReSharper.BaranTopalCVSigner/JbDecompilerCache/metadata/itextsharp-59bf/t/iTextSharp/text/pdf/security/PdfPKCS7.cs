// Type: iTextSharp.text.pdf.security.PdfPKCS7
// Assembly: itextsharp, Version=5.5.10.0, Culture=neutral, PublicKeyToken=8354ae6d2174ddca
// Assembly location: C:\Users\Baran.Topal\Downloads\itextsharp-all-5.5.10\itextsharp-dll-core\itextsharp.dll

using iTextSharp.text.pdf;
using Org.BouncyCastle.Asn1.Esf;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Ocsp;
using Org.BouncyCastle.Tsp;
using Org.BouncyCastle.X509;
using System;
using System.Collections.Generic;

namespace iTextSharp.text.pdf.security
{
    /// This class does all the processing related to signing
    ///             and verifying a PKCS#7 signature.
    public class PdfPKCS7
    {
        /// Assembles all the elements needed to create a signature, except for the data.
        ///             @param privKey the private key
        ///             @param certChain the certificate chain
        ///             @param interfaceDigest the interface digest
        ///             @param hashAlgorithm the hash algorithm
        ///             @param provider the provider or
        /// <code>
        /// null
        /// </code>
        /// for the default provider
        ///             @param hasRSAdata <CODE>true</CODE>if the sub-filter is adbe.pkcs7.sha1
        ///             @throws InvalidKeyException on error
        ///             @throws NoSuchProviderException on error
        ///             @throws NoSuchAlgorithmException on error
        public PdfPKCS7(ICipherParameters privKey, ICollection<X509Certificate> certChain, string hashAlgorithm, bool hasRSAdata);

        /// Use this constructor if you want to verify a signature using the sub-filter adbe.x509.rsa_sha1.
        ///             @param contentsKey the /Contents key
        ///             @param certsKey the /Cert key
        public PdfPKCS7(byte[] contentsKey, byte[] certsKey);

        /// Use this constructor if you want to verify a signature.
        ///             @param contentsKey the /Contents key
        ///             @param filterSubtype the filtersubtype
        ///             @param provider the provider or
        /// <code>
        /// null
        /// </code>
        /// for the default provider
        public PdfPKCS7(byte[] contentsKey, PdfName filterSubtype);

        public virtual void SetSignaturePolicy(SignaturePolicyInfo signaturePolicy);
        public virtual void SetSignaturePolicy(SignaturePolicyIdentifier signaturePolicy);

        /// Returns the name of the digest algorithm, e.g. "SHA256".
        ///             @return the digest algorithm name, e.g. "SHA256"
        public virtual string GetHashAlgorithm();

        /// Get the algorithm used to calculate the message digest, e.g. "SHA1withRSA".
        ///             @return the algorithm used to calculate the message digest
        public virtual string GetDigestAlgorithm();

        /// Sets the digest/signature to an external calculated value.
        ///             @param digest the digest. This is the actual signature
        ///             @param RSAdata the extra data that goes into the data tag in PKCS#7
        ///             @param digestEncryptionAlgorithm the encryption algorithm. It may must be <CODE>null</CODE>if the <CODE>digest</CODE>is also <CODE>null</CODE>. If the <CODE>digest</CODE>is not <CODE>null</CODE>then it may be "RSA" or "DSA"
        public virtual void SetExternalDigest(byte[] digest, byte[] RSAdata, string digestEncryptionAlgorithm);

        /// Update the digest with the specified bytes.
        ///             This method is used both for signing and verifying
        ///             @param buf the data buffer
        ///             @param off the offset in the data buffer
        ///             @param len the data length
        ///             @throws SignatureException on error
        public virtual void Update(byte[] buf, int off, int len);

        /// Gets the bytes for the PKCS#1 object.
        ///             @return a byte array
        public virtual byte[] GetEncodedPKCS1();

        /// Gets the bytes for the PKCS7SignedData object.
        ///             @return the bytes for the PKCS7SignedData object
        public virtual byte[] GetEncodedPKCS7();

        /// Gets the bytes for the PKCS7SignedData object. Optionally the authenticatedAttributes
        ///             in the signerInfo can also be set. If either of the parameters is <CODE>null</CODE>, none will be used.
        ///             @param secondDigest the digest in the authenticatedAttributes
        ///             @return the bytes for the PKCS7SignedData object
        public virtual byte[] GetEncodedPKCS7(byte[] secondDigest);

        /// Gets the bytes for the PKCS7SignedData object. Optionally the authenticatedAttributes
        ///             in the signerInfo can also be set, OR a time-stamp-authority client
        ///             may be provided.
        ///             @param secondDigest the digest in the authenticatedAttributes
        ///             @param tsaClient TSAClient - null or an optional time stamp authority client
        ///             @return byte[] the bytes for the PKCS7SignedData object
        ///             @since   2.1.6
        public virtual byte[] GetEncodedPKCS7(byte[] secondDigest, ITSAClient tsaClient, byte[] ocsp, ICollection<byte[]> crlBytes, CryptoStandard sigtype);

        public virtual byte[] getAuthenticatedAttributeBytes(byte[] secondDigest, byte[] ocsp, ICollection<byte[]> crlBytes, CryptoStandard sigtype);

        /// Verify the digest.
        ///             @throws SignatureException on error
        ///             @return <CODE>true</CODE>if the signature checks out, <CODE>false</CODE>otherwise
        public virtual bool Verify();

        /// Checks if the timestamp refers to this document.
        ///             @throws java.security.NoSuchAlgorithmException on error
        ///             @return true if it checks false otherwise
        ///             @since   2.1.6
        public virtual bool VerifyTimestampImprint();

        /// Checks if OCSP revocation refers to the document signing certificate.
        ///             @return true if it checks, false otherwise
        ///             @since   2.1.6
        public virtual bool IsRevocationValid();

        /// Returns the filter subtype.
        public virtual PdfName GetFilterSubtype();

        /// Returns the encryption algorithm
        ///             @return	the name of an encryption algorithm
        public virtual string GetEncryptionAlgorithm();

        /// Getter/setter for property sigName.
        ///             @return Value of property sigName.
        public virtual string SignName { get; set; }

        /// Getter for property reason.
        ///             @return Value of property reason.
        public virtual string Reason { get; set; }

        /// Getter for property location.
        ///             @return Value of property location.
        public virtual string Location { get; set; }

        /// Getter for property signDate.
        ///             @return Value of property signDate.
        public virtual DateTime SignDate { get; set; }

        /// Get the version of the PKCS#7 object.
        ///             @return the version of the PKCS#7 object.
        public virtual int Version { get; }

        /// Get the version of the PKCS#7 "SignerInfo" object.
        ///             @return the version of the PKCS#7 "SignerInfo" object.
        public virtual int SigningInfoVersion { get; }

        /// Getter for the ID of the digest algorithm, e.g. "2.16.840.1.101.3.4.2.1"
        public virtual string DigestAlgorithmOid { get; }

        /// Getter for the digest encryption algorithm
        public virtual string DigestEncryptionAlgorithmOid { get; }

        /// Get all the X.509 certificates associated with this PKCS#7 object in no particular order.
        ///             Other certificates, from OCSP for example, will also be included.
        ///             @return the X.509 certificates associated with this PKCS#7 object
        public virtual X509Certificate[] Certificates { get; }

        /// Get the X.509 sign certificate chain associated with this PKCS#7 object.
        ///             Only the certificates used for the main signature will be returned, with
        ///             the signing certificate first.
        ///             @return the X.509 certificates associated with this PKCS#7 object
        ///             @since   2.1.6
        public virtual X509Certificate[] SignCertificateChain { get; }

        /// Get the X.509 certificate actually used to sign the digest.
        ///             @return the X.509 certificate actually used to sign the digest
        public virtual X509Certificate SigningCertificate { get; }

        /// Get the X.509 certificate revocation lists associated with this PKCS#7 object
        ///             @return the X.509 certificate revocation lists associated with this PKCS#7 object
        public virtual ICollection<X509Crl> CRLs { get; }

        /// Gets the OCSP basic response if there is one.
        ///             @return the OCSP basic response or null
        ///             @since   2.1.6
        public virtual BasicOcspResp Ocsp { get; }

        /// Check if it's a PAdES-LTV time stamp.
        ///             @return true if it's a PAdES-LTV time stamp, false otherwise
        public virtual bool IsTsp { get; }

        /// Gets the timestamp token if there is one.
        ///             @return the timestamp token or null
        ///             @since   2.1.6
        public virtual TimeStampToken TimeStampToken { get; }

        /// Gets the timestamp date
        ///             @return  a date
        ///             @since   2.1.6
        public virtual DateTime TimeStampDate { get; }
    }
}
