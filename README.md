# **License Management System for LTT**
### Software Requirements Specification (SRS)

## Table of Contents :
+ ####  **1- Introduction**
    + 1.1 Purpose
    + 1.2 Scope
    + 1.3 Definitions, Acronyms, and Abbreviations
    + 1.4 References
    + 1.5 Overview
___
+ ####  **2- System Overview**
    - 2.1 Product Perspective
    - 2.2 Product Features
    - 2.3 User Classes and Characteristics
    - 2.4 Operating Environment
    - 2.5 Design and Implementation Constraints
    - 2.6 Assumptions and Dependencies
---
+ #### **3- Functional Requirements**
    - 3.1 User Management
    - 3.2 Department Management
    - 3.3 Category Management
    - 3.4 Product Management
    - 3.5 License Management

***
+ #### **4- Non-Functional Requirements**
    - 4.1 Performance
    - 4.2 Security
    - 4.3 Usability
    - 4.4 Reliability
---
+ #### **5- System Design**
    - 5.1 Architecture Overview
    - 5.2 Database Design
    - 5.3 User Interface Design
---
+ #### **6- Appendices**
    - 6.1 Glossary
    - 6.2 Use Case Diagram
    - 6.3 Class Diagram
    - 6.4 Entity-Relationship Diagram
----

## **1. Introduction**
### 1.1 Purpose

The purpose of the License Management System is to provide the LTT company (c) with a centralized platform for managing servers, hardware, and software licenses. The system allows users to create departments, manage contacts, categorize products, and track licenses.
&nbsp;


### 1.2 Scope
The License Management System will enable users to perform the following tasks:
- User management: Create and manage user accounts with different access levels.
- Department management: Create departments within the organization and assign department managers.
- Category management: Define categories for organizing products.
- Product management: Create and manage products within each category.
- License management: Track and manage licenses associated with each product.
  &nbsp;
### 1.3 Definitions, Acronyms, and Abbreviations
- **LTT**: Acronym for the company name.
- **SRS**: Software Requirements Specification.

### 1.4 References
[Insert references to any relevant documents or external resources.]
&nbsp;

### 1.5 Overview
This SRS document provides an overview of the License Management System for **LTT**. It outlines the system's features, functional and non-functional requirements, system design, and other relevant details.
&nbsp;

## **2. System Overview**
### 2.1 Product Perspective
The License Management System is a stand-alone application designed to be used within the **LTT** organization. It interacts with users through a user interface and stores data in a database.
### 2.2 Product Features
The key features of the License Management System include:

#### User Management
- Create, update, and delete user accounts with different access levels.
- Support different user roles, including administrators, department managers, and regular users.
- Provide options for updating and deleting user accounts.
- Assign appropriate access levels based on user roles.

#### Department Management
- Create departments within the organization.
- Allow department managers to manage their respective departments.
- Enable the assignment of department managers to departments.
- Track and provide access to department information, including contact details.

#### Category Management
- Define categories for organizing products.
- Allow administrators to create, update, and delete categories.
- Assign unique identifiers and names to categories.

#### Product Management
- Create and manage products within categories.
- Record product details such as name, version, and vendor information.
- Enable administrators to update or delete products.
- Associate products with their respective categories.

#### License Management
- Track and manage licenses associated with products.
- Record license details such as license type, expiration date, and usage information.
- Provide administrators and department managers with the ability to view and manage licenses.
- Offer options for updating or deleting licenses.

### 2.3 User Classes and Characteristics
The License Management System is designed for the following user classes:

1. Administrators: Responsible for system administration tasks, including user and department management, category creation, and license tracking.
2. Department Managers: Manage their respective departments, including assigning users, updating department information, and managing licenses.
3. Regular Users: Access the system to view licenses, products, and department information based on their assigned roles.

