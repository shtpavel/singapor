using System;
using System.Linq;
using System.Security.Cryptography;

namespace Singapor.Helpers
{
    public static class StringsGenerators
    {
        #region Public methods

        public static string GenerateEmail()
        {
            var template = "{0}@{1}.{2}";
            var name = "test";
            var addr = "gmail";
            var domain = "com";
            return string.Format(template, name, addr, domain);
        }

        public static string GenerateString(int charCount)
        {
            return GenerateRandomAlphanumeric(charCount);
        }

        #endregion

        #region Private methods

        private static string GenerateRandomAlphanumeric(int length, string characterSet = null)
        {
            if (characterSet == null)
                characterSet =
                    "ABCDEFGHIJKLMNOPQRSTUVWXYZ" +
                    "abcdefghijklmnopqrstuvwxyz" +
                    "0123456789";

            if (length < 0)
                throw new ArgumentException("length must not be negative", "length");
            if (length > int.MaxValue/8)
                throw new ArgumentException("length is too big", "length");
            if (characterSet == null)
                throw new ArgumentNullException("characterSet");
            var characterArray = characterSet.Distinct().ToArray();
            if (characterArray.Length == 0)
                throw new ArgumentException("characterSet must not be empty", "characterSet");

            var bytes = new byte[length*8];
            new RNGCryptoServiceProvider().GetBytes(bytes);
            var result = new char[length];
            for (var i = 0; i < length; i++)
            {
                var value = BitConverter.ToUInt64(bytes, i*8);
                result[i] = characterArray[value%(uint) characterArray.Length];
            }
            return new string(result);
        }

        #endregion
    }
}