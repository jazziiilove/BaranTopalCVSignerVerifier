/* 
 * Programmer: Baran Topal                   *
 * Solution name: BaranTopalCVSigner         * 
 * Project name: BaranTopalCVSigner          *
 * File name: Program.cs                     *
 *                                           *      
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 *	                                                                                         *
 *  LICENSE: This source file is subject to have the protection of GNU General               *
 *	Public License. You can distribute the code freely but storing this license information. *
 *	Contact Baran Topal if you have any questions. barantopal@barantopal.com                 *
 *	                                                                                         *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 */

namespace BaranTopalCVSigner
{
    class Program
    {
        static void Main(string[] args)
        {
            var sign = new Sign();
            sign.CreatePDF();
            sign.SignIt();
            sign.VerifySignature();
        }
    }
}