### 2.4 Operating Environment
The License Management System will be developed as a web-based application and should be compatible with the following operating environments:
- Operating System: Windows, macOS, Linux
- Web Browsers: Google Chrome, Mozilla Firefox, Microsoft Edge, Safari.
### 2.5 Design and Implementation Constraints
The following design and implementation constraints should be considered:
- The system should be developed using a web framework such as Django or Ruby on Rails.
- The database should be relational, such as MySQL or PostgreSQL.
- User interface design should follow modern web design principles and be responsive to different screen sizes.

### 2.6 Assumptions and Dependencies
The successful implementation of the License Management System depends on the following assumptions and dependencies:
- The availability of sufficient hardware and infrastructure to host the system.
- Users will have access to compatible web browsers and internet connectivity.
- Relevant data and information required for the system will be provided by the organization.
  &nbsp;

## 3. **Functional Requirements**

### 3.1 User Management
- The system shall allow administrators to create user accounts.
- The system shall support different user roles, including administrators, department managers, and regular users.
- The system shall provide options for updating and deleting user accounts.
- User accounts should have appropriate access levels based on their roles.

### 3.2 Department Management
- The system shall allow administrators to create departments within the organization.
- Department managers should be able to manage their respective departments.
- The system shall enable the assignment of department managers to departments.
- Department information, including contact details, should be tracked and accessible.

### 3.3 Category Management
- The system shall provide functionality to define categories for organizing products.
- Administrators should be able to create, update, and delete categories.
- Categories should have unique identifiers and names.

### 3.4 Product Management
- The system shall allow the creation and management of products within categories.
- Product details such as name, version, and vendor information should be recorded.
- Administrators should have the ability to update or delete products.
- Products should be associated with their respective categories.

### 3.5 License Management
- The system shall enable the tracking and management of licenses associated with products.
- Licenses should have details such as license type, expiration date, and usage information.
- Administrators and department managers should be able to view and manage licenses.
- The system should provide options for updating or deleting licenses.
  &nbsp;

## **4. Non-Functional Requirements**
### 4.1 Performance
- The system should be able to handle a large number of users and data records efficiently.
- Response times for user interactions and data retrieval should be minimal.
- The system should be scalable to accommodate future growth.

### 4.2 Security
- User authentication and authorization mechanisms should be in place to ensure data security.
- The system should enforce appropriate access controls based on user roles.
- Sensitive data, such as passwords and license information, should be encrypted.

### 4.3 Usability
- The user interface should be intuitive, user-friendly, and easy to navigate.
- The system should provide clear instructions and error messages to guide users.
- The system should support multiple languages, if required.

### 4.4 Reliability
- The system should be highly available and minimize downtime.
- Regular data backups should be performed to prevent data loss.
- The system should have error handling mechanisms to handle exceptions gracefully.
  &nbsp;

