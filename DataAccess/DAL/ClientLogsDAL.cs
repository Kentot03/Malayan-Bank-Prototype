using DataAccess;
using Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAL
{
    public class ClientLogsDAL
    {
        public static async Task<string> Create(clientlogs model)
        {
            using (var ctx = new DBContext())
            {
                model.log_date = DateTime.Now;
                await ctx.clientlogs.InsertOneAsync(model);
                return model._id;
            }
        }
        public static async Task<bool> Update(clientlogs model)
        {
            using (var ctx = new DBContext())
            {
                var filter = Builders<clientlogs>.Filter.Eq(x => x._id, model._id);
                //var orig = await ctx.clientlogs.Find(filter).FirstOrDefaultAsync();
                //model.created_by = orig.created_by;
                //model.created_date = orig.created_date;
                //model.modified_date = DateTime.Now;

                var result = await ctx.clientlogs.ReplaceOneAsync(filter, model);
                if (result.ModifiedCount > 0)
                    return true;
                else
                    return false;
            }
        }
        public static async Task<bool> Delete(string id)
        {
            using (var ctx = new DBContext())
            {
                var result = await ctx.clientlogs.DeleteOneAsync(x => x._id == id);
                if (result.DeletedCount > 0)
                    return true;
                else
                    return false;
            }
        }
        public static async Task<List<clientlogs>> ReadAll()
        {
            using (var ctx = new DBContext())
            {
                return await ctx.clientlogs.AsQueryable().ToListAsync();
            }
        }
        public static async Task<clientlogs> ReadById(string id)
        {
            using (var ctx = new DBContext())
            {
                var filter = Builders<clientlogs>.Filter.Where(x => x._id == id);
                return await ctx.clientlogs.Find(filter).FirstOrDefaultAsync();
            }
        }
    }
}
