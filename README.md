# TestExamAssignment

My main goal of this assignment was to do testdriven development using stub. I created the tests and implemented the methods with a "NotImplemented" exception thrown. The test would fail. I then worked on the method to make the test succeed. 

Current tests in the project
- Unit tests
- Integration tests
- Regression tests

There are no nonfunctional tests.

I used my time on the backend part of the project, but my goal was to eventually make it web based and then use selenium for the UI tests.
Due to not having an UI, some tests were unable to be done, such as a smoketest and acceptance test

Had the UI been implemented, the next step would be to include
- UI tests
- Smoke Test
- Acceptance Test

As well as relevant nonfunctional tests.

All the tests were written in Xunit in C#. I created a seperate test database for integration testing, which is located in the TestExamAssignment\TestExamAssignment.XTest\bin\Debug folder.


(Trello)

![alt text](https://i.gyazo.com/4bd46d5564a7ad0c1f6fc6f845df7012.png)
I broke down the customer requirments into specific usertasks. For this I used Trello. I added bulletpoints on each task with specific requirments related to the task. 

I tried doing the usertasks in cucumber, but due to the time contrains I eventually decided to break down the tasks manually.


(GIT)

I've created an additional branch called develop. The reason I've done this is because I find it ineffective to run travis everytime I do a push to the github repository. The goal is to only run travis whenever I do a pull from the develop branch into the master branch. This also allows others to do code reviews on my code and approve it. This might not be relevant as I am a solo group, but at least I avoid a million small builds ;).

Link for Travis CI.
https://travis-ci.com/Darkeonz/TestExamAssignment


Issues:

(Entity framework)

I am a big fan of the entity framework as it allows a user to do a lot with just a few Lambda expressions. Due to the fact that I choose to use a SQLite database, and that the frameworks newer versions doesn't allow to do a Code First approach to an SQLite database, I had to abandon the framework. It was either abandon the SQLite database or the framework. I decided to keep the database and interact with it in a more "old fashion" kind of way. I do feel strongly that the Entity Framework is a great and easily tested framework due to it's simple methods.  

The first problem I ran into was errors with the Travis instructions file and Xunit, as it the documentation for using Xunit with Travis is very dated. Several versions of Xunit would not work with travis and the build would fail everytime it build it. Eventually through much research, I discovered that xunit.runner.console -Version 2.4.1 worked for others with the same issue. 

One problem that occured when working with my SQLite database, was that all the integrations tests failed in travis but not on my local development environment. 

The error occures due to a missing sqlite.interop.dll file. Uppon researching why this file is missing, it appeared to be a common problem regarding what version of System.Data.SQLite I was running on my project. Due to not wanting to use too much time on the issue. I decided to accept the error in the CI chain for now. 

![alt text](https://i.gyazo.com/7111fac890d7f69abe6e2b8df1c9fc77.png)

- Intergration test resulting in locked database:

As seen in the code I've tried to retrieve all the semesters in the database, but it appears to lock the database so the other database tests fails, with the exception of testing opening and closing the connection. So I've commented it out at the moment

![alt text](https://i.gyazo.com/0b292e9b2f33651f2d06fd60a6d13a09.png)


