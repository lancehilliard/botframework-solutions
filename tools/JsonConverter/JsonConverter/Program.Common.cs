﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace JsonConverter
{
    partial class Program
    {
        public static readonly Dictionary<string, string> LocaleDic = new Dictionary<string, string>
        {
            { "en", "en-us" },
            { "de", "de-de" },
            { "fr", "fr-fr" },
            { "it", "it-it" },
            { "es", "es-es" },
            { "zh", "zh-cn" },
        };

        // eg: xx.zh-cn.json. Its locale is zh-cn.
        // xx.lg. Its locale is default locale.
        private string GetLocale(string file)
        {
            var fileName = Path.GetFileNameWithoutExtension(file);
            var nameAndExts = fileName.Split(".");
            if (LocaleDic.ContainsKey(nameAndExts[^1]))
            {
                return LocaleDic[nameAndExts[^1]];
            }
            else
            {
                return defaultLocale;
            }
        }

        private string GetDialogName(string file)
        {
            var fileName = Path.GetFileNameWithoutExtension(file);
            var nameAndExts = fileName.Split(".");
            if (LocaleDic.ContainsKey(nameAndExts[^1]))
            {
                return fileName.Substring(0, fileName.Length - nameAndExts[^1].Length - 1);
            }
            else
            {
                return fileName;
            }
        }

        private string GetFullPath(params string[] folders)
        {
            return Path.Join(root, Path.Join(folders));
        }
    }
}