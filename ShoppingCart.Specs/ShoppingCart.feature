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
	
Scenario: Calculate Subtotal from a stored cart
	Given the cart stored for user is
		| ProductId | Quantity | Owner		  |
		| 1         | 10       |   ccastro    |
		| 2         | 10       |   ccastro    |
		| 3         | 5        |   ccastro    |
		And the user logged is 'ccastro'
		And the products table is the following
		| ProductId | ProductName    | Price |
		| 1         | Arroz Progreso | 50    | 
		| 2         | Carne          | 40    | 
		| 3         | Queso          | 10    |  
	When the subtotal is calculated
	Then the result should be 950