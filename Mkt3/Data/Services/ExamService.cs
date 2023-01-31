using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Mkt3.Data;

public class ExamService
{
   private bool Loading;

   public async Task<List<Exam>> getAllExams()
   {
      await using var ctx = new Mkt3Context();
      var exams = ctx.Exams.OrderBy(e=>e.courseNumber).ToList();
      return exams;
   }

   
   public async Task<Exam?> getExam(string courseID, string examID)
   {

      await using var ctx = new Mkt3Context();

      try
      {
         var exam = ctx.Exams
            .Single(e => e.examID == examID && e.courseNumber == courseID);
         return exam;
      }
      catch
      {
         return null;
      }
      
      
   }
   
 }