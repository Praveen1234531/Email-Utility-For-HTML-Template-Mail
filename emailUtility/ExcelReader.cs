using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using Excel;
using System.IO;

namespace emailUtility
{
    public class Helper
    {
        public static string ExcelFilters
        {
            get { return "Excel files (*.xls;*.xlsx)|*.xls;*.xlsx"; }
        }
    }
        public class ExcelReader
    {
        public string[] WorkSheetNames;
        private DataTable _dataTable = new DataTable();
        private readonly string _path;
        private string _connectionString;

        public ExcelReader(string fileLocation)
        {
            _path = fileLocation;
            StartReading();
        }

        private void StartReading()
        {
            string[] splitByDots = _path.Split('.');
            //Excel 97-2003 file
            if (splitByDots[splitByDots.Length - 1] == "xls")
                OpenExcelFile(false);

            //Excel 2007 file
            if (splitByDots[splitByDots.Length - 1] == "xlsx")
                OpenExcelFile(true);
        }

        public void OpenExcelFile(bool isOpenXmlFormat)
        {
            //open the excel file using OLEDB

            if (isOpenXmlFormat)
                //read a 2007 file
                _connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                                    _path + ";Extended Properties=\"Excel 12.0;HDR=YES;IMEX=1;\"";
            else
                //read a 97-2003 file
                _connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" +
                                    _path + ";Extended Properties=Excel 8.0;HDR=YES;IMEX=1;";
            var con = new OleDbConnection(_connectionString);
            try
            {

                con.Open();

                //get all the available sheets
                DataTable dataSet = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                //get the number of sheets in the file
                if (dataSet != null)
                {
                    WorkSheetNames = new String[dataSet.Rows.Count];

                    int i = 0;
                    foreach (DataRow row in dataSet.Rows)
                    {
                        //insert the sheet's name in the current element of the array
                        //and remove the $ sign at the end
                        WorkSheetNames[i] = row["TABLE_NAME"].ToString().Trim('$');
                        i++;
                    }
                }

                con.Close();
                con.Dispose();

                if (dataSet != null)
                    dataSet.Dispose();
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }


        public DataView Data(string worksheetName)
        {
            _dataTable = GetWorksheet(worksheetName);
            return _dataTable.DefaultView;
        }

        public DataTable GetWorksheet(string worksheetName)
        {
            ExcelData excelData = new ExcelData(_path);
            IEnumerable<DataColumn> dataColumn;
            var data = excelData.GetData(worksheetName, out dataColumn).ToList();
            var dt = new DataTable();
            dataColumn.ToList().ForEach(x => dt.Columns.Add(x.ColumnName, x.DataType));
            data.ForEach(x =>
                dt.ImportRow(x));
            return dt;
        }
    }

    public class ExcelData
    {
        private string path;

        public ExcelData(string path)
        {
            this.path = path;
        }

        private IExcelDataReader GetExcelDataReader(bool isFirstRowAsColumnNames)
        {
            using (FileStream fileStream = File.Open(path, FileMode.Open, FileAccess.Read))
            {
                IExcelDataReader dataReader;

                if (path.EndsWith(".xls"))
                {
                    dataReader = ExcelReaderFactory.CreateBinaryReader(fileStream);
                }
                else if (path.EndsWith(".xlsx"))
                {
                    dataReader = ExcelReaderFactory.CreateOpenXmlReader(fileStream);
                }
                else
                {
                    //Throw exception for things you cannot correct
                    throw new FormatException("The file to be processed is not an Excel file");
                }

                dataReader.IsFirstRowAsColumnNames = isFirstRowAsColumnNames;

                return dataReader;
            }
        }

        private DataSet GetExcelDataAsDataSet(bool isFirstRowAsColumnNames)
        {
            return GetExcelDataReader(isFirstRowAsColumnNames).AsDataSet();
        }

        private DataTable GetExcelWorkSheet(string workSheetName, bool isFirstRowAsColumnNames)
        {
            DataSet dataSet = GetExcelDataAsDataSet(isFirstRowAsColumnNames);
            DataTable workSheet = dataSet.Tables[workSheetName];

            if (workSheet == null)
            {
                throw new Exception(string.Format("The worksheet {0} does not exist, has an incorrect name, or does not have any data in the worksheet", workSheetName));
            }

            return workSheet;
        }

        public IEnumerable<DataRow> GetData(string workSheetName, out IEnumerable<DataColumn> dataColumns,
            bool isFirstRowAsColumnNames = true)
        {
            DataTable workSheet = GetExcelWorkSheet(workSheetName, isFirstRowAsColumnNames);

            IEnumerable<DataRow> rows = from DataRow row in workSheet.Rows
                                        select row;
            dataColumns = from DataColumn column in workSheet.Columns
                          select column;

            return rows;
        }
    }
}
