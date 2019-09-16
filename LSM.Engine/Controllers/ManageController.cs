using EmbedIO;
using EmbedIO.Routing;
using EmbedIO.WebApi;
using LSM.Engine.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace LSM.Engine.Controllers
{
    public class ManageController : WebApiController
    {
        // DASHBOARD

        /// <summary>
        /// This method fetch all service states
        /// </summary>
        /// <returns>Service State</returns>
        [Route(HttpVerbs.Get, "/servicestate")]
        public object GetServiceState()
        {
            //Fetch service state from database
            ServiceState serviceState = new ServiceState();
            serviceState = DB.serviceState;

            // Check if service state exists
            if (serviceState == null)
            {
                serviceState = new ServiceState()
                {
                    AlertArchivingService = false,
                    AutoSyncModule = false,
                    BirthdayNotificationModule = false,
                    FlexAlertModule = false,
                    ServiceChargePostingModule = false,
                    SMSBankingModule = false,
                    TAlertModule = false,
                };

                //Initialize table properties
                DB.serviceState = serviceState;
            }

            // Return service state as JSON
            return new JavaScriptSerializer()
            .Serialize(serviceState);
        }


        /// <summary>
        /// This method handles Service State Update
        /// </summary>
        /// <param name="model"> Name Value Collection containing service and value</param>
        /// <returns>Service State</returns>
        [Route(HttpVerbs.Post, "/updateservicestate")]
        public object UpdateServiceState([FormData] NameValueCollection model)
        {
            string field = model.Get("service");
            string status = model.Get("value");

            ServiceState _states = null;
            try
            {
                // Fetch service states
                _states = DB.serviceState;

                // Get Service state
                if (_states == null)
                {
                    _states = new ServiceState();
                }


                bool _status = Convert.ToBoolean(status);

                switch (field)
                {
                    case "TAlertModule":
                        _states.TAlertModule = _status;
                        break;

                    case "FlexAlertModule":
                        _states.FlexAlertModule = _status;
                        break;

                    case "AlertArchivingService":
                        _states.AlertArchivingService = _status;
                        break;

                    case "AutoSyncModule":
                        _states.AutoSyncModule = _status;
                        break;

                    case "SMSBankingModule":
                        _states.SMSBankingModule = _status;
                        break;

                    case "BirthdayNotificationModule":
                        _states.BirthdayNotificationModule = _status;
                        break;

                    case "ServiceChargePostingModule":
                        _states.ServiceChargePostingModule = _status;
                        break;
                }
            }
            catch (Exception ex)
            {
                return new JavaScriptSerializer()
                .Serialize(new
                {
                    Error = true,
                    ex.Message
                });
            }

            //Update Service State
            DB.serviceState = _states;
            return new JavaScriptSerializer().Serialize(_states);
        }


        /// <summary>
        /// This method handles Se
        /// </summary>
        /// <param name="model"> Name Value Collection containing service and value</param>
        /// <returns>Service State</returns>
        [Route(HttpVerbs.Get, "/loadsettings")]
        public object loadsettings()
        {
            //Create an object of all settings entity
            object dto = new {
                app = DB.app,
                database = DB.database,
                performance = DB.performance
            };
            return new JavaScriptSerializer().Serialize(dto);
        }



        /// <summary>
        /// This method handles Se
        /// </summary>
        /// <param name="model"> Name Value Collection containing service and value</param>
        /// <returns>Service State</returns>
        [Route(HttpVerbs.Get, "/loadqueue")]
        public object LoadQueue()
        {
            //Create an object of all settings entity
            object dto = new
            {
                Transactions = generateValue(),
                SMS = generateValue(),
                Email = generateValue(),
                AutoSync = generateValue()
            };
            return new JavaScriptSerializer().Serialize(dto);
        }

        private int generateValue()
        {
            return new Random().Next(1, 9999);
        }


        // DATABASE SETTINGS
        /// <summary>
        /// This method handles Se
        /// </summary>
        /// <param name="model"> Name Value Collection containing service and value</param>
        /// <returns>Service State</returns>
        [Route(HttpVerbs.Post, "/databaseconfig")]
        public object DatabaseConfig([FormData] NameValueCollection model)
        {
            //Validate User input

            string AppRegistry = model.Get("AppRegistry");
            string DBType = model.Get("DBType");
            string ServerName = model.Get("ServerName");
            string Port = model.Get("Port");
            string DBInstance = model.Get("DBInstance");
            string Username = model.Get("Username");
            string Password = model.Get("Password");

            DatabaseConfig entity = null;
            try
            {
                // Fetch service states
                entity = DB.database;

                // Get Service state
                if (entity == null)
                {
                    entity = new DatabaseConfig();
                }

                // Map entity and model
                entity.AppRegistry = AppRegistry;
                entity.DBType = DBType;
                entity.DBInstance = DBInstance;
                entity.Password = Password;
                entity.Port = Port;
                entity.ServerName = ServerName;
                entity.Username = Username;

            }
            catch (Exception ex)
            {
                return new JavaScriptSerializer()
                .Serialize(new
                {
                    Error = true,
                    ex.Message
                });
            }

            //Update Service State
            DB.database = entity;
            return new JavaScriptSerializer().Serialize(entity);
        }

       

        /// <summary>
        /// This method handles Service State Update
        /// </summary>
        /// <param name="model"> Name Value Collection containing service and value</param>
        /// <returns>Service State</returns>
        [Route(HttpVerbs.Post, "/appconfig")]
        public object AppConfig([FormData] NameValueCollection model)
        {
            AppConfig entity = null;
            try
            {
                //Validate User input

                string ServerID = model.Get("ServerID");
                int TotalBatch = 0;
                Int32.TryParse(model.Get("TotalBatchSize"), out TotalBatch);

                bool EnableDebug = Convert.ToBoolean(model.Get("EnableDebug"));
                bool AutoStart_TAlert = Convert.ToBoolean(model.Get("AutoStart_TAlert"));
                bool AutoStart_CAlert = Convert.ToBoolean(model.Get("AutoStart_CAlert"));
                bool AutoStart_AutoSync = Convert.ToBoolean(model.Get("AutoStart_AutoSync"));
                bool AutoStart_SMSBanking = Convert.ToBoolean(model.Get("AutoStart_SMSBanking"));
                bool AutoStart_ServiceCharge = Convert.ToBoolean(model.Get("AutoStart_ServiceCharge"));
                bool AutoStart_Anniversary = Convert.ToBoolean(model.Get("AutoStart_Anniversary"));

                // Fetch service states
                entity = DB.app;

                // Get Service state
                if (entity == null)
                {
                    entity = new AppConfig();
                }

                // Map entity and model
                entity.ServerID = ServerID;
                entity.TotalBatchSize = TotalBatch;
                entity.EnableDebug = EnableDebug;
                entity.AutoStart_Anniversary = AutoStart_Anniversary;
                entity.AutoStart_AutoSync = AutoStart_AutoSync;
                entity.AutoStart_CAlert = AutoStart_CAlert;
                entity.AutoStart_ServiceCharge = AutoStart_ServiceCharge;
                entity.AutoStart_SMSBanking = AutoStart_SMSBanking;
                entity.AutoStart_TAlert = AutoStart_TAlert;
                entity.EnableDebug = EnableDebug;

            }
            catch (Exception ex)
            {
                return new JavaScriptSerializer()
                .Serialize(new
                {
                    Error = true,
                    ex.Message
                });
            }

            //Update Service State
            DB.app = entity;
            return new JavaScriptSerializer().Serialize(entity);
        }


        /// <summary>
        /// This method handles Service State Update
        /// </summary>
        /// <param name="model"> Name Value Collection containing service and value</param>
        /// <returns>Service State</returns>
        [Route(HttpVerbs.Post, "/performanceconfig")]
        public object PerformanceConfig([FormData] NameValueCollection model)
        {
            // Validate User input


            PerformanceConfig entity = null;
            try
            {
                string MaxDBConnection = model.Get("MaxDBConnection");

                int ConnectionTimeOut = 0;
                Int32.TryParse(model.Get("ConnectionTimeOut"), out ConnectionTimeOut);

                int MaxConOps_TAlert = 0;
                Int32.TryParse(model.Get("MaxConOps_TAlert"), out MaxConOps_TAlert);

                int MaxConOps_SC = 0;
                Int32.TryParse(model.Get("MaxConOps_SC"), out MaxConOps_SC);

                int MaxConOps_AutoSync = 0;
                Int32.TryParse(model.Get("MaxConOps_AutoSync"), out MaxConOps_AutoSync);

                int MaxConOps_Anniversary = 0;
                Int32.TryParse(model.Get("MaxConOps_Anniversary"), out MaxConOps_Anniversary);

                int MaxConOps_SMSBanking = 0;
                Int32.TryParse(model.Get("MaxConOps_SMSBanking"), out MaxConOps_SMSBanking);

                int MaxConOps_CAlert = 0;
                Int32.TryParse(model.Get("MaxConOps_CAlert"), out MaxConOps_CAlert);


                // Fetch service states
                entity = DB.performance;

                // Get Service state
                if (entity == null)
                {
                    entity = new PerformanceConfig();
                }

                // Map entity and model
                entity.ConnectionTimeOut = ConnectionTimeOut;
                entity.MaxConOps_Anniversary = MaxConOps_Anniversary;
                entity.MaxConOps_AutoSync = MaxConOps_AutoSync;
                entity.MaxConOps_CAlert = MaxConOps_CAlert;
                entity.MaxConOps_SC = MaxConOps_SC;
                entity.MaxConOps_SMSBanking = MaxConOps_SMSBanking;
                entity.MaxConOps_TAlert = MaxConOps_TAlert;
                entity.MaxDBConnection = MaxDBConnection;
            }
            catch (Exception ex)
            {
                return new JavaScriptSerializer()
                .Serialize(new
                {
                    Error = true,
                    ex.Message
                });
            }

            //Update Service State
            DB.performance = entity;
            return new JavaScriptSerializer().Serialize(entity);
        }
    }
}
