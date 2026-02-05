# Console Spreadsheet Application (C#)

A **console-based spreadsheet program** written in **C#**, inspired by basic Excel functionality.  
Users can manage cells, rows, and columns, perform arithmetic and string operations, and save the sheet to a text file.

---

## Overview

- Spreadsheet-style grid with **rows (1,2,3,...)** and **columns (A,B,C,...)**
- Each cell stores:
  - a **value**
  - a **type** (`integer`, `string`, `unassigned`)
- Operates entirely in the **console**

---

## Default Limits

- Visible sheet: **8 rows × 5 columns**
- Maximum capacity: **15 rows × 10 columns**

---

## Main Features

### Cell Operations
- Assign value (integer or string)
- View cell content
- Clear a single cell
- Clear entire sheet

### Row & Column Management
- Insert rows (up / down)
- Insert columns (left / right)

### Copy & Cut
- Copy / Cut cell
- Copy / Cut entire row
- Copy / Cut entire column

### Calculations & String Operations
- **Add**
  - Integer addition
  - String concatenation (uppercase or lowercase)
- **Subtract**
  - Integer subtraction
  - String removal
  - ASCII character removal
- **Multiply**
  - Integer multiplication
  - String repetition (negative numbers reverse the string)
- **Divide**
  - Integer division
  - Partial string extraction
- **Encrypt**
  - Caesar-style character shift using an integer key

### File Saving
- On exit, the spreadsheet is saved as:
  - `spreadsheet.txt`

---

## Menu

