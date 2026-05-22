# FITBAI
# 🏋️ Fit BAI

> **A tactical fitness accountability platform that calculates biometrics, deploys targeted workout protocols, and tracks progression.**

Fit BAI is a comprehensive desktop application built with C# and .NET WinForms. It features a custom-built, modern UI (Gothic dark theme), dynamic form routing, and local data management via MS Access. The system adapts to user biometrics to recommend specific fitness protocols (e.g., Protocol Alpha for fat loss, Protocol Omega for muscle gain).

---

## 🚀 Features

- **Dynamic Form Routing:** A seamless Single-Page-Application-like experience using a central dashboard container (`usrMAINpage`) to load child forms without window clutter.
- **Biometric Initialization & Calibration:** Calculates Body Mass Index (BMI) and assigns actionable fitness directives based on user height, weight, and goals.
- **Role-Based Access Control (RBAC):** Distinct domains for standard Clients, Instructors, and Administrators.
- **Custom UI Rendering Engine:** Bespoke C# `Paint` events generating linear gradients, hatched panel backgrounds, and borderless window dragging (via `user32.dll`).
- **Tactical Data Management:** - Local, offline data storage using MS Access (`OleDbConnection`).
  - Tactical CSV Export for external progress analysis.
  - "Scorched Earth" account termination requests for data privacy.
- **Secure Authentication:** User passwords are encrypted using SHA256 hashing.

---

## 🛠️ Tech Stack

- **Language:** C#
- **Framework:** .NET WinForms
- **Database:** Microsoft Access (`.accdb`) via `OleDbConnection`
- **Cryptography:** `System.Security.Cryptography` (SHA256)
- **Native APIs:** `user32.dll` (Win32 API for UI manipulation)

---

## ⚙️ Installation & Setup

### Prerequisites
- Visual Studio 2022 (or later) with the **.NET Desktop Development** workload installed.
- Microsoft Access Database Engine (if required to read `.accdb` files).
- redirect/create a mediavault tab

### Running the Project
1. **Clone the repository:**
   ```bash
   git clone [https://github.com/Deo-Deadulus/FitBAI.git](https://github.com/yourusername/FitBAI.git)
