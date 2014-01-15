﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18408
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuestionsAndAnswers.Models
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="QandAnswers")]
	public partial class DataClasses1DataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void Inserttag(tag instance);
    partial void Updatetag(tag instance);
    partial void Deletetag(tag instance);
    partial void Insertuser(user instance);
    partial void Updateuser(user instance);
    partial void Deleteuser(user instance);
    partial void Insertuser_post(user_post instance);
    partial void Updateuser_post(user_post instance);
    partial void Deleteuser_post(user_post instance);
    partial void Insertuser_favourite(user_favourite instance);
    partial void Updateuser_favourite(user_favourite instance);
    partial void Deleteuser_favourite(user_favourite instance);
    partial void Insertuser_post_tag(user_post_tag instance);
    partial void Updateuser_post_tag(user_post_tag instance);
    partial void Deleteuser_post_tag(user_post_tag instance);
    #endregion
		
		public DataClasses1DataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["QandAnswersConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<tag> tags
		{
			get
			{
				return this.GetTable<tag>();
			}
		}
		
		public System.Data.Linq.Table<user> users
		{
			get
			{
				return this.GetTable<user>();
			}
		}
		
		public System.Data.Linq.Table<user_post> user_posts
		{
			get
			{
				return this.GetTable<user_post>();
			}
		}
		
		public System.Data.Linq.Table<user_favourite> user_favourites
		{
			get
			{
				return this.GetTable<user_favourite>();
			}
		}
		
		public System.Data.Linq.Table<user_post_tag> user_post_tags
		{
			get
			{
				return this.GetTable<user_post_tag>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.tag")]
	public partial class tag : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private System.Data.Linq.Binary _name;
		
		private EntitySet<user_post_tag> _user_post_tags;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OnnameChanging(System.Data.Linq.Binary value);
    partial void OnnameChanged();
    #endregion
		
		public tag()
		{
			this._user_post_tags = new EntitySet<user_post_tag>(new Action<user_post_tag>(this.attach_user_post_tags), new Action<user_post_tag>(this.detach_user_post_tags));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", DbType="Int NOT NULL", IsPrimaryKey=true)]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_name", DbType="VarBinary(MAX) NOT NULL", CanBeNull=false, UpdateCheck=UpdateCheck.Never)]
		public System.Data.Linq.Binary name
		{
			get
			{
				return this._name;
			}
			set
			{
				if ((this._name != value))
				{
					this.OnnameChanging(value);
					this.SendPropertyChanging();
					this._name = value;
					this.SendPropertyChanged("name");
					this.OnnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="tag_user_post_tag", Storage="_user_post_tags", ThisKey="id", OtherKey="tag_id")]
		public EntitySet<user_post_tag> user_post_tags
		{
			get
			{
				return this._user_post_tags;
			}
			set
			{
				this._user_post_tags.Assign(value);
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
		
		private void attach_user_post_tags(user_post_tag entity)
		{
			this.SendPropertyChanging();
			entity.tag = this;
		}
		
		private void detach_user_post_tags(user_post_tag entity)
		{
			this.SendPropertyChanging();
			entity.tag = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.[user]")]
	public partial class user : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private string _username;
		
		private string _password;
		
		private System.DateTime _created_at;
		
		private string _email_address;
		
		private bool _is_admin;
		
		private bool _is_active;
		
		private EntitySet<user_post> _user_posts;
		
		private EntitySet<user_favourite> _user_favourites;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OnusernameChanging(string value);
    partial void OnusernameChanged();
    partial void OnpasswordChanging(string value);
    partial void OnpasswordChanged();
    partial void Oncreated_atChanging(System.DateTime value);
    partial void Oncreated_atChanged();
    partial void Onemail_addressChanging(string value);
    partial void Onemail_addressChanged();
    partial void Onis_adminChanging(bool value);
    partial void Onis_adminChanged();
    partial void Onis_activeChanging(bool value);
    partial void Onis_activeChanged();
    #endregion
		
		public user()
		{
			this._user_posts = new EntitySet<user_post>(new Action<user_post>(this.attach_user_posts), new Action<user_post>(this.detach_user_posts));
			this._user_favourites = new EntitySet<user_favourite>(new Action<user_favourite>(this.attach_user_favourites), new Action<user_favourite>(this.detach_user_favourites));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", DbType="Int NOT NULL", IsPrimaryKey=true, IsDbGenerated=true)]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_username", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string username
		{
			get
			{
				return this._username;
			}
			set
			{
				if ((this._username != value))
				{
					this.OnusernameChanging(value);
					this.SendPropertyChanging();
					this._username = value;
					this.SendPropertyChanged("username");
					this.OnusernameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_password", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string password
		{
			get
			{
				return this._password;
			}
			set
			{
				if ((this._password != value))
				{
					this.OnpasswordChanging(value);
					this.SendPropertyChanging();
					this._password = value;
					this.SendPropertyChanged("password");
					this.OnpasswordChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_created_at", DbType="DateTime NOT NULL")]
		public System.DateTime created_at
		{
			get
			{
				return this._created_at;
			}
			set
			{
				if ((this._created_at != value))
				{
					this.Oncreated_atChanging(value);
					this.SendPropertyChanging();
					this._created_at = value;
					this.SendPropertyChanged("created_at");
					this.Oncreated_atChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_email_address", CanBeNull=false)]
		public string email_address
		{
			get
			{
				return this._email_address;
			}
			set
			{
				if ((this._email_address != value))
				{
					this.Onemail_addressChanging(value);
					this.SendPropertyChanging();
					this._email_address = value;
					this.SendPropertyChanged("email_address");
					this.Onemail_addressChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_is_admin")]
		public bool is_admin
		{
			get
			{
				return this._is_admin;
			}
			set
			{
				if ((this._is_admin != value))
				{
					this.Onis_adminChanging(value);
					this.SendPropertyChanging();
					this._is_admin = value;
					this.SendPropertyChanged("is_admin");
					this.Onis_adminChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_is_active")]
		public bool is_active
		{
			get
			{
				return this._is_active;
			}
			set
			{
				if ((this._is_active != value))
				{
					this.Onis_activeChanging(value);
					this.SendPropertyChanging();
					this._is_active = value;
					this.SendPropertyChanged("is_active");
					this.Onis_activeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="user_user_post", Storage="_user_posts", ThisKey="id", OtherKey="user_id")]
		public EntitySet<user_post> user_posts
		{
			get
			{
				return this._user_posts;
			}
			set
			{
				this._user_posts.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="user_user_favourite", Storage="_user_favourites", ThisKey="id", OtherKey="user_id")]
		public EntitySet<user_favourite> user_favourites
		{
			get
			{
				return this._user_favourites;
			}
			set
			{
				this._user_favourites.Assign(value);
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
		
		private void attach_user_posts(user_post entity)
		{
			this.SendPropertyChanging();
			entity.user = this;
		}
		
		private void detach_user_posts(user_post entity)
		{
			this.SendPropertyChanging();
			entity.user = null;
		}
		
		private void attach_user_favourites(user_favourite entity)
		{
			this.SendPropertyChanging();
			entity.user = this;
		}
		
		private void detach_user_favourites(user_favourite entity)
		{
			this.SendPropertyChanging();
			entity.user = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.user_post")]
	public partial class user_post : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private int _user_id;
		
		private System.Nullable<int> _parent_post_id;
		
		private string _content;
		
		private int _ranking_points;
		
		private int _num_views;
		
		private bool _is_accepted_answer;
		
		private System.DateTime _created_at;
		
		private string _title;
		
		private EntitySet<user_favourite> _user_favourites;
		
		private EntitySet<user_post_tag> _user_post_tags;
		
		private EntityRef<user> _user;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void Onuser_idChanging(int value);
    partial void Onuser_idChanged();
    partial void Onparent_post_idChanging(System.Nullable<int> value);
    partial void Onparent_post_idChanged();
    partial void OncontentChanging(string value);
    partial void OncontentChanged();
    partial void Onranking_pointsChanging(int value);
    partial void Onranking_pointsChanged();
    partial void Onnum_viewsChanging(int value);
    partial void Onnum_viewsChanged();
    partial void Onis_accepted_answerChanging(bool value);
    partial void Onis_accepted_answerChanged();
    partial void Oncreated_atChanging(System.DateTime value);
    partial void Oncreated_atChanged();
    partial void OntitleChanging(string value);
    partial void OntitleChanged();
    #endregion
		
		public user_post()
		{
			this._user_favourites = new EntitySet<user_favourite>(new Action<user_favourite>(this.attach_user_favourites), new Action<user_favourite>(this.detach_user_favourites));
			this._user_post_tags = new EntitySet<user_post_tag>(new Action<user_post_tag>(this.attach_user_post_tags), new Action<user_post_tag>(this.detach_user_post_tags));
			this._user = default(EntityRef<user>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", DbType="Int NOT NULL", IsPrimaryKey=true, IsDbGenerated=true)]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_user_id", DbType="Int NOT NULL")]
		public int user_id
		{
			get
			{
				return this._user_id;
			}
			set
			{
				if ((this._user_id != value))
				{
					if (this._user.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.Onuser_idChanging(value);
					this.SendPropertyChanging();
					this._user_id = value;
					this.SendPropertyChanged("user_id");
					this.Onuser_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_parent_post_id", DbType="Int")]
		public System.Nullable<int> parent_post_id
		{
			get
			{
				return this._parent_post_id;
			}
			set
			{
				if ((this._parent_post_id != value))
				{
					this.Onparent_post_idChanging(value);
					this.SendPropertyChanging();
					this._parent_post_id = value;
					this.SendPropertyChanged("parent_post_id");
					this.Onparent_post_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_content", DbType="Text NOT NULL", CanBeNull=false, UpdateCheck=UpdateCheck.Never)]
		public string content
		{
			get
			{
				return this._content;
			}
			set
			{
				if ((this._content != value))
				{
					this.OncontentChanging(value);
					this.SendPropertyChanging();
					this._content = value;
					this.SendPropertyChanged("content");
					this.OncontentChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ranking_points", DbType="Int NOT NULL")]
		public int ranking_points
		{
			get
			{
				return this._ranking_points;
			}
			set
			{
				if ((this._ranking_points != value))
				{
					this.Onranking_pointsChanging(value);
					this.SendPropertyChanging();
					this._ranking_points = value;
					this.SendPropertyChanged("ranking_points");
					this.Onranking_pointsChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_num_views", DbType="Int NOT NULL")]
		public int num_views
		{
			get
			{
				return this._num_views;
			}
			set
			{
				if ((this._num_views != value))
				{
					this.Onnum_viewsChanging(value);
					this.SendPropertyChanging();
					this._num_views = value;
					this.SendPropertyChanged("num_views");
					this.Onnum_viewsChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_is_accepted_answer", DbType="Bit NOT NULL")]
		public bool is_accepted_answer
		{
			get
			{
				return this._is_accepted_answer;
			}
			set
			{
				if ((this._is_accepted_answer != value))
				{
					this.Onis_accepted_answerChanging(value);
					this.SendPropertyChanging();
					this._is_accepted_answer = value;
					this.SendPropertyChanged("is_accepted_answer");
					this.Onis_accepted_answerChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_created_at", DbType="DateTime NOT NULL")]
		public System.DateTime created_at
		{
			get
			{
				return this._created_at;
			}
			set
			{
				if ((this._created_at != value))
				{
					this.Oncreated_atChanging(value);
					this.SendPropertyChanging();
					this._created_at = value;
					this.SendPropertyChanged("created_at");
					this.Oncreated_atChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_title", CanBeNull=false)]
		public string title
		{
			get
			{
				return this._title;
			}
			set
			{
				if ((this._title != value))
				{
					this.OntitleChanging(value);
					this.SendPropertyChanging();
					this._title = value;
					this.SendPropertyChanged("title");
					this.OntitleChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="user_post_user_favourite", Storage="_user_favourites", ThisKey="id", OtherKey="user_post_id")]
		public EntitySet<user_favourite> user_favourites
		{
			get
			{
				return this._user_favourites;
			}
			set
			{
				this._user_favourites.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="user_post_user_post_tag", Storage="_user_post_tags", ThisKey="id", OtherKey="user_post_id")]
		public EntitySet<user_post_tag> user_post_tags
		{
			get
			{
				return this._user_post_tags;
			}
			set
			{
				this._user_post_tags.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="user_user_post", Storage="_user", ThisKey="user_id", OtherKey="id", IsForeignKey=true)]
		public user user
		{
			get
			{
				return this._user.Entity;
			}
			set
			{
				user previousValue = this._user.Entity;
				if (((previousValue != value) 
							|| (this._user.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._user.Entity = null;
						previousValue.user_posts.Remove(this);
					}
					this._user.Entity = value;
					if ((value != null))
					{
						value.user_posts.Add(this);
						this._user_id = value.id;
					}
					else
					{
						this._user_id = default(int);
					}
					this.SendPropertyChanged("user");
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
		
		private void attach_user_favourites(user_favourite entity)
		{
			this.SendPropertyChanging();
			entity.user_post = this;
		}
		
		private void detach_user_favourites(user_favourite entity)
		{
			this.SendPropertyChanging();
			entity.user_post = null;
		}
		
		private void attach_user_post_tags(user_post_tag entity)
		{
			this.SendPropertyChanging();
			entity.user_post = this;
		}
		
		private void detach_user_post_tags(user_post_tag entity)
		{
			this.SendPropertyChanging();
			entity.user_post = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.user_favourite")]
	public partial class user_favourite : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _user_id;
		
		private int _user_post_id;
		
		private EntityRef<user> _user;
		
		private EntityRef<user_post> _user_post;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Onuser_idChanging(int value);
    partial void Onuser_idChanged();
    partial void Onuser_post_idChanging(int value);
    partial void Onuser_post_idChanged();
    #endregion
		
		public user_favourite()
		{
			this._user = default(EntityRef<user>);
			this._user_post = default(EntityRef<user_post>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_user_id", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int user_id
		{
			get
			{
				return this._user_id;
			}
			set
			{
				if ((this._user_id != value))
				{
					if (this._user.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.Onuser_idChanging(value);
					this.SendPropertyChanging();
					this._user_id = value;
					this.SendPropertyChanged("user_id");
					this.Onuser_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_user_post_id", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int user_post_id
		{
			get
			{
				return this._user_post_id;
			}
			set
			{
				if ((this._user_post_id != value))
				{
					if (this._user_post.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.Onuser_post_idChanging(value);
					this.SendPropertyChanging();
					this._user_post_id = value;
					this.SendPropertyChanged("user_post_id");
					this.Onuser_post_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="user_user_favourite", Storage="_user", ThisKey="user_id", OtherKey="id", IsForeignKey=true)]
		public user user
		{
			get
			{
				return this._user.Entity;
			}
			set
			{
				user previousValue = this._user.Entity;
				if (((previousValue != value) 
							|| (this._user.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._user.Entity = null;
						previousValue.user_favourites.Remove(this);
					}
					this._user.Entity = value;
					if ((value != null))
					{
						value.user_favourites.Add(this);
						this._user_id = value.id;
					}
					else
					{
						this._user_id = default(int);
					}
					this.SendPropertyChanged("user");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="user_post_user_favourite", Storage="_user_post", ThisKey="user_post_id", OtherKey="id", IsForeignKey=true)]
		public user_post user_post
		{
			get
			{
				return this._user_post.Entity;
			}
			set
			{
				user_post previousValue = this._user_post.Entity;
				if (((previousValue != value) 
							|| (this._user_post.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._user_post.Entity = null;
						previousValue.user_favourites.Remove(this);
					}
					this._user_post.Entity = value;
					if ((value != null))
					{
						value.user_favourites.Add(this);
						this._user_post_id = value.id;
					}
					else
					{
						this._user_post_id = default(int);
					}
					this.SendPropertyChanged("user_post");
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.user_post_tag")]
	public partial class user_post_tag : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _tag_id;
		
		private int _user_post_id;
		
		private EntityRef<tag> _tag;
		
		private EntityRef<user_post> _user_post;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Ontag_idChanging(int value);
    partial void Ontag_idChanged();
    partial void Onuser_post_idChanging(int value);
    partial void Onuser_post_idChanged();
    #endregion
		
		public user_post_tag()
		{
			this._tag = default(EntityRef<tag>);
			this._user_post = default(EntityRef<user_post>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_tag_id", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int tag_id
		{
			get
			{
				return this._tag_id;
			}
			set
			{
				if ((this._tag_id != value))
				{
					if (this._tag.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.Ontag_idChanging(value);
					this.SendPropertyChanging();
					this._tag_id = value;
					this.SendPropertyChanged("tag_id");
					this.Ontag_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_user_post_id", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int user_post_id
		{
			get
			{
				return this._user_post_id;
			}
			set
			{
				if ((this._user_post_id != value))
				{
					if (this._user_post.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.Onuser_post_idChanging(value);
					this.SendPropertyChanging();
					this._user_post_id = value;
					this.SendPropertyChanged("user_post_id");
					this.Onuser_post_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="tag_user_post_tag", Storage="_tag", ThisKey="tag_id", OtherKey="id", IsForeignKey=true)]
		public tag tag
		{
			get
			{
				return this._tag.Entity;
			}
			set
			{
				tag previousValue = this._tag.Entity;
				if (((previousValue != value) 
							|| (this._tag.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._tag.Entity = null;
						previousValue.user_post_tags.Remove(this);
					}
					this._tag.Entity = value;
					if ((value != null))
					{
						value.user_post_tags.Add(this);
						this._tag_id = value.id;
					}
					else
					{
						this._tag_id = default(int);
					}
					this.SendPropertyChanged("tag");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="user_post_user_post_tag", Storage="_user_post", ThisKey="user_post_id", OtherKey="id", IsForeignKey=true)]
		public user_post user_post
		{
			get
			{
				return this._user_post.Entity;
			}
			set
			{
				user_post previousValue = this._user_post.Entity;
				if (((previousValue != value) 
							|| (this._user_post.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._user_post.Entity = null;
						previousValue.user_post_tags.Remove(this);
					}
					this._user_post.Entity = value;
					if ((value != null))
					{
						value.user_post_tags.Add(this);
						this._user_post_id = value.id;
					}
					else
					{
						this._user_post_id = default(int);
					}
					this.SendPropertyChanged("user_post");
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
