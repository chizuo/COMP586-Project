# Proposal for COMP 586 Object Oriented Software Development 
## Fall 2022 term project
### Contributors: 
- [Jacob Asaad](https://github.com/Jacob-Asaad)
- [Jonathan Chua](https://github.com/chizuo)
- [Harshleen Sadnani](https://github.com/harshleen8) 
- [Brandon Sorto](https://github.com/Brandon-CSUN)
<br><br>
# Topic
Our group will be implementing a university class student registration system. The software system will be implemented using a three-tier architecture[[1]](https://www.ibm.com/cloud/learn/three-tier-architecture#toc-what-is-th-tyaDx4QJ). The software system will be implementing business logic within the domain of the faculty and students who are matriculated into the school system (e.g. non-matriculated students will not be considered.).While a software system like this, are normally a functional portion of the greater system (e.g. used to calculate GPA, classes still required to fulfill the requirements of a degree, et al.) for a university, we will design the system to permit the logical inclusion but not implement those parts. Therefore, the primary requirements that the software system must satisfy would be to implement the necessary logical constraints that determine whether or not a professor can be assigned to teach a course and whether or not a student can successfully register to a course. Including the option to...
- ...override constraints based on an add-number. 
- ...have a privileged user, professor for that class or the department chair, be able to generate an add-number for that class.
- ...once a generated add-number is consumed, it will no longer be usable.
<br><br>
# Motivations
The goal of this term project, and therefore the motivation, is to showcase our understanding of software stacks that are commonly expected in today’s market of software engineers.Apply software engineering concepts to govern our approach. Apply design patterns that are applicable to each tier, to satisfy the principled engineering concept of reusing trusted solutions to address commonly occurring problems. Finally, the less abstract goal is to implement a more extensible waitlist than the current model used by C.S.U.N.
<br><br>
# Problem this Project Attempts to Solve
Our software attempts to facilitate the orchestration of a university course registration process that involves course creation, constraint enforcement, constraint overrides, student registration, and faculty assignments.
<br><br>
# Description of Deliverables
## The Software System will have the following requirements:
- Faculty Requirements
  - The system shall permit the faculty that is assigned to the course, to generate add-numbers that override student registration constraints.
- Student Requirements
  - The system shall permit a student to register for a course.
  - The system shall prevent a student from registering for a course if the student does not meet the pre-requisites.
  - The system shall permit a student to override any constraints to registering for a course if the student provides an add-number.
- Department Chair (or privileged user)
  - The system shall permit the department administrator to create courses within their department.
  - The system shall permit the department administrator to assign a faculty member to a course.
  - The system shall prevent the department administrator from assigning a faculty to a course if it conflicts with the faculty's existing schedule.
    - conflict of schedule is defined by having a course assigned to the faculty within 1 hour, before or after, an already assigned course.
- Course Requirements
  - The system shall prevent students from registering to the course when the student enrollment maximum limit is reached.
  - The system shall add interested students to a waitlist.
    - The system shall order the student waitlist, by default, based on student academic level
      - Student academic levels are: Graduate, Senior, Junior, Sophomore, or Freshman
    - The system shall contain other ordering options that include:
      - Order by waitlist entry time stamp.
<br><br>
## The Software System comprised of the following deliverables:
- The frontend application that represents the presentation tier[[2]](https://www.ibm.com/cloud/learn/three-tier-architecture#toc-the-three--iwvUcK4b). Thus all of its code & supporting documentation.
- The RESTful Web Service where the core application logic exists, that represents the application tier[[2]](https://www.ibm.com/cloud/learn/three-tier-architecture#toc-the-three--iwvUcK4b). The service acts as a database abstraction layer[[3]](https://en.wikipedia.org/wiki/Database_abstraction_layer) and therefore should be designed with the intent of being database agnostic for the frontend application. Thus all of its code & supporting documentation.
- The database as the persistent storage solution, a.k.a. the data tier[[2]](https://www.ibm.com/cloud/learn/three-tier-architecture#toc-the-three--iwvUcK4b). The database deliverable will include all stored procedures that abstract and encapsulate the database, the build script, and model.

