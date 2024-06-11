public interface IStudentProccesRepository
{
    Student getStudent(int Id);
    List<Student> getStudents();
    void addStudent(NewStudent student);
    bool removeStudent(int Id);
    bool updateStudent(UpdateStudent student);
}