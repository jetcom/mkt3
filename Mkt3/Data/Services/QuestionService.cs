namespace Mkt3.Data;

public class QuestionService
{

    private List<Question> questionList = new()
    {

        new Question
        {
            QuestionID = "stddev", type = "Short Answer", Prompt = "What is the stdDev of 5 and 6",
            Solutions = new List<string> {"no idea"}, Points = 1
        },
        new Question { QuestionID = "TFTest", type = "True/False", Prompt = "This will work", Solutions = new List<string> {"False"}, Points = 1 },
        new Question
        {
            QuestionID = "SATest2", type = "Short Answer", Prompt = "Will this work?",  Solutions = new List<string> {"Maybe"}, Points = 5
        }
    };

    public async Task<Question[]> GetQuestionsByBank(string bank)
    {
        return questionList.ToArray();

   


    }


    public Task<Question> GetQuestionAsync(string QuestionID)
    {
        return Task.FromResult(questionList.First(q => q.QuestionID == QuestionID));
    }


 
    public async Task<bool> SaveQuestion(Question question)
    {

        try
        {
            
            // at this point it needs to be committed to the db, it's already updated the internal data
            
            
            //saq = question;
            /*   repeater.Date = DateTime.Now;
               var pushRepeaterDefinition = Builders<History>
                   .Update.Push(h => h.RepeaterHistory, previousState);
               var updateOptions = new UpdateOptions { IsUpsert = true};
               await repeaterHistory.UpdateOneAsync(h => h._id == previousState._id, pushRepeaterDefinition, updateOptions); 
                       
   
               if (repeater._id != null)
               {
                   await collection.ReplaceOneAsync(r => r._id == repeater._id, repeater);
               }
               else
               {
                   await collection.InsertOneAsync(repeater);
   
               }
               return true;*/
            return true;
        }
        catch
        {
            return false;
        }
    }

    
}