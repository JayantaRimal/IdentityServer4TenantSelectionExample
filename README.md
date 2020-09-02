##### Identity Server 4 Tenant Selection Application Example ####

You can follow the tutorial here :

https://jayantarimal.com.np/implement-tenant-selection-in-identity-server-4-for-multi-tenant-application/

To run this application follow the points belows :


## In Authorization Project ##

Add your database connection settings in your appsettings.development.json file.

Make the required changes to the database seed in IdentityDbcontext, MasterDbContext and ConfigurationDbContext. You need to give your client configuration as per your requirement.

Run the migrations for IdentityDbContext, PersistedGrantDbContext, MasterDbContext and ConfigurationDbContext and update database.

## In Angular Client ##
Make changes to the client config in app.module.ts as per your requirement.

Finally run the application.
