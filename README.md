# 👨‍💻 Building Management System
### Basic Overview
* This project is a Final Project of Sipay Net Bootcamp which includes Asp.Net framework with Restful APIs, Database Designs and neccessary Services. 

#### Requirements
* Creating a BuildingManagementSystem app which is able to control by admin.
* The only thing accessible in the system is the Login API. The user can perform operations such as adding/deleting/listing/updating when necessary thanks to the admin role he has acquired after logging in.
  
 #### Used in the Project:
* Asp.Net Core Web API with `.Net6.0` framework.
* EntityFrameworkCore as an ORM and Tools packages.
* Microsoft SQL as an Database and packages.
* JWT Bearer Authentication library to generate tokens.
* AutoMapper for mapping results.
* Swagger used for tests.

## Installation and Usage
* To get the project :
  
 ```git clone: https://github.com/selin-krsli/Final-Case.git```
 
* To create the code first, in the  ```BuildingManagementSystem.Data``` folder and the 3 command lines we use in this file are as follows:
  
 ```add-migration InitialData```
 
 ```add-migration SeedData```
 
 ```update-database```

## Design of Structure

* In this project, *Clean Architecture Design Principles* used in the project structure.
  
 **BuildingManagementSystem.Base:**  This layer forms the foundation of the project, containing common components and fundamental classes. 
 
 **BuildingManagementSystem.Schema:**  This layer defines the database schemas and the structure of data objects. 
 
**BuildingManagementSystem.Data:**  This layer focuses on database access. It deals with database connections, queries, and data manipulation operations. 

**BuildingManagementSystem.Business:** This layer manages user requests at a higher level. It defines the overall structure and models of the business layer. 

**BuildingManagementSystem.Service:** This layer implements business logic and processes. It handles user requests, retrieves necessary data, processes it, and returns results.


## Badges

Add badges from somewhere like: [shields.io](https://shields.io/)

[![MIT License](https://img.shields.io/badge/License-MIT-green.svg)](https://choosealicense.com/licenses/mit/)
[![GPLv3 License](https://img.shields.io/badge/License-GPL%20v3-yellow.svg)](https://opensource.org/licenses/)
[![AGPL License](https://img.shields.io/badge/license-AGPL-blue.svg)](http://www.gnu.org/licenses/agpl-3.0)


