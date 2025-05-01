(You already did this in class, but just as a reminder, before the first time using Entity Framework Core, you'll need to run the following command at the command line)

```
dotnet tool install --global dotnet-ef 
```

# Entity Framework Web Instructions:

**Don't hesitate to copy and paste as much code from this repo as needed. There's no benefit to typing it all out, it's not "cheating".**

First, you'll need to add a reference to the following NuGet packages within your *data* project:


**MAKE SURE TO INSTALL ALL THESE**

* Microsoft.EntityFrameworkCore.SqlServer
* Microsoft.EntityFrameworkCore.Design
* Microsoft.Extensions.Configuration.FileExtensions
* Microsoft.Extensions.Configuration.Json

An alternative way do install these nuget packages that's much faster, is to either double click on the Data Project in Solution Explorer, or right click on the Data project in visual studio and click "Edit Project File". This will bring
up the project file, where you can paste in the following (after the `</PropertyGroup>` section):

```xml
  <ItemGroup>
    <PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="9.0.4">
      <PrivateAssets>all</PrivateAssets>
      <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
    </PackageReference>
    <PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="9.0.4" />
    <PackageReference Include="Microsoft.Extensions.Configuration.FileExtensions" Version="9.0.4" />
    <PackageReference Include="Microsoft.Extensions.Configuration.Json" Version="9.0.4" />
  </ItemGroup>
```

Save and close this file and now all those nuget packages will be installed.

You can then go ahead and create your `DbContext` class, however, make sure to create a constructor that takes in a connection string. See how I did it here:

https://github.com/LIT-W12/EFCoreWebDemo/blob/master/EFCoreWebDemo.Data/PeopleDataContext.cs#L12-L17

You can then create your classes that match the tables you want in your database, and then add them as a `DbSet<>` to your Context class:

https://github.com/LIT-W12/EFCoreWebDemo/blob/master/EFCoreWebDemo.Data/Person.cs

https://github.com/LIT-W12/EFCoreWebDemo/blob/master/EFCoreWebDemo.Data/PeopleDataContext.cs#L24

Then, you'll need to create a class that implements the interface `IDesignTimeDbContextFactory<NameOfYourDbContext>`. See mine here:

https://github.com/LIT-W12/EFCoreWebDemo/blob/master/EFCoreWebDemo.Data/PeopleDataContextFactory.cs

You'll then need to change the directory on this line to match the name of your web project:

https://github.com/LIT-W12/EFCoreWebDemo/blob/master/EFCoreWebDemo.Data/PeopleDataContextFactory.cs#L17

(at the end of that line where it says `EFCoreWebDemo.Web` by mine, change it to match the name of _your_ web project). You'll also need to change the return type of the `CreateDbContext` to match the name of your DbContext class.

Then, make sure to add your connection string in your **Web** project within the `appsettings.json` file:

https://github.com/LIT-W12/EFCoreWebDemo/blob/master/EFCoreWebDemo.Web/appsettings.json#L8-L11

Once you have all that set up, you can go to the command line, you can use the nuget command line for that:

<img width="641" alt="image" src="https://github.com/LITW11/EFCoreWebDemo/assets/159099703/35bcda9f-c706-458b-85ec-ac110bc61ea1">

and **make sure to go into the data projects directory**. You'll have to type something like `cd MyProject.Data` From there, you
can run both the `dotnet ef migrations add "{SomeMigration}"` and `dotnet ef database update` commands.

From there, you can create your repository classes as you did before, but instead of using the old style of database access code, you can now
use Entity Framework.
