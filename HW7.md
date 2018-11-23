### [Repo](https://github.com/klyu521/klyu521.github.io)

### Setup
For this homework, I get the API key from Giphy and create the Appsettings.config file in my computer.And hide the secret when I start to do the code.

```
 <appSettings file="..\..\..\..\AppSettings.config">
```
Then I consider that how to get API in my controller.
```
 public JsonResult Sticker(string id)
        {
           
            string apiKey = System.Web.Configuration.WebConfigurationManager.AppSettings["APIKEY"];



            string url = "https://api.giphy.com/v1/stickers/translate?api_key=" + apiKey + "&s=" + id;

            Debug.WriteLine(url);


            WebRequest request = WebRequest.Create(url);
            WebResponse getResponce = request.GetResponse();
```
### Code
Log the IPaddress and clent type of the user, I use the Request. to complete it.
```

            LogData item = new LogData();
            item.IPAddress = Request.UserHostAddress;
            item.Request = id;
            item.ClientBrowser = Request.UserAgent;
            db.Log.Add(item);
            db.SaveChanges();
```
Return Json
```

            Stream giphyStream = WebRequest.Create(url).GetResponse().GetResponseStream();


            var giphyData = new System.Web.Script.Serialization.JavaScriptSerializer()
                                  .Deserialize<Object>(new StreamReader(giphyStream)
                                  .ReadToEnd());
             return Json(giphyData, JsonRequestBehavior.AllowGet);
        }
    }
```
Get the data that we want to output 
```
function ajaxFuc(data) {

    var source = "/Translator/Sticker/" + data;
    console.log(source);


    $.ajax({
        type: "GET",
        dataType: "json",
        url: source,
        success: displayData,
        error: errorOnAjax
    });
}


function displayData(giphyData) {

    var imageUrl = giphyData.data.images.original_still.url;

    $("#Image").append("<img src='" + imageUrl + "' style='width:80px;height:80px; margin:15px;'/>");
}
```

### Database Logging
Create the model to log required.
```
public class LogData
    {
       
        [Key]
        [Required]
        public int ID { get; set; }

   
        [Required]
        public String IPAddress { get; set; }

       
        [Required]
        public String Request { get; set; }

        
        [Required]
        public String ClientBrowser { get; set; }

        
        [Required]
        public DateTime AccessTime { get; set; } = DateTime.Now;
    }
}
```
Then it is the Context file.
```
 public class LogContext : DbContext
    {


        public LogContext() : base("name=Log")
        {

        }

        /// <summary>
        /// Tells you what you can do with the db whether to get information from it or set information in it. 
        /// </summary>
        public virtual DbSet<LogData> Log { get; set; }

    }
}
```
### Routing
Change my own custom routing in the Routing.config file.
```
public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Translate",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Translator", action = "Sticker", id = UrlParameter.Optional }
            );
```

Create a new view for the action.
```
<form>
    <div class="row">
        <div class="col-md-6">
            <input id="InputBox" name="Request" type="text" style="width:500px" class="input-sm" />
        </div>
        <div class="col-md-6">
            <button class="btn btn-default" onclick="return clear()" type="submit">Clear</button>
        </div>
    </div>

</form>

<div id="Image" class="row" />

@section JavaScripts
    {
    <script type="text/javascript" src="~/Scripts/AJAX.js"></script>
}
```
### The video link of this homework


 
