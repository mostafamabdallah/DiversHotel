# Project name

Divers Hotel

## Task Description
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

## Framework used

ASP.NET MVC core 5.

## Server-side packages

1. Microsoft Entity Framework core 5.0.1.
2. Microsoft Entity Framework core SQL Server 5.0.1.
3. Microsoft Entity Framework core Tools 5.0.1.

## Client-side packages

1. BootStrap.
2. JQuery.
3. Font-Awesome
4. Google Fonts.

## External APIS

1. https://restcountries.com/v3.1/all  for getting countries data.

## Project Steps
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