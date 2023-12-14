create database ProductInventoryDb

use ProductInventoryDb

create table Products
(ProductId int primary key ,
ProductName nvarchar(50),
price float,
Quantity int,
MfDate date,
ExpDate date)

insert into Products values (1,'Talcom Powder','199.90',1,'12/24/2021','02/29/2024')
insert into Products values (2,'Parachute oil','128.99',1,'01/01/2023','10/31/2025')
insert into Products values (3,'Energy Drink','95.32',8,'12/01/2023','12/31/2024')
insert into Products values (4,'Oreo Biscuits','60.00',6,'11/01/2023','11/01/2025')
insert into Products values (5,'Ponds Gel','220.99',5,'12/24/2022','12/24/2024')
insert into Products values (6,'Wheat Atta','273.95',3,'11/01/2023','03/31/2024')

select * from Products
