namespace Mkt3.Data;

public class QuestionService
{

    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private ShortAnswerQuestion saq = new()
    {
        QuestionID = "Test1", Points = 1, Prompt = "What is the standard deviation of the universe", Solution = "42.3"
    };

    public Task<Question> GetQuestionAsync(string QuestionID)
    {
        var q1 = new Question() { QuestionID = "Test1", Points = 3, Prompt = "Answer this!", Solution = "No!" };
        return Task.FromResult(q1);
    }

    public Task<TrueFalseQuestion> GetTFQuestionAsync(string QuestionID)
    {
        var q1 = new TrueFalseQuestion()
            { QuestionID = "Test1", Points = 1, Prompt = "This is a TF Question", Solution = false };
        return Task.FromResult(q1);
    }

    public Task<ShortAnswerQuestion> GetShortAnswerQuestion(string QuestionID)
    {
        return Task.FromResult(saq);

    }

    public async Task<bool> SaveShortAnswerQuestion(ShortAnswerQuestion question)
    {

        try
        {
            saq = question;
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


    public async Task<bool> SaveTFQuestion(TrueFalseQuestion question)
    {

        try
        {
            return true;
        }
        catch
        {
            return false;
        }
    }
}