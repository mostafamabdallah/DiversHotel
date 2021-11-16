# Divers Hotel 🏩
## Task Description 📝
Divers Hotel is a 5 stars hotel having 150 rooms, those rooms are divided into 10 Room types (Sea View, Pool View, 
Garden View, Royal Suite, etc.) Each room has different price per night depending on the season and public holidays. 
The hotel offers its guests Three meal plans, Half Board, Full Board and All Inclusive. Each Meal plan has a different 
price Per Person Per Season, for example: Full Board Meal Plan costs 20 USD per night per person in the low season and 
30 USD per night per person in the high season.
Guests can chose the meal plan and room type when making reservation.
Your Task is:
1.  Create MS SQL Server Database that will capture the above requirements to store info about rooms, meal 
plans and their seasonal rates. (Please clarify column names, data types and column relations)
2.  Use Entity Framework or any other .Net based ORM of your choice to connect to the database
3. - Create a C# class that expose a single method named “GetReservationTotal” to take the following 
parameters:
(check-in date, check-out date, number of guests, room type, Meal plan)
And returns as output the total price for reservation.
4. - Create a single web page with a user-friendly interface to capture user reservation parameters input and 
return the reservation total amount. User interface should accept the below user input:
5.  Name, Email, Country, Adults, Children, Room Type, Meal Plan, Check-in and Checkout dates
Please assume the following:
6.  All Room Types can accommodate up to 2 adults and two children only.
7.  We should be able to add more room types and update rate intervals and prices without changing the Database 
Schema or the GetReservationTotal function implementation.
8.  Meal plan rates are per person. Children and Adults have the same rate.
9.  We should be able to modify/add/remove meal plans and their prices anytime without code changing

## Framework used 💁‍♂️

ASP.NET MVC core 5.

## Server-side packages 💾

1. Microsoft Entity Framework core 5.0.1.
2. Microsoft Entity Framework core SQL Server 5.0.1.
3. Microsoft Entity Framework core Tools 5.0.1.

## Client-side packages 💻

1. BootStrap.
2. JQuery.
3. Font-Awesome
4. Google Fonts.

## External APIS 📅

1. https://restcountries.com/v3.1/all  for getting countries data.

## before running.
1. Make sure to connect to your database server.
2. In PMC "package maneger console" type "add-migration" then "update-database".
3. Enjoy 😊.
## Project Steps

## 1. Server-Side
1. Create Project model.
    1. MealPlans Model 
    ```c#
        public class MealPlans
            {
                [System.ComponentModel.DataAnnotations.Key]
                public int Id { get; set; }
                public string mealPlans { get; set; }
                public int ratePerPerson_low_season { get; set; }
                public int ratePerPerson_high_season { get; set; }
            }
    ```
    2. RoomType Model 
    ```c#
        public class RoomType
            {
                [System.ComponentModel.DataAnnotations.Key]
                public int Id { get; set; }
                public string roomType { get; set; }
                public int ratePerPreson { get; set; }
            }
    ```
    3. Resrvation Model 

     ```c#
         public class Reservation
            {
                [System.ComponentModel.DataAnnotations.Key]
                public int Id { get; set; }
                public string name { get; set; }
                public string email { get; set; }
                public string country { get; set; }
                public int  no_adult { get; set; }
                public int no_children { get; set; }
                public int room_type_id { get; set; }
                public int meal_plan_id { get; set; }
                public DateTime checkin_date { get; set; }
                public DateTime checkout_date { get; set; }
            }
    ```
2. Create Database connection 
    In appsettings.json file we put our ConnectionStrings We set the server and database.

        ```json
         "ConnectionStrings": {
            "DefaultConnection": "Server=DESKTOP-C6P48T7;Database=DiversHotel;Trusted_Connection=True;MultipleActiveResultSets=True"
            },
         ```

3. Install Server-Side packages from NuGet package manger
    1. Microsoft Entity Framework core 5.0.1.
    2. Microsoft Entity Framework core SQL Server 5.0.1.
    3. Microsoft Entity Framework core Tools 5.0.1.

4. Create new class for our application database context and DbSet for every Model.

     ```c#
         public class ApplicationDBContext :DbContext
            {
                public ApplicationDBContext()
                {
                }

                public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) :base(options)
                {

                }
                public DbSet<MealPlans> MealPlans { get; set; }
                public DbSet<RoomType> RoomType { get; set; }
                public DbSet<Reservation> Reservation { get; set; }
            }
    ```

5. Make the application use the database context when application start, at startup.cs file :

    ```c#
        public void ConfigureServices(IServiceCollection services)
            {
                services.AddDbContext<ApplicationDBContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
                );
                services.AddControllersWithViews();
            }
    ```

6. Add migration (in package manger console type "add-migration" then "update-database")

