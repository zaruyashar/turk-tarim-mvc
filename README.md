# 🌾 Türk Tarım - Enterprise Agriculture Management System (ASP.NET Core MVC)

![.NET Core](https://img.shields.io/badge/.NET%20Core-10.0-512BD4?style=flat-square&logo=dotnet)
![Entity Framework](https://img.shields.io/badge/Entity%20Framework-Core-339933?style=flat-square)
![Architecture](https://img.shields.io/badge/Architecture-N--Tier-FF5722?style=flat-square)
![Security](https://img.shields.io/badge/Focus-Secure%20Code-000000?style=flat-square&logo=security)

Türk Tarım (Turkish Agriculture) is a comprehensive Content Management System (CMS) and corporate promotional platform designed for modern agricultural enterprises, built on a robust **N-Tier Architecture**.

This project was initially inspired by Murat Yücedağ's *"Step-by-Step N-Tier Architecture with C#"* course. However, it goes far beyond the standard curriculum, heavily customized with independent implementations focusing on **security, dynamic file management, performance optimization, and rigorous UI/UX consistency**.

## 👩‍💻 Developer Story: From QA to Backend

Hello! I am a software developer with a 7-year background in Translation, Localization, and Quality Assurance (QA). After years of hunting for edge cases to ensure end-user products are "flawless" & helping Turkish developers understand all about Amawon Web Services, I decided to cross over to the other side of the table and build systems from the ground up.

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

## 📸 Screenshots

[screenshots to be added here]

1. **Dashboard & Analytics:** `[screenshot here]` *(Showing Google Charts and stats)*
2. **Dynamic Profile Settings:** `[screenshot here]` *(Showcasing the custom PP upload area)*
3. **Empty State UI:** `[screenshot here]` *(Demonstrating the premium glassmorphism "Add your first record" design)*
4. **Responsive Mobile Views:** `[screenshot here]` *(Showing the perfectly aligned mobile navbar or sidebar)*

## ⚙️ Setup & Installation

To run this project on your local machine:

1. Clone the repository: `git clone https://github.com/zaruyashar/turk-tarim-mvc.git`
2. Open the `AgriculturePresentation.sln` solution in Visual Studio.
3. Update the connection string in the `Context.cs` file (located in the `DataAccessLayer` project) to match your local SQL Server instance.
4. Open the Package Manager Console, select `DataAccessLayer` as the Default Project, and run: `Update-Database`
5. Set `AgriculturePresentation` as the Startup Project and run the application.

---
*This repository is the culmination of a passion for learning, an obsession with quality assurance, and a deep appreciation for secure software. Thank you for visiting!*
