﻿using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using ForKids.DB.IDAL;
using ForKids.DB.Utility;//Please add references
namespace ForKids.DB.OleDbDAL
{
	/// <summary>
	/// 数据访问类:MEETINGBASE
	/// </summary>
	public partial class MEETINGBASE:IMEETINGBASE
	{
		public MEETINGBASE()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperOleDb.GetMaxID("ID", "MEETINGBASE"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from MEETINGBASE");
			strSql.Append(" where ID=@ID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.Integer,4)
			};
			parameters[0].Value = ID;

			return DbHelperOleDb.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(ForKids.DB.Model.MEETINGBASE model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into MEETINGBASE(");
			strSql.Append("NAME,DESCRITION,MEETINGDATE,ATTENDANCE,SUMMARY)");
			strSql.Append(" values (");
			strSql.Append("@NAME,@DESCRITION,@MEETINGDATE,@ATTENDANCE,@SUMMARY)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@NAME", OleDbType.VarChar,255),
					new OleDbParameter("@DESCRITION", OleDbType.VarChar,255),
					new OleDbParameter("@MEETINGDATE", OleDbType.Date),
					new OleDbParameter("@ATTENDANCE", OleDbType.Double),
					new OleDbParameter("@SUMMARY", OleDbType.VarChar,255)};
			parameters[0].Value = model.NAME;
			parameters[1].Value = model.DESCRITION;
			parameters[2].Value = model.MEETINGDATE;
			parameters[3].Value = model.ATTENDANCE;
			parameters[4].Value = model.SUMMARY;

			int rows=DbHelperOleDb.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ForKids.DB.Model.MEETINGBASE model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update MEETINGBASE set ");
			strSql.Append("NAME=@NAME,");
			strSql.Append("DESCRITION=@DESCRITION,");
			strSql.Append("MEETINGDATE=@MEETINGDATE,");
			strSql.Append("ATTENDANCE=@ATTENDANCE,");
			strSql.Append("SUMMARY=@SUMMARY");
			strSql.Append(" where ID=@ID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@NAME", OleDbType.VarChar,255),
					new OleDbParameter("@DESCRITION", OleDbType.VarChar,255),
					new OleDbParameter("@MEETINGDATE", OleDbType.Date),
					new OleDbParameter("@ATTENDANCE", OleDbType.Double),
					new OleDbParameter("@SUMMARY", OleDbType.VarChar,255),
					new OleDbParameter("@ID", OleDbType.Integer,4)};
			parameters[0].Value = model.NAME;
			parameters[1].Value = model.DESCRITION;
			parameters[2].Value = model.MEETINGDATE;
			parameters[3].Value = model.ATTENDANCE;
			parameters[4].Value = model.SUMMARY;
			parameters[5].Value = model.ID;

			int rows=DbHelperOleDb.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from MEETINGBASE ");
			strSql.Append(" where ID=@ID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.Integer,4)
			};
			parameters[0].Value = ID;

			int rows=DbHelperOleDb.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from MEETINGBASE ");
			strSql.Append(" where ID in ("+IDlist + ")  ");
			int rows=DbHelperOleDb.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ForKids.DB.Model.MEETINGBASE GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,NAME,DESCRITION,MEETINGDATE,ATTENDANCE,SUMMARY from MEETINGBASE ");
			strSql.Append(" where ID=@ID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.Integer,4)
			};
			parameters[0].Value = ID;

			ForKids.DB.Model.MEETINGBASE model=new ForKids.DB.Model.MEETINGBASE();
			DataSet ds=DbHelperOleDb.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"]!=null && ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["NAME"]!=null && ds.Tables[0].Rows[0]["NAME"].ToString()!="")
				{
					model.NAME=ds.Tables[0].Rows[0]["NAME"].ToString();
				}
				if(ds.Tables[0].Rows[0]["DESCRITION"]!=null && ds.Tables[0].Rows[0]["DESCRITION"].ToString()!="")
				{
					model.DESCRITION=ds.Tables[0].Rows[0]["DESCRITION"].ToString();
				}
				if(ds.Tables[0].Rows[0]["MEETINGDATE"]!=null && ds.Tables[0].Rows[0]["MEETINGDATE"].ToString()!="")
				{
					model.MEETINGDATE=DateTime.Parse(ds.Tables[0].Rows[0]["MEETINGDATE"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ATTENDANCE"]!=null && ds.Tables[0].Rows[0]["ATTENDANCE"].ToString()!="")
				{
					//model.ATTENDANCE=ds.Tables[0].Rows[0]["ATTENDANCE"].ToString();
				}
				if(ds.Tables[0].Rows[0]["SUMMARY"]!=null && ds.Tables[0].Rows[0]["SUMMARY"].ToString()!="")
				{
					model.SUMMARY=ds.Tables[0].Rows[0]["SUMMARY"].ToString();
				}
				return model;
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,NAME,DESCRITION,MEETINGDATE,ATTENDANCE,SUMMARY ");
			strSql.Append(" FROM MEETINGBASE ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperOleDb.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM MEETINGBASE ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperOleDb.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.ID desc");
			}
			strSql.Append(")AS Row, T.*  from MEETINGBASE T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperOleDb.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			OleDbParameter[] parameters = {
					new OleDbParameter("@tblName", OleDbType.VarChar, 255),
					new OleDbParameter("@fldName", OleDbType.VarChar, 255),
					new OleDbParameter("@PageSize", OleDbType.Integer),
					new OleDbParameter("@PageIndex", OleDbType.Integer),
					new OleDbParameter("@IsReCount", OleDbType.Boolean),
					new OleDbParameter("@OrderType", OleDbType.Boolean),
					new OleDbParameter("@strWhere", OleDbType.VarChar,1000),
					};
			parameters[0].Value = "MEETINGBASE";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperOleDb.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  Method
	}
}