7. Create Controller for every Model.
    1. For Room,Meal Models We created Room and Meal Controller and inside every controller We created (Update,Delete,Create) action.
     ```c#
         public class MealController : Controller
    {
        private readonly ApplicationDBContext _db;
        public MealController(ApplicationDBContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<MealPlans> objList = _db.MealPlans;
            return View(objList);
        }
        // GET Create
        public IActionResult Create()
        {
            return View();
        }
        //POST Create
        [HttpPost]
        public IActionResult Create(MealPlans obj)
        {
            _db.MealPlans.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        //GET Delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.MealPlans.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        //POST Delete
        [HttpPost]
        public IActionResult DeletePost(int? Id)
        {
            var obj = _db.MealPlans.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.MealPlans.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        //GET Update
        public IActionResult Update(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.MealPlans.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        //POST Update
        [HttpPost]
        public IActionResult Update(MealPlans obj)
        {
            _db.MealPlans.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public string getData()
        {
            var data = _db.MealPlans;
            var jsondata = JsonConvert.SerializeObject(data);
            return jsondata;
        }
    }
    ```

    8. Create 'GetReservationTotal()' that calculate the total amount of money.

        ```c#
            public ActionResult GetReservationTotal(Reservation obj)
                {
                    DateTime checkin = obj.checkin_date;
                    DateTime checkout = obj.checkout_date;
                    int no_of_days = (int)(checkout - checkin).TotalDays;
                    int no_persons = obj.no_adult + obj.no_children;
                    int meal_id = obj.meal_plan_id;
                    int room_id = obj.room_type_id;
                    float mealPrice;
                    if (checkin.Month > 5 && checkout.Month > 5)
                    {
                        mealPrice = _db.MealPlans.Find(meal_id).ratePerPerson_high_season;
                    }
                    else if (checkin.Month <= 5 && checkout.Month <= 5)
                    {
                        mealPrice = _db.MealPlans.Find(meal_id).ratePerPerson_low_season;
                    }
                    else
                    {
                        mealPrice = _db.MealPlans.Find(meal_id).ratePerPerson_high_season;
                    }
                    float roomPrice = _db.RoomType.Find(room_id).ratePerPreson;
                    float singleDayPrice = mealPrice + roomPrice;
                    float totalPrice = singleDayPrice * no_of_days * no_persons;
                    _db.Reservation.Add(obj);
                    _db.SaveChanges();
                    return View((object)totalPrice);
                }
         ```

    ## 2. Client-Side 
   1. Create View for every GET Controller action.
        looping throught the Model to create page content.
       ```c#
            @model IEnumerable<DiversHotel.Models.MealPlans>

            <div class="container">
            <div class="row justify-content-start mt-3">
                <a class="btn btn-danger col-3 col-sm-3 col-md-3 col-lg-2 col-xl-1" asp-area="" asp-controller="Admin" asp-action="Index">Back</a>
            </div>
            <h1 class="col-12" style="text-align:center;">Meal Plans</h1>
            <div class="row justify-content-center">
                <a class="btn btn-success col-6 col-sm-6 col-md-4 col-lg-3 col-xl-3" asp-area="" asp-controller="Meal" asp-action="Create">Create New Meal Plan</a>
            </div>
            <table class="table mt-4">
                <thead>
                    <tr>
                        <th scope="col">Meal plans</th>
                        <th scope="col">Low Season Rate Per Person</th>
                        <th scope="col">High Season Rate Per Person</th>
                        <th scope="col">Update</th>
                        <th scope="col">Delete</th>
                    </tr>
                </thead>
                <tbody>
                    @if (Model.Count() > 0)
                    {
                        @foreach (var meal in Model)
                        {
                    <tr>
                        <td>@meal.mealPlans</td>
                        <td>@meal.ratePerPerson_low_season</td>
                        <td>@meal.ratePerPerson_high_season</td>
                        <td><a class="btn btn-info col-12 col-sm-12 col-md-12 col-lg-12 col-xl-8" asp-area="" asp-controller="Meal" asp-route-Id="@meal.Id" asp-action="Update">Update</a></td>
                        <td><a class="btn btn-danger col-12 col-sm-12 col-md-12 col-lg-12 col-xl-8" asp-area="" asp-controller="Meal" asp-route-Id="@meal.Id" asp-action="Delete">Delete</a></td>
                    </tr>
                        }
                    }
                    else
                    {
                        <tr>
                            <td colspan="4" style="text-align:center;">No items created yet</td>
                        </tr>
                    }
                </tbody>
            </table>
            </div>
        ```

   2. In Home view create script to get Room types and meal plans and Countries data , also make some validation for reservation form.
        ```js
            const updateMealUI = async () => {
            const resposne = await fetch("/Meal/getData");
            try {
                const data = await resposne.json();
                if (data.length > 0) {
                    for (item of data) {
                        $('#mealPlane').append(`<option  value ="${item.Id}">${item.mealPlans}</option>`);
                    }
                } else {
                    $('#mealPlane').append(`<option>No Meal Plans Found</option>`);
                }

            } catch (error) {
                console.log("error:", error);
            }
        };
        const updateRoomUI = async () => {
            const resposne = await fetch("/Room/getData");
            try {
                const data = await resposne.json();
                if (data.length > 0) {
                    for (item of data) {
                        $('#roomType').append(`<option  value ="${item.Id}">${item.roomType}</option>`);
                    }
                } else {
                    $('#roomType').append(`<option>No Room Type Found</option>`);
                }

            } catch (error) {
                console.log("error:", error);
            }
        };
        const getCountries = async () => {
            const resposne = await fetch("https://restcountries.com/v3.1/all");
            try {
                const countries = await resposne.json();
                let countriesArrray = []
                if (countries.length > 0) {
                    for (country of countries) {
                        countriesArrray.push(country.name.common);
                    }
                    countriesArrray = countriesArrray.sort()
                    for (country of countriesArrray) {
                        $('#country').append(`<option  value ="${country}">${country}</option>`);
                    }
                } else {
                    $('#country').append(`<option>No Country Found</option>`);
                }

            } catch (error) {
                console.log("error:", error);
            }
        };
        const validation = () => {
            $('#from').on('change', function () {
                $('#to').attr('min', $(this).val())
            });

            $('#to').on('change', function () {
                $('#from').attr('max', $(this).val())
            });

            $('#adult , #child').on('keyup', function () {
                if ($(this).val() > 2 || $(this).val() < 0) {
                    $(this).val(2)
                    $('.redmes').show();
                } else {
                    $('.redmes').hide();
                }
            })
        }
        updateMealUI();
        updateRoomUI();
        getCountries();
        validation();
        ```


        ## Thank You ❤
