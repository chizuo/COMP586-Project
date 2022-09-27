# Proposal for COMP 586 Object Oriented Software Development 
## Fall 2022 term project
### Contributors: 
- [Jacob Asaad](https://github.com/Jacob-Asaad)
- [Jonathan Chua](https://github.com/chizuo)
- [Harshleen Sadnani](https://github.com/harshleen8) 
- [Brandon Sorto](https://github.com/Brandon-CSUN)
<br><br>
# Topic
Our group will be implementing a university class student registration system. The software system will be implemented using a three-tier architecture[1](https://www.ibm.com/cloud/learn/three-tier-architecture#toc-what-is-th-tyaDx4QJ). The software system will be implementing business logic within the domain of the faculty and students who are matriculated into the school system (e.g. non-matriculated students will not be considered.).While a software system like this, are normally a functional portion of the greater system (e.g. used to calculate GPA, classes still required to fulfill the requirements of a degree, et al.) for a university, we will design the system to permit the logical inclusion but not implement those parts. Therefore, the primary requirements that the software system must satisfy would be to implement the necessary logical constraints that determine whether or not a professor can be assigned to teach a course and whether or not a student can successfully register to a course. Including, the option to...
- ...override constraints based on an add number. 
- ...have a privilege user, professor for that class or the department chair, be able to generate an add number for that class.
- ...once a generated add number is consumed, it will no longer be useable.
<br><br>
# Motivations
The goal of this term project, and therefore the motivation, is to showcase our understanding of software stacks that are commonly expected in today’s market of software engineers.Apply software engineering concepts to govern our approach. Apply design patterns that are applicable to each tier, to satisfy the principled engineering concept of reusing trusted solutions to adress commonly occurring problems. Finally, the less abstract goal to implement a more extensible waitlist than the current model used by C.S.U.N.
# Problem this Project Attempts to Solve
Lorem Ipsum
<br><br>
# Description of Deliverables
## The Software System will implement the following:
- Feature 1
  - Sub-feature 1
- Feature 2
  - Sub-feature 1
<br><br>
## The Software System comprised of the following deliverables:
- The frontend application that represents the presentation tier[2](https://www.ibm.com/cloud/learn/three-tier-architecture#toc-the-three--iwvUcK4b). Thus all of its code & supporting documentation.
- The RESTful Web Service where the core application logic exists, that represents the application tier[2](https://www.ibm.com/cloud/learn/three-tier-architecture#toc-the-three--iwvUcK4b). The service acts as a database abstraction layer[3](https://en.wikipedia.org/wiki/Database_abstraction_layer) and therefore should be designed with the intent of being database agnostic for the frontend application. Thus all of its code & supporting documentation.
- The database as the persistent storage solution, a.k.a. the data tier[2](https://www.ibm.com/cloud/learn/three-tier-architecture#toc-the-three--iwvUcK4b). The database deliverable will include all stored procedures that abstract and encapsulate the database, the build script, and model.

