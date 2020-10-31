using System;
using System.IO;
using System.Linq;
using GraphQL;
using GraphQL.Types;
using Json.Net;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            string queryStr;
            if (args.Count() == 1)
            {
                queryStr = args[0];
            }
            else
            {
                Console.WriteLine("Query string expected as argument");
                return;
            }

            var schema = Schema.For(
                File.ReadAllLines("schema.graphql"),
                _ =>
                {
                    _.Types.Include<Query.Query>();
                });

            var execOptions = new ExecutionOptions
            {
                Schema = schema, 
                Query = queryStr
            };
            var docExec = new DocumentExecuter();
            var task = docExec.ExecuteAsync(execOptions);
            task.Wait();
            var result = JsonNet.Serialize(task.Result.Data);
            Console.WriteLine($"Request: {queryStr}");
            Console.WriteLine($"Response: {result}");
        }
    }
}