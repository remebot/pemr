using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;

namespace Iben.PEMR.Api.Tool.ConsoleTool
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string accessKeyId = "";
            string secretAccessKey = "";
            var client = new AmazonDynamoDBClient(accessKeyId, secretAccessKey, Amazon.RegionEndpoint.CNNorth1);

            var table = Table.LoadTable(client, "PEMR.User");

            //var document = new Document();
            //document["ID"] = "3";
            //document["Name"] = "呵呵";
            //document["CreateAt"] = DateTime.Now;


            var document = new Document();
            document["ID"] = "5";
            document["Name"] = "BBBBBB";
            document["CreateAt"] = "CCCCCC";

            Document doc1 = await table.PutItemAsync(document,new PutItemOperationConfig()
            {
                 ReturnValues = ReturnValues.None
            });



            Console.WriteLine("Item added to DynamoDB table.");

            Console.WriteLine("Hello, World!");
        }

    }
}
