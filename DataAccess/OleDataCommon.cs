using System;
using System.Data;
using System.Collections;
using System.Data.OleDb;

using Powerson.Framework;

namespace Powerson.DataAccess
{
	/// <summary>
	/// 
	/// </summary>
	public class OleDataCommon : DataCommon
	{
		protected OleDbDataAdapter		    _DataAdapter;
		protected OleDbConnection			_Connection;

		public event OleDbRowUpdatedEventHandler RowUpdated;


        public string ConnectString
        {
            set
            {
                _Connection.ConnectionString = value;
            }
        }

        public OleDataCommon(string connectString)
        {
            _Connection = new OleDbConnection();
            _Connection.ConnectionString = connectString;
        }


        public int GetAllData(string sql, DataSet dataSet, string tableName)
        {
            if (null == sql || sql.Length.Equals(0))
                throw new ArgumentNullException("用于查询的sql语句不能为空");
            if (null == dataSet)
                dataSet = new DataSet();
            if (null == tableName || tableName.Length.Equals(0))
                tableName = "tb1";

            _DataAdapter = new OleDbDataAdapter();
            _DataAdapter.SelectCommand = new OleDbCommand();
            _DataAdapter.SelectCommand.Connection = _Connection;
            _DataAdapter.SelectCommand.CommandText = sql;
            int ret;
            try
            {
                ret = _DataAdapter.Fill(dataSet, tableName);
                //p_ds.Tables[p_tableName].Namespace = p_sql;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                _Connection.Close();
                _DataAdapter.Dispose();
                _DataAdapter = null;
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
            _Connection.Open();
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
                    _DataAdapter.SelectCommand.CommandText = string.Format("select {1} from {0} where id=0", dt.TableName, str_cols);
                }
                OleDbCommandBuilder oleDbCmdBuilder = new OleDbCommandBuilder(_DataAdapter);
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
                }
            }
            _Connection.Close();
            return ret;
		}

		public int InsertData(DataSet newDataSet, string p_table_name)
		{
            if (null == newDataSet)
                throw new ArgumentNullException("用于更新的数据集不能为空");
            int newId = 0;

            DataTable dt = newDataSet.Tables[p_table_name];
            string str_cols = "";
            for (int i = 0; i < dt.Columns.Count; i ++ )
            {
                str_cols += dt.Columns[i].ColumnName;
                if (i < dt.Columns.Count - 1)
                    str_cols += ",";
            }
            _DataAdapter.SelectCommand.CommandText = string.Format("select {1} from {0} where id=0", p_table_name, str_cols);

			OleDbCommandBuilder oleDbCmdBuilder = new OleDbCommandBuilder(_DataAdapter);
			
			try
			{
				_Connection.Open();
				_DataAdapter.Update(newDataSet, p_table_name);
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
			}
            if (0 == newId)
                throw new DataException("没有插入任何数据");
			return newId;
		}

        public int ExecuteSql(string p_sql)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = _Connection;
            cmd.CommandText = p_sql;

            try
            {
	            _Connection.Open();
                return cmd.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                throw e;
            }
            finally
            {
                _Connection.Close();
            }
        }

		private void DataCommon_RowUpdated(object sender,OleDbRowUpdatedEventArgs e)
		{
			if(RowUpdated != null)
			{
				RowUpdated(sender,e);
			}
		}
        public int GetAllData(string p_spname, ArrayList p_params, DataSet p_ds, string p_tableName)
        {
            throw new NotImplementedException();
        }
        public int ExecuteSP(string p_spname, ArrayList p_params)
        {
            OleDbCommand cmd = CreateCmd(p_params);
            cmd.Connection = _Connection;
            cmd.CommandText = p_spname;
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
                cmd = null;
            }
            return ret;
        }
        private OleDbCommand CreateCmd(ArrayList prams)
        {
            OleDbCommand Cmd = new OleDbCommand();
            if (prams != null)
            {
                foreach (OleDbParameter paramenter in prams)
                {
                    if (paramenter != null)
                    {
                        Cmd.Parameters.Add(paramenter);
                    }
                }
            }
            return Cmd;
        }
    }
}
