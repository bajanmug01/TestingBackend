# TestingBackend
Simple test application that accesses an Azure SQL database and can read, write and delete test data.

## Requirements
Azure SQL Server with an SQL Database

## Add User-Secrets
Add your Database connectionString.
For example:
```
  "ConnectionStrings": {
    "Database": "Server=tcp:XXX.database.windows.net,1433;Initial Catalog=XXX;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;Authentication=Active Directory Interactive;",
  },
```
 



## Migratons
(https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=vs)
