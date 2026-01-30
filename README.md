# Trip Log

Trip Log is a web application built with the **.NET framework** that helps users plan trips. The application allows users to manage **destinations**, **accommodations**, **activities**, and **travel tips**, all of which are persisted in a database using a model-driven design. The UI is styled with **Bootstrap** for a clean and responsive experience.

---

## Features

- **Destinations**
  - Add, view, and manage trip destinations
- **Accommodations**
  - Track lodging details associated with a trip or destination
- **Activities**
  - Plan and log activities for each destination
- **Tips**
  - Save useful travel tips (food, packing, safety, local advice)

---

## Tech Stack

- **Framework:** ASP.NET Core (.NET 8)
- **ORM:** Entity Framework Core 8
- **Database:** SQL Server
- **Styling:** Bootstrap

---

## Data Models

The application stores trip data using the following models:

- `Trip`
- `Destination`
- `Accommodation`
- `Activity`
- `TripLogContext`
- `ErrorViewModel`
Each model represents a core part of the trip planning workflow and is stored in the database.

---

## Application Pages

1. **Destinations Page**
   - View and manage destinations
2. **Accommodations Page**
   - Add and manage lodging information
3. **Activities Page**
   - Track planned or completed activities
4. **Tips Page**
   - Add and view travel tips stored in the database

---

## Getting Started

### Prerequisites
- .NET 8 SDK
- SQL Server (or LocalDB / SQL Server Express)
- (Optional) EF Core CLI tools

### Installation

1. Clone the repository:
   ```bash
   git clone <https://github.com/josediaz99/tripLog.git>
   cd <tripLog>
2. Set connection string in appsetting.json
3. apply database migrations
   ```bash
   dotnet ef database update
4. Run Application:
   ```bash
   dotnet run
