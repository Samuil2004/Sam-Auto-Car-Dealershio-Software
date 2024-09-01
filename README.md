# Car Dealership Management System

## Overview

This project is a **full-stack car dealership management software** designed to streamline the operations of a car dealership, from managing inventory to facilitating sales and customer interactions. The application is built using **C#** (primarily), **JavaScript**, **CSS**, **HTML**, and **SQL**. The database is hosted on **SQL Server Management Studio**.

### Key Features

- **Desktop Application**:
  - Developed using **Windows Forms** in **.NET Core**.
  - **For Managers/CEOs**: Access advanced statistics and manage employees with full CRUD (Create, Read, Update, Delete) functionalities.
  - **For Employees**: 
    - Manage the dealership's vehicle inventory by adding, updating, removing, and deleting vehicles. Employees can also process vehicle sales and manage other vehicle-related tasks.
    - Access the **company archive** containing a record of all sales, providing valuable insights and historical data.
    - **Save Vehicles**: Employees can save a vehicle for purchase within the next three days, ensuring that no potential sale opportunities are missed.

- **Web Application**:
  - Developed using **ASP.NET Core Razor Pages**.
  - **For Customers**: 
    - Browse an extensive vehicle catalog, authenticate via login or sign-up, and make purchases. 
    - Customers can rate vehicles (out of 5 stars), mark vehicles as favorites, and receive personalized vehicle recommendations based on their favorited vehicles.

### Technical Details

- **Scalability**: The system's database is populated with over a thousand vehicle records, showcasing the software's ability to handle large datasets without performance degradation.
- **Security**: All sensitive data is securely stored and managed using a specialized hash encrypting algorithm, ensuring data integrity and security.
- **Search and Filter**: Both the desktop application and the website feature robust search and filtering capabilities, allowing users to quickly find vehicles or relevant data.
- **Recommendation Algorithm**: A custom recommendation algorithm suggests vehicles to logged-in customers based on their favorited items, enhancing the user experience.
- **Design Patterns**: The software implements the **Strategy Pattern**, enabling flexible and maintainable code by allowing dynamic behavior changes at runtime.
- **OOP & SOLID Principles**: The software is developed following Object-Oriented Programming (OOP) concepts and adheres to all SOLID principles, ensuring maintainable, scalable, and robust code.

### Documentation & Diagrams

The project includes extensive documentation to provide a comprehensive understanding of the software architecture and design:

- **SQL Diagram**: Located in the `Documents` folder, detailing the database design.
- **UML Class Diagram**: Also included in the `Documents` folder, illustrating the class structure and relationships.
- **User Requirements Specifications (URS)**: This document outlines all use cases that are part of the software.
- **Test Plan and Test Report**: These documents provide a detailed overview of the testing process, covering both successful and unsuccessful scenarios for each use case.

### Testing

Full software testing is integrated into the project in the form of **Unit Tests**. These tests ensure that each component of the software functions as expected, providing reliability and stability.

### Technologies Used

- **Frontend**: 
  - HTML, CSS, JavaScript
- **Backend**:
  - C# (with .NET Core Framework)
  - SQL Server Management Studio (SQL)
- **Web Application**:
  - ASP.NET Core Razor Pages
- **Desktop Application**:
  - Windows Forms (.NET Core)
- **Database**: 
  - SQL Server Management Studio
- **Security**:
  - Custom hash encrypting algorithm for secure data storage
- **Design Patterns**:
  - Strategy Pattern for dynamic behavior management
