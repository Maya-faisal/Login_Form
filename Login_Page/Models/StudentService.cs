namespace Login_Page.Models
{
    public class StudentService
    {
        private static List<Student> students = new List<Student>();

        public List<Student> GetStudents()
        {
            return students;
        }

        public void AddStudent(Student student)
        {
            students.Add(student);
        }

        public void DeleteStudent(Student student)
        {
            students.Remove(student);
        }

    }
}
