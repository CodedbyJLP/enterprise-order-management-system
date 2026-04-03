# enterprise-order-management-system
Microservices-based Order Management System using .NET, Docker, and Azure.



# 🏢 Enterprise Order Management System (OMS)

A **cloud-native microservices-based Order Management System** built using **.NET, Docker, and Azure**, designed to simulate real-world enterprise e-commerce platforms.

---

## 🚀 Overview

This project demonstrates the design and implementation of a **scalable backend system** similar to platforms like Amazon, focusing on:

* Microservices architecture
* Clean Architecture principles
* Cloud deployment on Azure
* CI/CD automation
* Containerisation using Docker

---

## 🧱 Architecture

The system is built using **Microservices Architecture**, where each service is independently developed, deployed, and scaled.

### 🔹 Services:

* **Identity Service** → Authentication & user management
* **Product Service** → Product catalog & inventory
* **Order Service** → Order processing & lifecycle

### 🔹 API Gateway:

* Central entry point using YARP

### 🔹 Communication:

* REST APIs (synchronous)
* Event-driven (RabbitMQ - optional)

---

## 🛠️ Tech Stack

### Backend:

* ASP.NET Core Web API
* Entity Framework Core

### Architecture:

* Clean Architecture
* Repository Pattern
* Dependency Injection

### DevOps:

* Docker & Docker Compose
* CI/CD using Azure DevOps

### Cloud:

* Azure App Service
* Azure SQL Database

### Security:

* JWT Authentication
* Role-based Authorization

---

## 🔐 Features

* User registration & login (JWT-based authentication)
* Role-based access (Admin, Customer)
* Product management (CRUD operations)
* Order creation and tracking
* Order status lifecycle (Created → Paid → Shipped → Delivered)
* Payment simulation
* Inventory management

---

## 🐳 Running the Project (Docker)

### Prerequisites:

* Docker installed

### Run:

```bash
docker-compose up --build
```

---

## ☁️ Deployment

The application is deployed on Azure:

* App Services for hosting APIs
* Azure SQL Database for persistence

---

## 🔄 CI/CD Pipeline

Implemented using Azure DevOps:

* Build automation
* Docker image creation
* Deployment to Azure

---

## 📁 Project Structure

```
/src
  /services
    /identity-service
    /product-service
    /order-service
  /gateway
/docker
/docs
README.md
```

---

## 📊 Future Enhancements

* API Gateway authentication
* Redis caching
* Advanced monitoring
* Integration with Azure Service Bus

---

## 💬 Key Highlights

* Designed a **microservices-based system** using Clean Architecture
* Implemented **secure APIs using JWT authentication**
* Containerised services using Docker
* Deployed to Azure with CI/CD pipelines

---

## 👩‍💻 Author

Lakshmi Jasti
.NET Developer | 5+ Years Experience

---
