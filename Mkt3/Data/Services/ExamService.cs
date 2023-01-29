namespace Mkt3.Data;

public class ExamService
{

   public async Task<Exam> getExam()
   {
      return new Exam()
      {
         courseName = "Test Course",
         courseNumber = "CSCI.001",
         examName = "Test Exam",
         maxPoints = 100,
         term = "Spring 2023",
         useCheckboxes = true,
         defaultPoints = 1,
         defaultSolutionSpace = "2.5in",
         defaultLineLength = "3in",
         department = "Test Department",
         school = "Made up school of technology"
      };
   }

 
}