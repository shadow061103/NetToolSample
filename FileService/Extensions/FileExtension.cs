using FileService.Attributes;
using FileService.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FileService.Extensions
{
    public static class FileExtension
    {
        public static string ToCourseString(this Course course)
        {
            var rows = new List<string>();
            //欄位空值補空白
            var space = "";
            //分隔符號
            var split = ",";

            var props = typeof(Course).GetProperties();
            foreach (var prop in props)
            {
                var lengthAttr = prop.GetCustomAttribute<LengthAttribute>();
                if (lengthAttr != null)
                {
                    var value = (string)prop.GetValue(course);

                    if (string.IsNullOrEmpty(value))
                    {
                        rows.Add(space);
                        continue;
                    }
                    var length = lengthAttr.Length;
                    var stringByte = Encoding.GetEncoding(950).GetBytes(value);
                    rows.Add(Encoding.GetEncoding(950).GetString(new ArraySegment<byte>(stringByte, 0, Math.Min(length, stringByte.Length))));
                }
            }

            return string.Join(split, rows);
        }

        private static dynamic SetDetail(Type type, string line)
        {
            var props = type.GetProperties();
            var result = Activator.CreateInstance(type);
            var value = line.Split(',');
            foreach (var prop in props)
            {
                var csvSite = prop.GetCustomAttribute<CSVSiteAttribute>();
                if (csvSite != null)
                {
                    var data = "";
                    try
                    {
                        data = value[csvSite.Site];
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"parsing failed,{prop.Name} {csvSite.Site}");
                    }

                    SetValue(result, prop.Name, data);
                }
            }
            return result;
        }

        private static void SetValue(object theObject, string theProperty, object theValue)
        {
            var msgInfo = theObject.GetType().GetProperty(theProperty);
            msgInfo.SetValue(theObject, theValue, null);
        }

        public static Stream ToStream(this string content)
        {
            var big5 = Encoding.GetEncoding(950);
            var byteArray = big5.GetBytes(content);

            return new MemoryStream(byteArray);
        }
    }
}