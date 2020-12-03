Example migration:
Create (in package manager console):
Add-Migration update-20201203 -StartupProject WebApi -Project Infrastructure

Update database:
Update-Database -StartupProject WebApi -Project Infrastructure