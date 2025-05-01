# CSC202Final
Using Windows Form App to make a Budget Tracker

First Run Checklist:
🔹 Step 1: Launch the App
 App starts without crashing.

 Main form (Form1) shows: amount textbox, category dropdown, date picker, notes textbox, and 4 buttons.

🔹 Step 2: Add an Expense
 Enter a number in the Amount textbox (e.g., 12.50).

 Choose a Category from the dropdown (e.g., Food).

 Pick today’s date from the DatePicker.

 Add a note (optional).

 Click Add Expense.

 Expectation: no crash or error; expense is stored in memory (you won’t see it yet).

🔹 Step 3: Save to File
 Click Save.

 Expectation: a file like expenses.txt is created or updated.

 If file creation fails, you should see a message box (handled by exception handling).

🔹 Step 4: Load from File
 Click Load.

 Expectation: existing expenses are loaded into memory.

 If file doesn’t exist or is corrupt, you get a clear error message (exception handling).

🔹 Step 5: View Summary (Form2)
 Click View Summary.

 New form appears with a ListBox of expenses and a label showing total amount spent.

 Check that all expense info (category, date, amount, notes) is showing correctly.

 Total matches the sum of the amounts.
