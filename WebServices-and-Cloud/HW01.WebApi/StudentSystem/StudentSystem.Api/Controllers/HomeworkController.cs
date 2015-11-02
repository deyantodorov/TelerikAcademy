namespace StudentSystem.Api.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using StudentSystem.Api.Models;
    using StudentSystem.Models;

    [RoutePrefix("api/homework")]
    public class HomeworkController : BaseApiController
    {
        [HttpGet]
        [Route("get")]
        public IHttpActionResult Get()
        {
            var items = this.Data.Homeworks.All()
                .Select(x => new HomeworkModel()
                {
                    FileUrl = x.FileUrl,
                    TimeSent = x.TimeSent,
                    StudentId = x.StudentId,
                    CourseId = x.CourseId
                });

            if (!items.Any())
            {
                return this.NotFound();
            }

            return this.Ok(items);
        }

        [HttpGet]
        [Route("get/{id:int}")]
        public IHttpActionResult Get(int id)
        {
            var item = this.Data.Homeworks.GetById(id);

            if (item != null)
            {
                var result = new HomeworkModel()
                {
                    FileUrl = item.FileUrl,
                    TimeSent = item.TimeSent,
                    StudentId = item.StudentId,
                    CourseId = item.CourseId
                };

                return this.Ok(result);
            }

            return this.NotFound();
        }

        [HttpPost]
        [Route("post")]
        public IHttpActionResult Post(HomeworkModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest("Incorrect data");
            }

            // Just adding first student and course 
            var item = new Homework()
            {
                FileUrl = model.FileUrl,
                TimeSent = DateTime.Now,
                StudentId = this.Data.Students.All().First().Id,
                CourseId = this.Data.Courses.All().First().Id
            };

            this.Data.Homeworks.Add(item);
            this.Data.SaveChanges();

            return this.Ok("Record added");
        }

        [HttpPut]
        [Route("update/{id:int}")]
        public IHttpActionResult Update(int id, Homework model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest("Invalid model");
            }

            var item = this.Data.Homeworks.GetById(id);

            if (item == null)
            {
                return this.NotFound();
            }

            item.FileUrl = model.FileUrl;
            item.TimeSent = model.TimeSent;

            this.Data.Homeworks.Update(item);
            this.Data.SaveChanges();

            return this.Ok("Updated");
        }

        [HttpDelete]
        [Route("delete/{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            var item = this.Data.Homeworks.GetById(id);

            if (item == null)
            {
                return this.NotFound();
            }

            this.Data.Homeworks.Delete(item);
            this.Data.SaveChanges();

            return this.Ok("Deleted");
        }
    }
}