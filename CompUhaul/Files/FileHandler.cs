﻿///////////////////////////////////////
#region Namespace Directives

using System;
using System.Collections.Generic;
using System.IO;

#endregion
///////////////////////////////////////

namespace CompUhaul.Files
{
    public abstract class FileHandler
    {
        ////////////////////////////////////////
        #region Data Retrieval


        protected string ReadContentFromFile(string _filePath)
        {
            string _content = String.Empty;

            try
            {
                if (File.Exists(_filePath))
                {
                    using (StreamReader FileReadObject = new StreamReader(_filePath))
                    {
                        _content = FileReadObject.ReadToEnd();
                        FileReadObject.Close();
                    }
                }
            }
            catch
            {
                _content = String.Empty;
            }

            return _content;
        }

        #endregion

        ////////////////////////////////////////
        #region Data Separation


        protected string[] SeparateFileDataByLine(string fileData)
        {
            string[] linesInFile = fileData.Split('\n', '\r');

            List<string> filteredData = new List<string>();

            foreach (string item in linesInFile)
                if (item != String.Empty && item != "0")
                    filteredData.Add(item);

            return filteredData.ToArray();
        }


        protected string[][] SeparateLineDataByColumn(string[] linesInFile)
        {
            List<string[]> dataParsingVehicle = new List<string[]>();

            foreach (string item in linesInFile)
            {
                string[] set = item.Split(':', '\t');

                for (int i = 0; i < set.Length; i++)
                    set[i] = set[i].Trim();

                dataParsingVehicle.Add(FilterEmptyStrings(set));
            }

            return dataParsingVehicle.ToArray();
        }

        #endregion

        ////////////////////////////////////////
        #region Data Filters


        protected string[] FilterEmptyStrings(string[] dataColumns)
        {
            List<string> filteredSet = new List<string>();

            foreach (string component in dataColumns)
                if (component != String.Empty)
                    filteredSet.Add(component);

            return filteredSet.ToArray();
        }

        #endregion
    }
}
