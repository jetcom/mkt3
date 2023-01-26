namespace Mkt3.Data;

public class QuestionService
{

    private List<Question> questionList = new()
    {

        new Question
        {
            QuestionID = "stddev", type = "ShortAnswer", Prompt = "What is the stdDev of 5 and 6",
            Solution = "no idea", Points = 1
        },
        new Question { QuestionID = "TFTest", type = "TF", Prompt = "This will work", Solution = "False", Points = 1 },
        new Question
        {
            QuestionID = "SATest2", type = "ShortAnswer", Prompt = "This will work", Solution = "Maybe", Points = 5
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


 
    public async Task<bool> SaveShortAnswerQuestion(Question question)
    {

        try
        {
            
            var oldQuestion = (from q in questionList where q.QuestionID == question.QuestionID select q).First<Question>();
            oldQuestion = question;
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


    public async Task<bool> SaveTFQuestion(Question question)
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