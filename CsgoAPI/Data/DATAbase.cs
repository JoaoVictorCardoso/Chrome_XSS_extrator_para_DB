namespace CsgoAPI.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class DATAbase : DbContext
    {
        // Your context has been configured to use a 'DATAbase' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'CsgoAPI.Data.DATAbase' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'DATAbase' 
        // connection string in the application configuration file.
        public DATAbase()
            : base("name=DATAbase")
        {
        }


        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

#pragma warning disable CS0436 // Type conflicts with imported type
        public virtual DbSet<CsgoItem> Item { get; set; }
#pragma warning restore CS0436 // Type conflicts with imported type
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}