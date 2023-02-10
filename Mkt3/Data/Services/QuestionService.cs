using System.ComponentModel;
using System.Diagnostics;
using Humanizer;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace Mkt3.Data;

public class QuestionService
{

    private readonly Mkt3Context ctx;

    public QuestionService(Mkt3Context _ctx)
    {
        ctx = _ctx;
    }
    public async Task<List<Question>> GetQuestionsByTopic(int topicID, string owner)
    {

        //var topicID = ctx.Topics.Where(t => t.Course == course && t.Name == topic).Select(t => t.ID).ToList();

        var questionID = ctx.QuestionTopics.Where(qt => topicID == (qt.TopicID)).Select(q=>q.QuestionID).ToList();
        var questions = ctx.Questions.Where(q => questionID.Contains(q.ID) && q.Owner == owner)
            .OrderBy(q=>q.Prompt).ToList();
    
        foreach(var q in questions)
        {
            try
            {
                q.Group = ctx.Groups.First(g => g.ID == Convert.ToInt32(q.GroupID)).Name;
            }
            catch
            {
                q.Group = "";
            }
        }
        
        return questions;
    }


    public async Task<Question?> GetQuestionAsync(string QuestionID, string owner)
    {
      //  await using var ctx = new Mkt3Context();
        return ctx.Questions.FirstOrDefault(q => q.ID == Convert.ToInt32(QuestionID) && q.Owner == owner);
    }
    
    public async Task<bool> UpdateQuestion(Question? question, int topicID)
    {
        //await using var ctx = new Mkt3Context();
        bool isNew = false;
        if (string.IsNullOrEmpty(question.QuestionLabel)) return false;
        try
        {


            if (question.ID != 0)
            {
                ctx.Questions.Update(question);

            }

            else
            {
                ctx.Questions.Add(question);
                isNew = true;

            }

            var i = await ctx.SaveChangesAsync();
            if (!isNew) return true;
            ctx.QuestionTopics.Add(new QuestionTopic { QuestionID = question.ID, TopicID = topicID });
            i = await ctx.SaveChangesAsync();

            return true;
        }
        catch
        {
            return false;
        }
    }
    public async Task<bool> DeleteQuestion(Question question)
    {
        try
        {
            //await using var ctx = new Mkt3Context();
            ctx.Questions.Remove(question);
            await ctx.SaveChangesAsync();
        }
        catch
        {
            return false;
        }

        return true;
    }
    
}