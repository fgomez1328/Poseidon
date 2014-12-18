﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.18444
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Poseidon.Models
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="poseidon_db")]
	public partial class DataClasses1DataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Definiciones de métodos de extensibilidad
    partial void OnCreated();
    partial void InsertCompany(Company instance);
    partial void UpdateCompany(Company instance);
    partial void DeleteCompany(Company instance);
    partial void InsertLogger(Logger instance);
    partial void UpdateLogger(Logger instance);
    partial void DeleteLogger(Logger instance);
    partial void InsertUser(User instance);
    partial void UpdateUser(User instance);
    partial void DeleteUser(User instance);
    partial void InsertUserType(UserType instance);
    partial void UpdateUserType(UserType instance);
    partial void DeleteUserType(UserType instance);
    partial void InsertZone(Zone instance);
    partial void UpdateZone(Zone instance);
    partial void DeleteZone(Zone instance);
    #endregion
		
		public DataClasses1DataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["poseidon_dbConnectionString"].ConnectionString, mappingSource)
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
		
		public System.Data.Linq.Table<Company> Company
		{
			get
			{
				return this.GetTable<Company>();
			}
		}
		
		public System.Data.Linq.Table<Logger> Logger
		{
			get
			{
				return this.GetTable<Logger>();
			}
		}
		
		public System.Data.Linq.Table<User> User
		{
			get
			{
				return this.GetTable<User>();
			}
		}
		
		public System.Data.Linq.Table<UserType> UserType
		{
			get
			{
				return this.GetTable<UserType>();
			}
		}
		
		public System.Data.Linq.Table<Zone> Zone
		{
			get
			{
				return this.GetTable<Zone>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Company")]
	public partial class Company : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _company_id;
		
		private string _company_name;
		
		private System.Nullable<System.DateTime> _creation_date;
		
		private string _company_description;
		
		private EntitySet<Logger> _Logger;
		
		private EntitySet<User> _User;
		
    #region Definiciones de métodos de extensibilidad
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Oncompany_idChanging(int value);
    partial void Oncompany_idChanged();
    partial void Oncompany_nameChanging(string value);
    partial void Oncompany_nameChanged();
    partial void Oncreation_dateChanging(System.Nullable<System.DateTime> value);
    partial void Oncreation_dateChanged();
    partial void Oncompany_descriptionChanging(string value);
    partial void Oncompany_descriptionChanged();
    #endregion
		
		public Company()
		{
			this._Logger = new EntitySet<Logger>(new Action<Logger>(this.attach_Logger), new Action<Logger>(this.detach_Logger));
			this._User = new EntitySet<User>(new Action<User>(this.attach_User), new Action<User>(this.detach_User));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_company_id", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int company_id
		{
			get
			{
				return this._company_id;
			}
			set
			{
				if ((this._company_id != value))
				{
					this.Oncompany_idChanging(value);
					this.SendPropertyChanging();
					this._company_id = value;
					this.SendPropertyChanged("company_id");
					this.Oncompany_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_company_name", DbType="VarChar(50)")]
		public string company_name
		{
			get
			{
				return this._company_name;
			}
			set
			{
				if ((this._company_name != value))
				{
					this.Oncompany_nameChanging(value);
					this.SendPropertyChanging();
					this._company_name = value;
					this.SendPropertyChanged("company_name");
					this.Oncompany_nameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_creation_date", DbType="DateTime")]
		public System.Nullable<System.DateTime> creation_date
		{
			get
			{
				return this._creation_date;
			}
			set
			{
				if ((this._creation_date != value))
				{
					this.Oncreation_dateChanging(value);
					this.SendPropertyChanging();
					this._creation_date = value;
					this.SendPropertyChanged("creation_date");
					this.Oncreation_dateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_company_description", DbType="VarChar(100)")]
		public string company_description
		{
			get
			{
				return this._company_description;
			}
			set
			{
				if ((this._company_description != value))
				{
					this.Oncompany_descriptionChanging(value);
					this.SendPropertyChanging();
					this._company_description = value;
					this.SendPropertyChanged("company_description");
					this.Oncompany_descriptionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Company_Logger", Storage="_Logger", ThisKey="company_id", OtherKey="company_id")]
		public EntitySet<Logger> Logger
		{
			get
			{
				return this._Logger;
			}
			set
			{
				this._Logger.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Company_User", Storage="_User", ThisKey="company_id", OtherKey="company_id")]
		public EntitySet<User> User
		{
			get
			{
				return this._User;
			}
			set
			{
				this._User.Assign(value);
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
		
		private void attach_Logger(Logger entity)
		{
			this.SendPropertyChanging();
			entity.Company = this;
		}
		
		private void detach_Logger(Logger entity)
		{
			this.SendPropertyChanging();
			entity.Company = null;
		}
		
		private void attach_User(User entity)
		{
			this.SendPropertyChanging();
			entity.Company = this;
		}
		
		private void detach_User(User entity)
		{
			this.SendPropertyChanging();
			entity.Company = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Logger")]
	public partial class Logger : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _logger_id;
		
		private string _logger_sites_name;
		
		private System.Nullable<int> _logger_sms;
		
		private System.Nullable<int> _logger_type;
		
		private string _logger_serial_number;
		
		private System.Nullable<int> _instalation_type;
		
		private System.Nullable<int> _chip_id;
		
		private System.Nullable<double> _latitude;
		
		private System.Nullable<double> _longitute;
		
		private System.Nullable<double> _elevation;
		
		private string _antenna_position;
		
		private System.Nullable<int> _final_csq;
		
		private System.Nullable<bool> _gprs_test_status;
		
		private System.Nullable<System.DateTime> _creation_date;
		
		private System.Nullable<int> _creation_user;
		
		private System.Nullable<System.DateTime> _instalation_date;
		
		private System.Nullable<int> _instalation_user;
		
		private System.DateTime _approval_date;
		
		private System.Nullable<int> _approval_user;
		
		private int _company_id;
		
		private System.Nullable<int> _zone_id;
		
		private string _url_image;
		
		private System.Nullable<bool> _status;
		
		private string _location_name;
		
		private string _location_id;
		
		private EntityRef<Company> _Company;
		
    #region Definiciones de métodos de extensibilidad
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Onlogger_idChanging(int value);
    partial void Onlogger_idChanged();
    partial void Onlogger_sites_nameChanging(string value);
    partial void Onlogger_sites_nameChanged();
    partial void Onlogger_smsChanging(System.Nullable<int> value);
    partial void Onlogger_smsChanged();
    partial void Onlogger_typeChanging(System.Nullable<int> value);
    partial void Onlogger_typeChanged();
    partial void Onlogger_serial_numberChanging(string value);
    partial void Onlogger_serial_numberChanged();
    partial void Oninstalation_typeChanging(System.Nullable<int> value);
    partial void Oninstalation_typeChanged();
    partial void Onchip_idChanging(System.Nullable<int> value);
    partial void Onchip_idChanged();
    partial void OnlatitudeChanging(System.Nullable<double> value);
    partial void OnlatitudeChanged();
    partial void OnlongituteChanging(System.Nullable<double> value);
    partial void OnlongituteChanged();
    partial void OnelevationChanging(System.Nullable<double> value);
    partial void OnelevationChanged();
    partial void Onantenna_positionChanging(string value);
    partial void Onantenna_positionChanged();
    partial void Onfinal_csqChanging(System.Nullable<int> value);
    partial void Onfinal_csqChanged();
    partial void Ongprs_test_statusChanging(System.Nullable<bool> value);
    partial void Ongprs_test_statusChanged();
    partial void Oncreation_dateChanging(System.Nullable<System.DateTime> value);
    partial void Oncreation_dateChanged();
    partial void Oncreation_userChanging(System.Nullable<int> value);
    partial void Oncreation_userChanged();
    partial void Oninstalation_dateChanging(System.Nullable<System.DateTime> value);
    partial void Oninstalation_dateChanged();
    partial void Oninstalation_userChanging(System.Nullable<int> value);
    partial void Oninstalation_userChanged();
    partial void Onapproval_dateChanging(System.DateTime value);
    partial void Onapproval_dateChanged();
    partial void Onapproval_userChanging(System.Nullable<int> value);
    partial void Onapproval_userChanged();
    partial void Oncompany_idChanging(int value);
    partial void Oncompany_idChanged();
    partial void Onzone_idChanging(System.Nullable<int> value);
    partial void Onzone_idChanged();
    partial void Onurl_imageChanging(string value);
    partial void Onurl_imageChanged();
    partial void OnstatusChanging(System.Nullable<bool> value);
    partial void OnstatusChanged();
    partial void Onlocation_nameChanging(string value);
    partial void Onlocation_nameChanged();
    partial void Onlocation_idChanging(string value);
    partial void Onlocation_idChanged();
    #endregion
		
		public Logger()
		{
			this._Company = default(EntityRef<Company>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_logger_id", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int logger_id
		{
			get
			{
				return this._logger_id;
			}
			set
			{
				if ((this._logger_id != value))
				{
					this.Onlogger_idChanging(value);
					this.SendPropertyChanging();
					this._logger_id = value;
					this.SendPropertyChanged("logger_id");
					this.Onlogger_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_logger_sites_name", DbType="VarChar(50)")]
		public string logger_sites_name
		{
			get
			{
				return this._logger_sites_name;
			}
			set
			{
				if ((this._logger_sites_name != value))
				{
					this.Onlogger_sites_nameChanging(value);
					this.SendPropertyChanging();
					this._logger_sites_name = value;
					this.SendPropertyChanged("logger_sites_name");
					this.Onlogger_sites_nameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_logger_sms", DbType="Int")]
		public System.Nullable<int> logger_sms
		{
			get
			{
				return this._logger_sms;
			}
			set
			{
				if ((this._logger_sms != value))
				{
					this.Onlogger_smsChanging(value);
					this.SendPropertyChanging();
					this._logger_sms = value;
					this.SendPropertyChanged("logger_sms");
					this.Onlogger_smsChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_logger_type", DbType="Int")]
		public System.Nullable<int> logger_type
		{
			get
			{
				return this._logger_type;
			}
			set
			{
				if ((this._logger_type != value))
				{
					this.Onlogger_typeChanging(value);
					this.SendPropertyChanging();
					this._logger_type = value;
					this.SendPropertyChanged("logger_type");
					this.Onlogger_typeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_logger_serial_number", DbType="VarChar(50)")]
		public string logger_serial_number
		{
			get
			{
				return this._logger_serial_number;
			}
			set
			{
				if ((this._logger_serial_number != value))
				{
					this.Onlogger_serial_numberChanging(value);
					this.SendPropertyChanging();
					this._logger_serial_number = value;
					this.SendPropertyChanged("logger_serial_number");
					this.Onlogger_serial_numberChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_instalation_type", DbType="Int")]
		public System.Nullable<int> instalation_type
		{
			get
			{
				return this._instalation_type;
			}
			set
			{
				if ((this._instalation_type != value))
				{
					this.Oninstalation_typeChanging(value);
					this.SendPropertyChanging();
					this._instalation_type = value;
					this.SendPropertyChanged("instalation_type");
					this.Oninstalation_typeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_chip_id", DbType="Int")]
		public System.Nullable<int> chip_id
		{
			get
			{
				return this._chip_id;
			}
			set
			{
				if ((this._chip_id != value))
				{
					this.Onchip_idChanging(value);
					this.SendPropertyChanging();
					this._chip_id = value;
					this.SendPropertyChanged("chip_id");
					this.Onchip_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_latitude", DbType="Float")]
		public System.Nullable<double> latitude
		{
			get
			{
				return this._latitude;
			}
			set
			{
				if ((this._latitude != value))
				{
					this.OnlatitudeChanging(value);
					this.SendPropertyChanging();
					this._latitude = value;
					this.SendPropertyChanged("latitude");
					this.OnlatitudeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_longitute", DbType="Float")]
		public System.Nullable<double> longitute
		{
			get
			{
				return this._longitute;
			}
			set
			{
				if ((this._longitute != value))
				{
					this.OnlongituteChanging(value);
					this.SendPropertyChanging();
					this._longitute = value;
					this.SendPropertyChanged("longitute");
					this.OnlongituteChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_elevation", DbType="Float")]
		public System.Nullable<double> elevation
		{
			get
			{
				return this._elevation;
			}
			set
			{
				if ((this._elevation != value))
				{
					this.OnelevationChanging(value);
					this.SendPropertyChanging();
					this._elevation = value;
					this.SendPropertyChanged("elevation");
					this.OnelevationChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_antenna_position", DbType="VarChar(50)")]
		public string antenna_position
		{
			get
			{
				return this._antenna_position;
			}
			set
			{
				if ((this._antenna_position != value))
				{
					this.Onantenna_positionChanging(value);
					this.SendPropertyChanging();
					this._antenna_position = value;
					this.SendPropertyChanged("antenna_position");
					this.Onantenna_positionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_final_csq", DbType="Int")]
		public System.Nullable<int> final_csq
		{
			get
			{
				return this._final_csq;
			}
			set
			{
				if ((this._final_csq != value))
				{
					this.Onfinal_csqChanging(value);
					this.SendPropertyChanging();
					this._final_csq = value;
					this.SendPropertyChanged("final_csq");
					this.Onfinal_csqChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_gprs_test_status", DbType="Bit")]
		public System.Nullable<bool> gprs_test_status
		{
			get
			{
				return this._gprs_test_status;
			}
			set
			{
				if ((this._gprs_test_status != value))
				{
					this.Ongprs_test_statusChanging(value);
					this.SendPropertyChanging();
					this._gprs_test_status = value;
					this.SendPropertyChanged("gprs_test_status");
					this.Ongprs_test_statusChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_creation_date", DbType="DateTime")]
		public System.Nullable<System.DateTime> creation_date
		{
			get
			{
				return this._creation_date;
			}
			set
			{
				if ((this._creation_date != value))
				{
					this.Oncreation_dateChanging(value);
					this.SendPropertyChanging();
					this._creation_date = value;
					this.SendPropertyChanged("creation_date");
					this.Oncreation_dateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_creation_user", DbType="Int")]
		public System.Nullable<int> creation_user
		{
			get
			{
				return this._creation_user;
			}
			set
			{
				if ((this._creation_user != value))
				{
					this.Oncreation_userChanging(value);
					this.SendPropertyChanging();
					this._creation_user = value;
					this.SendPropertyChanged("creation_user");
					this.Oncreation_userChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_instalation_date", DbType="DateTime")]
		public System.Nullable<System.DateTime> instalation_date
		{
			get
			{
				return this._instalation_date;
			}
			set
			{
				if ((this._instalation_date != value))
				{
					this.Oninstalation_dateChanging(value);
					this.SendPropertyChanging();
					this._instalation_date = value;
					this.SendPropertyChanged("instalation_date");
					this.Oninstalation_dateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_instalation_user", DbType="Int")]
		public System.Nullable<int> instalation_user
		{
			get
			{
				return this._instalation_user;
			}
			set
			{
				if ((this._instalation_user != value))
				{
					this.Oninstalation_userChanging(value);
					this.SendPropertyChanging();
					this._instalation_user = value;
					this.SendPropertyChanged("instalation_user");
					this.Oninstalation_userChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_approval_date", DbType="DateTime NOT NULL")]
		public System.DateTime approval_date
		{
			get
			{
				return this._approval_date;
			}
			set
			{
				if ((this._approval_date != value))
				{
					this.Onapproval_dateChanging(value);
					this.SendPropertyChanging();
					this._approval_date = value;
					this.SendPropertyChanged("approval_date");
					this.Onapproval_dateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_approval_user", DbType="Int")]
		public System.Nullable<int> approval_user
		{
			get
			{
				return this._approval_user;
			}
			set
			{
				if ((this._approval_user != value))
				{
					this.Onapproval_userChanging(value);
					this.SendPropertyChanging();
					this._approval_user = value;
					this.SendPropertyChanged("approval_user");
					this.Onapproval_userChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_company_id", DbType="Int NOT NULL")]
		public int company_id
		{
			get
			{
				return this._company_id;
			}
			set
			{
				if ((this._company_id != value))
				{
					if (this._Company.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.Oncompany_idChanging(value);
					this.SendPropertyChanging();
					this._company_id = value;
					this.SendPropertyChanged("company_id");
					this.Oncompany_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_zone_id", DbType="Int")]
		public System.Nullable<int> zone_id
		{
			get
			{
				return this._zone_id;
			}
			set
			{
				if ((this._zone_id != value))
				{
					this.Onzone_idChanging(value);
					this.SendPropertyChanging();
					this._zone_id = value;
					this.SendPropertyChanged("zone_id");
					this.Onzone_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_url_image", DbType="VarChar(200)")]
		public string url_image
		{
			get
			{
				return this._url_image;
			}
			set
			{
				if ((this._url_image != value))
				{
					this.Onurl_imageChanging(value);
					this.SendPropertyChanging();
					this._url_image = value;
					this.SendPropertyChanged("url_image");
					this.Onurl_imageChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_status", DbType="Bit")]
		public System.Nullable<bool> status
		{
			get
			{
				return this._status;
			}
			set
			{
				if ((this._status != value))
				{
					this.OnstatusChanging(value);
					this.SendPropertyChanging();
					this._status = value;
					this.SendPropertyChanged("status");
					this.OnstatusChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_location_name", DbType="VarChar(50)")]
		public string location_name
		{
			get
			{
				return this._location_name;
			}
			set
			{
				if ((this._location_name != value))
				{
					this.Onlocation_nameChanging(value);
					this.SendPropertyChanging();
					this._location_name = value;
					this.SendPropertyChanged("location_name");
					this.Onlocation_nameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_location_id", DbType="VarChar(20)")]
		public string location_id
		{
			get
			{
				return this._location_id;
			}
			set
			{
				if ((this._location_id != value))
				{
					this.Onlocation_idChanging(value);
					this.SendPropertyChanging();
					this._location_id = value;
					this.SendPropertyChanged("location_id");
					this.Onlocation_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Company_Logger", Storage="_Company", ThisKey="company_id", OtherKey="company_id", IsForeignKey=true)]
		public Company Company
		{
			get
			{
				return this._Company.Entity;
			}
			set
			{
				Company previousValue = this._Company.Entity;
				if (((previousValue != value) 
							|| (this._Company.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Company.Entity = null;
						previousValue.Logger.Remove(this);
					}
					this._Company.Entity = value;
					if ((value != null))
					{
						value.Logger.Add(this);
						this._company_id = value.company_id;
					}
					else
					{
						this._company_id = default(int);
					}
					this.SendPropertyChanged("Company");
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.[User]")]
	public partial class User : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _user_id;
		
		private string _user_name;
		
		private System.Nullable<System.DateTime> _user_creation;
		
		private int _user_type_id;
		
		private int _company_id;
		
		private string _user_pass;
		
		private string _user_login;
		
		private EntityRef<Company> _Company;
		
		private EntityRef<UserType> _UserType;
		
    #region Definiciones de métodos de extensibilidad
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Onuser_idChanging(int value);
    partial void Onuser_idChanged();
    partial void Onuser_nameChanging(string value);
    partial void Onuser_nameChanged();
    partial void Onuser_creationChanging(System.Nullable<System.DateTime> value);
    partial void Onuser_creationChanged();
    partial void Onuser_type_idChanging(int value);
    partial void Onuser_type_idChanged();
    partial void Oncompany_idChanging(int value);
    partial void Oncompany_idChanged();
    partial void Onuser_passChanging(string value);
    partial void Onuser_passChanged();
    partial void Onuser_loginChanging(string value);
    partial void Onuser_loginChanged();
    #endregion
		
		public User()
		{
			this._Company = default(EntityRef<Company>);
			this._UserType = default(EntityRef<UserType>);
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
					this.Onuser_idChanging(value);
					this.SendPropertyChanging();
					this._user_id = value;
					this.SendPropertyChanged("user_id");
					this.Onuser_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_user_name", DbType="VarChar(50)")]
		public string user_name
		{
			get
			{
				return this._user_name;
			}
			set
			{
				if ((this._user_name != value))
				{
					this.Onuser_nameChanging(value);
					this.SendPropertyChanging();
					this._user_name = value;
					this.SendPropertyChanged("user_name");
					this.Onuser_nameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_user_creation", DbType="DateTime")]
		public System.Nullable<System.DateTime> user_creation
		{
			get
			{
				return this._user_creation;
			}
			set
			{
				if ((this._user_creation != value))
				{
					this.Onuser_creationChanging(value);
					this.SendPropertyChanging();
					this._user_creation = value;
					this.SendPropertyChanged("user_creation");
					this.Onuser_creationChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_user_type_id", DbType="Int NOT NULL")]
		public int user_type_id
		{
			get
			{
				return this._user_type_id;
			}
			set
			{
				if ((this._user_type_id != value))
				{
					if (this._UserType.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.Onuser_type_idChanging(value);
					this.SendPropertyChanging();
					this._user_type_id = value;
					this.SendPropertyChanged("user_type_id");
					this.Onuser_type_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_company_id", DbType="Int NOT NULL")]
		public int company_id
		{
			get
			{
				return this._company_id;
			}
			set
			{
				if ((this._company_id != value))
				{
					if (this._Company.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.Oncompany_idChanging(value);
					this.SendPropertyChanging();
					this._company_id = value;
					this.SendPropertyChanged("company_id");
					this.Oncompany_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_user_pass", DbType="VarChar(32)")]
		public string user_pass
		{
			get
			{
				return this._user_pass;
			}
			set
			{
				if ((this._user_pass != value))
				{
					this.Onuser_passChanging(value);
					this.SendPropertyChanging();
					this._user_pass = value;
					this.SendPropertyChanged("user_pass");
					this.Onuser_passChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_user_login", DbType="VarChar(20)")]
		public string user_login
		{
			get
			{
				return this._user_login;
			}
			set
			{
				if ((this._user_login != value))
				{
					this.Onuser_loginChanging(value);
					this.SendPropertyChanging();
					this._user_login = value;
					this.SendPropertyChanged("user_login");
					this.Onuser_loginChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Company_User", Storage="_Company", ThisKey="company_id", OtherKey="company_id", IsForeignKey=true)]
		public Company Company
		{
			get
			{
				return this._Company.Entity;
			}
			set
			{
				Company previousValue = this._Company.Entity;
				if (((previousValue != value) 
							|| (this._Company.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Company.Entity = null;
						previousValue.User.Remove(this);
					}
					this._Company.Entity = value;
					if ((value != null))
					{
						value.User.Add(this);
						this._company_id = value.company_id;
					}
					else
					{
						this._company_id = default(int);
					}
					this.SendPropertyChanged("Company");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="UserType_User", Storage="_UserType", ThisKey="user_type_id", OtherKey="user_type_id", IsForeignKey=true)]
		public UserType UserType
		{
			get
			{
				return this._UserType.Entity;
			}
			set
			{
				UserType previousValue = this._UserType.Entity;
				if (((previousValue != value) 
							|| (this._UserType.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._UserType.Entity = null;
						previousValue.User.Remove(this);
					}
					this._UserType.Entity = value;
					if ((value != null))
					{
						value.User.Add(this);
						this._user_type_id = value.user_type_id;
					}
					else
					{
						this._user_type_id = default(int);
					}
					this.SendPropertyChanged("UserType");
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.UserType")]
	public partial class UserType : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _user_type_id;
		
		private string _user_type_name;
		
		private EntitySet<User> _User;
		
    #region Definiciones de métodos de extensibilidad
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Onuser_type_idChanging(int value);
    partial void Onuser_type_idChanged();
    partial void Onuser_type_nameChanging(string value);
    partial void Onuser_type_nameChanged();
    #endregion
		
		public UserType()
		{
			this._User = new EntitySet<User>(new Action<User>(this.attach_User), new Action<User>(this.detach_User));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_user_type_id", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int user_type_id
		{
			get
			{
				return this._user_type_id;
			}
			set
			{
				if ((this._user_type_id != value))
				{
					this.Onuser_type_idChanging(value);
					this.SendPropertyChanging();
					this._user_type_id = value;
					this.SendPropertyChanged("user_type_id");
					this.Onuser_type_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_user_type_name", DbType="VarChar(50)")]
		public string user_type_name
		{
			get
			{
				return this._user_type_name;
			}
			set
			{
				if ((this._user_type_name != value))
				{
					this.Onuser_type_nameChanging(value);
					this.SendPropertyChanging();
					this._user_type_name = value;
					this.SendPropertyChanged("user_type_name");
					this.Onuser_type_nameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="UserType_User", Storage="_User", ThisKey="user_type_id", OtherKey="user_type_id")]
		public EntitySet<User> User
		{
			get
			{
				return this._User;
			}
			set
			{
				this._User.Assign(value);
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
		
		private void attach_User(User entity)
		{
			this.SendPropertyChanging();
			entity.UserType = this;
		}
		
		private void detach_User(User entity)
		{
			this.SendPropertyChanging();
			entity.UserType = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Zone")]
	public partial class Zone : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _zone_id;
		
		private string _zone_name;
		
		private string _zone_code;
		
    #region Definiciones de métodos de extensibilidad
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Onzone_idChanging(int value);
    partial void Onzone_idChanged();
    partial void Onzone_nameChanging(string value);
    partial void Onzone_nameChanged();
    partial void Onzone_codeChanging(string value);
    partial void Onzone_codeChanged();
    #endregion
		
		public Zone()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_zone_id", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int zone_id
		{
			get
			{
				return this._zone_id;
			}
			set
			{
				if ((this._zone_id != value))
				{
					this.Onzone_idChanging(value);
					this.SendPropertyChanging();
					this._zone_id = value;
					this.SendPropertyChanged("zone_id");
					this.Onzone_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_zone_name", DbType="VarChar(100)")]
		public string zone_name
		{
			get
			{
				return this._zone_name;
			}
			set
			{
				if ((this._zone_name != value))
				{
					this.Onzone_nameChanging(value);
					this.SendPropertyChanging();
					this._zone_name = value;
					this.SendPropertyChanged("zone_name");
					this.Onzone_nameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_zone_code", DbType="VarChar(50)")]
		public string zone_code
		{
			get
			{
				return this._zone_code;
			}
			set
			{
				if ((this._zone_code != value))
				{
					this.Onzone_codeChanging(value);
					this.SendPropertyChanging();
					this._zone_code = value;
					this.SendPropertyChanged("zone_code");
					this.Onzone_codeChanged();
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
