# Asana-Style Productivity App

## Overview
This project is a full-stack productivity application inspired by tools like Asana. It was built using C# and the .NET ecosystem to demonstrate backend development, application architecture, and multi-interface design.

The system is composed of multiple projects that work together, including a REST API, shared library, CLI tool, and a MAUI-based frontend.

## Architecture
The solution is divided into several components:

- **Asana2.API**  
  RESTful API that handles core application logic, data processing, and endpoints.

- **Asana2.Library**  
  Shared codebase containing models, business logic, and reusable components used across all projects.

- **Asana2.CLI**  
  Command-line interface for interacting with the system without a graphical UI.

- **Asana2.Maui**  
  Cross-platform frontend built with .NET MAUI.

## Features
- Task and project management system
- Modular architecture with separation of concerns
- Reusable shared library across multiple applications
- REST API for handling requests and data operations
- Multiple interfaces (CLI and GUI)

## Tech Stack
- C#
- .NET
- ASP.NET Web API
- .NET MAUI
- CLI (Command Line Interface)
- Visual Studio

## Purpose
This project was created to practice building a structured, multi-project application and to understand how different components of a full-stack system interact with each other.

## Key Takeaways
- Designing multi-project solutions in .NET
- Building and structuring REST APIs
- Managing dependencies between projects
- Separating business logic into reusable libraries
- Working with multiple application interfaces (CLI + GUI)

## How to Run

### Prerequisites
- Visual Studio with:
  - ASP.NET and web development workload
  - .NET MAUI workload
- .NET SDK installed

### Steps
1. Clone the repository
2. Open the `.sln` file in Visual Studio
3. Restore NuGet packages
4. Set `Asana2.API` as the startup project
5. Run the application

## Future Improvements
- Add authentication and user accounts
- Improve UI/UX in the MAUI frontend
- Add database integration
- Expand task management features

## Notes
This project demonstrates full-stack development concepts and application architecture using the .NET ecosystem.
