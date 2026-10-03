# UPDATES REPORT DOCUMENT

<!--
NOTE: This file provides a brief record of changes made to the application by each developer on their respective branch.

INSTRUCTIONS:
- Copy the update template below whenever you need to report new changes.
- Replace all placeholder values enclosed in square brackets ([]) with the appropriate information, then remove the brackets.
- Keep updates in reverse chronological order, with the most recent update appearing at the top of the file.
- Each report MUST begin and end with a horizontal divider (---) to separate it from other reports.
- When adding a new report, place it above the previous report's opening divider.
- Ensure each report clearly summarizes the changes made to your branch.
-->

## UPDATE TEMPLATE:

copy the template below to create new report

```

---

### Developer Name: [Full Name]

### Branch: [Branch Name]

### Date: DD-MM-YYYY

### REPORT

[Provide a concise summary of the changes made, features implemented, bugs fixed, or other relevant updates.]

---

```

## REPORTS

---

### Developer Name: Daniel C. Opute

### Branch: do-recreate-db-and-style-account-pages

### Date: 03-10-2026

### REPORT

- DB models have been written on data directory.
- You must run a migration and update to create and update the db at your end.

```
dotnet tool install --global dotnet-ef    (once only; skip if already installed)
dotnet ef migrations add AddForumTables
dotnet ef database update
```

- All Account pages i.e. (Login, Register...) has been styled.

---
