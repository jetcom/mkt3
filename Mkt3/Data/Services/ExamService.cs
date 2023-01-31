using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Mkt3.Data;

public class ExamService
{
   private bool Loading;

   
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