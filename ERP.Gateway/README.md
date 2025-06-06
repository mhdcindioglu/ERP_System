# ERP.Gateway

This is the API Gateway service for the ERP microservices architecture. It serves as the single entry point for all client requests and routes them to the appropriate backend services.

## Features

- **API Gateway**: Routes requests to appropriate microservices
- **Load Balancing**: Distributes requests across service instances
- **CORS Support**: Handles cross-origin requests
- **Health Checks**: Provides gateway health status
- **Request/Response Transformation**: Modifies requests and responses as needed

## Technology Stack

- **.NET 9**: Latest version of .NET framework
- **Ocelot**: API Gateway library for .NET
- **ASP.NET Core**: Web framework

## Configuration

The gateway is configured using `ocelot.json` file which defines:
- Route mappings
- Downstream services
- Load balancing strategies
- Authentication policies

## Getting Started

### Prerequisites
- .NET 9 SDK
- Visual Studio 2022 or VS Code

### Running the Application

```bash
dotnet run
```

The gateway will start on `https://localhost:5000` (HTTPS) and `http://localhost:5001` (HTTP).

### Health Check

Check gateway health status:
```
GET /gateway/health
```

## Next Steps

1. Add authentication and authorization
2. Configure rate limiting
3. Add service discovery
4. Implement request/response logging
5. Add circuit breaker patterns
