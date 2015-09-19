namespace VisitorPattern
{
    public class VacationVisitor:IVisitor
    {
        public void Visit(Element element)
        {
            var employee = element as Employee;

            if (employee != null)
            {
                employee.VacationDays += 5;
            }
        }
    }
}