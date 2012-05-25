#region using
using System;
using System.IO;
using System.Security.Cryptography;
#endregion

namespace Negar.Security.Classes
{
    /// <summary>
    /// كلاس مدیریت رمز گذاری داده ها
    /// </summary>
    public static class Cryptographer
    {

        #region String EncryptString(String ClearString, String Password)
        /// <summary>
        /// EncryptByte a String into a string using a password 
        /// </summary>
        /// <param name="ClearString"></param>
        /// <param name="Password"></param>
        /// <remarks>Uses EncryptFile(Byte[], Byte[], Byte[]) </remarks>
        /// <returns></returns>
        public static String EncryptString(String ClearString, String Password)
        {
            // First we need to turn the input string into a Byte array. 
            Byte[] clearBytes = System.Text.Encoding.Unicode.GetBytes(ClearString);

            // Then, we need to turn the password into Key and IV 
            // We are using salt to make it harder to guess our key
            // using a dictionary attack - 
            // trying to guess a password by enumerating all possible words. 
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(Password,
                new Byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });

            // Now get the key/IV and do the encryption using the
            // function that accepts Byte arrays. 
            // Using PasswordDeriveBytes object we are first getting
            // 32 bytes for the Key 
            // (the default Rijndael key length is 256bit = 32bytes)
            // and then 16 bytes for the IV. 
            // IV should always be the block size, which is by default
            // 16 bytes (128 bit) for Rijndael. 
            // If you are using DES/TripleDES/RC2 the block size is
            // 8 bytes and so should be the IV size. 
            // You can also read KeySize/BlockSize properties off
            // the algorithm to find out the sizes. 
            Byte[] encryptedData = EncryptByte(clearBytes, pdb.GetBytes(32), pdb.GetBytes(16));

            // Now we need to turn the resulting Byte array into a string. 
            // A common mistake would be to use an Encoding class for that.
            //It does not work because not all Byte values can be
            // represented by characters. 
            // We are going to be using Base64 encoding that is designed
            //exactly for what we are trying to do. 
            return Convert.ToBase64String(encryptedData);
        }
        #endregion

        #region void EncryptFile(String SourceFilePath, String TargetFilePath, String Password)
        /// <summary>
        /// EncryptString a file into another file using a password
        /// </summary>
        /// <param name="SourceFilePath"></param>
        /// <param name="TargetFilePath"></param>
        /// <param name="Password"></param>
        public static void EncryptFile(String SourceFilePath, String TargetFilePath, String Password)
        {
            // First we are going to open the file streams 
            FileStream fsIn = new FileStream(SourceFilePath, FileMode.Open, FileAccess.Read);
            FileStream fsOut = new FileStream(TargetFilePath, FileMode.OpenOrCreate, FileAccess.Write);

            // Then we are going to derive a Key and an IV from the
            // Password and create an algorithm 
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(Password,
                new Byte[] {0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 
            0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76});

            Rijndael alg = Rijndael.Create();
            alg.Key = pdb.GetBytes(32);
            alg.IV = pdb.GetBytes(16);

            // Now create a crypto stream through which we are going
            // to be pumping data. 
            // Our TargetFilePath is going to be receiving the encrypted bytes. 
            CryptoStream cs = new CryptoStream(fsOut,
                alg.CreateEncryptor(), CryptoStreamMode.Write);

            // Now will will initialize a buffer and will be processing
            // the input file in chunks. 
            // This is done to avoid reading the whole file (which can
            // be huge) into memory. 
            const Int32 bufferLen = 4096;
            Byte[] buffer = new Byte[bufferLen];
            Int32 bytesRead;

            do
            {
                // read a chunk of data from the input file 
                bytesRead = fsIn.Read(buffer, 0, bufferLen);
                // encrypt it 
                cs.Write(buffer, 0, bytesRead);
            } while (bytesRead != 0);

            // close everything. this will also close the unrelying fsOut stream
            cs.Close();
            fsIn.Close();
        }
        #endregion

        #region Byte[] EncryptByte(Byte[] ClearData, String Password)
        /// <summary>
        /// EncryptByte a String into a string using a password 
        /// </summary>
        /// <param name="ClearData"></param>
        /// <param name="Password"></param>
        /// <remarks>Uses EncryptFile(Byte[], Byte[], Byte[]) </remarks>
        /// <returns></returns>
        public static Byte[] EncryptByte(Byte[] ClearData, String Password)
        {
            // We need to turn the password into Key and IV 
            // We are using salt to make it harder to guess our key
            // using a dictionary attack - 
            // trying to guess a password by enumerating all possible words. 
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(Password,
                new Byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });

