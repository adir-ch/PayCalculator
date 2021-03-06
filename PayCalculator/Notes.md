This document contains some notes about the architecture and design decisios I've made while working on the project. In addition this document contains some notes about the code and how to use / extend it.

This document will be updated during my work.

### Architecture and Design decisions ###

- Architecture is aimed to present a typical enterprise application.
- The main goal is to build an easily maintainable, extendable nd scalable application using SOLID design and coding principles.
- The system structure will be built following the Domain Driven Design rich model principles (data is not separated from the logic).
- The purpose is to first design a model, and build the application according to the common language that is presented in the model.
- Each service is a standalone service that can be stored separately
- Business services will not include business rules.
- Business object contain the business logic and does not perform CRUD operations.
- The business object will be created by a DAO object (rich model).
- All the application's components can be extended (business behavior, services and DOA's).
- The different locations salary calculation was done as part of the application's extensions.


### General Coding notes ###

- The client is a simple class that run different scenarios on the code, in real apps it can be WebApp or WPF app, since the server is accessible via WebApi (fake WebApi).
- The WebApi are a simple class that mimics a web api, and was done only to separate the client form the server.
- The contracts should be available for both Client and Server.
- Best practice is to write the contracts using some scripting language or XML (with contract schema), and generate the contract classes using a class generator.
- All the hard coded values in the code should be taken from an external DB.
- The Data layer object are called DAO's since they represent a data access object.
- A business object will always get created by the DAO, a service will never create a business object (DDD).
- Tests are implemented for business object only.
- The test should cover the entire code, but since time is limited, tests are not implemented for the skeleton classes (such as fake DB or webapi).
- I should have called BusinessObjects project BusinessComponents :-(
- Setting the data in the contracts as is (not doing any conversion), in real life application it should be converted by the
serializes / deserializers - which I do not implement here (for simplicity purpose).
- Contract request / response validation should be done after deserialize (according to a schema). All data arriving to the server service should be already valid.
- Abstract classes are tested through testing the derived classes.
- Australian tax offset - if calculated tax is smaller than 445, I've set the tax to 0 (unless you get money for earning low income - didn't really know what to do...).

### Error handling ###

- A Service error response will be sent back to the client if the server had an exception. It is the client responsibility to handle to error response correctly (since I've implemented a thin client, I only implemented basic error handling).
- Didn't waste time on creating my own exception and used the .NET ones.

### Testings ###

- I've created tests for an Australian employee, and not for the rest, since the tests are almost identical. 

### Integration tests ###

- Integration tests are actually an end to end test.
- Those test can be also refereed to as behavioral test, since they check the results without all the small steps in between.
- The principle is to send a request and compare the response to should-be (or expected) response.
- I've created an Integration test for each service.
- In real life application, the test will also use the actual WebApi when running the test.

### 3rd party ###

- Dependency injection - Unity
- Testing framework - NUnit + Moq
- WebApi - Created a fake WebApi service
- DB - created a hash table that represents a memory DB.

