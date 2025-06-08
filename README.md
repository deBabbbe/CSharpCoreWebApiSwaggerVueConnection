[![.NET](https://github.com/deBabbbe/CSharpCoreWebApiSwaggerVueConnection/actions/workflows/dotnet.yml/badge.svg)](https://github.com/deBabbbe/CSharpCoreWebApiSwaggerVueConnection/actions/workflows/dotnet.yml)
[![Vue CI](https://github.com/deBabbbe/CSharpCoreWebApiSwaggerVueConnection/actions/workflows/vue.yml/badge.svg)](https://github.com/deBabbbe/CSharpCoreWebApiSwaggerVueConnection/actions/workflows/vue.yml)

[![.NET](https://github.com/deBabbbe/CSharpCoreWebApiSwaggerVueConnection/actions/workflows/dotnet.yml/badge.svg)](https://github.com/deBabbbe/CSharpCoreWebApiSwaggerVueConnection/actions/workflows/dotnet.yml)

This project demonstrates how to connect an ASP.NET Core Web API with a Vue.js frontend using OpenAPI/Swagger for type-safe API integration.

## Features

- ASP.NET Core Web API with Swagger/OpenAPI documentation
- Vue.js frontend with TypeScript
- Automated API client generation using OpenAPI Generator
- Type-safe API integration
- CORS configuration

## Prerequisites

- .NET 8.0 SDK
- Node.js (LTS version)
- npm

## Project Structure

```
├── WeatherApi/                 # Backend API project
│   ├── Controllers/           # API Controllers
│   └── Properties/            # Launch settings
├── weather-frontend/          # Vue.js frontend project
│   ├── src/
│   │   ├── components/       # Vue components
│   │   └── generated/api/    # Auto-generated API client
│   ├── openapi.config.json   # OpenAPI Generator config
│   └── package.json
└── README.md
```

## Setup & Running

### 1. Backend (ASP.NET Core Web API)

```bash
# Navigate to the API project
cd WeatherApi

# Run the API
dotnet run
```

The API will be available at:
- API Endpoint: http://localhost:5258
- Swagger UI: http://localhost:5258/swagger

### 2. Frontend (Vue.js)

```bash
# Navigate to the frontend project
cd weather-frontend

# Install dependencies
npm install

# Generate API client (make sure API is running)
npx @openapitools/openapi-generator-cli generate -i http://localhost:5258/swagger/v1/swagger.json -g typescript-axios -o src/generated/api --additional-properties=supportsES6=true,npmVersion=6.9.0,typescriptThreePlus=true

# Start development server
npm run dev
```

The frontend will be available at http://localhost:5173

## Development Workflow

### Updating the API Client

Whenever you make changes to the API (e.g., adding new endpoints, modifying models), you need to regenerate the API client:

1. Ensure the API is running (`cd WeatherApi && dotnet run`)
2. In a new terminal, run:
   ```bash
   cd weather-frontend
   npx @openapitools/openapi-generator-cli generate -i http://localhost:5258/swagger/v1/swagger.json -g typescript-axios -o src/generated/api --additional-properties=supportsES6=true,npmVersion=6.9.0,typescriptThreePlus=true
   ```

The generated client includes:
- TypeScript interfaces for all API models
- Type-safe API client methods
- Request/response type definitions

### Using the Generated API Client

```typescript
import { WeatherApi, Configuration, WeatherData } from '../generated/api'

// Create API client instance
const apiClient = new WeatherApi(
  new Configuration({
    basePath: 'http://localhost:5258',
  })
)

// Use type-safe API methods
const response = await apiClient.weatherGet()
const weatherData: WeatherData[] = response.data
```

## API Endpoints

The API provides the following endpoints:

- `GET /Weather` - Retrieve all weather data
- `POST /Weather` - Add new weather data

All API endpoints are documented in the Swagger UI (http://localhost:5258/swagger).
