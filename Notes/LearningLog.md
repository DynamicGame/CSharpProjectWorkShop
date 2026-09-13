# C# Learning Log

## 13 September 2026 — Console Expense Tracker

### What I built
A console app that lets users add, view, and delete expenses and see their total spending. Expenses are stored in memory while the app runs.

### Concepts I practised
- Classes and properties to represent an expense.
- `List<Expense>` to store expenses.
- A menu using a `while` loop and `switch`.
- Methods to separate responsibilities.
- An interface to separate console interaction from application logic.
- Input validation using `TryParse` and `IsNullOrWhiteSpace`.
- LINQ `Sum` to calculate total spending.

### Lessons from my code reviews
- **Strings are immutable.** `Trim()` returns a new string, so I must assign or return its result.
- **Parsing and validation are different.** A negative amount can parse successfully but still be invalid for the app.
- **Use the simplest operation.** `Sum` is clearer for totals, and `foreach` is clearer for displaying items than creating a temporary list.
- **Display numbers and list indexes differ.** Expense number 1 has list index 0, so deletion uses `RemoveAt(number - 1)` after checking the bounds.
- **`return` exits only the current method.** Returning from `ViewExpenses()` does not also exit `DeleteExpense()`.
- **Nullable annotations do not handle null automatically.** `string?` allows null, and `!` suppresses a warning; neither adds runtime handling.
- **Formatting changes the display.** `F2` shows two decimal places without changing the stored amount.

### What was verified
Previous builds completed with zero warnings and errors. Run checks covered adding expenses, invalid input, trimming descriptions, totals, deletion, renumbering, and exiting.

The latest source review confirmed that `DeleteExpense()` now returns immediately after displaying the empty-list message when there are no expenses. This latest change was reviewed in code, not rerun.

### Completed improvements
-  Simplify totals with `Sum` and display expenses with `foreach`.
-  Explain invalid descriptions and invalid or nonpositive amounts.
-  Trim descriptions before storing them.
- Display amounts and totals with two decimal places.
- Handle input ending at the main menu.
- Stop the delete operation immediately when the list is empty.
- Use “expense number” in the delete prompt.

### Remaining improvement
- Handle input ending during the description and amount prompts. Detect `null` and stop adding the expense cleanly rather than repeatedly prompting.

### Next project — Console Quiz Game
Practise modelling questions, validating answer choices, tracking a score, and resetting state for a new game.

First checkpoint: display one question with four options, accept a valid answer, and check whether it is correct.
