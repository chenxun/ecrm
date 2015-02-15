using System;
using System.Data;
using System.Collections;
using System.Data.Common;

namespace Powerson.DataAccess
{
	/// <summary>
	/// 
	/// </summary>
	public interface DataCommon
	{
        /// <summary>
        /// 根据sql将数据读取到DataSet中
        /// </summary>
        /// <param name="p_selectSql">读取数据的sql语句</param>
        /// <param name="p_ds">用于Fill数据的DataSet</param>
        /// <param name="p_tableName">保存在DataSet中的Table名称</param>
        int GetAllData(string p_selectSql, DataSet p_ds, string p_tableName);
        /// <summary>
        /// 使用存储过程，将数据fill到DataSet中
        /// </summary>
        /// <param name="p_spname"></param>
        /// <param name="p_params"></param>
        /// <param name="p_ds"></param>
        /// <param name="p_tableName"></param>
        int GetAllData(string p_spname, ArrayList p_params, DataSet p_ds, string p_tableName);
		/// <summary>
		/// 将DataSet中的数据更新到数据库
		/// </summary>
		/// <param name="newDataSet"></param>
        int UpdateData(DataSet newDataSet);
		/// <summary>
		/// 将DataSet中的一张表中的新数据插入数据库，同时得到新记录的id
		/// </summary>
		/// <param name="newDataSet"></param>
		/// <param name="p_srcTable"></param>
		/// <returns></returns>
        int InsertData(DataSet newDataSet, string p_srcTable);
        /// <summary>
        /// 只执行sql语句
        /// </summary>
        /// <param name="p_sql"></param>
        /// <returns></returns>
        int ExecuteSql(string p_sql);
        /// <summary>
        /// 执行一个存储过程
        /// </summary>
        /// <param name="p_spname"></param>
        /// <param name="p_params"></param>
        /// <returns></returns>
        int ExecuteSP(string p_spname, ArrayList p_params);

		/// <summary>
		/// 连接字符串
		/// </summary>
		string ConnectString
		{
			set;
		}

	}
}
