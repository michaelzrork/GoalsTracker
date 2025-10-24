# GoalsTracker

**Full-stack performance tracking application built to solve a team pain point.**

<div align="center">

<img width="800" alt="GoalsTracker Main View" src="https://github.com/user-attachments/assets/53751a67-2c04-49f8-98ed-0581edf7a192" />

*Real-time goal tracking with dynamic calculations and historical data preservation*

</div>

---

## The Problem

My support team at Vermont Systems tracked performance goals using an Excel spreadsheet. Every version update required manual data migration, causing:
- ❌ Lost historical data
- ❌ Data migration errors  
- ❌ Hours wasted on repetitive transfers
- ❌ Risk of formula breakage with each update

## The Solution

Built a persistent web application that eliminates manual migrations while maintaining all Excel functionality—plus real-time calculations, historical tracking, and a cleaner interface.

<div align="center">

<img width="800" alt="Cases Closed View" src="https://github.com/user-attachments/assets/3f12cb73-be43-4bae-85f4-d270b73b6163" />

*Track cases closed by quarter or custom date range with automatic average calculations*

</div>

---

## Key Features

### Core Functionality
- **Daily Entry Tracking** - Log hours worked and cases closed with timestamps
- **Flexible Date Ranges** - View by quarter or custom date range
- **Dynamic Calculations** - Real-time averages based on actual work days
- **CRUD Operations** - Create, view, edit, and delete entries with confirmation
- **Historical Data** - Preserves all data across application updates
- **Responsive UI** - Clean, mobile-friendly Razor Pages interface

### Technical Highlights
- **Persistent Storage** - SQLite database with automatic initialization
- **Entity Framework Core** - Type-safe data access and migrations
- **Input Validation** - Business logic enforcement and error handling
- **Production-Ready** - Built with data integrity and reliability from day one

<div align="center">

<img width="800" alt="Edit Entry View" src="https://github.com/user-attachments/assets/9ed0a73f-7102-4d03-8ac5-744fd7a76deb" />

*Edit existing entries with validation and confirmation*

</div>

---

## Tech Stack

- **Backend:** C# / ASP.NET Core 6.0+
- **Frontend:** Razor Pages / Bootstrap
- **Database:** SQLite with Entity Framework Core
- **Hosting:** IIS-ready, Docker-compatible

---

## Running Locally

### Prerequisites
- .NET 6.0 SDK or later
- Visual Studio 2022 (recommended) or VS Code

### Quick Start
```bash
# Clone the repository
git clone https://github.com/michaelzrork/GoalsTracker.git
cd GoalsTracker

# Restore dependencies
dotnet restore

# Run the application
dotnet run
```

Navigate to `https://localhost:5001` (or the URL shown in terminal)

### Database Initialization
The application automatically creates and seeds the SQLite database (`GoalsTracker.db`) on first run. No manual setup required.

**Database Schema:**
- **TimeEntries** - Date, hours worked, cases closed
- **Goals** - Quarterly targets and tracking settings
- **Users** - (Planned feature)

---

## Project Evolution

This project started as a direct Excel replacement and is evolving to demonstrate modern web development practices:

**✅ Completed:**
- Core CRUD functionality with SQLite
- Date range filtering and quarterly views
- Work day-based average calculations
- Edit/delete with confirmation dialogs

**🚧 In Progress:**
- Docker containerization for consistent deployment
- CI/CD pipeline with GitHub Actions
- Unit tests with xUnit

**📋 Planned Features:**
- Daily goal tracking with progress indicators
- Weekly and quarterly average breakdowns
- Visualizations showing goal progress
- Dynamic calculations: "X cases/day needed to hit quarterly goal"
- Days off tracking (exclude from goal calculations)
- Net work day counts in selected periods

**🎯 Stretch Goals:**
- User authentication and multi-user support
- Integration with Dynamics 365 (pull case data automatically)
- OAuth login support
- Export to Excel/PDF

---

<div align="center">

<img width="800" alt="Delete Confirmation" src="https://github.com/user-attachments/assets/789f959a-6045-4fb4-ae5e-03a229c71901" />

*Delete confirmation prevents accidental data loss*

</div>

---

## Why This Project Matters

Beyond demonstrating technical skills, this project shows:
- **Problem Identification** - Recognized team inefficiency and pain point
- **Practical Solution Design** - Built exactly what was needed, no feature bloat
- **User Empathy** - Maintained familiar workflow while improving it
- **Production Mindset** - Data integrity and reliability from day one

Built because I saw a problem. Deployed because it worked. Maintained because people used it.

---

## Contact

**Michael Rork**  
michaelzrork@gmail.com  
[LinkedIn](https://linkedin.com/in/michaelzrork) • [GitHub](https://github.com/michaelzrork)

---

<div align="center">

*Built with C# and determination to solve real problems.*

</div>
