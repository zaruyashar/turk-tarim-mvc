# 🌾 Türk Tarım - Enterprise Agriculture Management System (ASP.NET Core MVC)

![.NET Core](https://img.shields.io/badge/.NET%20Core-10.0-512BD4?style=flat-square&logo=dotnet)
![Entity Framework](https://img.shields.io/badge/Entity%20Framework-Core-339933?style=flat-square)
![Architecture](https://img.shields.io/badge/Architecture-N--Tier-FF5722?style=flat-square)
![Security](https://img.shields.io/badge/Focus-Secure%20Code-000000?style=flat-square&logo=security)

Türk Tarım (Turkish Agriculture) is a comprehensive Content Management System (CMS) and corporate promotional platform designed for modern agricultural enterprises, built on a robust **N-Tier Architecture**.

This project was initially inspired by Murat Yücedağ's *"Step-by-Step N-Tier Architecture with C#"* course. However, it goes far beyond the standard curriculum, heavily customized with independent implementations focusing on **security, dynamic file management, performance optimization, and rigorous UI/UX consistency**.

## 👩‍💻 Developer Story: From QA to Backend

Hello! I am a software developer with a 7-year background in Translation, Localization, and Quality Assurance (QA). After years of hunting for edge cases to ensure end-user products are "flawless" & helping Turkish developers understand all about Amazon Web Services, I decided to cross over to the other side of the table and build systems from the ground up.

This is my first full-scale CRUD and Backend project. However, I channeled my rigorous QA mindset directly into the code quality and user experience. Instead of the typical *"if it works, don't touch it"* approach, I focused on questions like *"If this breaks, how do we gracefully guide the user?"*, *"How does this render on a 320px screen?"* and *"How do we prevent data leaks here?"*

## 🚀 Key Features & Independent Enhancements

What sets this project apart from a standard tutorial project are the features I architected on my own initiative, driven by extensive testing and defensive programming:

* **Custom Identity & Profile Management:** Extended the standard `IdentityUser` to a custom `AppUser` class. Engineered server-side physical file uploading, dynamic profile image management, and real-time global UI synchronization (e.g., Navbar profile pictures). Implement secure password change flows with smart redirection and SweetAlert notifications.
* **Smart & Optimized Dashboard:** Built a dynamic admin dashboard featuring client-side quick search filtering for the sidebar, a dynamic unread notification bell mechanism, and resolved memory leaks in overview statistics to ensure high performance.
* **Bulletproof Fallback Mechanisms:** Implemented a dual-layer defense for broken images. Even if a valid image path exists in the database, if the physical file is missing or corrupted on the server, the system won't break. A global `onerror` architecture instantly deploys custom fallback assets.
* **Premium "Empty States":** Replaced ugly blank tables with premium glassmorphism "No Data Found" interfaces that actively encourage the user to add their first record, significantly boosting the UX of the admin dashboard.
* **Rigorous Mobile & Responsive UX:** Applied extensive mobile UI testing to resolve modal overflows, enforce strict flexbox grid alignments, and implement modern interactions like "click-outside-to-close" for sidebars and navbars across tablet and mobile breakpoints.

## 🛡️ Focus on Secure Coding & DRY Architecture

* **Centralized Authorization:** Instead of scattering `[Authorize]` attributes across multiple files, engineered an `AdminBaseController`. All admin panel controllers inherit from this base, ensuring strict access control globally without code duplication.
* **Global Cache-Busting:** Implemented global `ResponseCache` policies within the base controller to prevent unauthorized access via the browser's "Back" button after a user logs out.
* **Comprehensive Threat Mitigation:** * Implemented **Rate Limiting** and prevented **Mass Assignment** vulnerabilities on public contact forms.
    * Mitigated account takeover risks during profile updates with defensive null checks and fail-fast validations.
* **Global CSRF Protection:** Configured Auto Validate Antiforgery Tokens centrally at the application level to secure all POST requests against Cross-Site Request Forgery attacks, rather than relying on manual attribute placement.
* **Strict HTTP Verb Enforcement:** Refactored all destructive operations (e.g., Delete) from `HTTP GET` to `HTTP POST`. This critical architectural decision prevents accidental data wiping by web crawlers or browser link pre-fetching, and strictly neutralizes GET-based CSRF vulnerabilities.
* **Safe File Handling:** Secured profile image uploads by processing physical files with `Guid.NewGuid()`, eliminating risks of naming collisions and malicious file overriding.

## 🛠️ Tech Stack

* **Backend:** C#, ASP.NET Core MVC 10.0
* **Architecture:** N-Tier Architecture (Entity, Data Access, Business, UI Layers)
* **Database & ORM:** MS SQL Server, Entity Framework Core (Code First & Migrations)
* **Authentication:** ASP.NET Core Identity
* **Frontend:** HTML5, CSS3, Bootstrap 4/5, SweetAlert2, Google Charts

## 📸 Showcase & UI/UX Details

Here is a visual tour of the robust features, fallback mechanisms, and responsive designs implemented across the system.

### 1. Dashboard & Profile Management
The core administration panel featuring dynamic charts, real-time stats, and the custom Identity profile management system.
* **Dashboard & Analytics:** 
<img width="100%" alt="Dashboard and Overview" src="https://github.com/user-attachments/assets/49ead320-1be5-4432-9e1e-cd2ed333c3cb" />

* **Dynamic Profile Settings:** 
<img width="100%" alt="Dynamic Profile Settings" src="https://github.com/user-attachments/assets/46471102-a685-4b24-8f1c-210a4d602fd1" />

### 2. Bulletproof Fallback Mechanisms
Demonstrating the global `onerror` architecture. When a physical image file is missing, the system gracefully degrades to custom, context-aware illustrations instead of broken UI elements.
* **Frontend Fallback (Missing Team Avatar):** 
<img width="100%" alt="UI Fallback" src="https://github.com/user-attachments/assets/8bab5888-fbd1-4a2d-9d10-b3779efe3061" />

* **Admin Fallback (Missing Service Icon):** 
<img width="100%" alt="Admin Fallback" src="https://github.com/user-attachments/assets/f35dc807-ca53-4a5f-a6b0-7b4e4ac9dbe4" />

### 3. Premium "Empty States"
Replacing standard blank tables with engaging, glassmorphism-inspired UI to encourage user interaction when no data is present.
* **Frontend Empty State (Announcements):** 
<img width="100%" alt="UI Empty State" src="https://github.com/user-attachments/assets/ef55d093-a6d0-4ed8-b63d-8e0028a3b2c5" />

* **Admin Empty State:** 
<img width="100%" alt="Admin Empty State" src="https://github.com/user-attachments/assets/b000c2ed-9db7-4a78-91ae-95d60c00204f" />

### 4. Responsive Mobile & Tablet Views
Extensive media queries and flexbox realignments ensure the complex CMS dashboard and frontend are perfectly usable on any device.
* **Mobile View (iPhone XR):** 
<img width="100%" alt="Mobile Interface - 1" src="https://github.com/user-attachments/assets/cb0b1be3-852b-4fd7-a75a-6012b87a9c8c" />

* **Tablet View (iPad Mini):** 
<img width="100%" alt="Mobile Interface - 2" src="https://github.com/user-attachments/assets/107195e5-330b-4a4a-b218-f45540267751" />

### 5. Polished User Interactions
Replacing standard browser alerts with elegant, integrated SweetAlert2 notifications for all CRUD operations.
* **Action Feedback:** 
<img width="100%" alt="SweetAlert2" src="https://github.com/user-attachments/assets/f0a0ee06-99a1-425f-be29-794c989aaf41" />

### 6. Read-Only Portfolio Shield (Demo Protection)
Implemented a robust ID-based data protection system to ensure the integrity of the live demo, preventing the modification or deletion of core portfolio entities while allowing full CRUD testing for newly created data.
<img width="3071" height="1439" alt="Protected Data SweetAlert" src="https://github.com/user-attachments/assets/84ed4c00-8afe-4193-a595-b530cb3b0351" />

<img width="3071" height="1445" alt="Protected Data SweetAlert 2" src="https://github.com/user-attachments/assets/08c7bf38-7d68-4a6f-b046-56d481afc6b9" />

## LIVE DEMO
- User-facing: https://zaruyashar.me/
- Admin: https://zaruyashar.me/Login

## ⚙️ Setup & Installation

To run this project on your local machine:

1. Clone the repository: `git clone https://github.com/zaruyashar/turk-tarim-mvc.git`
2. Open the `AgriculturePresentation.sln` solution in Visual Studio.
3. Update the connection string in the `Context.cs` file (located in the `DataAccessLayer` project) to match your local SQL Server instance.
4. Open the Package Manager Console, select `DataAccessLayer` as the Default Project, and run: `Update-Database`
5. Set `AgriculturePresentation` as the Startup Project and run the application.

---
*This repository is the culmination of a passion for learning, an obsession with quality assurance, and a deep appreciation for secure software. Thank you for visiting!*
