using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

using Powerson.Framework;
using Powerson.DataAccess;

namespace Powerson.BusinessFacade
{
    public class ExcelUtil
    {
        public static DataTable GetExcelData(string excel_file_path, string sheet_name)
        {
            string str_excel_conn = BuildConnectString(excel_file_path);
            OleDataCommon oled_excel = new OleDataCommon(str_excel_conn);
            DataSet ds_excel = new DataSet();
            oled_excel.GetAllData("SELECT * FROM [" + sheet_name + "$]", ds_excel, sheet_name);

            if (null == ds_excel)
                throw new NullReferenceException("没有取得EXCEL文件的信息");

            return ds_excel.Tables[0];
        }

        private static string BuildConnectString(string excel_file_path)
        {
            if (!System.IO.File.Exists(excel_file_path))
                throw new System.IO.FileNotFoundException("file not found", excel_file_path);
            string ext = StringUtil.StrRight(excel_file_path, ".", false);
            string ret = null;
            switch (ext)
            {
                case "xls":
                    ret = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=\"Excel 8.0;HDR=Yes\"", excel_file_path);
                    break;
                case "xlsx":
                    ret = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0;HDR=YES\";", excel_file_path);
                    break;
                default:
                    throw new System.IO.FileNotFoundException("please select excel file", excel_file_path);
            }
            return ret;
        }

    }
}