## **5. System Design**
### 5.1 Architecture Overview
[Provide an overview of the system's architecture, including any components or modules.]

### 5.2 Database Design

#### **Department Table**
#### **Department Table**
| #       | Type        | Notes     | Example      |
|---------|-------------|-----------|--------------|
| ID      | Guid        | Unique-PK | --           |
| Name    | varchar(50) | Unique    | IT           |
| Contact | Network     |           | 095444444    |
---
#### **Category Table**
| #       | Type        | Notes     | Example      |
|---------|-------------|-----------|--------------|
| ID      | Guid        | Unique-PK | --           |
| Name    | varchar(50) | Unique    | Software     |
| Description | varchar(255) |      | .....        |
---
#### **Product Table**
| #       | Type        | Notes     | Example      |
|---------|-------------|-----------|--------------|
| ID      | Guid        | Unique-PK | --           |
| Name    | varchar(50) | Unique    | IT           |
| Description | varchar(255) |      | Notes..      |
| CategoryId | Guid      |           | --           |
| Provider | varchar(50) |          | Adobe        |
 
---
#### **License Table**
| #       | Type        | Notes     | Example      |
|---------|-------------|-----------|--------------|
| ID      | Guid        | Unique-PK | --           |
| ProductId | Guid      |           | --          |
| SerialKey | varchar(100) |         | SADS23-FDSSD-SSS.. |
| StartDate | DateTime      |           | 1-01-2022    |
| ExpireDate | DateTime     |           | 1-01-2024    |
| NumOfDevices | int    |           | 10           |
| TimeType | int        |           | 1            |
| DepartmentId | Guid   |           | --            |
| Contact | varchar(100) |           | adobe@adobe.com |
| ImpactLevel | int    |           | 1            |
| ImpactDescription | varchar(255) | | this Software is very important.. |
| PriceInUSD | decimal(10,2) |       | 350.00       |
| PriceInLYD | decimal(10,2) |       | 1550.00      |

#### **Enum ImpactLevel**
| Short   | Type          | 
|---------|---------------|
| 1       | Catastrophic  | 
| 2       | Critical      |
| 3       | High          |
| 4       | Medium        |
| 5       | Low           |

#### - Impact Levels Description :
- **Catastrophic Impact:** This level signifies the most severe impact possible. It represents a complete system failure, causing substantial damage, compromising sensitive data, or posing a significant threat to safety, security, or compliance.
- **Critical Impact:** This level indicates a severe impact on operations or functionality. It may lead to complete system downtime, data loss, or significant financial or operational consequences.
- **High Impact:** This level represents a significant impact on operations or functionality. It may result in widespread disruptions, affecting a large number of users or critical processes.
- **Medium Impact:** This level signifies a moderate impact on operations or functionality. It may cause noticeable disruptions or affect a subset of users or processes.
- **Low Impact:** This level indicates that the product or issue has a minimal impact on operations or functionality. It may result in minor inconveniences or negligible disruptions.


#### *Enum TimeType*
| Short   | Duration      | 
|---------|---------------|
| 1       | Perpetual     | 
| 2       | Annual        |
| 3       | Monthly       |
| 4       | Quarterly     |
| 5       | Semi-annual   |
| 6       | Custom        |

#### - Time Type Description :
- *Perpetual:* A perpetual license grants the user the right to use the software indefinitely, without any time limitations. The license does not expire, and the user can continue to use the software without renewals.
- *Annual:* An annual license provides the user with the right to use the software for a specific period of one year. It requires renewal at the end of each year to continue using the software.
- *Monthly:* A monthly license allows the user to use the software for a duration of one month. It requires monthly renewals to maintain the license and continue using the software.
- *Quarterly:* A quarterly license provides the user with the right to use the software for a duration of three months. It requires renewal every quarter to continue using the software.
- *Semi-annual:* A semi-annual license allows the user to use the software for a duration of six months. It requires renewal twice a year to continue using the software.
- *Custom Duration:* Some licenses may have custom durations, such as 3-months, 6-months, 9-months, or other specific timeframes. These licenses offer flexibility in choosing a duration that suits the user's needs.


### 5.3 User Interface Design
[Check Attached Design.PDF] 


## **6. Appendices**
### 6.1 Glossary
[Include a glossary of terms and definitions used throughout the document.]

### 6.2 Use Case Diagram
[Insert a use case diagram illustrating the system's major use cases and actors.]

### 6.3 Class Diagram
[Include a class diagram depicting the system's class structure and relationships.]

### 6.4 Entity-Relationship Diagram
```csharp
public class Department
{
    public Guid ID { get; set; }
    public string Name { get; set; }
    public string Contact { get; set; }
}

public class Category
{
    public Guid ID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}

public class Product
{
    public Guid ID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Guid CategoryId { get; set; }
    public string Provider { get; set; }
}

public class License
{
    public Guid ID { get; set; }
    public Guid ProductId { get; set; }
    public string SerialKey { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime ExpireDate { get; set; }
    public int NumOfDevices { get; set; }
    public int TimeType { get; set; }
    public Guid DepartmentId { get; set; }
    public string Contact { get; set; }
    public int ImpactLevel { get; set; }
    public string ImpactDescription { get; set; }
    public decimal PriceInUSD { get; set; }
    public decimal PriceInLYD { get; set; }
}
```
[Include an entity-relationship (ER) diagram representing the system's data model, including entities, relationships, and cardinality.]
