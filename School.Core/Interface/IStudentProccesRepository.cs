public interface IStudentProccesRepository
{
    Student getStudent(int Id);
    List<Student> getStudents();
    bool addStudent(NewStudent student);
    bool removeStudent(int Id);
    string updateStudent(UpdateStudent student);
    string login(string username, string password);
}