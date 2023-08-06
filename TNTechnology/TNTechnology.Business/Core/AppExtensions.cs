using LazZiya.ExpressLocalization;
using System.ComponentModel;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace TNTechnology.Business.Core
{
    public static class AppExtensions
    {
        #region Common

        public static string GetDescription<T>(this T source)
        {
            if (source == null)
                return "NULL";

            var fi = source.GetType().GetField(source.ToString());

            if (fi == null)
                return "NULL";

            var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute), false);

            return attributes.Length > 0 ? attributes[0].Description : source.ToString();
        }

        #endregion

        #region String

        public static string ToSearchString(this string text)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;

            text = text.ToLower();

            text = text.Replace(" ", "").ToLower();
            text = text.Replace("đ", "d").ToLower();

            var special = new[]
            {
                "`", "~", "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "-", "_", "=", "+",
                "{", "}", "[", "]", ";", ":", "'", "\"", "<", ",", ">", ".", "?", "/", "\\"
            };

            text = special.Aggregate(text, (current, sp) => current.Replace(sp, ""));

            text = text.Normalize(NormalizationForm.FormD);
            var chars = text.Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                .ToArray();
            return new string(chars).Normalize(NormalizationForm.FormC);
        }

        public static string ToSHA512Hash(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return value;

            using (var sha512 = SHA512.Create())
            {
                var hash = sha512.ComputeHash(Encoding.UTF8.GetBytes(value));

                var stringBuilder = new StringBuilder();

                foreach (var b in hash)
                    stringBuilder.AppendFormat(b.ToString("x2"));
                return stringBuilder.ToString().ToUpper();
            }
        }

        private const int KeySize = 256;

        public static string Encrypt(this string plainText, string hashKey)
        {
            var initVector = hashKey.Substring(0, 16);

            if (string.IsNullOrEmpty(plainText))
                return string.Empty;

            var initVectorBytes = Encoding.UTF8.GetBytes(initVector);
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            var password = new PasswordDeriveBytes(hashKey, null);
            var keyBytes = password.GetBytes(KeySize / 8);
            var symmetricKey = new AesManaged
            {
                Padding = PaddingMode.Zeros,
                Mode = CipherMode.CBC
            };
            var encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);
            var memoryStream = new MemoryStream();
            var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
            cryptoStream.FlushFinalBlock();
            var cipherTextBytes = memoryStream.ToArray();
            memoryStream.Close();
            cryptoStream.Close();
            return Convert.ToBase64String(cipherTextBytes);
        }

        public static string Decrypt(this string cipherText, string hashKey)
        {
            var initVector = hashKey.Substring(0, 16);

            if (string.IsNullOrEmpty(cipherText))
                return string.Empty;

            var initVectorBytes = Encoding.UTF8.GetBytes(initVector);
            var cipherTextBytes = Convert.FromBase64String(cipherText);
            var password = new PasswordDeriveBytes(hashKey, null);
            var keyBytes = password.GetBytes(KeySize / 8);
            var symmetricKey = new AesManaged { Padding = PaddingMode.Zeros, Mode = CipherMode.CBC };
            var decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);
            var memoryStream = new MemoryStream(cipherTextBytes);
            var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            var plainTextBytes = new byte[cipherTextBytes.Length];
            var decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
            memoryStream.Close();
            cryptoStream.Close();
            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
        }

        public static string FormatDate(this DateTime? dateTime)
        {
            if (dateTime == null || dateTime.Value.Year == 1)
            {
                return "";
            }
            else
            {
                return $"{dateTime:dd/MM/yyyy}";
            }
        }

        public static string FormatMonth(DateTime? dateTime)
        {
            if (dateTime == null || dateTime.Value.Year == 1)
            {
                return "";
            }
            else
            {
                return $"{dateTime:MM/yyyy}";
            }
        }

        public static string FormatYear(DateTime? dateTime)
        {
            if (dateTime == null || dateTime.Value.Year == 1)
            {
                return "";
            }
            else
            {
                return $"{dateTime:yyyy}";
            }
        }

        public static string FormatDateTime(DateTime? dateTime)
        {
            if (dateTime == null || dateTime.Value.Year == 1)
            {
                return "";
            }
            else
            {
                return $"{dateTime:HH:mm:ss, dd/MM/yyyy}";
            }
        }

        public static string FormatPhoneUsa(string phone)
        {
            if (phone == null || phone.Length == 0 || string.IsNullOrWhiteSpace(phone))
            {
                return "";
            }

            char[] array = phone.ToCharArray();
            string newPhone = "";
            for (int i = 0; i < array.Length; i++)
            {
                if (i == 0)
                {
                    newPhone += "(";
                }

                if (i == 6)
                {
                    newPhone += " ";
                }

                newPhone += array[i];

                if (i == 2)
                {
                    newPhone += ") ";
                }
            }
            return newPhone;
        }
        #endregion

        #region Decimals

        public static string ToCurrencyString(this decimal value)
        {
            if (value == 0m)
                return "0.00";

            if (value > 1)
            {
                return value.ToString("N2");
            }

            if (value > 0.01m)
            {
                return value.ToString("N4");
            }

            if (value > 0.0001m)
            {
                return value.ToString("N6");
            }

            return value.ToString("N8");
        }

        #endregion

        public static string NewGuid()
        {
            return Guid.NewGuid().ToString("N");
        }

        public static string GenerateSlug(this string phrase)
        {
            var t = GetString(phrase);
            var s = RemoveAccent(t).ToLower();
            s = Regex.Replace(s, @"[^a-z0-9\s-]", " ");
            s = Regex.Replace(s, @"\s+", " ").Trim();
            var list = new[] { " ", "~", "`", "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "-", "_", "+", "=", "/", "\\", "+", "?", "<", ">", ".", ",", "{", "}", "[", "]", "|" };

            var stringAsArr = s.Split(list, StringSplitOptions.RemoveEmptyEntries).ToList();

            var result = string.Join("-", stringAsArr);

            return result.ToLower();
        }

        public static string GetString(string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC).Replace("đ", "d").Replace("Đ", "D");
        }

        private static string RemoveAccent(string txt)
        {
            byte[] bytes = System.Text.Encoding.GetEncoding("Cyrillic").GetBytes(txt);
            return System.Text.Encoding.ASCII.GetString(bytes);
        }

        public static string CheckImg(this string? img, string type = "")
        {
            if (string.IsNullOrEmpty(img) || img == "1")
            {
                switch (type)
                {
                    case "sex":
                        return AppEnums.DefaultImage.Girl.GetDescription();
                    case "img":
                        return AppEnums.DefaultImage.Img.GetDescription();
                    case "product":
                        return AppEnums.DefaultImage.Product.GetDescription();
                    default:
                        return AppEnums.DefaultImage.Img.GetDescription();
                }
            }
            else
            {
                return img.Trim();
            }
        }

        public static string Localization(this string text, ISharedCultureLocalizer loc, params object[] args)
        {
            var culture = CultureInfo.CurrentCulture.Name;

            object[] param = new object[args.Length];

            foreach (var item in args.Select((value, i) => new { i, value }))
            {
                param[item.i] = HttpUtility.HtmlDecode(loc.GetLocalizedString(culture, item.value.ToString()));
            }

            return HttpUtility.HtmlDecode(loc.GetLocalizedString(culture, text, param));
        }
    }
}
