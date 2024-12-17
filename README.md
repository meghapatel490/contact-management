# contact-management

Setup instructions : 
- Install .Net 8.0

How to run the application :
- Run application Ctrl + F5
  
A brief explanation of design decisions and application structure
- Separated business logic using interface and use dependency injection to inject in controller. (Single responsibility)
- Reuse the business logic service at various places
- Do not add business logic in controller for better readability and separated business logic using interface
- Added api validation in the model using data annotation
- Added common exception handler for setting own error message to use it all apis and registerd in program file
- Added CORS policy to alllow access for angular (third party domain)

Performance Considerations:
 - Using a modular, loosely coupled architecture that can be useful for performance improvement
 - We can use async/await for asyncronous tasks for long running or lengthy process
 - We csn use cloud-based security solutions for scalability
