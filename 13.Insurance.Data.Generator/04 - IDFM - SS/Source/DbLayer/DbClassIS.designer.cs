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
	
	
	[System.Data.Linq.Mapping.DatabaseAttribute(Name="ImagingSystem")]
	public partial class DbClassIS : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    #endregion
		
		public DbClassIS(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DbClassIS(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DbClassIS(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DbClassIS(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		[Function(Name="Services.SP_SelectCategories")]
		public ISingleResult<SP_SelectCategoriesResult> SP_SelectCategories()
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
			return ((ISingleResult<SP_SelectCategoriesResult>)(result.ReturnValue));
		}
		
		[Function(Name="Insurances.SP_SelectInsFullData")]
		public ISingleResult<SP_SelectInsFullDataResult> SP_SelectInsFullData()
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
			return ((ISingleResult<SP_SelectInsFullDataResult>)(result.ReturnValue));
		}
		
		[Function(Name="Services.SP_SelectServicesList")]
		public ISingleResult<SP_SelectServicesListResult> SP_SelectServicesList()
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
			return ((ISingleResult<SP_SelectServicesListResult>)(result.ReturnValue));
		}
	}
	
	public partial class SP_SelectCategoriesResult
	{
		
		private System.Nullable<short> _ID;
		
		private System.Nullable<bool> _IsActive;
		
		private string _Name;
		
		public SP_SelectCategoriesResult()
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
		
		[Column(Storage="_IsActive", DbType="Bit")]
		public System.Nullable<bool> IsActive
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
		
		[Column(Storage="_Name", DbType="NVarChar(30) NOT NULL", CanBeNull=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this._Name = value;
				}
			}
		}
	}
	
	public partial class SP_SelectInsFullDataResult
	{
		
		private System.Nullable<short> _ID;
		
		private System.Nullable<bool> _BaseIsActive;
		
		private System.Nullable<bool> _IsActive;
		
		private string _Name;
		
		private System.Nullable<bool> _IsIns1;
		
		private System.Nullable<bool> _IsIns2;
		
		private System.Nullable<System.DateTime> _ContractStartDate;
		
		private System.Nullable<System.DateTime> _ContractEndDate;
		
		private System.Nullable<byte> _PatientPercent;
		
		private System.Nullable<int> _InsurerPartLimit;
		
		private System.Nullable<short> _Ins2FormulasIX;
		
		private string _Description;
		
		public SP_SelectInsFullDataResult()
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
		
		[Column(Storage="_BaseIsActive", DbType="Bit")]
		public System.Nullable<bool> BaseIsActive
		{
			get
			{
				return this._BaseIsActive;
			}
			set
			{
				if ((this._BaseIsActive != value))
				{
					this._BaseIsActive = value;
				}
			}
		}
		
		[Column(Storage="_IsActive", DbType="Bit")]
		public System.Nullable<bool> IsActive
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
		
		[Column(Storage="_Name", DbType="NVarChar(30)")]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this._Name = value;
				}
			}
		}
		
		[Column(Storage="_IsIns1", DbType="Bit")]
		public System.Nullable<bool> IsIns1
		{
			get
			{
				return this._IsIns1;
			}
			set
			{
				if ((this._IsIns1 != value))
				{
					this._IsIns1 = value;
				}
			}
		}
		
		[Column(Storage="_IsIns2", DbType="Bit")]
		public System.Nullable<bool> IsIns2
		{
			get
			{
				return this._IsIns2;
			}
			set
			{
				if ((this._IsIns2 != value))
				{
					this._IsIns2 = value;
				}
			}
		}
		
		[Column(Storage="_ContractStartDate", DbType="SmallDateTime")]
		public System.Nullable<System.DateTime> ContractStartDate
		{
			get
			{
				return this._ContractStartDate;
			}
			set
			{
				if ((this._ContractStartDate != value))
				{
					this._ContractStartDate = value;
				}
			}
		}
		
		[Column(Storage="_ContractEndDate", DbType="SmallDateTime")]
		public System.Nullable<System.DateTime> ContractEndDate
		{
			get
			{
				return this._ContractEndDate;
			}
			set
			{
				if ((this._ContractEndDate != value))
				{
					this._ContractEndDate = value;
				}
			}
		}
		
		[Column(Storage="_PatientPercent", DbType="TinyInt")]
		public System.Nullable<byte> PatientPercent
		{
			get
			{
				return this._PatientPercent;
			}
			set
			{
				if ((this._PatientPercent != value))
				{
					this._PatientPercent = value;
				}
			}
		}
		
		[Column(Storage="_InsurerPartLimit", DbType="Int")]
		public System.Nullable<int> InsurerPartLimit
		{
			get
			{
				return this._InsurerPartLimit;
			}
			set
			{
				if ((this._InsurerPartLimit != value))
				{
					this._InsurerPartLimit = value;
				}
			}
		}
		
		[Column(Storage="_Ins2FormulasIX", DbType="SmallInt")]
		public System.Nullable<short> Ins2FormulasIX
		{
			get
			{
				return this._Ins2FormulasIX;
			}
			set
			{
				if ((this._Ins2FormulasIX != value))
				{
					this._Ins2FormulasIX = value;
				}
			}
		}
		
		[Column(Storage="_Description", DbType="NVarChar(300)")]
		public string Description
		{
			get
			{
				return this._Description;
			}
			set
			{
				if ((this._Description != value))
				{
					this._Description = value;
				}
			}
		}
	}
	
	public partial class SP_SelectServicesListResult
	{
		
		private short _ID;
		
		private bool _IsActive;
		
		private string _Code;
		
		private string _Name;
		
		private System.Nullable<short> _CategoryIX;
		
		private string _CategoryName;
		
		private int _PriceFree;
		
		private int _PriceGov;
		
		private string _Description;
		
		public SP_SelectServicesListResult()
		{
		}
		
		[Column(Storage="_ID", DbType="SmallInt NOT NULL")]
		public short ID
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
		
		[Column(Storage="_IsActive", DbType="Bit NOT NULL")]
		public bool IsActive
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
		
		[Column(Storage="_Code", DbType="NVarChar(5) NOT NULL", CanBeNull=false)]
		public string Code
		{
			get
			{
				return this._Code;
			}
			set
			{
				if ((this._Code != value))
				{
					this._Code = value;
				}
			}
		}
		
		[Column(Storage="_Name", DbType="NVarChar(255) NOT NULL", CanBeNull=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this._Name = value;
				}
			}
		}
		
		[Column(Storage="_CategoryIX", DbType="SmallInt")]
		public System.Nullable<short> CategoryIX
		{
			get
			{
				return this._CategoryIX;
			}
			set
			{
				if ((this._CategoryIX != value))
				{
					this._CategoryIX = value;
				}
			}
		}
		
		[Column(Storage="_CategoryName", DbType="NVarChar(30) NOT NULL", CanBeNull=false)]
		public string CategoryName
		{
			get
			{
				return this._CategoryName;
			}
			set
			{
				if ((this._CategoryName != value))
				{
					this._CategoryName = value;
				}
			}
		}
		
		[Column(Storage="_PriceFree", DbType="Int NOT NULL")]
		public int PriceFree
		{
			get
			{
				return this._PriceFree;
			}
			set
			{
				if ((this._PriceFree != value))
				{
					this._PriceFree = value;
				}
			}
		}
		
		[Column(Storage="_PriceGov", DbType="Int NOT NULL")]
		public int PriceGov
		{
			get
			{
				return this._PriceGov;
			}
			set
			{
				if ((this._PriceGov != value))
				{
					this._PriceGov = value;
				}
			}
		}
		
		[Column(Storage="_Description", DbType="NVarChar(300)")]
		public string Description
		{
			get
			{
				return this._Description;
			}
			set
			{
				if ((this._Description != value))
				{
					this._Description = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
