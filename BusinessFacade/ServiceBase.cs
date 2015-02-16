using System;
using System.Data;
using Powerson.DataAccess;

namespace Powerson.BusinessFacade
{
	/// <summary>
	/// 
	/// </summary>
	public class ServiceBase
	{
        protected DataCommon dataCommon;
		public ServiceBase()
		{
			dataCommon = null;
		}
		public DataCommon ServiceDataCommon
		{
			set
			{
				dataCommon = value;
			}
		}
		protected object createDO(string p_sql, string[] p_property, Type p_type)
		{
            DataSet ds = new DataSet();
			try
			{
				dataCommon.GetAllData(p_sql, ds, "DataObject");
			}
			catch(Exception e)
			{
				throw new Exception("读取数据库失败，请检查日志文件", e);
			}
			if (ds.Tables[0].Rows.Count.Equals(0))
			{
				return null;
			}
			return createDO(ds.Tables[0].Rows[0], p_property, p_type);
		}
		protected object createDO(DataRow p_source, string[] p_property, Type p_type)
		{
			if (p_source == null)
			{
				throw new NullReferenceException("传入的数据表参数是null，无法转换为对象");
			}
			object ret = Activator.CreateInstance(p_type);
			foreach (string pro in p_property)
			{
				if (!p_source.Table.Columns.Contains(pro))
				{
					throw new Exception(string.Format("对象的{0}属性，数据表中没有相关的列与此匹配", pro));
				}
				if (p_source.IsNull(pro) )
				{
					continue;
				}
				try
				{
					ret.GetType().GetProperty(pro).SetValue(ret, p_source[pro], null);
				}
				catch(Exception e)
				{
					throw new Exception(string.Format("在给对象{0}赋值时出现错误", pro), e);
				}
			}

			return ret;
		}
		protected object[] createDO(DataTable p_source, string[] p_property, Type p_type)
		{
			if (p_source == null)
			{
				throw new NullReferenceException("传入的数据表参数是null，无法转换为对象");
			}
			foreach (string pro in p_property)
			{
				if (!p_source.Columns.Contains(pro))
				{
					throw new Exception(string.Format("对象的{0}属性，数据表中没有相关的列与此匹配", pro));
				}
			}
			object[] ret = new object[p_source.Rows.Count];
			for (int i = 0 ; i < p_source.Rows.Count ; i ++)
			{
				object obj = Activator.CreateInstance(p_type);
				foreach (string pro in p_property)
				{
					if (p_source.Rows[i].IsNull(pro) )
					{
						continue;
					}
					try
					{
						obj.GetType().GetProperty(pro).SetValue(obj, p_source.Rows[i][pro], null);
					}
					catch(Exception e)
					{
						throw new Exception(string.Format("在给对象{0}赋值时出现错误", pro), e);
					}
				}
				ret.SetValue(obj,i);
			}

			return ret;
		}

	}
}
