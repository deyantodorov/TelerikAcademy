Hi,

You could test it with simple Postman, Fiddler or any other similar tool. Of course run application first.

Because in conditions it's not specified what type of services I should add I udded just fiew simple services:

http://localhost:{yourport}/api/student/get/ - get all students

http://localhost:{yourport}/api/student/get/1/ - get student with id 1

http://localhost:{yourport}/api/student/post/ - add student in db

http://localhost:{yourport}/api/student/update/id - update record json with new data

Content-Type: application/json

Example JSON:
{
	"FirstName":"FirstName",
	"LastName":"LastName",
	"Address":"Address",
	"Email":"Email",
}

The same options for Courses