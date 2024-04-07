using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using Iben.PEMR.Api.Domain.DynamoDB;

namespace Iben.PEMR.Api.Repository;

public class UserRepository
{

    /// <summary>
    /// Adds a new item to the table.
    /// </summary>
    /// <param name="client">An initialized Amazon DynamoDB client object.</param>
    /// <param name="user">A Movie object containing informtation for
    /// the movie to add to the table.</param>
    /// <param name="tableName">The name of the table where the item will be added.</param>
    /// <returns>A Boolean value that indicates the results of adding the item.</returns>
    public static async Task<bool> PutItemAsync(AmazonDynamoDBClient client, User user, string tableName)
    {
        var item = new Dictionary<string, AttributeValue>
        {
            ["UserID"] = new AttributeValue { S = user.UserID},
            ["Password"] = new AttributeValue { S = user.Password },
            ["Name"] = new AttributeValue { S = user.Name },
            ["LastName"] = new AttributeValue { S = user.LastName },
            ["FirstName"] = new AttributeValue { S = user.FirstName },
            ["Mobile"] = new AttributeValue { S = user.Mobile },
            ["Email"] = new AttributeValue { S = user.Email },
            ["CreateAt"] = new AttributeValue { S = user.CreateAt.ToString("yyy-MM-dd HH:mm:ss:ffff") },
            ["UpdateAt"] = new AttributeValue { S = user.UpdateAt?.ToString("yyy-MM-dd HH:mm:ss:ffff") }
        };

        var request = new PutItemRequest
        {
            TableName = tableName,
            Item = item,
        };

        var response = await client.PutItemAsync(request);
        return response.HttpStatusCode == System.Net.HttpStatusCode.OK;
    }


}
