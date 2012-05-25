﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.4927
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sepehr.DbLayer
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[System.Data.Linq.Mapping.DatabaseAttribute(Name="PatientsSystem")]
	public partial class DbClassPS : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    #endregion
		
		public DbClassPS(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DbClassPS(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DbClassPS(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DbClassPS(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		[Function(Name="Clinic.SP_SelectRefPhysiciansSpecs")]
		public ISingleResult<SP_SelectRefPhysiciansSpecsResult> SP_SelectRefPhysiciansSpecs()
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
			return ((ISingleResult<SP_SelectRefPhysiciansSpecsResult>)(result.ReturnValue));
		}
	}
	
	public partial class SP_SelectRefPhysiciansSpecsResult
	{
		
		private System.Nullable<short> _ID;
		
		private int _IsActive;
		
		private string _Title;
		
		public SP_SelectRefPhysiciansSpecsResult()
		{
		}
		
		[Column(Storage="_ID", DbType="SmallInt")]
		public System.Nullable<short> ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this._ID = value;
				}
			}
		}
		
		[Column(Storage="_IsActive", DbType="Int NOT NULL")]
		public int IsActive
		{
			get
			{
				return this._IsActive;
			}
			set
			{
				if ((this._IsActive != value))
				{
					this._IsActive = value;
				}
			}
		}
		
		[Column(Storage="_Title", DbType="NVarChar(20) NOT NULL", CanBeNull=false)]
		public string Title
		{
			get
			{
				return this._Title;
			}
			set
			{
				if ((this._Title != value))
				{
					this._Title = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
