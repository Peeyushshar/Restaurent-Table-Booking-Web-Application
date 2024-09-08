# Restaurant Table Booking Web Application

The Restaurant Table Booking Web Application is designed to provide a seamless table booking experience for customers and efficient reservation management for restaurant staff. Built using ASP.NET Core Web API with Clean Architecture, it leverages Entity Framework Core for data management and ensures a maintainable, scalable codebase.

## Features

 1. Table Booking: Customers can book tables online, specifying the date, time, and number of guests.
 2. Reservation Management: Restaurants can manage and update bookings, track reservations, and handle cancellations.
 3. Clean Architecture: The application is built following Clean Architecture principles, ensuring separation of concerns and a modular structure.
 4. Entity Framework Core: Utilizes EF Core for database operations, providing an efficient and robust data management system.

## Technologies Used

 1. ASP.NET Core Web API: Backend framework for building RESTful services.
 2. Entity Framework Core: ORM for database management.
 3. Clean Architecture: Architectural pattern for organizing code.
 4. SQL Server: Database used for storing reservation data.

## Setup Instructions

 1. Clone the Repository:
    
     git clone https://github.com/yourusername/restaurant-table-booking.git

 2. Navigate to the Project Directory:

    cd restaurant-table-booking

 3. Update the Database Connection String:

    1.  Open appsettings.json.
    2.  Update the ConnectionStrings section with your SQL Server connection details.

 4. Run Database Migrations:

     dotnet ef database update

 5. Build and Run the Application

    dotnet run

## Usage

  a. Access the API endpoints via tools like Postman or directly from your front-end application.
  b. Integrate with a front-end for user-facing booking interfaces.
