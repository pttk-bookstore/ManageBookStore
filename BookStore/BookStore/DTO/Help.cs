﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace BookStore.DTO
{
    public static class Help
    {
        public static Byte[] ImageToByte(BitmapImage imageSource)
        {
            byte[] data;
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(imageSource));
            using (MemoryStream ms = new MemoryStream())
            {
                encoder.Save(ms);
                data = ms.ToArray();
            }
            return data;
        }

        /// <summary>
        ///Hàm chuyển từ byte sang bitmap
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static BitmapImage ByteToImage(byte[] array)
        {
            using (var ms = new System.IO.MemoryStream(array))
            {
                var image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad; // here
                image.StreamSource = ms;
                image.EndInit();
                return image;
            }
        }

        /// <summary>
        /// Hàm kiểm tra xem chuỗi nhập vào có phải INT hay không
        /// </summary>
        /// <param name="stringNumber"></param>
        /// <returns></returns>
        public static bool isInt(string stringNumber)
        {
            int myInt;
            if (int.TryParse(stringNumber, out myInt) == true)
                return true;

            //Kiểm tra nếu như giá trị <=0
            if (myInt <= 0)
            {
                return false;
            }
            return false;
        }

        /// <summary>
        /// hàm kiểm tra chuỗi nhập vào có phải kiểu FLOAT hay không
        /// </summary>
        /// <param name="stringNumber"></param>
        /// <returns></returns>
        public static bool isFloat(string stringNumber)
        {
            float myFloat;
            if (float.TryParse(stringNumber, out myFloat))
                return true;

            //Kiểm tra giá trị <=0
            if (myFloat <= 0)
            {
                return false;
            }
            return false;
        }

        /// <summary>
        /// Hàm kiểm tra định dạng email
        /// </summary>
        /// <param name="Email"></param>
        /// <returns></returns>
        public static bool isEmail(string Email)
        {
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}"
                                           + @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\"
                                           + @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(Email))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Hàm mã hóa base 64
        /// </summary>
        /// <param name="plainText"></param>
        /// <returns></returns>
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        /// <summary>
        /// Hàm giải mã base 64
        /// </summary>
        /// <param name="base64EncodedData"></param>
        /// <returns></returns>
        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        static public BitmapImage LoadImage(string filename)
        {
            return new BitmapImage(new Uri("pack://application:,,,/" + filename));
        }
    }
}
