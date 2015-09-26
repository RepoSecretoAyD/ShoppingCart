Feature: ShoppingCart
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Calculate Subtotal
	Given the cart has the following items
		| ProductId | ProductName    | Price | Quantity |
		| 1         | Arroz Progreso | 50    | 10       |
		| 2         | Carne          | 40    | 10       |
		| 3         | Queso          | 10    | 5        |
	When the subtotal is calculated
	Then the result should be 950

	#Ejercicio1
Scenario: Calculate Subtotal from a stored cart
	Given the cart stored for user is
		| ProductId | Quantity | Owner		  |
		| 1         | 10       |   ccastro    |
		| 2         | 10       |   ccastro    |
		| 3         | 5        |   ccastro    |
	And the products table is the following
		| ProductId | ProductName    | Price | Quantity |
		| 1         | Arroz Progreso | 50    | 200      |
		| 2         | Carne          | 40    | 300      |
		| 3         | Queso          | 10    | 250      |
	And the user logged is 'ccastro'
	When the subtotal is calculated
	Then the result should be 950


	#Ejercicio 2 parte 1
Scenario: Try to calculate Subtotal from a stored cart thats not exceeding product existance quantity
	Given the cart stored for user is
		| ProductId | Quantity | Owner		  |
		| 1         | 10       |   ccastro    |
		| 2         | 10       |   ccastro    |
		| 3         | 5        |   ccastro    |
	And the products table is the following
		| ProductId | ProductName    | Price | Quantity  |
		| 1         | Arroz Progreso | 50    | 10        |
		| 2         | Carne          | 40    | 15        |
		| 3         | Queso          | 10    | 5         |
	And the user logged is 'ccastro'
	When the subtotal is calculated
	Then the result should be 950

	#Ejercicio 2 parte 2
Scenario: Try to calculate Subtotal from a stored cart that is exceeding existance quantity
	Given the cart stored for user is
		| ProductId | Quantity | Owner		   |
		| 1         | 100       |   ccastro    |
		| 2         | 100       |   ccastro    |
		| 3         | 50        |   ccastro    |
	And the products table is the following
		| ProductId | ProductName    | Price | Quantity  |
		| 1         | Arroz Progreso | 50    | 70        |
		| 2         | Carne          | 40    | 83        |
		| 3         | Queso          | 10    | 50        |
	And the user logged is 'ccastro'
	When the subtotal is calculated
	Then the user is presented with an error message about quantity

		#Ejercicio 3 parte 1
Scenario: Try to calculate Subtotal from a stored cart that has no expired items
	Given the cart stored for user is
		| ProductId | Quantity | Owner		   |
		| 1         | 10        |   ccastro    |
		| 2         | 10        |   ccastro    |
		| 3         | 5         |   ccastro    |
	And the products table with Date is the following
		| ProductId | ProductName    | Price | Quantity | Date          |
		| 1         | Arroz Progreso | 50    | 10       | 1420113600000 |
		| 2         | Carne          | 40    | 15       | 1420113600000 |
		| 3         | Queso          | 10    | 5        | 1420113600000 |
	And the user logged is 'ccastro'
	When the subtotal is calculated
	Then the result should be 950

			#Ejercicio 3 parte 2
Scenario: Try to calculate Subtotal from a stored cart that has some expired items
	Given the cart stored for user is
		| ProductId | Quantity | Owner		   |
		| 1         | 10        |   ccastro    |
		| 2         | 10        |   ccastro    |
		| 3         | 5         |   ccastro    |
	And the products table with Date is the following
		| ProductId | ProductName    | Price | Quantity | Date          |
		| 1         | Arroz Progreso | 50    | 10       | 1420113600000 |
		| 2         | Carne          | 40    | 15       | 1420113600000 |
		| 3         | Queso          | 10    | 5        | 1420070399000 |
	And the user logged is 'ccastro'
	When the subtotal is calculated
	Then the user is presented with an error message about expiration

				#Ejercicio 4 parte 1
Scenario: Try to calculate Subtotal from a stored cart that has some discounts
	Given the cart stored for user is
		| ProductId | Quantity | Owner		   |
		| 1         | 10        |   ccastro    |
		| 2         | 10        |   ccastro    |
		| 3         | 5         |   ccastro    |
	And the products table is the following
		| ProductId | ProductName    | Price | Quantity |
		| 1         | Arroz Progreso | 50    | 10       |
		| 2         | Carne          | 40    | 15       |
		| 3         | Queso          | 10    | 5        |
	And the discounts table is the following
		| ProductId | Discount |
		| 2         | 0.15     |
	And the user logged is 'ccastro'
	When the subtotal is calculated
	Then the result should be 890

					#Ejercicio 4 parte 2
Scenario: Try to calculate Subtotal from a stored cart that has discounts on everything
	Given the cart stored for user is
		| ProductId | Quantity | Owner		   |
		| 1         | 10        |   ccastro    |
		| 2         | 10        |   ccastro    |
		| 3         | 5         |   ccastro    |
	And the products table is the following
		| ProductId | ProductName    | Price | Quantity |
		| 1         | Arroz Progreso | 50    | 10       |
		| 2         | Carne          | 40    | 15       |
		| 3         | Queso          | 10    | 5        |
	And the discounts table is the following
		| ProductId | Discount |
		| 1         | 0.30     |
		| 2         | 0.15     |
		| 3         | 0.50     |
	And the user logged is 'ccastro'
	When the subtotal is calculated
	Then the result should be 715