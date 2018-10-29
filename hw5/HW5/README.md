### Homework 5
## [Repo](https://github.com/klyu521/klyu521.github.io)

### Start doing the new project.
First, i created a new empty MVC application, and added my .gitignore file to the base directory of the project. Then I start to do the part of Database, becasuse it based on the homework4 and I need build a database.
At the beginning, I create up.sql and down.sql files to build database.
```
CREATE TABLE [dbo].[Requests]
(
	[ID]			INT IDENTITY (1,1)	NOT NULL,
	[FirstName]		NVARCHAR(20)		NOT NULL,
	[LastName]		NVARCHAR(20)		NOT NULL,
	[PhoneNumber]	NVARCHAR(12)		NOT NULL,
	[ApartmentName]	NVARCHAR(30)		NOT NULL,
	[UnitNumber]	INT					NOT NULL,
	[Explanation]	NVARCHAR(60)		NOT NULL,
	[Permission]	BIT					NOT NULL,
	CONSTRAINT [PK_dbo.Requests] PRIMARY KEY CLUSTERED ([ID] ASC)
);

INSERT INTO [dbo].[Requests] (FirstName, LastName, PhoneNumber, ApartmentName, UnitNumber, Explanation, Permission) VALUES
	('Xueying', 'Zhang', '450-123-1122', 'Powell', 11, 'Important', 0),
	('Zhuo', 'Liu', '120-899-4882', 'LA', 5, 'Important', 0),
	('Chunguang', 'Lyu', '852-478-1234', 'Oregon', 10, ' Broken', 1),
	('Jing', 'Li', '777-888-9999', 'Bejing', 1, 'Bulb', 1),
	('Zha', 'Na', '447-567-3321', 'Shanghai', 8, 'Does not work', 0)
GO
```
down.sql
```
DROP TABLE [dbo].[Requests];
```
### Create the Data Model Class and Data Context Class
I follow the note in class to create the Context Class. Context is what will allow the data in the model to interact with the controller and view, and I snstall the Entity Framework.
```
using HW5.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HW5.DAL
{
    public class RequestsContext :  DbContext
    {
        public RequestsContext() : base("name=Requests") { }
        public virtual DbSet<Requests> Requests { get; set; }
    }
}
```
Then I Create the data model.
```
 namespace HW5.Models
{
    public class Requests
    {
        /// <summary>
        /// The automatically generated ID in the database. This is the PRIMARY KEY.
        /// </summary>
        [Key]
        public int ID { get; set; }


        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
     
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        
        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
       
        [Required]
        [Display(Name = "Apartment Name")]
        public string ApartmentName { get; set; }
      
        [Required]
        [Display(Name = "Unit Number")]
        public int UnitNumber { get; set; }
        
        [Required(ErrorMessage = "Explanation"), StringLength(80, ErrorMessage = "Input can be less than 80 Characters")] 
        public string Explanation { get; set; }

        [Required]
        public bool Permission { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()}: {FirstName} {LastName} {PhoneNumber} {ApartmentName} UnitNumber = {UnitNumber} {Explanation} Permission = {Permission}";
        }
    }
}
```
###  Connecting to the Database
I find the Web.confign file and use <ConnectionStrings> to connet the database.
```
  <configSections>
    <!-- For more information on Entity Framework configuration, visit http://go.microsoft.com/fwlink/?LinkID=237468 -->
    <section name="entityFramework" type="System.Data.Entity.Internal.ConfigFile.EntityFrameworkSection, EntityFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" requirePermission="false" />
  </configSections>
  <connectionStrings>
    <add name="Requests"
         connectionString="Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\18640\source\repos\HW5\HW5\App_Data\Requests.mdf;Integrated Security=True"
         providerName="System.Data.SqlClient"/>
  </connectionStrings>
```
