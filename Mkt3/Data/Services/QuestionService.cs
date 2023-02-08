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

    public List<Group> GetAllGroups(string TopicID, string owner)
    {
       // using var ctx = new Mkt3Context();
        var groups = ctx.Groups.Where(g => g.TopicID == Convert.ToInt32(TopicID) && g.Owner == owner).OrderBy(g=>g.Name).ToList();
        groups.Add(new Group(owner) {ID=-1, Name="New Group..."});
        return groups;
    }
    
    public Group GetGroup(int? GroupID, string owner)
    {
        
        //using var ctx = new Mkt3Context();
        try
        {
            return ctx.Groups.First(g => g.ID == Convert.ToInt32(GroupID) && g.Owner == owner);
        }
        catch
        {
            return null;
        }
    }
    
    public async Task<int> UpdateGroup(Group group)
    {
        //using var ctx = new Mkt3Context();
        if (group.ID != null)
        {
            ctx.Groups.Update(group);
        }
        else
        {
            ctx.Groups.Add(group);
        }

        var i = await ctx.SaveChangesAsync();
        return group.ID.Value;

    }

    public async Task DeleteGroup(Group group)
    {
        //await using var ctx = new Mkt3Context();
        ctx.Groups.Remove(group);
        var qToUpdate =  ctx.Questions.Where(q => q.GroupID == group.ID).ToList();
        foreach (var q in qToUpdate)
        {
            q.GroupID = null;
        }
        await ctx.SaveChangesAsync();
    }

    public async Task<Topic> GetTopicsByID(int topicID)
    {
        //await using var ctx = new Mkt3Context();
        var topic = ctx.Topics.First(t => t.ID == topicID);
        return topic;
    }

    public async Task<List<Topic>> GetTopics(string userID)
    {
        //await using var ctx = new Mkt3Context();
        var topics = ctx.Topics.Where(t=>t.Owner==userID).OrderBy(e=>e.Course).ToList();
        return topics;
    }

    public async Task<bool> UpdateTopic(Topic topic)
    {
        //await using var ctx = new Mkt3Context();
        ctx.Topics.Update(topic);
        await ctx.SaveChangesAsync();
        return true;
    }

    public async Task AddTopic(string TopicName)
    {
        try
        {
            //await using var ctx = new Mkt3Context();
            var t = new Topic { Course = TopicName, Name = "Default Pool" };
            ctx.Topics.Add(t);
            await ctx.SaveChangesAsync();
        }
        catch (Exception e)
        {
           Debug.WriteLine(e); 
        }

    }
    
    
 
    public async Task<bool> Update(Question? question, int topicID)
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
    public async Task<bool> Delete(Question question)
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