﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

[assembly: global::System.Data.Objects.DataClasses.EdmSchemaAttribute()]

// Original file name:
// Generation date: 10/29/2010 5:53:32 PM
namespace MPSite.Models
{
    
    /// <summary>
    /// There are no comments for MoneyPacificSiteEntities in the schema.
    /// </summary>
    public partial class MoneyPacificSiteEntities : global::System.Data.Objects.ObjectContext
    {
        /// <summary>
        /// Initializes a new MoneyPacificSiteEntities object using the connection string found in the 'MoneyPacificSiteEntities' section of the application configuration file.
        /// </summary>
        public MoneyPacificSiteEntities() : 
                base("name=MoneyPacificSiteEntities", "MoneyPacificSiteEntities")
        {
            this.OnContextCreated();
        }
        /// <summary>
        /// Initialize a new MoneyPacificSiteEntities object.
        /// </summary>
        public MoneyPacificSiteEntities(string connectionString) : 
                base(connectionString, "MoneyPacificSiteEntities")
        {
            this.OnContextCreated();
        }
        /// <summary>
        /// Initialize a new MoneyPacificSiteEntities object.
        /// </summary>
        public MoneyPacificSiteEntities(global::System.Data.EntityClient.EntityConnection connection) : 
                base(connection, "MoneyPacificSiteEntities")
        {
            this.OnContextCreated();
        }
        partial void OnContextCreated();
    }
}
