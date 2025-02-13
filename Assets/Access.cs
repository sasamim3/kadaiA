using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Threading.Tasks;
using System;
using UnityEditor;

public class Access : MonoBehaviour
{
    private MongoClient client;
    private IMongoDatabase database;
    private IMongoCollection<BsonDocument> collection;


    // Start is called before the first frame update
    void Start()
    {
        client = new MongoClient("mongodb+srv://sasami:Sasami333@cluster0.nuo3k.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0");
        database = client.GetDatabase("kadai");
        collection = database.GetCollection<BsonDocument>("kadai_1");
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerController.Players == 0)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("Score", 0);
            var result = collection.Find("{Score:0}").FirstOrDefault();
            var update = Builders<BsonDocument>.Update.Set("Data", ScoreController.Score);
            collection.UpdateOne(filter, update);
        }
    }

}