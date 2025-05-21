
# Population Reporting System - Use Cases

This document provides detailed use cases derived from the use case diagram of the **Population Reporting System**. Each use case outlines the interaction between the user and the system, preconditions, triggers, main flow, and expected outcomes.

---

## 1. Login/Logout
**Preconditions:** User is registered in the system.  
**Trigger:** User accesses the system login page.

**Main Flow:**
1. User enters credentials.
2. System verifies credentials.
3. If correct, user is granted access.
4. For logout, user clicks "Logout".

**Outcome:** User is logged in or logged out successfully.

---

## 2. Generate Country Population Report
**Preconditions:** User is logged in.  
**Trigger:** User selects "Country Population Report" option.

**Main Flow:**
1. System prompts for country selection.
2. User selects desired country.
3. System fetches and displays the population report.

**Outcome:** Population data for the selected country is displayed.

---

## 3. Generate City Population Report
**Preconditions:** User is logged in.  
**Trigger:** User selects "City Population Report".

**Main Flow:**
1. User selects a country or region.
2. System provides list of cities.
3. User selects cities.
4. System generates report.

**Outcome:** City population data is shown.

---

## 4. Generate Capital City Population Report
**Preconditions:** User is logged in.  
**Trigger:** User selects "Capital City Report".

**Main Flow:**
1. User selects a country.
2. System fetches capital city population data.

**Outcome:** Capital city population data is displayed.

---

## 5. Generate Top-N Population Reports
**Preconditions:** User is logged in.  
**Trigger:** User selects "Top-N Reports".

**Main Flow:**
1. User enters a number (N).
2. System fetches and ranks top-N populated regions or cities.

**Outcome:** Top-N list is displayed.

---

## 6. View Language Speaker Statistics
**Preconditions:** User is logged in.  
**Trigger:** User selects "Language Speaker Statistics".

**Main Flow:**
1. System provides list of languages.
2. User selects language(s).
3. System fetches speaker stats.

**Outcome:** Language speaker data is displayed.

---

## 7. View Population Breakdown (Continent/Region/Country)
**Preconditions:** User is logged in.  
**Trigger:** User selects "Population Breakdown".

**Main Flow:**
1. User selects continent or region.
2. System shows hierarchical breakdown.

**Outcome:** Data displayed by continent, region, and country.

---

## 8. View Continent/Region/Country Population
**Preconditions:** User is logged in.  
**Trigger:** User selects a geographic level to view.

**Main Flow:**
1. System shows population for selected level.

**Outcome:** Aggregated population data is shown.

---

## 9. View District/City Population
**Preconditions:** User is logged in.  
**Trigger:** User selects "District/City Population".

**Main Flow:**
1. User selects a region.
2. System lists districts/cities.
3. User selects specific district/city.

**Outcome:** Population of selected area is shown.

---

## 10. Compare City vs Non-City Population
**Preconditions:** User is logged in.  
**Trigger:** User selects comparison option.

**Main Flow:**
1. System calculates urban vs rural populations.
2. Data is presented visually (e.g., chart).

**Outcome:** Comparison is displayed.

---

## 11. Generate Country Report with Specific Columns
**Preconditions:** User is logged in.  
**Trigger:** User selects custom report option.

**Main Flow:**
1. User selects desired columns (e.g., area, growth rate).
2. System generates report based on input.

**Outcome:** Customized country report is shown.

---

## 12. Generate City Report with Specific Columns
**Preconditions:** User is logged in.  
**Trigger:** User selects city report customization.

**Main Flow:**
1. User picks desired fields (e.g., density, capital status).
2. Report is generated accordingly.

**Outcome:** Tailored city report is generated.

---

## 13. Generate Capital City Report with Specific Columns
**Preconditions:** User is logged in.  
**Trigger:** User chooses capital city report customization.

**Main Flow:**
1. Columns are selected.
2. System compiles report.

**Outcome:** Customized capital city report is displayed.

---

## 14. Generate Population Report with Specific Columns
**Preconditions:** User is logged in.  
**Trigger:** User opts for full population report customization.

**Main Flow:**
1. User selects columns.
2. System generates comprehensive population report.

**Outcome:** Fully customized population report is shown.

---

## Notes for Development and Testing:
- Ensure access control mechanisms for login/logout.
- Validate all input fields (e.g., country names, numbers).
- Implement pagination or filtering for large datasets.
- Ensure export options for reports (CSV, PDF, etc.).
- Validate accuracy and consistency of population data.
