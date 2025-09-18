# Maintenance Request Portal

A full-stack maintenance request and tracking application built with **C# .NET** and **Angular**.  
This project simulates a real-world system for managing maintenance tasks in a facility, from the initial report to resolution.

## Demo

(To add your video: Create a `demo` folder in your project, save your GIF/video file there as `MaintenancePortal.gif`, and then push the changes to GitHub.)

![Demo](./demo/MaintenancePortal.gif)

## Features

- **User Authentication:** Secure user registration and login system.
- **Role-Based Access:** Different views and permissions for Operators and Technicians.
- **Asset Management:** Add and manage a list of serviceable assets.
- **Ticket Creation:** Logged-in users can create new maintenance tickets for specific assets.
- **Dynamic UI:** The user interface updates in real-time based on login status.

## Technologies Used

- **Backend:** C# with ASP.NET Core Web API  
- **Database:** Entity Framework Core with SQL Server  
- **Frontend:** Angular  
- **Styling:** Bootstrap  

## How to Run

1. **Backend:**  
   - Open the `.sln` file in the `/backend` folder with **Visual Studio 2022**.  
   - Run the project.  

2. **Frontend:**  
   - Navigate to the `/frontend/client` folder in your terminal.  
   - Run:  
     ```bash
     npm install
     ng serve
     ```  

