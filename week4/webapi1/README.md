"# WebAPI1 Folder" 
# 📌 Week 4 – WebAPI1 Assignment

This folder contains the implementation of a simple RESTful Web API using **ASP.NET Core**, developed as part of the **Cognizant Digital Nurture 4.0 – .NET FSE** training program.

---

## ✅ Objectives

- ✔️ Understand REST architecture and Web API concepts
- ✔️ Create a Web API using ASP.NET Core
- ✔️ Implement CRUD operations with action verbs (GET, POST, PUT, DELETE)
- ✔️ Configure and use **Swagger** for API documentation and testing
- ✔️ Test APIs using **Postman**
- ✔️ Use appropriate HTTP status codes and request/response handling

---

## 🧾 Folder Structure

week4/
└── webapi1/
├── Controllers/ # Contains ValuesController.cs
├── output/ # Contains screenshots of output
├── Program.cs
├── appsettings.json
├── appsettings.Development.json
├── MyFirstWebAPI.csproj
├── MyFirstWebAPI.http
└── README.md # This file


---

## 🚀 How to Run the Project

1. Open the project in **Visual Studio**.
2. Press `Ctrl + F5` or click **Start Without Debugging**.
3. The project will launch Swagger at:
https://localhost:[port]/swagger

4. Use Swagger to test API endpoints:
- `GET /api/values`
- `GET /api/values/{id}`
- `POST /api/values`
- `PUT /api/values/{id}`
- `DELETE /api/values/{id}`

---

## 🔧 Technologies Used

- ASP.NET Core Web API
- C#
- Swagger (Swashbuckle)
- Visual Studio 2022
