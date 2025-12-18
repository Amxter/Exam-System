# Online Exam System (WinForms)

## Overview
Online Exam System is a desktop application built with **C# .NET WinForms** and **SQL Server**.  
It allows instructors to create and manage exams, while students can log in, take exams within a defined schedule, and view their results with full review details.

---

## Features

### Instructor Features
- **Create Exams**
  - Create exams for a specific **Class** and **Section**
  - Set exam **date**, **open time**, **close time**, and **duration**
  - Configure exam settings such as:
    - Show result after submission
    - Allow exam review after submission
- **Manage Questions**
  - Add questions to an exam
  - Support multiple question types (e.g., Multiple Choice, True/False, Short Answer)
  - Set question marks and optional image attachments
  - Add choices for MCQ questions and mark correct answers
- **Monitoring & Reports**
  - View how many students took the exam
  - View students' marks and exam statistics
  - See **average**, **min/max**, and overall performance
  - View each student attempt details:
    - Answers for each question
    - Correct/incorrect status

### Student Features
- **Authentication**
  - Student login using username/password
- **Exam Access**
  - View available exams assigned to their class/section
  - Start an exam only during the allowed time window
- **Taking the Exam**
  - Answer questions and submit the exam
  - Timer-based duration control
- **Results & Review**
  - View final mark after submission (if enabled)
  - Review the exam (if enabled):
    - See each question
    - See student answer
    - See correct answer
    - See whether the answer was correct or incorrect

---

## Tech Stack
- **Frontend (Desktop UI):** C# .NET WinForms  
- **Backend / Data Layer:** SQL Server  
- **Database Design:** Relational model (ERD → relational mapping), normalization where needed

---

## Database (High Level)
Core entities include:
- People (Students, Instructors)
- Departments, Classes, Sections
- Exams, Questions, Choices
- Exam Appointments (schedule & duration)
- Student Attempts (who took the exam and when)
- Student Answers (answers per question per attempt)

> Note: The database schema is designed to support exam scheduling, multiple question types, attempt tracking, and full exam review.

---

## Project Structure (Suggested)
- `WinFormsApp/` → UI Forms and controls
- `DataAccess/` → DB connection, repositories, queries (ADO.NET)
- `Models/` → Entities / DTOs
- `Scripts/` → SQL scripts (create tables, constraints, sample data)
- `Docs/` → ERD, diagrams, notes

---

## Setup Instructions

### Requirements
- Windows
- Visual Studio 2022+
- .NET (your target version)
- SQL Server (Express/Developer) + SSMS

### Steps
1. Clone the repository:
   ```bash
   git clone <REPO_URL>
