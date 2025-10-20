# Goals Tracker

Goals Tracker is a way for support staff to track the number of hours they've worked or how many cases they've closed with in-depth analysis of their progress toward hitting their goals.

## Screenshots

### Home Screen
<img width="800" alt="Home" src="https://github.com/user-attachments/assets/53751a67-2c04-49f8-98ed-0581edf7a192" />

### Cases Closed
<img width="800" alt="Cases_Closed" src="https://github.com/user-attachments/assets/3f12cb73-be43-4bae-85f4-d270b73b6163" />

*[View more screenshots](#additional-screenshots)*

## Setup & Installation

1. **Prerequisites:** .NET 6.0 or later
2. **Clone the repository:** `git clone https://github.com/michaelzrork/GoalsTracker.git`
3. **Run the application:** `dotnet run`
4. **Database:** SQLite database (`GoalsTracker.db`) will be created automatically on first run

### Database Schema
The app automatically creates tables for:
- **TimeEntries:** Date, hours worked, cases closed
- **Goals:** Quarterly targets and tracking settings
- **Users:** (Future feature)

## Current Features
- Enter daily time worked and cases closed
- Edit and delete time/case entries
- View cases closed by quarter or custom date range
- Calculate averages based on work days

## Planned Features
- Daily goal tracking
- Averages broken down per week and quarter
- Visualizations to show close you are to your goal
- Calculations to show how many hours/cases you need per day to hit your goal by the end of the quarter
- User logins
- Ability to add days off to exclude those days from your goals
- Net work day counts in the selected time period

## Stretch Goals
- Integration with MS products to pull case and time entries from Dynamics
- Login with OAuth

## Additional Screenshots
### Edit Entry
<img width="800" alt="Case_Entry_Edit" src="https://github.com/user-attachments/assets/9ed0a73f-7102-4d03-8ac5-744fd7a76deb" />

### Delete Entry Confirmation
<img width="800" alt="Delete_Confirmation" src="https://github.com/user-attachments/assets/789f959a-6045-4fb4-ae5e-03a229c71901" />



# Screenshots

