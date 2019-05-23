# TestExamAssignment

This project includes the following tests:


Issues:

One problem that occured when working with my SQLite database, was that all the integrationstests failed in travis but not on my local develop environment. 

The error occures due to a missing sqlite.interop.dll file. Uppon researching why this file is missing, it appeared to be a common problem regarding what version of System.Data.SQLite I was running on my project. Due to not wanting to use too much time on the issue. I decided to accept the error in the CI chain for now. 

![alt text](https://i.gyazo.com/7111fac890d7f69abe6e2b8df1c9fc77.png)

Intergration test resulting in locked database:

As seen in the code I've tried to retrieve all the semesters in the database, but it appears to lock the database so the other database tests fails, with the exception of testing opening and closing the connection. So I've commented it out at the moment

![alt text](https://i.gyazo.com/0b292e9b2f33651f2d06fd60a6d13a09.png)
