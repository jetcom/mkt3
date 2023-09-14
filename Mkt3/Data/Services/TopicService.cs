using System.ComponentModel;
using System.Diagnostics;
using Humanizer;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace Mkt3.Data;

public class TopicService
{

    private readonly Mkt3Context ctx;

    public TopicService(Mkt3Context _ctx)
    {
        ctx = _ctx;
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

    public async Task<bool> AddTopic(string TopicName, string owner)
    {
        try
        {
            //await using var ctx = new Mkt3Context();
            var t = new Topic { Course = TopicName, Name = "Default Pool", Owner = owner};
            ctx.Topics.Add(t);
            await ctx.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
           Debug.WriteLine(e);
           return false;
        }

    }
    
   
    
}