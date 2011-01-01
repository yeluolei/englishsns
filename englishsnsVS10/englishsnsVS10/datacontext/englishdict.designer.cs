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

namespace englishsnsVS10.datacontext
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="ENGLISHDICT.MDF")]
	public partial class englishdictDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void Insertword(word instance);
    partial void Updateword(word instance);
    partial void Deleteword(word instance);
    partial void Insertexplanation(explanation instance);
    partial void Updateexplanation(explanation instance);
    partial void Deleteexplanation(explanation instance);
    #endregion
		
		public englishdictDataContext() :
        base(global::System.Configuration.ConfigurationManager.ConnectionStrings["englishdictConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public englishdictDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public englishdictDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public englishdictDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public englishdictDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<word> words
		{
			get
			{
				return this.GetTable<word>();
			}
		}
		
		public System.Data.Linq.Table<explanation> explanations
		{
			get
			{
				return this.GetTable<explanation>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.words")]
	public partial class word : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _wordname;
		
		private EntitySet<explanation> _explanations;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnwordnameChanging(string value);
    partial void OnwordnameChanged();
    #endregion
		
		public word()
		{
			this._explanations = new EntitySet<explanation>(new Action<explanation>(this.attach_explanations), new Action<explanation>(this.detach_explanations));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_wordname", DbType="VarChar(30) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string wordname
		{
			get
			{
				return this._wordname;
			}
			set
			{
				if ((this._wordname != value))
				{
					this.OnwordnameChanging(value);
					this.SendPropertyChanging();
					this._wordname = value;
					this.SendPropertyChanged("wordname");
					this.OnwordnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="word_explanation", Storage="_explanations", ThisKey="wordname", OtherKey="wordname")]
		public EntitySet<explanation> explanations
		{
			get
			{
				return this._explanations;
			}
			set
			{
				this._explanations.Assign(value);
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
		
		private void attach_explanations(explanation entity)
		{
			this.SendPropertyChanging();
			entity.word = this;
		}
		
		private void detach_explanations(explanation entity)
		{
			this.SendPropertyChanging();
			entity.word = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.explanations")]
	public partial class explanation : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _wordname;
		
		private string _expcontent;
		
		private int _id;
		
		private EntityRef<word> _word;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnwordnameChanging(string value);
    partial void OnwordnameChanged();
    partial void OnexpcontentChanging(string value);
    partial void OnexpcontentChanged();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    #endregion
		
		public explanation()
		{
			this._word = default(EntityRef<word>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_wordname", DbType="VarChar(30) NOT NULL", CanBeNull=false)]
		public string wordname
		{
			get
			{
				return this._wordname;
			}
			set
			{
				if ((this._wordname != value))
				{
					if (this._word.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnwordnameChanging(value);
					this.SendPropertyChanging();
					this._wordname = value;
					this.SendPropertyChanged("wordname");
					this.OnwordnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_expcontent", DbType="Text NOT NULL", CanBeNull=false, UpdateCheck=UpdateCheck.Never)]
		public string expcontent
		{
			get
			{
				return this._expcontent;
			}
			set
			{
				if ((this._expcontent != value))
				{
					this.OnexpcontentChanging(value);
					this.SendPropertyChanging();
					this._expcontent = value;
					this.SendPropertyChanged("expcontent");
					this.OnexpcontentChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="word_explanation", Storage="_word", ThisKey="wordname", OtherKey="wordname", IsForeignKey=true)]
		public word word
		{
			get
			{
				return this._word.Entity;
			}
			set
			{
				word previousValue = this._word.Entity;
				if (((previousValue != value) 
							|| (this._word.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._word.Entity = null;
						previousValue.explanations.Remove(this);
					}
					this._word.Entity = value;
					if ((value != null))
					{
						value.explanations.Add(this);
						this._wordname = value.wordname;
					}
					else
					{
						this._wordname = default(string);
					}
					this.SendPropertyChanged("word");
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
