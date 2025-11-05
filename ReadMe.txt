<-------------------------->
<--    NuGet Packages    -->
<-------------------------->

<-- Api -->
Microsoft.EntityFrameworkCore.SqlServer
Microsoft.EntityFrameworkCore.Tools
Swashbuckle.AspNetCore

<-- DataAccess -->
Microsoft.EntityFrameworkCore.SqlServer
Microsoft.EntityFrameworkCore.Tools

<-- Entites -->
Microsoft.EntityFrameworkCore.SqlServer
Microsoft.EntityFrameworkCore.Tools

<--------------------------->
<-- create classes for Ef -->
<--------------------------->

<-- Remove example files if not alredy done -->

// Open Package Manager Console \\
Tools > NuGet Package Manager > Package Manager Console

// Find Connection string \\
View > SQL Server ObjectExplorer > Desired db > Properties > Connection string

<-- change "connection string" & "dbNameContext" -->

// Copy/Paste to Package Manager Console and run with correct connection string and db Context name \\
Scaffold-DbContext " connection string "
Microsoft.EntityFrameworkCore.SqlServer -Context dbNameContext -
Project Entities -StartupProject Api

<-- Move "dbNameContext" to Context folder -->
