# AIMS
Alcohol Inventory Managment System Project for Code Kentucky

### Project objective:

  - Track the quantity and value of a business's alcohol inventory.

### Statement of Work:  

  - Gather inventory into a csv file and value of each unique product.

  - I plan to implement the following commands:

  	- Add Product - Save name of new product and cost of unit.
	- Remove Product - Remove product name and cost. 
	- Track Inventory - Input quantity of a product at the current time by tenths of a bottle.
	- Edit - Retrieve current or previous copies of stored inventory numbers and adjust specific product quantities.  
	- Report - Access a summary of inventory levels, value of inventory and compare to previous inventories. 
	- Exit - Close the program.

## Features you are integrating into your project:

### Feature 1: 
	
  - Implement a “master loop” console application where the user can repeatedly enter commands/perform actions,
	including choosing to exit the program
	
### Feature 2:
	
  - Read data from an external file, such as text, JSON, CSV, etc and use that data in your application
	
### Feature 3:
	
  - Create a dictionary or list, populate it with several values, retrieve at least one value, and use it in your program
	
### Feature 4:
	
  - Create an additional class which inherits one or more properties from its parent (Different feature from original project plan)
	
  - If time permits, I plan to implement additional functionality such as a LINQ query and unit test as a stretch goal.
## Instructions For Use:
### First Things First
  - While I expect things to load as they should, in case theres an issue csvHelper, just paste this code into the shell:  > dotnet add package CsvHelper
  - Although my application is capable of storing Product information, it will be empty upon arrival. Here is some sample values to assist in testing although 
    you are more than welcome to make it up as you go ;-)

	Sample Values
		
		Category,Name,Price 
		Vodka,Titos,14.56
		Vodka,Stoli,11.28
		Bourbon,Woodford,36.15
		Bourbon,Weller,47.4
		Gin,Bombay,31.25
		Gin,Hendricks,10.68
	    Gin,Beefeater,27.68
		
### Recommended Use:
	- To assist in testing I would suggest starting with ADDing several CATEGORIES followed by a 
	  couple of PRODUCTS to get a good idea of the functionality of the application.
	- Adding INVENTORY values next will set you up to see what REPORT can do.
	- I would recommend testing out either EDIT here since you will have some values to adjust and 
	  compare or EXIT since you can observe the .csv reading and writing functionality.
	- Last but not least I reserved the REMOVE fuction for last given the time spent inputting values.