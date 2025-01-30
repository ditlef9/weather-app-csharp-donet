# Weather App Csharp Donet (Console Application) 

This is a simple console-based weather application built in C# using .NET. The application fetches real-time weather data from the OpenWeatherMap API and displays essential weather details like temperature, humidity, and conditions for a given city.

The goal of this project is to demonstrate how to consume external APIs in a .NET console application, handle JSON responses, and work with asynchronous programming in C#.

---

## Index

[🏠 1 How to run locally](#1-how-to-run-locally)<br>
[☁️ 2 How to deploy to Azure](#2-how-to-deploy-to-azure)<br>
[🛠️ 3 How I created the app](#3-how-i-created-the-app)<br>
[📜 4 License](#4-license)<br>

---

## 🏠 1 How to run locally

### Prerequisites
- .NET SDK installed ([Download here](https://dotnet.microsoft.com/download))
- API Key from [OpenWeatherMap](https://openweathermap.org/api)

### Steps
1. Clone this repository:
   ```bash
   git clone https://github.com/ditlef9/weather-app-csharp-donet.git
   cd weather-app-csharp-donet
   ```
2. Install dependencies (if any):
   ```bash
   dotnet restore
   ```
3. Add your API Key in `Program.cs`:
   ```csharp
   string apiKey = "your_api_key_here";
   ```
4. Run the application:
   ```bash
   dotnet run
   ```
5. Enter a city name when prompted to fetch and display weather data.

---

## ☁️ 2 How to deploy to Azure

### Steps to deploy to Azure App Service
1. Ensure you have the Azure CLI installed ([Download here](https://learn.microsoft.com/en-us/cli/azure/install-azure-cli)).
2. Login to Azure:
   ```bash
   az login
   ```
3. Create an Azure Web App:
   ```bash
   az webapp create --resource-group MyResourceGroup --plan MyPlan --name WeatherAppCSharp --runtime "DOTNETCORE:7.0"
   ```
4. Publish the app:
   ```bash
   dotnet publish -c Release -o ./publish
   az webapp deploy --resource-group MyResourceGroup --name WeatherAppCSharp --src-path ./publish
   ```
5. Visit your deployed application via the Azure-provided URL.

---

## 🛠️ 3 How I created the app

New console app:
```
dotnet new console -n WeatherApp
```

Added `HttpClient` to call the OpenWeatherMap API, parsed JSON responses using `System.Text.Json`, and formatted the output to display weather details in the console.

---

## 📜 4 License

This project is licensed under the
[Apache License 2.0](https://www.apache.org/licenses/LICENSE-2.0).

```
Copyright 2024 github.com/ditlef9

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0
```