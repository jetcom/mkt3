using System.ComponentModel;
using Humanizer;
using Microsoft.EntityFrameworkCore;

namespace Mkt3.Data;

public class QuestionService
{



    public async Task<List<Question>> GetQuestionsByTopic(int topicID)
    {
        await using var ctx = new Mkt3Context();

        //var topicID = ctx.Topics.Where(t => t.Course == course && t.Name == topic).Select(t => t.ID).ToList();

        var questionID = ctx.QuestionTopics.Where(qt => topicID == (qt.TopicID)).Select(q=>q.QuestionID).ToList();
        var questions = ctx.Questions.Where(q => questionID.Contains(q.ID)).ToList();

        foreach(var q in questions)
        {
            var tagIDs = ctx.QuestionTopics.Where(qt => qt.QuestionID == q.ID).Select(q=>q.TopicID).ToList();
            foreach (var tag in ctx.Topics.Where(t => tagIDs.Contains(t.ID)).ToList())
            {
           
                q.ExamTags.Add(tag.Course + " "+tag.Name);
                
            }
        }
        

       /* var query= from article in db.Articles
            where article.Categories.Any(c=>c.Category_ID==cat_id)
            select article;*/
        //var query= ctx.QuestionTopics.Where(qt=>qt.TopicID=topic).SelectMany(c=>);
        
        
      /*  var tid = ctx.QuestionTopics.First(top => top.Course == course && top.Name == topic);
        // var tags = context.Posts.Where(post => post.Tags.All(tag => tagIds.Contains(tag)));
        var questions = ctx.Questions.Where(q => )
            // return exams;*/
        return questions;
    }


    public async Task<Question?> GetQuestionAsync(string QuestionID)
    {
        await using var ctx = new Mkt3Context();
        return ctx.Questions.First(q => q.QuestionLabel == QuestionID);
    }

    public async Task<Topic> GetTopicsByID(int topicID)
    {
        await using var ctx = new Mkt3Context();
        var topic = ctx.Topics.First(t => t.ID == topicID);
        return topic;
    }
    
    public async Task<List<Topic>> GetTopics()
    {
        await using var ctx = new Mkt3Context();
        var topics = ctx.Topics.OrderBy(e=>e.Course).ToList();
        return topics;
    }

    public async Task<bool> UpdateTopic(Topic topic)
    {
        await using var ctx = new Mkt3Context();
        ctx.Topics.Update(topic);
        await ctx.SaveChangesAsync();
        return true;
    }
 
    public async Task<bool> Update(Question? question, int topicID)
    {
        await using var ctx = new Mkt3Context();
        
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
                
            }

            var i = await ctx.SaveChangesAsync();
            ctx.QuestionTopics.Add(new QuestionTopic {QuestionID = question.ID, TopicID = topicID});
            i = await ctx.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }
    public async Task<bool> Delete(Question question)
    {
        try
        {
            await using var ctx = new Mkt3Context();
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