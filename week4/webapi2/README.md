# WebAPI2 – Assignment (Week 4)

## 📌 Objectives

- Understand and demonstrate the creation of a simple WebAPI using .NET Core.
- Perform CRUD operations using HTTP verbs (GET, POST, PUT, DELETE).
- Configure routing using attribute routing and test the API using Postman.
- Understand HTTP status codes returned by API endpoints.

---

## 🔧 Technologies Used

- .NET Core Web API
- C#
- Swagger (Swashbuckle.AspNetCore)
- Postman
- Visual Studio 2022

---

## 🔄 HTTP Verbs Implemented

| Verb    | Description                   | Route Example                    |
|---------|-------------------------------|----------------------------------|
| GET     | Get all items                 | `/api/Employee`                 |
| GET     | Get item by ID                | `/api/Employee/{id}`            |
| POST    | Create new item               | `/api/Employee`                 |
| PUT     | Update existing item by ID    | `/api/Employee/{id}`            |
| DELETE  | Delete item by ID             | `/api/Employee/{id}`            |

---

## 🛠 How to Run the Project

1. Open the project in **Visual Studio**.
2. Ensure NuGet packages (like `Swashbuckle.AspNetCore`) are installed.
3. Run the project using `Ctrl + F5`.
4. Navigate to `https://localhost:<port>/swagger` to test API via Swagger UI.

---

## 📬 Testing with Postman

- Import the endpoints manually or use Swagger's "Export to Postman" collection.
- Set proper headers like `Content-Type: application/json`.
- Use `GET`, `POST`, `PUT`, and `DELETE` methods to interact with endpoints.
- View response JSON and status codes in the Postman response panel.

---

## 📁 Project Structure

week4/
└── webapi2/
├── Controllers/
├── Program.cs
├── MyFirstWebAPI.http
├── *.json
├── *.csproj
└── output/
└── (Screenshots of Swagger & Postman testing)


---

## ✅ Output Preview

- Screenshots of:
  - Swagger UI
  - Postman Testing for all HTTP methods (GET, POST, PUT, DELETE)

(Refer to `output/` folder)

---

## 🧠 Key Learnings

- Creating and consuming RESTful Web APIs.
- Swagger integration for API documentation and testing.
- Postman usage for API testing.
- Routing, controller setup, and dependency configuration in .NET Core.

---

> 🔄 This assignment demonstrates foundational skills in building and testing RESTful APIs using .NET Core.

