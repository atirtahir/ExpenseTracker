﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ExpenseTracker
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="ExpenseTracker")]
	public partial class ExpenseTrackerDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertExpenseCategory(ExpenseCategory instance);
    partial void UpdateExpenseCategory(ExpenseCategory instance);
    partial void DeleteExpenseCategory(ExpenseCategory instance);
    partial void InsertExpenseIncoming(ExpenseIncoming instance);
    partial void UpdateExpenseIncoming(ExpenseIncoming instance);
    partial void DeleteExpenseIncoming(ExpenseIncoming instance);
    partial void InsertExpenseDetail(ExpenseDetail instance);
    partial void UpdateExpenseDetail(ExpenseDetail instance);
    partial void DeleteExpenseDetail(ExpenseDetail instance);
    #endregion
		
		public ExpenseTrackerDataContext() : 
				base(global::ExpenseTracker.Properties.Settings.Default.ExpenseTrackerConnectionString1, mappingSource)
		{
			OnCreated();
		}
		
		public ExpenseTrackerDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ExpenseTrackerDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ExpenseTrackerDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ExpenseTrackerDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<ExpenseCategory> ExpenseCategories
		{
			get
			{
				return this.GetTable<ExpenseCategory>();
			}
		}
		
		public System.Data.Linq.Table<ExpenseIncoming> ExpenseIncomings
		{
			get
			{
				return this.GetTable<ExpenseIncoming>();
			}
		}
		
		public System.Data.Linq.Table<ExpenseDetail> ExpenseDetails
		{
			get
			{
				return this.GetTable<ExpenseDetail>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.ExpenseCategory")]
	public partial class ExpenseCategory : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _CatID;
		
		private string _Category;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnCatIDChanging(int value);
    partial void OnCatIDChanged();
    partial void OnCategoryChanging(string value);
    partial void OnCategoryChanged();
    #endregion
		
		public ExpenseCategory()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CatID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int CatID
		{
			get
			{
				return this._CatID;
			}
			set
			{
				if ((this._CatID != value))
				{
					this.OnCatIDChanging(value);
					this.SendPropertyChanging();
					this._CatID = value;
					this.SendPropertyChanged("CatID");
					this.OnCatIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Category", DbType="VarChar(150)")]
		public string Category
		{
			get
			{
				return this._Category;
			}
			set
			{
				if ((this._Category != value))
				{
					this.OnCategoryChanging(value);
					this.SendPropertyChanging();
					this._Category = value;
					this.SendPropertyChanged("Category");
					this.OnCategoryChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.ExpenseIncoming")]
	public partial class ExpenseIncoming : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _IncID;
		
		private System.Nullable<int> _Price;
		
		private System.Nullable<System.DateTime> _Date;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIncIDChanging(int value);
    partial void OnIncIDChanged();
    partial void OnPriceChanging(System.Nullable<int> value);
    partial void OnPriceChanged();
    partial void OnDateChanging(System.Nullable<System.DateTime> value);
    partial void OnDateChanged();
    #endregion
		
		public ExpenseIncoming()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IncID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int IncID
		{
			get
			{
				return this._IncID;
			}
			set
			{
				if ((this._IncID != value))
				{
					this.OnIncIDChanging(value);
					this.SendPropertyChanging();
					this._IncID = value;
					this.SendPropertyChanged("IncID");
					this.OnIncIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Price", DbType="Int")]
		public System.Nullable<int> Price
		{
			get
			{
				return this._Price;
			}
			set
			{
				if ((this._Price != value))
				{
					this.OnPriceChanging(value);
					this.SendPropertyChanging();
					this._Price = value;
					this.SendPropertyChanged("Price");
					this.OnPriceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Date", DbType="Date")]
		public System.Nullable<System.DateTime> Date
		{
			get
			{
				return this._Date;
			}
			set
			{
				if ((this._Date != value))
				{
					this.OnDateChanging(value);
					this.SendPropertyChanging();
					this._Date = value;
					this.SendPropertyChanged("Date");
					this.OnDateChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.ExpenseDetail")]
	public partial class ExpenseDetail : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ExpID;
		
		private string _ExpenseCategory;
		
		private string _Details;
		
		private System.Nullable<int> _Price;
		
		private System.Nullable<System.DateTime> _Date;
		
		private System.Nullable<int> _RemainingAmount;
		
		private System.Nullable<int> _CurrentTotalIncome;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnExpIDChanging(int value);
    partial void OnExpIDChanged();
    partial void OnExpenseCategoryChanging(string value);
    partial void OnExpenseCategoryChanged();
    partial void OnDetailsChanging(string value);
    partial void OnDetailsChanged();
    partial void OnPriceChanging(System.Nullable<int> value);
    partial void OnPriceChanged();
    partial void OnDateChanging(System.Nullable<System.DateTime> value);
    partial void OnDateChanged();
    partial void OnRemainingAmountChanging(System.Nullable<int> value);
    partial void OnRemainingAmountChanged();
    partial void OnCurrentTotalIncomeChanging(System.Nullable<int> value);
    partial void OnCurrentTotalIncomeChanged();
    #endregion
		
		public ExpenseDetail()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ExpID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ExpID
		{
			get
			{
				return this._ExpID;
			}
			set
			{
				if ((this._ExpID != value))
				{
					this.OnExpIDChanging(value);
					this.SendPropertyChanging();
					this._ExpID = value;
					this.SendPropertyChanged("ExpID");
					this.OnExpIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ExpenseCategory", DbType="VarChar(150)")]
		public string ExpenseCategory
		{
			get
			{
				return this._ExpenseCategory;
			}
			set
			{
				if ((this._ExpenseCategory != value))
				{
					this.OnExpenseCategoryChanging(value);
					this.SendPropertyChanging();
					this._ExpenseCategory = value;
					this.SendPropertyChanged("ExpenseCategory");
					this.OnExpenseCategoryChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Details", DbType="VarChar(250)")]
		public string Details
		{
			get
			{
				return this._Details;
			}
			set
			{
				if ((this._Details != value))
				{
					this.OnDetailsChanging(value);
					this.SendPropertyChanging();
					this._Details = value;
					this.SendPropertyChanged("Details");
					this.OnDetailsChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Price", DbType="Int")]
		public System.Nullable<int> Price
		{
			get
			{
				return this._Price;
			}
			set
			{
				if ((this._Price != value))
				{
					this.OnPriceChanging(value);
					this.SendPropertyChanging();
					this._Price = value;
					this.SendPropertyChanged("Price");
					this.OnPriceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Date", DbType="Date")]
		public System.Nullable<System.DateTime> Date
		{
			get
			{
				return this._Date;
			}
			set
			{
				if ((this._Date != value))
				{
					this.OnDateChanging(value);
					this.SendPropertyChanging();
					this._Date = value;
					this.SendPropertyChanged("Date");
					this.OnDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RemainingAmount", DbType="Int")]
		public System.Nullable<int> RemainingAmount
		{
			get
			{
				return this._RemainingAmount;
			}
			set
			{
				if ((this._RemainingAmount != value))
				{
					this.OnRemainingAmountChanging(value);
					this.SendPropertyChanging();
					this._RemainingAmount = value;
					this.SendPropertyChanged("RemainingAmount");
					this.OnRemainingAmountChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CurrentTotalIncome", DbType="Int")]
		public System.Nullable<int> CurrentTotalIncome
		{
			get
			{
				return this._CurrentTotalIncome;
			}
			set
			{
				if ((this._CurrentTotalIncome != value))
				{
					this.OnCurrentTotalIncomeChanging(value);
					this.SendPropertyChanging();
					this._CurrentTotalIncome = value;
					this.SendPropertyChanged("CurrentTotalIncome");
					this.OnCurrentTotalIncomeChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
