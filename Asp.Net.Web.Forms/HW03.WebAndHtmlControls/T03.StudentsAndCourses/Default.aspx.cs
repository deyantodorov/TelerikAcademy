using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace T03.StudentsAndCourses
{
    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.University.Items.Count == 0)
            {
                this.University.Items.Add("Select University");
                this.Specialty.Items.Add("Select Specialty");
                this.Courses.Attributes.Add("style", "height: 150px");

                for (int i = 0; i < 10; i++)
                {
                    this.University.Items.Add("University" + i);
                    this.Specialty.Items.Add("Specialty" + i);
                    this.Courses.Items.Add("Courses" + i);
                }
            }
        }

        protected void RegisterUser_Click(object sender, EventArgs e)
        {
            userRegistrationInfo.Visible = true;

            var h1 = GetTitle();
            userRegistrationInfo.Controls.Add(h1);

            var firstName = GetParagraph(this.txtFirstName.Text, "First name: ");
            userRegistrationInfo.Controls.Add(firstName);

            var lastName = GetParagraph(this.txtLastName.Text, "Last name: ");
            userRegistrationInfo.Controls.Add(lastName);

            var university = GetParagraph(this.University.SelectedValue, "University: ");
            userRegistrationInfo.Controls.Add(university);

            var specialty = GetParagraph(this.Specialty.SelectedValue, "Specialty: ");
            userRegistrationInfo.Controls.Add(specialty);
            
            var courseNames = (from ListItem item in this.Courses.Items where item.Selected select item.Text).ToArray();
            var course = GetParagraph(string.Join(", ", courseNames), "Courses: ");
            userRegistrationInfo.Controls.Add(course);
        }

        private static HtmlGenericControl GetParagraph(string text, string label)
        {
            var p = new HtmlGenericControl()
            {
                TagName = "p",
                InnerText = label
            };

            var strong = new HtmlGenericControl()
            {
                TagName = "strong",
                InnerText = text,
            };

            p.Controls.Add(strong);

            return p;
        }

        private static HtmlGenericControl GetTitle()
        {
            var h1 = new HtmlGenericControl
            {
                TagName = "h1",
                InnerText = "Student information is:"
            };

            h1.Attributes.Add("class", "title");
            return h1;
        }
    }
}