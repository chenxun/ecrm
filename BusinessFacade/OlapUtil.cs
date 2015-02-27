using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;

namespace Powerson.Framework
{
    public class OlapUtil
    {
        public const string COL_MEMBER_X = "MemberX";
        public const string COL_MEMBER_Y = "MemberY";
        public const string COL_MEMBER_z = "MemberZ";
        public const string ROW_NULL = "[未设置]";
        /// <summary>
        /// 统计一张二维表中的1个字段
        /// 这个字段的每个值，统计出一个总数
        /// </summary>
        /// <param name="p_source"></param>
        /// <param name="p_colx"></param>
        /// <returns></returns>
        public static DataTable OneDimStat(DataTable p_source, string p_colx)
        {
            if (p_source == null)
                throw new ArgumentNullException("用于统计的元数据表为空");
            if (null == p_colx )
                throw new ArgumentNullException("用于统计的列名称为空");
            if (!p_source.Columns.Contains(p_colx) )
                throw new ArgumentException("元数据表并不包含这两列，无法统计");

            DataTable ret = new DataTable("OneDim");
            ret.Columns.Add(COL_MEMBER_X, typeof(String));
            ret.Columns.Add(COL_MEMBER_Y, typeof(Int32));
            ret.PrimaryKey = new DataColumn[] { ret.Columns[COL_MEMBER_X] };

            foreach(DataRow dr in p_source.Rows)
            {
                string str_colx = dr[p_colx].ToString();
                DataRow rowx = null;
                if (str_colx.Length == 0)
                {
                    rowx = ret.Rows.Find(ROW_NULL);
                    if (rowx == null)
                    {
                        DataRow row = ret.NewRow();
                        row[COL_MEMBER_X] = ROW_NULL;
                        row[COL_MEMBER_Y] = 1;
                        ret.Rows.Add(row);
                        continue;
                    }
                    else// 代码到了这里，说明ret中已经有了一行是[未设置] [6/16/2009]
                    {
                        rowx[COL_MEMBER_Y] = Convert.ToInt32(rowx[COL_MEMBER_Y]) + 1;
                        continue;
                    }
                }
                rowx = ret.Rows.Find(str_colx);
                if (rowx == null)
                {
                    DataRow row = ret.NewRow();
                    row[COL_MEMBER_X] = str_colx;
                    row[COL_MEMBER_Y] = 1;
                    ret.Rows.Add(row);
                    continue;
                }
                else
                {
                    rowx[COL_MEMBER_Y] = Convert.ToInt32(rowx[COL_MEMBER_Y]) + 1;
                    continue;
                }
            }
            return ret;
        }
        public static DataTable OneDimCountByDate(DataTable p_source, string p_date_col)
        {
            if (p_source == null)
                throw new ArgumentNullException("用于统计的元数据表为空");
            if (!p_source.Columns.Contains(p_date_col))
                throw new ArgumentException("元数据表并不包含日期列，无法统计");

            DataTable ret = new DataTable("OneDim");
            ret.Columns.Add(COL_MEMBER_X, typeof(String));
            ret.Columns.Add(COL_MEMBER_Y, typeof(float));
            ret.PrimaryKey = new DataColumn[] { ret.Columns[COL_MEMBER_X] };
            foreach (DataRow dr in p_source.Rows)
            {
                if (dr.IsNull(p_date_col) || dr[p_date_col].ToString().Length == 0)
                    continue;
                DateTime dr_date = Convert.ToDateTime(dr[p_date_col]);
                DataRow rowx = null;

                rowx = ret.Rows.Find(dr_date.ToShortDateString());
                if (rowx == null)
                {
                    DataRow row = ret.NewRow();
                    row[COL_MEMBER_X] = dr_date.ToShortDateString();
                    row[COL_MEMBER_Y] = 1;
                    ret.Rows.Add(row);
                    continue;
                }
                else
                {
                    rowx[COL_MEMBER_Y] = Convert.ToInt32(rowx[COL_MEMBER_Y]) + 1;
                    continue;
                }
            }
            return ret;
        }
        /// <summary>
        /// 计算一个字段的平均值，比如算bug平均关闭时间
        /// </summary>
        /// <param name="p_source"></param>
        /// <param name="p_colx"></param>
        /// <param name="p_coly"></param>
        /// <returns></returns>
        public static DataTable OneDimAverage(DataTable p_source, string p_colx, string p_coly, string p_filter)
        {
            if (p_source == null)
                throw new ArgumentNullException("用于统计的元数据表为空");
            if (null == p_coly)
                throw new ArgumentNullException("用于统计的列名称为空");
            if (!p_source.Columns.Contains(p_coly))
                throw new ArgumentException("元数据表并不包含这两列，无法统计");

            DataTable ret = new DataTable("OneDim");
            ret.Columns.Add(COL_MEMBER_X, typeof(String));
            ret.Columns.Add(COL_MEMBER_Y, typeof(Int32));
            ret.Columns.Add(COL_MEMBER_z, typeof(Single));
            ret.PrimaryKey = new DataColumn[] { ret.Columns[COL_MEMBER_X] };

            if (null != p_filter)// 如果有过滤条件，要先应用一下 [12/2/2010 tiantong]
            {
                DataView dv = p_source.DefaultView;
                dv.RowFilter = p_filter;
                p_source = dv.ToTable();
            }
            foreach (DataRow dr in p_source.Rows)
            {
                string str_colx = dr[p_coly].ToString();
                DataRow rowx = null;
                if (str_colx.Length == 0)
                {
                    rowx = ret.Rows.Find(ROW_NULL);
                    if (rowx == null)
                    {
                        DataRow row = ret.NewRow();
                        row[COL_MEMBER_X] = ROW_NULL;
                        row[COL_MEMBER_Y] = 1;
                        row[COL_MEMBER_z] = Convert.ToDouble(dr[p_colx]);
                        ret.Rows.Add(row);
                        continue;
                    }
                    else// 代码到了这里，说明ret中已经有了一行是[未设置] [6/16/2009]
                    {
                        rowx[COL_MEMBER_Y] = Convert.ToInt32(rowx[COL_MEMBER_Y]) + 1;
                        rowx[COL_MEMBER_z] = Convert.ToDouble(rowx[COL_MEMBER_z]) + Convert.ToDouble(dr[p_colx]);
                        continue;
                    }
                }
                rowx = ret.Rows.Find(str_colx);
                if (rowx == null)
                {
                    DataRow row = ret.NewRow();
                    row[COL_MEMBER_X] = str_colx;
                    row[COL_MEMBER_Y] = 1;
                    row[COL_MEMBER_z] = Convert.ToDouble(dr[p_colx]);
                    ret.Rows.Add(row);
                    continue;
                }
                else
                {
                    rowx[COL_MEMBER_Y] = Convert.ToInt32(rowx[COL_MEMBER_Y]) + 1;
                    rowx[COL_MEMBER_z] = Convert.ToDouble(rowx[COL_MEMBER_z]) + Convert.ToDouble(dr[p_colx]);
                    continue;
                }
            }
            foreach(DataRow dr in ret.Rows)
            {
                if (Convert.ToInt32(dr[COL_MEMBER_Y]) == 0)
                    continue;
                dr[COL_MEMBER_z] = Convert.ToDouble(dr[COL_MEMBER_z]) / Convert.ToDouble(dr[COL_MEMBER_Y]);
            }
            return ret;
        }
        /// <summary>
        /// 用两个维度来统计一个表格
        /// </summary>
        /// <param name="p_source">元数据表格</param>
        /// <param name="p_colx">x列是统计维度</param>
        /// <param name="p_coly">y列是分组维度</param>
        /// <returns>x列的成员出现在col上，y列的成员出现在row上</returns>
        public static DataTable TwoDimStat(DataTable p_source, string p_colx, string p_coly)
        {
            if(p_source == null)
                throw new ArgumentNullException("用于统计的元数据表为空");
            if(null == p_colx || null == p_coly)
                throw new ArgumentNullException("用于统计的列名称");
            if(!p_source.Columns.Contains(p_colx) || !p_source.Columns.Contains(p_coly))
                throw new ArgumentException("元数据表并不包含这两列，无法统计");
            
            DataTable ret = new DataTable("TwoDim");
            string str_memberx = COL_MEMBER_X;
            string str_null = ROW_NULL;
            ret.Columns.Add(str_memberx, typeof(String));
            ret.PrimaryKey = new DataColumn[] { ret.Columns["MemberX"] };
            
            // 首先建立好返回表的结构 [6/16/2009]
            foreach(DataRow dr in p_source.Rows)
            {
                DataColumn col = null;
                if (dr.IsNull(p_colx) || dr[p_colx].ToString().Trim().Length == 0 )
                {
                    if (!ret.Columns.Contains(str_null))
                    {
                        col = new DataColumn(str_null, typeof(float));
                        col.DefaultValue = 0;
                        ret.Columns.Add(col);
                        continue;
                    }
                }else
                {
                    if (!ret.Columns.Contains(dr[p_colx].ToString()))
                    {
                        col = new DataColumn(dr[p_colx].ToString(), typeof(float));
                        col.DefaultValue = 0;
                        ret.Columns.Add(col);
                        continue;
                    }

                }
            }
            foreach (DataRow dr in p_source.Rows)
            {
                string str_coly = dr[p_coly].ToString();
                // 判断str_coly是不是空，并且ret中没有一行是[未设置] [6/16/2009]
                DataRow rowy = null;
                if(str_coly.Length == 0 )
                {
                    rowy = ret.Rows.Find(str_null);
                    if(rowy == null)
                    {
                        DataRow row = ret.NewRow();
                        row[str_memberx] = str_null;
                        // 如果碰巧x也是空，那就... [6/16/2009]
                        if(dr[p_colx].ToString().Length == 0 )
                        {
                            row[str_null] = 1;
                        }else
                        {
                            row[dr[p_colx].ToString()] = 1;
                        }
                        ret.Rows.Add(row);
                        continue;
                    }else// 代码到了这里，说明ret中已经有了一行是[未设置] [6/16/2009]
                    {
                        if(dr[p_colx].ToString().Length == 0 )
                        {
                            rowy[str_null] = Convert.ToInt32(rowy[str_null]) + 1;
                        }else
                        {
                            rowy[dr[p_colx].ToString()] = Convert.ToInt32(rowy[dr[p_colx].ToString()]) + 1;
                        }
                        continue;
                    }
                }
                // 代码到了这里，说明y不是空，那就看看ret有没有一行是y [6/16/2009]
                rowy = ret.Rows.Find(str_coly);
                if(rowy == null)
                {
                    DataRow row = ret.NewRow();
                    row[str_memberx] = str_coly;
                    if (dr[p_colx].ToString().Length == 0)
                    {
                        row[str_null] = 1;
                    }
                    else
                    {
                        row[dr[p_colx].ToString()] = 1;
                    }
                    ret.Rows.Add(row);
                    continue;
                }
                else
                {
                    if (dr[p_colx].ToString().Length == 0)
                    {
                        rowy[str_null] = Convert.ToInt32(rowy[str_null]) + 1;
                    }
                    else
                    {
                        rowy[dr[p_colx].ToString()] = Convert.ToInt32(rowy[dr[p_colx].ToString()]) + 1;
                    }
                    continue;
                }
            }
            //foreach (DataColumn dc in ret.Columns)
            //{
            //    if (dc.ColumnName.StartsWith("1"))
            //    {
            //        dc.SetOrdinal(1);
            //    }
            //}
            return ret;
        }
        /// <summary>
        /// 根据一个字段的数值求和，然后再除以条目的个数
        /// 比如计算reopen率，reopen的个数是一个字段
        /// </summary>
        /// <param name="p_source"></param>
        /// <param name="p_col_group"></param>
        /// <param name="p_filter"></param>
        /// <returns></returns>
        public static DataTable BugReopenRate(DataTable p_source, string p_col_to_compute, string p_col_group, string p_filter)
        {
            if (p_source == null)
                throw new ArgumentNullException("用于统计的元数据表为空");
            if (null == p_col_group)
                throw new ArgumentNullException("用于统计的列名称为空");
            if (!p_source.Columns.Contains(p_col_group))
                throw new ArgumentException("元数据表并不包含这两列，无法统计");

            const string COL_REOPEN_TIMES = "reopen_times";
            const string COL_REOPEN_RATE = "reopen_rate";
            const string COL_BUG_COUNT = "bug_count";
            DataTable ret = new DataTable("BugReopenRate");
            ret.Columns.Add(COL_MEMBER_X, typeof(String));
            ret.Columns.Add(COL_MEMBER_z, typeof(Single));
            ret.Columns.Add(COL_REOPEN_TIMES, typeof(Int32));
            ret.Columns.Add(COL_BUG_COUNT, typeof(Int32));
            ret.PrimaryKey = new DataColumn[] { ret.Columns[COL_MEMBER_X] };

            if (null != p_filter)
            {
                DataView dv = p_source.DefaultView;
                dv.RowFilter = p_filter;
                p_source = dv.ToTable();
            }
            foreach (DataRow dr in p_source.Rows)
            {
                string str_group = dr[p_col_group].ToString();
                DataRow rowx = null;
                if (str_group.Length == 0)
                {
                    rowx = ret.Rows.Find(ROW_NULL);
                    if (rowx == null)
                    {
                        DataRow row = ret.NewRow();
                        row[COL_MEMBER_X] = ROW_NULL;
                        row[COL_BUG_COUNT] = 1;
                        row[COL_REOPEN_TIMES] = dr[p_col_to_compute];
                        ret.Rows.Add(row);
                        continue;
                    }
                    else// 代码到了这里，说明ret中已经有了一行是[未设置] [6/16/2009]
                    {
                        rowx[COL_BUG_COUNT] = Convert.ToInt32(rowx[COL_BUG_COUNT]) + 1;
                        rowx[COL_REOPEN_TIMES] = Convert.ToSingle(rowx[COL_REOPEN_TIMES]) + Convert.ToSingle(dr[p_col_to_compute]);
                        continue;
                    }
                }
                rowx = ret.Rows.Find(str_group);
                if (rowx == null)
                {
                    DataRow row = ret.NewRow();
                    row[COL_MEMBER_X] = str_group;
                    row[COL_BUG_COUNT] = 1;
                    row[COL_REOPEN_TIMES] = dr[p_col_to_compute];
                    ret.Rows.Add(row);
                    continue;
                }
                else
                {
                    rowx[COL_BUG_COUNT] = Convert.ToInt32(rowx[COL_BUG_COUNT]) + 1;
                    rowx[COL_REOPEN_TIMES] = Convert.ToSingle(rowx[COL_REOPEN_TIMES]) + Convert.ToSingle(dr[p_col_to_compute]);
                    continue;
                }
            }
            foreach (DataRow dr in ret.Rows)
            {
                if (Convert.ToInt32(dr[COL_BUG_COUNT]) == 0)
                    continue;
                dr[COL_MEMBER_z] = 100 * Convert.ToSingle(dr[COL_REOPEN_TIMES]) / Convert.ToSingle(dr[COL_BUG_COUNT]);
            }

            return ret;
        }

    }
}
