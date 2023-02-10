using System.ComponentModel;
using System.Diagnostics;
using Humanizer;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace Mkt3.Data;

public class GroupService
{

    private readonly Mkt3Context ctx;

    public GroupService(Mkt3Context _ctx)
    {
        ctx = _ctx;
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
    
    
}