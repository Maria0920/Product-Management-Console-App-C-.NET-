# Product Store Application

This project is a **C# .NET console application** developed as part of a university assignment.  
It allows users to enter product details, validate product IDs, and display product information by category.

---

## 📌 Features
- Prompt the user to enter **1–30 products**.
- Validate product IDs (must follow category code + two digits, e.g. `a-01`).
- Automatically assign products to a category if an invalid ID is entered.
- Display all product details including:
  - Product ID  
  - Product Name  
  - Category Name  
  - Quantity  
  - Price  
- View a **filtered list of products by category** (Apparel, Books, Foods, Toys, Others).

---

## 🛠️ Technologies Used
- Language: **C#**
- Framework: **.NET Console Application**

---

## 🚀 How to Run
1. Clone the repository:
   ```bash
   git clone https://github.com/your-username/ProductStoreApplication.git

2. Navigate to the project folder:
   cd ProductStoreApplication

3. Run the program:
   dotnet run --project ProductStoreApplication/ProductStoreApplication.csproj


🌱 Assignment Context

This application was built as part of a programming assignment focused on:
- Practising object-oriented design with classes and properties.
- Using arrays and loops to manage multiple objects.
- Implementing input validation and error handling.
- Demonstrating console-based user interaction.


📷 Example Output
****************************************************************
****************************************************************
*       This program will determine how much the book is       *
*           You will be asked to enter product ID              *
****************************************************************
****************************************************************

Please enter an integer which is in the range of 1 and 30 >>

📖 Categories
a- → Apparel
b- → Books
f- → Foods
t- → Toys
o- → Others

⚠️ Notes
Some advanced features (e.g. persistence, database storage) are not included as this is a console-based assignment project.
Invalid product IDs are reassigned to the Others category automatically.