            // Now get the key/IV and do the encryption using the
            // function that accepts Byte arrays. 
            // Using PasswordDeriveBytes object we are first getting
            // 32 bytes for the Key 
            // (the default Rijndael key length is 256bit = 32bytes)
            // and then 16 bytes for the IV. 
            // IV should always be the block size, which is by default
            // 16 bytes (128 bit) for Rijndael. 
            // If you are using DES/TripleDES/RC2 the block size is
            // 8 bytes and so should be the IV size. 
            // You can also read KeySize/BlockSize properties off
            // the algorithm to find out the sizes. 
            return EncryptByte(ClearData, pdb.GetBytes(32), pdb.GetBytes(16));
        }
        #endregion

        #region private Byte[] EncryptByte(Byte[] ClearData, Byte[] Key, Byte[] IV)
        // EncryptFile a Byte array into a Byte array using a key and an IV 
        private static Byte[] EncryptByte(Byte[] ClearData, Byte[] Key, Byte[] IV)
        {
            // Create a MemoryStream to accept the encrypted bytes 
            MemoryStream ms = new MemoryStream();

            // Create a symmetric algorithm. 
            // We are going to use Rijndael because it is strong and
            // available on all platforms. 
            // You can use other algorithms, to do so substitute the
            // next line with something like 
            //      TripleDES alg = TripleDES.Create(); 
            Rijndael alg = Rijndael.Create();

            // Now set the key and the IV. 
            // We need the IV (Initialization Vector) because
            // the algorithm is operating in its default 
            // mode called CBC (Cipher Block Chaining).
            // The IV is XORed with the first block (8 Byte) 
            // of the data before it is encrypted, and then each
            // encrypted block is XORed with the 
            // following block of plaintext.
            // This is done to make encryption more secure. 

            // There is also a mode called ECB which does not need an IV,
            // but it is much less secure. 
            alg.Key = Key;
            alg.IV = IV;

            // Create a CryptoStream through which we are going to be
            // pumping our data. 
            // CryptoStreamMode.Write means that we are going to be
            // writing data to the stream and the output will be written
            // in the MemoryStream we have provided. 
            CryptoStream cs = new CryptoStream(ms, alg.CreateEncryptor(), CryptoStreamMode.Write);

            // Write the data and make it do the encryption 
            cs.Write(ClearData, 0, ClearData.Length);

            // Close the crypto stream (or do FlushFinalBlock). 
            // This will tell it that we have done our encryption and
            // there is no more data coming in, 
            // and it is now a good time to apply the padding and
            // finalize the encryption process. 
            cs.Close();

            // Now get the encrypted data from the MemoryStream.
            // Some people make a mistake of using GetBuffer() here,
            // which is not the right way. 
            Byte[] encryptedData = ms.ToArray();

            return encryptedData;
        }
        #endregion

        // ======================================================

        #region String DecryptString(String EncryptedString, String Password)
        /// <summary>
        /// Decrypt a String into a string using a password 
        /// </summary>
        /// <param name="EncryptedString"></param>
        /// <param name="Password"></param>
        /// <remarks>
        /// Uses DecryptFile(Byte[], Byte[], Byte[])
        /// </remarks>
        /// <returns></returns>
        public static String DecryptString(String EncryptedString, String Password)
        {
            // First we need to turn the input string into a Byte array. 
            // We presume that Base64 encoding was used 
            Byte[] cipherBytes = Convert.FromBase64String(EncryptedString);

            // Then, we need to turn the password into Key and IV 
            // We are using salt to make it harder to guess our key
            // using a dictionary attack - 
            // trying to guess a password by enumerating all possible words. 
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(Password,
                new Byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });

            // Now get the key/IV and do the decryption using
            // the function that accepts Byte arrays. 
            // Using PasswordDeriveBytes object we are first
            // getting 32 bytes for the Key 
            // (the default Rijndael key length is 256bit = 32bytes)
            // and then 16 bytes for the IV. 
            // IV should always be the block size, which is by
            // default 16 bytes (128 bit) for Rijndael. 
            // If you are using DES/TripleDES/RC2 the block size is
            // 8 bytes and so should be the IV size. 
            // You can also read KeySize/BlockSize properties off
            // the algorithm to find out the sizes. 
            Byte[] decryptedData = DecryptByte(cipherBytes,
                pdb.GetBytes(32), pdb.GetBytes(16));

            // Now we need to turn the resulting Byte array into a string. 
            // A common mistake would be to use an Encoding class for that.
            // It does not work 
            // because not all Byte values can be represented by characters. 
            // We are going to be using Base64 encoding that is 
            // designed exactly for what we are trying to do. 
            return System.Text.Encoding.Unicode.GetString(decryptedData);
        }

        #endregion

        #region void DecryptFile(String SourceFilePath, String DecryptedFilePath, String Password)
        /// <summary>
        /// Decrypt a file into another file using a password 
        /// </summary>
        /// <param name="SourceFilePath"></param>
        /// <param name="TargetFilePath"></param>
        /// <param name="Password"></param>
        public static void DecryptFile(String SourceFilePath, String TargetFilePath, String Password)
        {
            // First we are going to open the file streams 
            FileStream fsIn = new FileStream(SourceFilePath, FileMode.Open, FileAccess.Read);
            FileStream fsOut = new FileStream(TargetFilePath, FileMode.OpenOrCreate, FileAccess.Write);

            // Then we are going to derive a Key and an IV from
            // the Password and create an algorithm 
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(Password,
                new Byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            Rijndael alg = Rijndael.Create();

            alg.Key = pdb.GetBytes(32);
            alg.IV = pdb.GetBytes(16);

            // Now create a crypto stream through which we are going
            // to be pumping data. 
            // Our TargetFilePath is going to be receiving the Decrypted bytes. 
            CryptoStream cs = new CryptoStream(fsOut, alg.CreateDecryptor(), CryptoStreamMode.Write);

            // Now will will initialize a buffer and will be 
            // processing the input file in chunks. 
            // This is done to avoid reading the whole file (which can be
            // huge) into memory. 
            const Int32 bufferLen = 4096;
            Byte[] buffer = new Byte[bufferLen];
            Int32 bytesRead;

            do
            {
                // read a chunk of data from the input file 
                bytesRead = fsIn.Read(buffer, 0, bufferLen);
                // DecryptFile it 
                cs.Write(buffer, 0, bytesRead);
            } while (bytesRead != 0);

            // close everything 
            cs.Close(); // this will also close the unrelying fsOut stream 
            fsIn.Close();
        }
        #endregion

        #region Byte[] DecryptByte(Byte[] EncryptedData, String Password)
        /// <summary>
        /// DecryptString bytes into bytes using a password
        /// </summary>
        /// <param name="EncryptedData"></param>
        /// <param name="Password"></param>
        /// <remarks>Uses DecryptFile(Byte[], Byte[], Byte[]) </remarks>
        /// <returns></returns>
        public static Byte[] DecryptByte(Byte[] EncryptedData, String Password)
        {
            // We need to turn the password into Key and IV. 
            // We are using salt to make it harder to guess our key
            // using a dictionary attack - 
            // trying to guess a password by enumerating all possible words. 
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(Password,
                new Byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });

            // Now get the key/IV and do the Decryption using the 
            //function that accepts Byte arrays. 
            // Using PasswordDeriveBytes object we are first getting
            // 32 bytes for the Key 
            // (the default Rijndael key length is 256bit = 32bytes)
            // and then 16 bytes for the IV. 
            // IV should always be the block size, which is by default
            // 16 bytes (128 bit) for Rijndael. 
            // If you are using DES/TripleDES/RC2 the block size is
            // 8 bytes and so should be the IV size. 

            // You can also read KeySize/BlockSize properties off the
            // algorithm to find out the sizes. 
            return DecryptByte(EncryptedData, pdb.GetBytes(32), pdb.GetBytes(16));
        }
        #endregion

        #region private Byte[] DecryptByte(Byte[] EncryptedData, Byte[] Key, Byte[] IV)
        /// <summary>
        /// DecryptString a Byte Array into a Byte Array using a Key and an IV 
        /// </summary>
        /// <param name="EncryptedData"></param>
        /// <param name="Key"></param>
        /// <param name="IV"></param>
        /// <returns></returns>
        private static Byte[] DecryptByte(Byte[] EncryptedData, Byte[] Key, Byte[] IV)
        {
            // Create a MemoryStream that is going to accept the decrypted bytes 
            MemoryStream ms = new MemoryStream();
            // Create a symmetric algorithm. 
            // We are going to use Rijndael because it is strong and
            // available on all platforms. 
            // You can use other algorithms, to do so substitute the next
            // line with something like 
            //     TripleDES alg = TripleDES.Create(); 
            Rijndael alg = Rijndael.Create();

            // Now set the key and the IV. 
            // We need the IV (Initialization Vector) because the algorithm
            // is operating in its default 
            // mode called CBC (Cipher Block Chaining). The IV is XORed with
            // the first block (8 Byte) 
            // of the data after it is decrypted, and then each decrypted
            // block is XORed with the previous 
            // cipher block. This is done to make encryption more secure. 
            // There is also a mode called ECB which does not need an IV,
            // but it is much less secure. 
            alg.Key = Key;
            alg.IV = IV;

            // Create a CryptoStream through which we are going to be
            // pumping our data. 
            // CryptoStreamMode.Write means that we are going to be
            // writing data to the stream 
            // and the output will be written in the MemoryStream
            // we have provided. 
            CryptoStream cs = new CryptoStream(ms, alg.CreateDecryptor(), CryptoStreamMode.Write);

            // Write the data and make it do the decryption 
            cs.Write(EncryptedData, 0, EncryptedData.Length);

            // Close the crypto stream (or do FlushFinalBlock). 
            // This will tell it that we have done our decryption
            // and there is no more data coming in, 
            // and it is now a good time to remove the padding
            // and finalize the decryption process. 
            cs.Close();

            // Now get the decrypted data from the MemoryStream. 
            // Some people make a mistake of using GetBuffer() here,
            // which is not the right way. 
            Byte[] decryptedData = ms.ToArray();

            return decryptedData;
        }
        #endregion

    }
}