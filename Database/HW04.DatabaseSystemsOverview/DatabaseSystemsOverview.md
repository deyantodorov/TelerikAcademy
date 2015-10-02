**1. What database models do you know?**

1.	Relational database management systems
2.	Non relational database management systems


**2. Which are the main functions performed by a Relational Database Management System (RDBMS)?**

 1. Relation to tables. There are three types of relations:
	- One-to-One
	- One-to-Many
	- Many-to-Many

**3. Define what is "table" in database terms.**

All data are aranged in rows and columns. In which every rows have the same data type as previous row.

**4. Explain the difference between a primary and a foreign key.**

 - **Primary key** is connected to current table column
 - **Foreign key** is connected with foreign table column

**5. Explain the different kinds of relationships between tables in relational databases.**

 - One-to-one - specific row from column in table is connected to only one specific row from column on different table. Connection is unique and can be occupied only from one cell in each table. For example, one companay can have only one VAT number.
 - One-to-many - one table cell can be connected to many other cells in different table. For example, scientist titles can be used on many different persons.
 - Many-to-many - for example orders and products in some shop. One order can have many products and many orders can have one product.
 - Self-relationship - for example employers company hierarchy. In table Employers we can have column with relation to different row for supervisor, director, CEO and etc.

**6. When is a certain database schema normalized? What are the advantages of normalized databases?**

One table is normalized when we don't have repetitions of information. There are 6 levels of normalizations:

1.	**First normal form**:
    - Data is stored in tables
    - Fields in rows are atomic (inseparable) values 
    - There are no repetition within single row
    - A primary key is defined for each table

2.	**Second normal form**:
    - All requirement from 1-st normal form
    - There are no columns that do not depend on part of the primary key 

3. **Third normal form**:
    - All requirements from 2-nd normal form
    - The only dependencies between columns are of type "a column depends on personal key"

4. **Fourth normal form**:
    - All requirements from 3-rd normal form
    - There is one column at most in each table that can have many possible values for single key (multi-valued attribute)


**7. What are database integrity constraints and when are they used?**

Ensure data integrity in database tables. 

1. Primary key constraint
2. Unique key constraint
3. Foreign key constraint
4. Check constraint

**8. Point out the pros and cons of using indexes in a database.**

 - **Pros**: Speed up searching
 - **Cons**: adding and deleting records in indexed tables is slower

**9. What's the main purpose of the SQL language?**

 - **DDL** (data definition language) - CREATE, ALTER, DROP commands
 - **DML** (data manipulation language) - SELECT, INSERT, UPDATE DELETE or CRUD operations

**10. What are transactions used for? Give an example.**

Sequence of database operations which are executed as a single unit. For example, withdrawing money from ATM. We could make analogy with asynchonious programming where we use locking. We should be carefull with "Dead Lock" when we work in transaction mode.

**11. What is a NoSQL database?**

A NoSQL (originally referring to "non SQL" or "non relational") database provides a mechanism for storage and retrieval of data that is modeled in means other than the tabular relations used in relational databases.

**12. Explain the classical non-relational data models.**

Use document-base model. Scheme free document storage. Still support CRUD (create, read, update, delete). Indexing and querying support, concurrency and transactions. Optimized for append / retrieve. Great performance and scalability. "No SQL" is equal to Non SQL or Not only SQL.

**13. Give few examples of NoSQL databases and their pros and cons.**

1. Examples:
 - MongoDB
 - Redis
 - Cassandra

2. Pros & Cons:
 - Pros: Easy escalation
 - Cons: data stored as documents, single entity is single document