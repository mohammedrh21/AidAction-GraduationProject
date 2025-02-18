using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Dynamic;

namespace AidAction.Repository.Generic
{
    public static class ReClasser
    {
        public static IDictionary<string, object> FixMeUp<T>(this T fixMe)
        {
            var t = fixMe.GetType();
            var returnClass = new ExpandoObject() as IDictionary<string, object>;

            foreach (var pr in t.GetProperties())
            {
                var val = pr.GetValue(fixMe);
                if (val is string && string.IsNullOrWhiteSpace(val.ToString())) { }
                else if (val == null) { }
                else
                {
                    returnClass.Add(pr.Name, val);
                }
            }
            return returnClass;
        }

        public static object DictionaryToObject(this IDictionary<string, object> dictionary)
        {
            var expandoObj = new ExpandoObject();
            var expandoObjCollection = (ICollection<KeyValuePair<string, object>>)expandoObj;

            foreach (var keyValuePair in dictionary)
            {
                expandoObjCollection.Add(keyValuePair);
            }
            return expandoObj;
        }
    }

    public class GenericRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public GenericRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration["ConnectionStrings:DefaultConnection"];
        }

        public IDbConnection CreateConnection()
        {
            var connection = new SqlConnection(_connectionString);
            connection.Open(); // Ensure the connection is open
            return connection;
        }



        protected async Task<T> CommandAsync<T>(string sql, object parameters = null) where T : class
        {
            using (var connection = CreateConnection())
            {
                try
                {
                    var newObject = parameters ?? new { }; // Avoid modifying the original object

                    var queryResponse = await connection.QueryAsync(sql, param: newObject, commandType: CommandType.StoredProcedure);

                    if (typeof(T) == typeof(JObject))
                    {
                        var jsonString = queryResponse.FirstOrDefault()?.JsonObject ?? "{}"; // Avoid potential null reference
                        return JObject.Parse(jsonString) as T;
                    }
                    else if (typeof(T) == typeof(JArray))
                    {
                        var jsonArrayString = "[" + string.Join(",", queryResponse.Select(row => row.JsonObject ?? "{}")) + "]";
                        return JArray.Parse(jsonArrayString) as T;
                    }
                    else
                    {
                        throw new InvalidOperationException($"Unsupported type {typeof(T).Name}");
                    }
                }
                catch (Exception ex)
                {
                    ex.Data.Add("sp", sql);
                    ex.Data.Add("param", parameters);
                    ex.Data.Add("message", ex.Message);

                    if (typeof(T) == typeof(JObject))
                    {
                        var errorJson = new { rv = -1, Msg = ex.Message };
                        return JObject.FromObject(errorJson) as T;
                    }
                    else if (typeof(T) == typeof(JArray))
                    {
                        var errorArray = new[] { new { rv = -1, Msg = ex.Message } };
                        return JArray.FromObject(errorArray) as T;
                    }
                    else
                    {
                        throw;
                    }
                }
            }
        }




        //protected async Task<T> CommandAsync<T>(string sql, object parameters = null) where T : class
        //{
        //    using (var connection = CreateConnection())
        //    {
        //        if (connection is SqlConnection sqlConnection)
        //        {
        //            await sqlConnection.OpenAsync();
        //        }

        //        try
        //        {
        //            var newObject = parameters ?? new { }; // Avoid modifying the original object

        //            Console.WriteLine($"Executing {sql} with params: {JsonConvert.SerializeObject(newObject)}"); // Log params

        //            var queryResponse = await connection.QueryAsync(sql, param: newObject, commandType: CommandType.StoredProcedure, buffered: false);

        //            if (typeof(T) == typeof(JObject))
        //            {
        //                var jsonString = queryResponse.FirstOrDefault()?.JsonObject ?? "{}"; // Avoid potential null reference
        //                return JObject.Parse(jsonString) as T;
        //            }
        //            else if (typeof(T) == typeof(JArray))
        //            {
        //                var jsonArrayString = "[" + string.Join(",", queryResponse.Select(row => row.JsonObject ?? "{}")) + "]";
        //                return JArray.Parse(jsonArrayString) as T;
        //            }
        //            else
        //            {
        //                throw new InvalidOperationException($"Unsupported type {typeof(T).Name}");
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            ex.Data.Add("sp", sql);
        //            ex.Data.Add("param", parameters);
        //            ex.Data.Add("message", ex.Message);

        //            if (typeof(T) == typeof(JObject))
        //            {
        //                var errorJson = new { rv = -1, Msg = ex.Message };
        //                return JObject.FromObject(errorJson) as T;
        //            }
        //            else if (typeof(T) == typeof(JArray))
        //            {
        //                var errorArray = new[] { new { rv = -1, Msg = ex.Message } };
        //                return JArray.FromObject(errorArray) as T;
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //    }
        //}

        public async Task<DataTable> GetDataTableRepoAsync(string sql, object parameters = null, int? commandTimeout = null)
        {
            try
            {
                using (var con = new SqlConnection(_connectionString))
                {
                    await con.OpenAsync(); // Ensure connection is open
                    DataTable dt = new DataTable();

                    using (var reader = await con.ExecuteReaderAsync(sql, parameters, commandType: CommandType.StoredProcedure, commandTimeout: commandTimeout))
                    {
                        dt.Load(reader);
                    }
                    return dt;
                }
            }
            catch (Exception ex)
            {
                ex.Data.Add("sp", sql);
                ex.Data.Add("param", parameters);
                ex.Data.Add("message", ex.Message);
                throw;
            }
        }
    }
}
