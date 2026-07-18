# EcommerceAPI

A full-featured RESTful API for an e-commerce platform built with ASP.NET Core 10 and .NET 10.

## 🚀 Technologies Used

- **ASP.NET Core 10** & **.NET 10**
- **Entity Framework Core 10** with SQL Server
- **ASP.NET Identity** for user management
- **JWT Authentication** for secure access
- **Swagger / OpenAPI** for API documentation

## ✨ Features

- 🔐 JWT Authentication & Role-based Authorization (Admin / Customer)
- 📦 Products CRUD with Pagination
- 🗂️ Categories CRUD
- 🛒 Order System with stock management
- ✅ Input Validation
- ⚠️ Global Error Handling
- 📄 Swagger UI

## 📁 Project Structure

EcommerceAPI/
├── Controllers/ → API Endpoints
├── Services/ → Business Logic
├── Models/ → Database Entities
├── DTOs/ → Data Transfer Objects
├── Data/ → DbContext
├── Helpers/ → Pagination & ApiResponse
├── Middleware/ → Global Error Handling
├── Extensions/ → Extension Methods
├── Constants/ → Roles
└── Exceptions/ → Custom Exceptions





## 🔑 API Endpoints

### Auth

| Method | Endpoint | Description |

|--------|----------|-------------|

| POST | /api/auth/register | Register new user |

| POST | /api/auth/login | Login & get token |

### Products

| Method | Endpoint | Description | Role |

|--------|----------|-------------|------|

| GET | /api/products | Get all products | Public |

| GET | /api/products/{id} | Get product by id | Public |

| POST | /api/products | Create product | Admin |

| PUT | /api/products/{id} | Update product | Admin |

| DELETE | /api/products/{id} | Delete product | Admin |

### Categories

| Method | Endpoint | Description | Role |

|--------|----------|-------------|------|

| GET | /api/categories | Get all categories | Public |

| GET | /api/categories/{id} | Get category by id | Public |

| POST | /api/categories | Create category | Admin |

| PUT | /api/categories/{id} | Update category | Admin |

| DELETE | /api/categories/{id} | Delete category | Admin |

### Orders

| Method | Endpoint | Description | Role |

|--------|----------|-------------|------|

| POST | /api/orders | Create order | Customer |

| GET | /api/orders | Get user orders | Customer |

| GET | /api/orders/{id} | Get order by id | Customer |

| PUT | /api/orders/{id}/cancel | Cancel order | Customer |

| PUT | /api/orders/{id}/status | Update order status | Admin |

| GET | /api/orders/all | Get all orders | Admin |

## ⚙️ Setup

1. Clone the repository

2. Update connection string in `appsettings.json`

3. Run migrations:

dotnet ef database update

4. Run the project:
dotnet run

5. Open Swagger UI at `https://localhost:7064`