///////////////////////////////////////
#region Namespace Directives

using System;
using System.Collections.Generic;
using System.IO;

#endregion
///////////////////////////////////////

namespace CompUhaul.Files.Handlers
{
    public class TextFileHandler : FileHandler
    {
        ////////////////////////////////////////
        #region Constructor

        public TextFileHandler(string _fullPath) : base(_fullPath) { }

        #endregion

        ////////////////////////////////////////
        #region Data Retrieval


        protected string ReadContentFromFile()
        {
            string _content = String.Empty;

            try
            {
                if (base._dataFile.Exists)
                {
                    using (StreamReader FileReadObject = new StreamReader(base._dataFile.FullPath))
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


        protected string[][] ReadTabularContentFromFile()
        {
            string fileContent = ReadContentFromFile();

            string[] linesInFile = SeparateFileDataByLine(fileContent);

            string[][] columnsData = SeparateLineDataByColumn(linesInFile);

            return columnsData;
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