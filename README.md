# 20 09 01 Entity Lecture

### CodeTogether
#### Database Set Up
- create an MCV application called `Lecture` using the .NET CLI
- add the required Entity Framework packages
```
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
```
- create a model called ResidentModel
	- int id
	- string name
	- int apartmentNumber
	- bool hasPets
- create a database context called ApartmentDbContext
	- this class extends the base class DbContext imported from `Microsoft.EntityFrameworkCore`
	- this class constructor extends the base constructor passing `options` define as type `DbContextOptions<ClassName>`
	- this class has one property `residents` of type `DbSet<ModelToReference>`
- update the `appsettings.json` file to include `ConnectionStrings` property
```
{
	...

  "ConnectionStrings" : {
    "DefaultDbConnection" : "DataSource=databaseFileName.db"
  }
}
```
- update the `Startup.cs` file to include reference to created database context and connection string in the `ConfigurationSrevices` method
```c#
public void ConfigureServices(IServiceCollection services)
{
    services.AddControllersWithViews();
    // add db context
    services.AddDbContext<CreatedDBContext>(options => options.UseSqlite(Configuration.GetConnectionString("DefaultDbConnection")));
}
```
- add migrations for initial creation
```
dotnet ef migrations add uniqueMigrationMessage
```
- apply migrations
```
dotnet ef database update
```
- view created database in the sqlite explorer 

#### CRUD Functionality 
- create a controller called `ApartmentController` that extends the base class controller
- define one private readonly class property called `_context` and set the value of that property in the class constructor 
- Add a new resident to the database
	- define a post method called `AddResident` with parameters for each property of the model EXCEPT id
	- create a new instance of the Resident Model, setting the object property values equal to the method parameters
	- add the new resident to the reference to the Apartment Db Context
	- save changes made to the reference to the Apartment Db Context
	- return the string "Resident Created" as content
	- run method in postman and check update in sqlite explorer
- View All residents in the database
	- define a get method called `ViewResidents`
	- define a string `displayStr` 
	- call the `ToList` method on db set property of the reference to the Apartment db context and save returned value in a list of resident model objects called `residents`
	- iterate through the list of resident model objects appending each objects properties to the display string
	- run method in postman
- Update the `hasPets` property of a resident
	- define a put method called `UpdateResidentsPets` with parameters for id and hasPets
	- use LINQ to return the resident with the id matching the id passed in
	- update the hasPets property to the corresponding value passed in
	- save changes made to the reference to the Apartment Db Context
	- return the string "Resident Updated" as content
	- run method in postman and view all resident to check update
- Delete a resident
	- define a delete method called `DeleteResident` with parameter for id 
	- use LINQ to return the resident with the id matching the id passed in
	- remove matching resident from  the reference to the Apartment Db Context
	- save changes made to the reference to the Apartment Db Context
	- return the string "Resident Deleted" as content
	- run method in postman and view all resident to check update

#### Implementing Views
- create a view for the apartment controller called ViewResidents.cshtml
- define the view model as the ApartmentDbContext
- iterate through the resident models objects in the db set property of the view model
- display each residents is, name, and apartment number
- if a resident has pets display the text "This resident has pets" along with the other properties
- refactor each method to return the ViewResidents view instead of plain content

#### Implementing Error Handling
- if a matching resident is not found when using LINQ expressions in update and delete method return the string "Matching User Not Found" 