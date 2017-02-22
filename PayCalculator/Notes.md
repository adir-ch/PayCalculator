This document contains some notes about the architecture and design decisios I've made while working on the project. In addition this document contains some notes about the code and how to use / extend it.

This document will be updated during my work.

### Architecture and Design decisions ###

- Architecture is aimed to present a typical enterprise application.
- The system structure was build following the Domain Driven Design principles.

### General Coding notes ###

- The contracts should be available for both Client and Server.
- Best practice is to write the contracts using some scripting language or XML (with contract schema), and generate the contract classes using a class generator.
- All the hard coded values in the code should be taken from an external DB.

