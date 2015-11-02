namespace StudentSystem.Api.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using StudentSystem.Api.Models;
    using StudentSystem.Models;

    [RoutePrefix("api/student")]
    public class StudentController : BaseApiController
    {
        [HttpGet]
        [Route("get")]
        public IHttpActionResult Get()
        {
            var students = this.Data.Students.All()
                .Select(x => new
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                });

            return this.Ok(students);
        }

        [HttpGet]
        [Route("get/{id:int}")]
        public IHttpActionResult Get(int id)
        {
            var student = this.Data.Students.GetById(id);

            if (student != null)
            {
                var result = new
                {
                    FirstName = student.FirstName,
                    LastName = student.LastName
                };

                return this.Ok(result);
            }

            return this.NotFound();
        }

        [HttpPost]
        [Route("post")]
        public IHttpActionResult Post(StudentModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest("Incorrect data");
            }

            var student = new Student
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                StudentInfo =
                {
                    Address = model.Address,
                    Email = model.Email
                }
            };

            this.Data.Students.Add(student);
            this.Data.SaveChanges();

            return this.Ok("Record added");
        }

        [HttpPut]
        [Route("update/{id:int}")]
        public IHttpActionResult Update(int id, StudentModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest("Invalid model");
            }

            var student = this.Data.Students.GetById(id);

            if (student == null)
            {
                return this.NotFound();
            }

            student.FirstName = model.FirstName;
            student.LastName = model.LastName;
            student.StudentInfo.Address = model.Address;
            student.StudentInfo.Email = model.Email;

            this.Data.Students.Update(student);
            this.Data.SaveChanges();

            return this.Ok("Updated");
        }

        [HttpDelete]
        [Route("delete/{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            var student = this.Data.Students.GetById(id);

            if (student == null)
            {
                return this.NotFound();
            }

            this.Data.Students.Delete(student);
            this.Data.SaveChanges();

            return this.Ok("Deleted");
        }
    }
}