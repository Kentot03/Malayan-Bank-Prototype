using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public static class MongoQueryExtensions
    {
        public static Task<List<T>> ToMongoListAsync<T>(this IQueryable<T> mongoQueryOnly)
        {
            return ((IMongoQueryable<T>)mongoQueryOnly).ToListAsync();
        }
    }
}
