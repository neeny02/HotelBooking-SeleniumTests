Hotel Booking Automation Tests (C# + Selenium)
📌 Overview

This repository contains automated UI tests for a hotel booking workflow, implemented in C#, using Selenium WebDriver and MSTest.
The tests demonstrate browser automation, dynamic element interaction, handling date pickers, dropdowns, waits, and common user flows found in hotel booking systems.

🚀 Features

Automated browser testing with Google Chrome

Dynamic date selection (no hard-coded selectors)

Interaction with:

Input fields

Buttons

Dropdowns

Radio buttons

Checkboxes

Explicit waits using WebDriverWait

Clear test structure using MSTest

Designed for interview-ready demonstration of Selenium skills

🧰 Tech Stack
Component	Purpose
C# (.NET)	Main programming language
Selenium WebDriver	Browser automation
ChromeDriver / Selenium Manager	Controls Chrome
MSTest	Test framework
NuGet Packages	Selenium.WebDriver, Selenium.Support, MSTest.TestFramework, etc.
📂 Project Structure
HotelBookingTests.slnx
└── TestProject1/
    ├── TestProject1.csproj
    ├── BookingDotCom.cs (example test class)
    └── Other test support files

⚙️ Prerequisites

Make sure the following are installed:

.NET 6 SDK or higher

Google Chrome

(Optional) ChromeDriver manually — but Selenium Manager can download it automatically

Restore dependencies:

dotnet restore

▶️ Running Tests

Using CLI:

dotnet test


Using Visual Studio:

Open the solution .slnx

Open Test Explorer

Click Run All

🧪 Example Test Flow

Your test scenarios include:

Launching the hotel booking website

Entering destination

Selecting check-in and check-out dates

Choosing number of guests

Performing a search

Validating that results load correctly

All element interactions use explicit waits and proper locators to make the tests reliable.

🔍 Troubleshooting
NoSuchElementException

Occurs if an element has not loaded yet.
Fix: Increase explicit wait time or improve CSS/XPath locator.

TimeoutException

The element did not appear in time.
Fix: Ensure page loads correctly and waits are applied at the right moment.

ElementClickInterceptedException

Something blocks the element (popup, overlay).
Fix: Wait for overlays or scroll element into view.

📄 License

MIT License (optional to change).
