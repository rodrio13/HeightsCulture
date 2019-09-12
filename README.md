# Heights Culture
## Concept Description
Heights Culture is your go-to source for styles influenced by the latest fashions with an added flair. We aim to inspire our customers to be the best version of themselves and to be confident in their own skin - and of course, their outfits.
Our vision is fast-paced, forward-thinking and fashion-centered at its core, and all of our products reflect these ideals. We invite you to browse our site to find just what you have been looking for. Look good, feel good, shop Heights Culture today.
## Site Map
![Site Map](https://user-images.githubusercontent.com/52425891/62828942-55819900-bba7-11e9-80c8-a4a0e16454a9.png)
This is a very basic site map for my website. 
## WireFrame
![Wireframe](https://user-images.githubusercontent.com/52425891/62828971-c628b580-bba7-11e9-8795-bb3b808cdf22.png)

* I kept my wireframe very basic so that who ever is viewing this can focus on the structure of the website instead of the look.
* On the top left of the website it will have the name and logo.
* The boxes you see on the top right is the menu and they follow you throughout the entire website. The Home button, which when pressed and you're on another part of the website will take you back to the home page.
* The Store button will take you to a page where you can view all the products.
* The About button will take you to a page that will have what our views are.
* The last one is the Cart button that will take you to your shopping cart.
* Bellow that is a big button that will display our new collection. It will rotate through the new products in intervals of 4 seconds. 
* Bellow that on the left is the Shop All that does the same as the Shop menu button.
* As well as, the About Us that does the exact same as the About menu button.
* Bellow all that is the Contact Us. This will allow the customer to leave a review or just contact us for any assistance.

## Entity Relationship Diagram
![ERD MSSA](https://user-images.githubusercontent.com/52425891/62828990-71d20580-bba8-11e9-9b16-3a3bf27e772f.png)
## Database
````
------------------------------------ HeightsCulture ----------------------------------
DROP DATABASE IF EXISTS HeightsCulture;
CREATE DATABASE HeightsCulture
--------------------------------- Creating Tables #1 ---------------------------------
USE HeightsCulture;
DROP TABLE IF EXISTS Customers;
CREATE TABLE Customers
(
CustomerID       INT           NOT NULL,
CustFirstName    VARCHAR(30)   NOT NULL,
CustLastName     VARCHAR(30)   NOT NULL,
CustStreet       VARCHAR(30)   NOT NULL,
CustCity         VARCHAR(30)   NOT NULL,
StateID          CHAR(2)       NOT NULL,
CustZip          INT           NOT NULL,
CustPhone        VARCHAR(30)   NOT NULL,
                 PRIMARY KEY   (CustomerID),
				 FOREIGN KEY   (StateID) REFERENCES States(StateID)
)
INSERT INTO Customers
(CustomerID, CustFirstName, CustLastName, CustStreet, CustCity, StateID, CustZip, CustPhone)
VALUES
(0001, 'Kevin', 'Carillo', '122nd Street', 'Jamaica', 'NY', 11420, '3478793883')
--------------------------------- Creating Tables #2 ---------------------------------
USE HeightsCulture;
DROP TABLE IF EXISTS CustomerAccount;
CREATE TABLE CustomerAccount
(
AccountID                INT          NOT NULL,
CustomerID               INT          NOT NULL,
LastPurchaseDate         DATE         NOT NULL,
LastPaymentDate          DATE         NOT NULL,
LastAccountTransaction   DATE         NOT NULL,
TransactionID            CHAR(2)      NOT NULL,
Balance                  INT          NOT NULL,
						 PRIMARY KEY  (AccountID),
						 FOREIGN KEY  (CustomerID)    REFERENCES Customers(CustomerID),
						 FOREIGN KEY  (TransactionID) REFERENCES Transactions(TransactionID)
)
INSERT INTO CustomerAccount
(AccountID, CustomerID, LastPurchaseDate, LastPaymentDate, LastAccountTransaction, TransactionID, Balance)
VALUES
(001, 0001, '2019-01-01', '2019-01-01', '2019-01-01', '01', 673.2)
--------------------------------- Creating Tables #3 ---------------------------------
USE HeightsCulture;
DROP TABLE IF EXISTS Supplier;
CREATE TABLE Supplier
(
SupplierID    INT            NOT NULL,
SupName       VARCHAR(30)    NOT NULL,
SupStreet     VARCHAR(30)    NOT NULL,
SupCity       VARCHAR(30)    NOT NULL,
StateID       CHAR(2)        NOT NULL,
SupZip        VARCHAR(30)    NOT NULL,
SupPhone      VARCHAR(30)    NOT NULL,
			  PRIMARY KEY    (SupplierID),
			  FOREIGN KEY    (StateID)     REFERENCES States(StateID)
)
INSERT INTO Supplier
(SupplierID, SupName, SupStreet, SupCity, StateID, SupZip, SupPhone)
VALUES
(001, 'GraphTees', '567 72nd Street', 'Park View', 'NY', '12345', '760-777-777')
--------------------------------- Creating Tables #4 ---------------------------------
USE HeightsCulture;
DROP TABLE IF EXISTS ProductInventory;
CREATE TABLE ProductInventory
(
InventoryID      INT            NOT NULL,
SerialNumber     VARCHAR(30)    NOT NULL,
SupplierID       INT            NOT NULL,
InventoryDate    DATE           NOT NULL,
ProductID        VARCHAR(30)    NOT NULL,
				 PRIMARY KEY    (InventoryID),
				 FOREIGN KEY    (SupplierID)  REFERENCES Supplier(SupplierID),
				 FOREIGN KEY    (ProductID)   REFERENCES Products(ProductID)
)
INSERT INTO ProductInventory
(InventoryID, SerialNumber, SupplierID, InventoryDate, ProductID)
VALUES
(001, '00101001', 001, '2019-01-01', 'A01'),
(002, '00101002', 002, '2019-01-01', 'A02')
--------------------------------- Creating Tables #5 ---------------------------------
USE HeightsCulture;
DROP TABLE IF EXISTS Products;
CREATE TABLE Products
(
ProductID         VARCHAR(30)     NOT NULL,
ProdName          VARCHAR(30)     NOT NULL,
InventoryPrice    INT             NOT NULL,
SalePrice         INT             NOT NULL,
ProdDescription   VARCHAR(100)    NOT NULL,
				  PRIMARY KEY     (ProductID)
)
INSERT INTO Products
(ProductID, ProdName, InventoryPrice, SalePrice, ProdDescription)
VALUES
('A01', 'T-Shirt', 40.3, 54.3, 'T-Shirt with graphic design'),
('A02', 'Pants', 30, 55.9, 'Skinny Jeans')
--------------------------------- Creating Tables #6 ---------------------------------
USE HeightsCulture;
DROP TABLE IF EXISTS PurchaseOrder;
CREATE TABLE PurchaseOrder
(
PurchaseID       INT            NOT NULL,
InventoryID      INT            NOT NULL,
PurchaseDate     DATE           NOT NULL,
CustomerID       INT            NOT NULL,
SerialNumber     INT            NOT NULL,
ProductID        VARCHAR(30)    NOT NULL,
Quantity         INT            NOT NULL,
Price            INT            NOT NULL,
				 PRIMARY KEY    (PurchaseID), 
				 FOREIGN KEY    (InventoryID)  REFERENCES ProductInventory(InventoryID),
				 FOREIGN KEY    (CustomerID)   REFERENCES Customers(CustomerID),
				 FOREIGN KEY    (ProductID)    REFERENCES Products(ProductID)
)
INSERT INTO PurchaseOrder
(PurchaseID, InventoryID, PurchaseDate, CustomerID, SerialNumber, ProductID, Quantity, Price)
VALUES
(001, 001, '2019-01-01', 001, 001010001, 'A01', 01, 54.3),
(002, 002, '2019-01-01', 002, 001010002, 'A02', 01, 55.9)
--------------------------------- Creating Tables #7 ---------------------------------
USE HeightsCulture;
DROP TABLE IF EXISTS States;
CREATE TABLE States
(
StateID        CHAR(2)         NOT NULL,
StateName      VARCHAR(30)     NOT NULL,
			   PRIMARY KEY     (StateID)
)
INSERT INTO States
(StateID, StateName)
VALUES 
('AL', 'Alabama'),
('AK', 'Alaska'),
('AZ', 'Arizona'),
('AR', 'Arkansas'),
('CA', 'California'),
('CO', 'Colorado'),
('CT', 'Connecticut'),
('DE', 'Delaware'),
('FL', 'Florida'),
('GA', 'Georgia'),
('HI', 'Hawaii'),
('ID', 'Idaho'),
('IL', 'Illinois'),
('IN', 'Indiana'),
('IA', 'Iowa'),
('KS', 'Kansas'),
('KY', 'Kentucky'),
('LA', 'Louisiana'),
('ME', 'Maine'),
('MD', 'Maryland'),
('MA', 'Massachusetts'),
('MI', 'Michigan'),
('MN', 'Minnesota'),
('MS', 'Mississippi'),
('MO', 'Missouri'),
('MT', 'Montana'),
('NE', 'Nebraska'),
('NV', 'Nevada'),
('NH', 'New Hampshire'),
('NJ', 'New Jersey'),
('NM', 'New Mexico'),
('NY', 'New York'),
('NC', 'North Carolina'),
('ND', 'North Dakota'),
('OH', 'Ohio'),
('OK', 'Oklahoma'),
('OR', 'Oregon'),
('PA', 'Pennsylvania'),
('RI', 'Rhode Island'),
('SC', 'South Carolina'),
('SD', 'South Dakota'),
('TN', 'Tennessee'),
('TX', 'Texas'),
('UT', 'Utah'),
('VT', 'Vermont'),
('VA', 'Virginia'),
('WA', 'Washington'),
('WV', 'West Virginia'),
('WI', 'Wisconsin'),
('WY', 'Wyoming')

--------------------------------- Creating Tables #8 ---------------------------------
USE HeightsCulture;
DROP TABLE IF EXISTS Transactions;
CREATE TABLE Transactions
(
TransactionID        CHAR(2)            NOT NULL,
TransDescription     VARCHAR(100)       NOT NULL,
		             PRIMARY KEY        (TransactionID)
)
INSERT INTO Transactions
(TransactionID, TransDescription)
VALUES
('01', 'Shirt'),
('02', 'Pant'),
('03', 'Short'),
('04', 'Sweater')
````
## Database Diagram
![Database Diagram](https://user-images.githubusercontent.com/52425891/62829222-bf9d3c80-bbad-11e9-95e0-0db735519c21.PNG)

## Prototype
![HeightsCulture Prototype](https://user-images.githubusercontent.com/52425891/64799633-f6ae9700-d539-11e9-9a8e-0d05c5195102.PNG)
