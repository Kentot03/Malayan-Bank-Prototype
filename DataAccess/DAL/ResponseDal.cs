using DataAccess;
using Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.DAL
{
    public class ResponseDal
    {
        public static List<colResponse> Read()
        {
            using (var ctx = new DBContext())
            {
                return ctx.Response.AsQueryable().ToList();
            }
        }

        public static string Create(colResponse model)
        {
            using (var ctx = new DBContext())
            {
                ctx.Response.InsertOne(model);
                return model._id;
            }
        }
        public static bool Update(colResponse model)
        {
            using (var ctx = new DBContext())
            {
                var orig = ctx.Response.AsQueryable().Where(x => x._id == model._id).FirstOrDefault();

                var filter = Builders<colResponse>.Filter.Eq(x => x._id, model._id);
                var result = ctx.Response.ReplaceOne(filter, model).ModifiedCount;
                if (result > 0)
                    return true;
                else
                    return false;
            }
        }
        public static bool Delete(string id)
        {
            using (var ctx = new DBContext())
            {
                var result = ctx.Response.DeleteOne(x => x._id == id).DeletedCount;
                if (result > 0)
                    return true;
                else
                    return false;
            }
        }
    }
}
