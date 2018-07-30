using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using  Entity.Common;

namespace  Common
{
    /// <summary>
    /// Excel操作帮助
    /// </summary>
    public class ExcelHandle: IDisposable
    {
        private readonly string _fileName; //文件名
        private IWorkbook _workbook;
        private FileStream _fs;
        private bool _disposed;

        public ExcelHandle(string fileName)
        {
            this._fileName = fileName;
            _disposed = false;
        }
        /// <summary>
        /// 导出到excel
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <param name="sheetName"></param>
        /// <returns></returns>
        public static MemoryStream ListToExcel<T>(List<T> data, string sheetName = "Sheet1") where T : class
        {
            var count = 0;
            var columnIndex = 0;

            var type = data.GetType();
            var properties = type.GetGenericArguments()[0].GetProperties(); //获取T类型的所有属性

            IWorkbook workbook = new HSSFWorkbook();
            var sheet = workbook.CreateSheet(sheetName);

            try
            {
                var rowHeader = sheet.CreateRow(count);
                for (var n = 0; n < properties.Length; n++)
                {
                    //sheet.AutoSizeColumn(n);//自动列宽
                    var ignore = ((ExcelExportIgnoreAttribute[])properties[n].GetCustomAttributes(typeof(ExcelExportIgnoreAttribute), false)).FirstOrDefault();
                    if (ignore != null)
                    {
                        //sheet.SetColumnHidden(n, true);
                        continue;
                    }

                    var displayName = ((DisplayNameAttribute[])properties[n].GetCustomAttributes(typeof(DisplayNameAttribute), false)).FirstOrDefault();
                    rowHeader.CreateCell(columnIndex).SetCellValue(displayName == null ? "无列名" : displayName.DisplayName);
                    columnIndex++;
                }
                count++;



                for (var i = 0; i < data.Count; ++i)
                {
                    var obj = data[i];
                    var row = sheet.CreateRow(count);

                    columnIndex = 0;

                    for (var j = 0; j < properties.Length; ++j)
                    {
                        var ignore = ((ExcelExportIgnoreAttribute[])properties[j].GetCustomAttributes(typeof(ExcelExportIgnoreAttribute), false)).FirstOrDefault();
                        if (ignore != null)
                        {
                            //sheet.SetColumnHidden(j, true);
                            continue;
                        }
                        var pValue = properties[j].GetValue(obj, null);
                        var cell = row.CreateCell(columnIndex);
                        cell.SetCellValue(pValue == null ? "" : pValue.ToString());
                        columnIndex++;
                    }
                    ++count;
                }

                using (var ms = new MemoryStream())
                {
                    workbook.Write(ms); //写入到内存流
                    ms.Flush();
                    ms.Position = 0;
                    return ms;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static MemoryStream RenderToExcel(DataTable table)
        {
            try
            {
                IWorkbook workbook = new HSSFWorkbook();
                var sheet = workbook.CreateSheet();
                var headerRow = sheet.CreateRow(0);
                // handling header.
                foreach (DataColumn column in table.Columns)
                    headerRow.CreateCell(column.Ordinal).SetCellValue(column.Caption);//If Caption not set, returns the ColumnName value

                // handling value.
                int rowIndex = 1;

                foreach (DataRow row in table.Rows)
                {
                    var dataRow = sheet.CreateRow(rowIndex);

                    foreach (DataColumn column in table.Columns)
                    {
                        dataRow.CreateCell(column.Ordinal).SetCellValue(row[column].ToString());
                    }

                    rowIndex++;
                }
                using (var ms = new MemoryStream())
                {
                    workbook.Write(ms); //写入到内存流
                    ms.Flush();
                    ms.Position = 0;
                    return ms;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 将excel中的数据导入到DataTable中
        /// </summary>
        /// <param name="sheetName">excel工作薄sheet的名称</param>
        /// <param name="isFirstRowColumn">第一行是否是DataTable的列名</param>
        /// <returns>返回的DataTable</returns>
        public DataTable ExcelToDataTable(string sheetName, bool isFirstRowColumn)
        {
            var data = new DataTable();
            try
            {
                _fs = new FileStream(_fileName, FileMode.Open, FileAccess.Read);
                if (_fileName.IndexOf(".xlsx", StringComparison.Ordinal) > 0) // 2007版本以上
                    _workbook = new XSSFWorkbook(_fs);
                else if (_fileName.IndexOf(".xls", StringComparison.Ordinal) > 0) // 2003版本
                    _workbook = new HSSFWorkbook(_fs);

                ISheet sheet = null;
                sheet = sheetName != null ? _workbook.GetSheet(sheetName) : _workbook.GetSheetAt(0);
                if (sheet == null) return data;
                var firstRow = sheet.GetRow(0);
                int cellCount = firstRow.LastCellNum; //一行最后一个cell的编号 即总的列数

                var startRow = 0;
                if (isFirstRowColumn)
                {
                    for (int i = firstRow.FirstCellNum; i < cellCount; ++i)
                    {
                        var column = new DataColumn(firstRow.GetCell(i).ToString());
                        data.Columns.Add(column);
                    }
                    startRow = sheet.FirstRowNum + 1;
                }
                else
                {
                    startRow = sheet.FirstRowNum;
                }

                //最后一列的标号
                var rowCount = sheet.LastRowNum;
                for (var i = startRow; i <= rowCount; ++i)
                {
                    var row = sheet.GetRow(i);
                    if (row == null)//没有数据的行默认是null
                    {
                        continue;
                    }
                    if (string.IsNullOrWhiteSpace(row.GetCell(row.FirstCellNum).ToString()))
                    {
                        continue;
                    }

                    var dataRow = data.NewRow();
                    for (int j = row.FirstCellNum; j < cellCount; ++j)
                    {
                        if (row.GetCell(j) != null) //同理，没有数据的单元格都默认是null
                            dataRow[j] = row.GetCell(j).ToString();
                    }
                    data.Rows.Add(dataRow);
                }

                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 创建一个Excel
        /// </summary>
        /// <param name="data"></param>
        /// <param name="fileNamePath">文件名绝对路径</param>
        /// <param name="folder">文件所在的文件夹绝对路径</param>
        public void CreateExcel(DataTable data, string fileNamePath, string folder = null)
        {

            var wk = new XSSFWorkbook();
            var sheet = wk.CreateSheet("Sheet1");

            //字体设置
            var font = wk.CreateFont();
            font.Color = HSSFColor.Red.Index;
            var style = wk.CreateCellStyle();
            style.SetFont(font);


            var count = 0;

            var headerRow = sheet.CreateRow(count);
            foreach (DataColumn column in data.Columns)
                headerRow.CreateCell(column.Ordinal).SetCellValue(column.Caption);
            count++;
            foreach (DataRow row in data.Rows)
            {
                var datarow = sheet.CreateRow(count);

                foreach (DataColumn column in data.Columns)
                {
                    var cell = datarow.CreateCell(column.Ordinal);
                    var cellValue = row[column].ToString();
                    if (!string.IsNullOrEmpty(cellValue))
                    {
                        var array = cellValue.Split('#');
                        if (array.Length == 2)
                            cell.CellStyle = style;

                        cell.SetCellValue(array[0]);
                    }
                    else
                    {
                        cell.SetCellValue(cellValue);
                    }

                }
                ++count;
            }

            if (!string.IsNullOrWhiteSpace(folder))
            {
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

            }

            using (var openWrite = File.OpenWrite(fileNamePath)) //打开一个xlsx文件，如果没有则自行创建，如果存在myxls.xlsx文件则在创建是不要打开该文件！
            {
                wk.Write(openWrite);   //向打开的这个xlsx文件中写入mySheet表并保存。
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    if (_fs != null)
                        _fs.Close();
                }

                _fs = null;
                _disposed = true;
            }
        }
    }
}
