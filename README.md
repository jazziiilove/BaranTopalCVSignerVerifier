# BaranTopalCVSignerVerifier
This program first creates a pdf file, then signs that file, then verifies the signature.

/*

 * Note that the jks store I used before has a certificate which has expired, so I regenerate the certificate in jks, THEN I convert the jks file to pfx
 * Unfortunately, jks store previously used by Itext library for Java implementation is not really recognized in .NET implementation,
 * so we need to convert it to pfx as follows:
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
