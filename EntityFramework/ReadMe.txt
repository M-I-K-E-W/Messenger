TO BUILD THE ENTITY MODEL FROM THE DB
=====================================

1) Open Nuget packet manager console from Tools menu
2) Set the project 'EntityFramework' as 'Startup  project' by right clicking on the project within the solution explorer
3) In the Nuget packet manager console, set the default project to 'EntityFramework'
4) Copy and paste the Scaffolding command below ...

Scaffold-DbContext "Server=.\mssqlexpress2019;Database=Messenger;Trusted_Connection=True;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Context DataContext -force

TO ADD A NEW MIGRATION CHANGE
=============================

1) Follow steps 1, 2, and 3 at the top
2) Copy and paste the command below ...

Add-Migration <Appropriate name indicating new changes>

TO MIGRATE CHANGES
==================

1) Follow steps 1, 2, and 3 at the top
2) Copy and paste the command below ...

Update-Database

DIMENSION DATA
==============

1) In the solution explorer locate the folder "Resources" (directly underneath the solution node), and open "Dimensions.sql"
2) Run the SQL. You will be prompted for the credentials of the SQL DB (.\mssqlexpress2019, use local user, and defualt db to "VideoAcquisitionManager")