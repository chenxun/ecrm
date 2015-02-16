using System;
using System.Data;
using System.Collections;
using MySql.Data.MySqlClient;

using Powerson.Framework;

namespace Powerson.DataAccess
{
	/// <summary>
	/// 
	/// </summary>
	public class MysqlDataCommon : DataCommon
	{
        MySqlDataAdapter       _DataAdapter;
        MySqlConnection        _Connection;

        public event MySqlRowUpdatedEventHandler RowUpdated;

        public MysqlDataCommon(string p_conn)
		{
            _Connection = new MySqlConnection();
            _Connection.ConnectionString = p_conn;
        }

        void _oraDataAdp_RowUpdated(object sender, MySqlRowUpdatedEventArgs e)
        {
            if (RowUpdated != null)
            {
                RowUpdated(sender, e);
            }
        }
        public string ConnectString
        {
            set
            {
                _Connection.ConnectionString = value;
            }
        }


        public int GetAllData(string selectString, DataSet ds, string tableName)
        {
            if (null == selectString || selectString.Length.Equals(0))
                throw new ArgumentNullException("用于查询的sql语句不能为空");
            if (null == ds)
                ds = new DataSet();
            if (null == tableName || tableName.Length.Equals(0))
                tableName = "t1";

            _DataAdapter = new MySqlDataAdapter();
            _DataAdapter.SelectCommand = new MySqlCommand();
            _DataAdapter.SelectCommand.Connection = _Connection;
            _DataAdapter.SelectCommand.CommandText = selectString;
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
            _DataAdapter = new MySqlDataAdapter();
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

        public int ExecuteSql(string p_sql)
        {
            if(p_sql == null || p_sql.Length == 0)
                throw new ArgumentNullException("用于查询的sql语句不能为空");

            MySqlCommand cmd = new MySqlCommand(p_sql, _Connection);
            int ret = 0;
            try
            {
                _Connection.Open();
                ret = cmd.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                throw e;
            }
            finally
            {
                _Connection.Close();
                cmd = null;
            }
            return ret;
        }
        public int ExecuteSP(string spname, ArrayList param)
        {
            if (null == spname || spname.Length.Equals(0))
                throw new ArgumentNullException("用于查询的SP名称不能为空");
            MySqlCommand cmd = CreateCmd(spname, param);
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
        public MySqlParameter CreateParam(string ParamName, MySqlDbType dbType, int size, object value)
        {
            MySqlParameter param;
            param = new MySqlParameter(ParamName, dbType);
            if (size > 0)
            {
                param.Size = size;
            }
            ///创建输出类型的参数
            param.Direction = ParameterDirection.Input;
            if (value != null)
            {
                param.Value = value;
            }
            return param;
        }
        private MySqlCommand CreateCmd(string procName, ArrayList prams)
        {
            MySqlCommand Cmd = new MySqlCommand();
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Connection = _Connection;
            Cmd.CommandText = procName;
            if (prams != null)
            {
                foreach (MySqlParameter paramenter in prams)
                {
                    if (paramenter != null)
                    {
                        Cmd.Parameters.Add(paramenter);
                    }
                }
            }
            return Cmd;
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

                    _DataAdapter = new MySqlDataAdapter();
                    //_DataAdapter.RowUpdated += new MySqlRowUpdatedEventHandler(_oraDataAdp_RowUpdated);
                    _DataAdapter.SelectCommand = new MySqlCommand();
                    _DataAdapter.SelectCommand.Connection = _Connection;
                    _DataAdapter.SelectCommand.CommandText = string.Format("select {1} from {0} limit 1", dt.TableName, str_cols);
                }
                MySqlCommandBuilder CmdBuilder = new MySqlCommandBuilder(_DataAdapter);
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
        public int InsertData(DataSet newDataSet, string p_srcTable)
        {
            int newId;

            foreach (DataTable dt in newDataSet.Tables)
            {
                if (dt.TableName.Equals(p_srcTable))
                {
                    string str_cols = "";
                    foreach (DataColumn dc in dt.Columns)
                    {
                        str_cols += dc.ColumnName + ",";
                    }
                    str_cols = StringUtil.StrLeftBack(str_cols, ",", true);
                    _DataAdapter = new MySqlDataAdapter();
                    _DataAdapter.SelectCommand = new MySqlCommand();
                    _DataAdapter.SelectCommand.Connection = _Connection;
                    _DataAdapter.SelectCommand.CommandText = string.Format("select {1} from {0} limit 0", dt.TableName, str_cols);
                    MySqlCommandBuilder sqlCmdBuilder = new MySqlCommandBuilder(_DataAdapter);
                    try
                    {
                        _Connection.Open();
                        _DataAdapter.Update(newDataSet, p_srcTable);
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
                        sqlCmdBuilder = null;
                        _DataAdapter.SelectCommand = null;
                        _DataAdapter = null;
                    }
                    return newId;
                }
            }
            throw new Exception("数据集中并不存在表" + p_srcTable);
        }

	}
}
