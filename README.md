# PcMAG backend

Generate model classes with:
````
dotnet-ef dbcontext scaffold "DataSource=./Pcmag.db;" Microsoft.EntityFrameworkCore.Sqlite -o Models/Entities
````
where DataSource value is path to the SQLite database file