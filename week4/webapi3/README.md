# WebAPI3 - ASP.NET Core Web API with Custom Filters

## 📌 Overview

This project demonstrates key Web API features using ASP.NET Core, including:

- Returning a list of `Employee` objects via GET
- Handling POST requests using `[FromBody]`
- Implementing custom filters:
  - **Authorization Filter** using `CustomAuthFilter`
  - **Exception Filter** using `CustomExceptionFilter`

---

## 📁 Project Structure

- **Controllers/**
  - `EmployeeController.cs` — Handles GET and POST requests for employees
- **Models/**
  - `Employee.cs`, `Department.cs`, `Skill.cs` — Domain classes
- **Filters/**
  - `CustomAuthFilter.cs` — Validates `Authorization` header
  - `CustomExceptionFilter.cs` — Catches exceptions and logs them to a file
- **Program.cs** — Configures services and middleware

---

## ✅ Features Implemented

### 1. GET /api/Employee
- Returns a hardcoded list of employees
- `[AllowAnonymous]` attribute is used
- Custom exception is thrown to trigger `CustomExceptionFilter`

### 2. POST /api/Employee
- Accepts JSON body and deserializes it using `[FromBody]`
- Adds employee to the existing list (in-memory)

### 3. Authorization Filter
- Ensures `Authorization` header is present
- Must include the word `Bearer`
- Otherwise, returns:
  - `400 Invalid request - No Auth token`
  - `400 Invalid request - Token present but Bearer unavailable`

### 4. Exception Filter
- Catches any unhandled exception
- Logs the exception message into a file on the system
- Returns `500 Internal Server Error`

---

## 🚀 How to Run

1. Open in Visual Studio or use `dotnet run` in the terminal
2. Navigate to: `https://localhost:<port>/swagger`
3. Use Swagger UI to test `GET` and `POST` endpoints

### 🛑 Note:
To test successfully:
- Add header: `Authorization: Bearer <any_token>`

---

## 📂 Output Folder

- `/Output` directory included to store logs or results if needed.

---

## 📚 Technologies Used

- ASP.NET Core 6 Web API
- Swagger (Swashbuckle)
- Action Filters
- Exception Handling

---



