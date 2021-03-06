﻿using System;
using System.IO;
using System.Text.RegularExpressions;

namespace PIE.Meteo.Model
{
    internal class HJDataSourceInfo : IDataSourceInfo
    {
        public string FilePath
        {
            get;
            set;
        }

        public DateTime? ImageTime
        {
            get;

            set;
        }

        public DateTime? GetImageTime(string filePath)
        {
            FilePath = filePath;
            string fileName = Path.GetFileNameWithoutExtension(filePath);
            ImageTime = GetImageTimeFromFileName(fileName);
            return ImageTime;
        }

        public DateTime? GetImageTimeFromFileName(string fileName)
        {
            Match match = Regex.Match(fileName, @"-(\d{8})-");
            if (match.Groups.Count > 1)
            {
                return DateTime.ParseExact(match.Groups[1].Value, "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture);
            }
            else
            {
                return null;
            }
        }
    }
}
