using System;
using System.Data;
using System.Collections;
using System.Data.SqlClient;

using Powerson.Framework;

namespace Powerson.DataAccess
{
	/// <summary>
	/// 
	/// </summary>
	public class SqlDataCommon : DataCommon
	{
        SqlDataAdapter      _DataAdapter;
        SqlConnection       _Connection;

        public event SqlRowUpdatedEventHandler RowUpdated;


        public SqlDataCommon(string connectString)
        {
            if (null == connectString || connectString.Length.Equals(0))
                throw new ArgumentNullException("创建对象时连接字符串不能为空");
            _Connection = new SqlConnection();
            _Connection.ConnectionString = connectString;
        }
        public string ConnectString
        {
            set
            {
                _Connection.ConnectionString = value;
            }
        }
        public int GetAllData(string selectSql, DataSet ds, string tableName)
        {
            if (null == selectSql || selectSql.Length.Equals(0))
            {
                throw new ArgumentNullException("select语句不能是空");
            }
            _DataAdapter = new SqlDataAdapter();
            _DataAdapter.SelectCommand = new SqlCommand();
            _DataAdapter.SelectCommand.Connection = _Connection;
            _DataAdapter.SelectCommand.CommandText = selectSql;

            if (null == ds)
            {
                ds = new DataSet();
            }
            if (null == tableName || tableName.Length.Equals(0))
            {
                tableName = "t1";
            }
            int ret = 0;
            try
            {
                _DataAdapter.Fill(ds, tableName);
                ret = ds.Tables[tableName].Rows.Count;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                _Connection.Close();
                _DataAdapter.SelectCommand = null;
                _DataAdapter.Dispose();
            }
            return ret;
        }
        public int GetAllData(string spname, ArrayList p_params, DataSet ds, string tableName)
        {
            if (null == spname || spname.Length.Equals(0))
                throw new ArgumentNullException("用于查询的SP名称不能为空");
            if (null == ds)
                ds = new DataSet();
            if (null == tableName || tableName.Length.Equals(0))
                tableName = "t1";
            _DataAdapter = new SqlDataAdapter();
            _DataAdapter.SelectCommand = CreateCmd(spname, p_params);
            int ret;
            try
            {
                _DataAdapter.Fill(ds, tableName);
                ret = ds.Tables[tableName].Rows.Count;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                _Connection.Close();
                _DataAdapter.SelectCommand.Dispose();
                _DataAdapter.Dispose();
                _DataAdapter = null;
            }
            return ret;
        }
        public int ExecuteSql(string sql)
        {
            if (sql == null || sql.Length == 0)
                throw new ArgumentNullException("用于查询的sql语句不能为空");

            SqlCommand cmd = new SqlCommand(sql, _Connection);
            int ret = 0;
            try
            {
                _Connection.Open();
                ret = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                _Connection.Close();
                cmd.Dispose();
            }
            return ret;
        }
        public int ExecuteSP(string spname, ArrayList param)
        {
            if (null == spname || spname.Length.Equals(0))
                throw new ArgumentNullException("用于查询的SP名称不能为空");
            SqlCommand cmd = CreateCmd(spname, param);
            int ret;
            try
            {
                _Connection.Open();
                ret = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                _Connection.Close();
                cmd.Dispose();
            }
            return ret;
        }
        public int UpdateData(DataSet newDataSet)
        {
            if (null == newDataSet)
                throw new ArgumentNullException("用于更新的数据集不能为空");
            if (newDataSet.Tables.Count.Equals(0))
                throw new Exception("用于更新的数据集中没有数据表");
            int ret = 0;
            foreach (DataTable dt in newDataSet.Tables)
            {
                if (dt.TableName.Length > 0)
                {
                    string str_cols = "";
                    foreach (DataColumn dc in dt.Columns)
                    {
                        str_cols += dc.ColumnName + ",";
                    }
                    str_cols = StringUtil.StrLeftBack(str_cols, ",", true);

                    _DataAdapter = new SqlDataAdapter();
                    _DataAdapter.SelectCommand = new SqlCommand();
                    _DataAdapter.SelectCommand.Connection = _Connection;
                    _DataAdapter.SelectCommand.CommandText = string.Format("select top 1 {1} from {0}", dt.TableName, str_cols);
                }
                SqlCommandBuilder CmdBuilder = new SqlCommandBuilder(_DataAdapter);
                CmdBuilder.QuotePrefix = "[";
                CmdBuilder.QuoteSuffix = "]";
                try
                {
                    ret += _DataAdapter.Update(newDataSet, dt.TableName);
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    _Connection.Close();
                    CmdBuilder.RefreshSchema();
                    CmdBuilder.Dispose();
                    _DataAdapter.Dispose();
                    _DataAdapter = null;
                }
            }
            return ret;
        }
        public int InsertData(DataSet newDataSet, string srcTable)
        {
            if (!newDataSet.Tables.Contains(srcTable))
                throw new Exception("数据集中并不存在表" + srcTable);
            int newId;
            DataTable dt = newDataSet.Tables[srcTable];
            //get all col name
            string str_cols = "";
            foreach (DataColumn dc in dt.Columns)
            {
                str_cols += dc.ColumnName + ",";
            }
            str_cols = StringUtil.StrLeftBack(str_cols, ",", true);
            // prepair work
            _DataAdapter = new SqlDataAdapter();
            _DataAdapter.SelectCommand = new SqlCommand();
            _DataAdapter.SelectCommand.Connection = _Connection;
            _DataAdapter.SelectCommand.CommandText = string.Format("select top 1 {1} from {0}", dt.TableName, str_cols);
            SqlCommandBuilder CmdBuilder = new SqlCommandBuilder(_DataAdapter);
            CmdBuilder.QuotePrefix = "[";
            CmdBuilder.QuoteSuffix = "]";

            try
            {
                _Connection.Open();
                _DataAdapter.Update(newDataSet, srcTable);
                _DataAdapter.SelectCommand.CommandText = "SELECT @@IDENTITY";
                newId = Convert.ToInt32(_DataAdapter.SelectCommand.ExecuteScalar());
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                _Connection.Close();
                CmdBuilder.Dispose();
                _DataAdapter.Dispose();
                _DataAdapter = null;
            }
            return newId;
        }
        private SqlCommand CreateCmd(string procName, ArrayList prams)
        {
            SqlCommand Cmd = new SqlCommand();
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Connection = _Connection;
            Cmd.CommandText = procName;
            if (prams != null)
            {
                foreach (SqlParameter paramenter in prams)
                {
                    if (paramenter != null)
                    {
                        Cmd.Parameters.Add(paramenter);
                    }
                }
            }
            return Cmd;
        }
        private void DataCommon_RowUpdated(object sender, SqlRowUpdatedEventArgs e)
        {
            if (RowUpdated != null)
            {
                RowUpdated(sender, e);
            }
        }
	}
}
