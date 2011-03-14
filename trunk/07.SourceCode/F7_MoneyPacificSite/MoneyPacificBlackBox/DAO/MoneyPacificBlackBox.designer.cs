﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MoneyPacificBlackBox.DAO
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="moneypacific_blackbox")]
	public partial class MoneyPacificBlackBoxDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertTransaction(Transaction instance);
    partial void UpdateTransaction(Transaction instance);
    partial void DeleteTransaction(Transaction instance);
    partial void InsertPacificCodeState(PacificCodeState instance);
    partial void UpdatePacificCodeState(PacificCodeState instance);
    partial void DeletePacificCodeState(PacificCodeState instance);
    partial void InsertPacificCode(PacificCode instance);
    partial void UpdatePacificCode(PacificCode instance);
    partial void DeletePacificCode(PacificCode instance);
    #endregion
		
		public MoneyPacificBlackBoxDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["moneypacific_blackboxConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public MoneyPacificBlackBoxDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public MoneyPacificBlackBoxDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public MoneyPacificBlackBoxDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public MoneyPacificBlackBoxDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Transaction> Transactions
		{
			get
			{
				return this.GetTable<Transaction>();
			}
		}
		
		public System.Data.Linq.Table<PacificCodeState> PacificCodeStates
		{
			get
			{
				return this.GetTable<PacificCodeState>();
			}
		}
		
		public System.Data.Linq.Table<PacificCode> PacificCodes
		{
			get
			{
				return this.GetTable<PacificCode>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.[Transaction]")]
	public partial class Transaction : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private System.Nullable<int> _RelateId;
		
		private System.Nullable<System.Guid> _PacificCodeId;
		
		private System.Nullable<System.DateTime> _CreateDate;
		
		private string _Origine;
		
		private System.Nullable<int> _Amount;
		
		private string _SMS;
		
		private string _Comment;
		
		private System.Nullable<bool> _IsSuccessful;
		
		private EntityRef<PacificCode> _PacificCode;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnRelateIdChanging(System.Nullable<int> value);
    partial void OnRelateIdChanged();
    partial void OnPacificCodeIdChanging(System.Nullable<System.Guid> value);
    partial void OnPacificCodeIdChanged();
    partial void OnCreateDateChanging(System.Nullable<System.DateTime> value);
    partial void OnCreateDateChanged();
    partial void OnOrigineChanging(string value);
    partial void OnOrigineChanged();
    partial void OnAmountChanging(System.Nullable<int> value);
    partial void OnAmountChanged();
    partial void OnSMSChanging(string value);
    partial void OnSMSChanged();
    partial void OnCommentChanging(string value);
    partial void OnCommentChanged();
    partial void OnIsSuccessfulChanging(System.Nullable<bool> value);
    partial void OnIsSuccessfulChanged();
    #endregion
		
		public Transaction()
		{
			this._PacificCode = default(EntityRef<PacificCode>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RelateId", DbType="Int")]
		public System.Nullable<int> RelateId
		{
			get
			{
				return this._RelateId;
			}
			set
			{
				if ((this._RelateId != value))
				{
					this.OnRelateIdChanging(value);
					this.SendPropertyChanging();
					this._RelateId = value;
					this.SendPropertyChanged("RelateId");
					this.OnRelateIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PacificCodeId", DbType="UniqueIdentifier")]
		public System.Nullable<System.Guid> PacificCodeId
		{
			get
			{
				return this._PacificCodeId;
			}
			set
			{
				if ((this._PacificCodeId != value))
				{
					if (this._PacificCode.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnPacificCodeIdChanging(value);
					this.SendPropertyChanging();
					this._PacificCodeId = value;
					this.SendPropertyChanged("PacificCodeId");
					this.OnPacificCodeIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CreateDate", DbType="DateTime")]
		public System.Nullable<System.DateTime> CreateDate
		{
			get
			{
				return this._CreateDate;
			}
			set
			{
				if ((this._CreateDate != value))
				{
					this.OnCreateDateChanging(value);
					this.SendPropertyChanging();
					this._CreateDate = value;
					this.SendPropertyChanged("CreateDate");
					this.OnCreateDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Origine", DbType="NVarChar(20)")]
		public string Origine
		{
			get
			{
				return this._Origine;
			}
			set
			{
				if ((this._Origine != value))
				{
					this.OnOrigineChanging(value);
					this.SendPropertyChanging();
					this._Origine = value;
					this.SendPropertyChanged("Origine");
					this.OnOrigineChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Amount", DbType="Int")]
		public System.Nullable<int> Amount
		{
			get
			{
				return this._Amount;
			}
			set
			{
				if ((this._Amount != value))
				{
					this.OnAmountChanging(value);
					this.SendPropertyChanging();
					this._Amount = value;
					this.SendPropertyChanged("Amount");
					this.OnAmountChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SMS", DbType="NVarChar(255)")]
		public string SMS
		{
			get
			{
				return this._SMS;
			}
			set
			{
				if ((this._SMS != value))
				{
					this.OnSMSChanging(value);
					this.SendPropertyChanging();
					this._SMS = value;
					this.SendPropertyChanged("SMS");
					this.OnSMSChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Comment", DbType="NVarChar(255)")]
		public string Comment
		{
			get
			{
				return this._Comment;
			}
			set
			{
				if ((this._Comment != value))
				{
					this.OnCommentChanging(value);
					this.SendPropertyChanging();
					this._Comment = value;
					this.SendPropertyChanged("Comment");
					this.OnCommentChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IsSuccessful", DbType="Bit")]
		public System.Nullable<bool> IsSuccessful
		{
			get
			{
				return this._IsSuccessful;
			}
			set
			{
				if ((this._IsSuccessful != value))
				{
					this.OnIsSuccessfulChanging(value);
					this.SendPropertyChanging();
					this._IsSuccessful = value;
					this.SendPropertyChanged("IsSuccessful");
					this.OnIsSuccessfulChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="PacificCode_Transaction", Storage="_PacificCode", ThisKey="PacificCodeId", OtherKey="Id", IsForeignKey=true)]
		public PacificCode PacificCode
		{
			get
			{
				return this._PacificCode.Entity;
			}
			set
			{
				PacificCode previousValue = this._PacificCode.Entity;
				if (((previousValue != value) 
							|| (this._PacificCode.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._PacificCode.Entity = null;
						previousValue.Transactions.Remove(this);
					}
					this._PacificCode.Entity = value;
					if ((value != null))
					{
						value.Transactions.Add(this);
						this._PacificCodeId = value.Id;
					}
					else
					{
						this._PacificCodeId = default(Nullable<System.Guid>);
					}
					this.SendPropertyChanged("PacificCode");
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.PacificCodeState")]
	public partial class PacificCodeState : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _Code;
		
		private string _Description;
		
		private EntitySet<PacificCode> _PacificCodes;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnCodeChanging(string value);
    partial void OnCodeChanged();
    partial void OnDescriptionChanging(string value);
    partial void OnDescriptionChanged();
    #endregion
		
		public PacificCodeState()
		{
			this._PacificCodes = new EntitySet<PacificCode>(new Action<PacificCode>(this.attach_PacificCodes), new Action<PacificCode>(this.detach_PacificCodes));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Code", DbType="NVarChar(20)")]
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
					this.OnCodeChanging(value);
					this.SendPropertyChanging();
					this._Code = value;
					this.SendPropertyChanged("Code");
					this.OnCodeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Description", DbType="NVarChar(255)")]
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
					this.OnDescriptionChanging(value);
					this.SendPropertyChanging();
					this._Description = value;
					this.SendPropertyChanged("Description");
					this.OnDescriptionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="PacificCodeState_PacificCode", Storage="_PacificCodes", ThisKey="Id", OtherKey="StatusId")]
		public EntitySet<PacificCode> PacificCodes
		{
			get
			{
				return this._PacificCodes;
			}
			set
			{
				this._PacificCodes.Assign(value);
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
		
		private void attach_PacificCodes(PacificCode entity)
		{
			this.SendPropertyChanging();
			entity.PacificCodeState = this;
		}
		
		private void detach_PacificCodes(PacificCode entity)
		{
			this.SendPropertyChanging();
			entity.PacificCodeState = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.PacificCode")]
	public partial class PacificCode : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _Id;
		
		private string _CodeNumber;
		
		private System.Nullable<int> _LastTransaction;
		
		private System.Nullable<int> _StatusId;
		
		private System.Nullable<int> _InitialAmount;
		
		private System.Nullable<int> _ActualAmount;
		
		private System.Nullable<System.DateTime> _CreateDate;
		
		private System.Nullable<System.DateTime> _LastDate;
		
		private System.Nullable<System.DateTime> _ExpireDate;
		
		private string _Comment;
		
		private EntitySet<Transaction> _Transactions;
		
		private EntityRef<PacificCodeState> _PacificCodeState;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(System.Guid value);
    partial void OnIdChanged();
    partial void OnCodeNumberChanging(string value);
    partial void OnCodeNumberChanged();
    partial void OnLastTransactionChanging(System.Nullable<int> value);
    partial void OnLastTransactionChanged();
    partial void OnStatusIdChanging(System.Nullable<int> value);
    partial void OnStatusIdChanged();
    partial void OnInitialAmountChanging(System.Nullable<int> value);
    partial void OnInitialAmountChanged();
    partial void OnActualAmountChanging(System.Nullable<int> value);
    partial void OnActualAmountChanged();
    partial void OnCreateDateChanging(System.Nullable<System.DateTime> value);
    partial void OnCreateDateChanged();
    partial void OnLastDateChanging(System.Nullable<System.DateTime> value);
    partial void OnLastDateChanged();
    partial void OnExpireDateChanging(System.Nullable<System.DateTime> value);
    partial void OnExpireDateChanged();
    partial void OnCommentChanging(string value);
    partial void OnCommentChanged();
    #endregion
		
		public PacificCode()
		{
			this._Transactions = new EntitySet<Transaction>(new Action<Transaction>(this.attach_Transactions), new Action<Transaction>(this.detach_Transactions));
			this._PacificCodeState = default(EntityRef<PacificCodeState>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true)]
		public System.Guid Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CodeNumber", DbType="NVarChar(20)")]
		public string CodeNumber
		{
			get
			{
				return this._CodeNumber;
			}
			set
			{
				if ((this._CodeNumber != value))
				{
					this.OnCodeNumberChanging(value);
					this.SendPropertyChanging();
					this._CodeNumber = value;
					this.SendPropertyChanged("CodeNumber");
					this.OnCodeNumberChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LastTransaction", DbType="Int")]
		public System.Nullable<int> LastTransaction
		{
			get
			{
				return this._LastTransaction;
			}
			set
			{
				if ((this._LastTransaction != value))
				{
					this.OnLastTransactionChanging(value);
					this.SendPropertyChanging();
					this._LastTransaction = value;
					this.SendPropertyChanged("LastTransaction");
					this.OnLastTransactionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_StatusId", DbType="Int")]
		public System.Nullable<int> StatusId
		{
			get
			{
				return this._StatusId;
			}
			set
			{
				if ((this._StatusId != value))
				{
					if (this._PacificCodeState.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnStatusIdChanging(value);
					this.SendPropertyChanging();
					this._StatusId = value;
					this.SendPropertyChanged("StatusId");
					this.OnStatusIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_InitialAmount", DbType="Int")]
		public System.Nullable<int> InitialAmount
		{
			get
			{
				return this._InitialAmount;
			}
			set
			{
				if ((this._InitialAmount != value))
				{
					this.OnInitialAmountChanging(value);
					this.SendPropertyChanging();
					this._InitialAmount = value;
					this.SendPropertyChanged("InitialAmount");
					this.OnInitialAmountChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ActualAmount", DbType="Int")]
		public System.Nullable<int> ActualAmount
		{
			get
			{
				return this._ActualAmount;
			}
			set
			{
				if ((this._ActualAmount != value))
				{
					this.OnActualAmountChanging(value);
					this.SendPropertyChanging();
					this._ActualAmount = value;
					this.SendPropertyChanged("ActualAmount");
					this.OnActualAmountChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CreateDate", DbType="DateTime")]
		public System.Nullable<System.DateTime> CreateDate
		{
			get
			{
				return this._CreateDate;
			}
			set
			{
				if ((this._CreateDate != value))
				{
					this.OnCreateDateChanging(value);
					this.SendPropertyChanging();
					this._CreateDate = value;
					this.SendPropertyChanged("CreateDate");
					this.OnCreateDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LastDate", DbType="DateTime")]
		public System.Nullable<System.DateTime> LastDate
		{
			get
			{
				return this._LastDate;
			}
			set
			{
				if ((this._LastDate != value))
				{
					this.OnLastDateChanging(value);
					this.SendPropertyChanging();
					this._LastDate = value;
					this.SendPropertyChanged("LastDate");
					this.OnLastDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ExpireDate", DbType="DateTime")]
		public System.Nullable<System.DateTime> ExpireDate
		{
			get
			{
				return this._ExpireDate;
			}
			set
			{
				if ((this._ExpireDate != value))
				{
					this.OnExpireDateChanging(value);
					this.SendPropertyChanging();
					this._ExpireDate = value;
					this.SendPropertyChanged("ExpireDate");
					this.OnExpireDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Comment", DbType="NVarChar(255)")]
		public string Comment
		{
			get
			{
				return this._Comment;
			}
			set
			{
				if ((this._Comment != value))
				{
					this.OnCommentChanging(value);
					this.SendPropertyChanging();
					this._Comment = value;
					this.SendPropertyChanged("Comment");
					this.OnCommentChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="PacificCode_Transaction", Storage="_Transactions", ThisKey="Id", OtherKey="PacificCodeId")]
		public EntitySet<Transaction> Transactions
		{
			get
			{
				return this._Transactions;
			}
			set
			{
				this._Transactions.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="PacificCodeState_PacificCode", Storage="_PacificCodeState", ThisKey="StatusId", OtherKey="Id", IsForeignKey=true)]
		public PacificCodeState PacificCodeState
		{
			get
			{
				return this._PacificCodeState.Entity;
			}
			set
			{
				PacificCodeState previousValue = this._PacificCodeState.Entity;
				if (((previousValue != value) 
							|| (this._PacificCodeState.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._PacificCodeState.Entity = null;
						previousValue.PacificCodes.Remove(this);
					}
					this._PacificCodeState.Entity = value;
					if ((value != null))
					{
						value.PacificCodes.Add(this);
						this._StatusId = value.Id;
					}
					else
					{
						this._StatusId = default(Nullable<int>);
					}
					this.SendPropertyChanged("PacificCodeState");
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
		
		private void attach_Transactions(Transaction entity)
		{
			this.SendPropertyChanging();
			entity.PacificCode = this;
		}
		
		private void detach_Transactions(Transaction entity)
		{
			this.SendPropertyChanging();
			entity.PacificCode = null;
		}
	}
}
#pragma warning restore 1591