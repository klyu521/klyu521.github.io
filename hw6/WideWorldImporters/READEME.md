### [Repo](https://github.com/klyu521/klyu521.github.io)


### Setup
For this homework, I download the SQL Server Managment Studio 2017. I never used it before and it has many problems when I used it. I spent a lot of time to make sure it can be worked.
Then I start to recovery the .bak file and connet the database.

### Code 
After I create a new project, I download the Microsoft.SqlServer.Types first and add code in Global.asax.cs.

Then I do the people search part.
```
<h2 style="text-align:center; margin-top:30px; font-family:Calibri">Client Search</h2>

@using (Html.BeginForm("Index", "Home", FormMethod.Get, new { @style = "margin-top:30px;" }))
{
    <div class="form-group">

        @Html.TextBox("input", "", new { @class = "form-control", @placeholder = "Search using Name", required = "required", @style = "margin: 0px auto;" })
        <div style="text-align:center; margin-top:5px;">
            <button class="btn btn-default" type="submit" style="background-color:#ffd800; color:white; text-align:center;">Search</button>
        </div>
    </div>
}

@if (ViewBag.show)
{
    if (Model.Count() == 0)
    {
        <h4 style="color:#ff0000;">No matches found with that name.</h4>
    }

    else
    {
        <h4>Names containing the search input:</h4>
        foreach (var Result in Model)
        {

            <div style="margin-bottom:6px;">
                <a class="btn btn-primary btn-md btn-block" href="Home/Details/@Result.PersonID" role="button"> @Result.FullName (@Result.PreferredName) </a>
            </div>
        }
    }
}
```
Next I create the Controller and the Viewmodel, the ViewModel pass the Details View to get database information from Person. 
The ViewModel called info.cs
```
namespace WideWorldImporters.Models.ViewModel
{
    public class Info
    { 
        public Person Person { get; set; }

        public Customer Customer { get; set; }

        public IEnumerable<InvoiceLine> InvoiceLine { get; set; }
    }
}
```

The controller
```
public ActionResult Index(String input)
        {
            input = Request.QueryString["input"];
            if (input == null)
            {
                ViewBag.show = false;
                return View();
            }
            else
            {
                ViewBag.show = true;
                return View(db.People.Where(search => search.FullName.Contains(input)).ToList());
            }
        }

        
        public ActionResult Details(int? id)
        {
           
            ViewBag.NotEmployee = false;

            Info vm = new Info();

            vm.Person = db.People.Find(id);

            // Returns 404 if the input ID is not in the database 
            if (id == null || vm.Person == null)
            {
                return HttpNotFound();
            }

            // Check the customer data
            if (vm.Person.Customers2.Count() > 0)
            {
                ViewBag.NotEmployee = true;

                // Get customer ID
                int custID = vm.Person.Customers2.FirstOrDefault().CustomerID;

                // Finds the customer
                vm.Customer = db.Customers.Find(custID);

                // Gets the Gross Sales and Gross Profit for Purchase History table
                ViewBag.GrossSales = vm.Customer.Orders.SelectMany(i => i.Invoices).SelectMany(il => il.InvoiceLines).Sum(ep => ep.ExtendedPrice);
                ViewBag.GrossProfit = vm.Customer.Orders.SelectMany(i => i.Invoices).SelectMany(il => il.InvoiceLines).Sum(lp => lp.LineProfit);

                // Builds a list of top 10 items purchased in descending order by selecting into the invoicelines data table
                vm.InvoiceLine = vm.Customer.Orders.SelectMany(i => i.Invoices)
                                                .SelectMany(il => il.InvoiceLines)
                                                .OrderByDescending(lp => lp.LineProfit)
                                                .Take(10)
                                                .ToList();
            }

           
            return View(vm);
        }
    }
}
```
The view which can show all the details information.
```
<div class="row">
        <div class="col-md-4" style="border:5px solid blue; background-color:gray;">
            <h2 style="text-align:center; font-weight:bold; margin-bottom:20px; border-bottom: 2px solid blue; padding-bottom: 20px;">
                @Html.DisplayFor(model => model.Person.FullName)
            </h2>
            <dl class="dl-horizontal">
                <dt>
                    Preferred Name:
                </dt>
                <dd>
                    @Html.DisplayFor(model => model.Person.PreferredName)
                </dd>

                <dt>
                    Phone Number:
                </dt>
                <dd>
                    @Html.DisplayFor(model => model.Person.PhoneNumber)
                </dd>

                <dt>
                    Fax Number:
                </dt>
                <dd>
                    @Html.DisplayFor(model => model.Person.FaxNumber)
                </dd>

                <dt>
                    Email address:
                </dt>
                <dd>
                    <a href="mailto:@Model.Person.EmailAddress"> @Html.DisplayFor(model => model.Person.EmailAddress)</a>
                </dd>

                <dt>
                    Member Since:
                </dt>
                <dd>
                    @string.Format("{0:MM/dd/yyyy}", Convert.ToDateTime(Html.DisplayFor(model => model.Person.ValidFrom).ToString()))
                </dd>
            </dl>

        </div>
        <div class="col-md-4">
            <img src="https://via.placeholder.com/160x200?text=Photo" alt="@Model.Person.Photo" />
        </div>
```
Here is my video: [Homework6](https://www.youtube.com/watch?v=xKdQIlU8EWU&feature=youtu.be)
