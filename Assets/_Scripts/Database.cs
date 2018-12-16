using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Data;
using Mono.Data.Sqlite;

public class Database : MonoBehaviour {

    string connectionString;
    private List<DataHolder> dataList = new List<DataHolder>();

	// Use this for initialization
	void Start () {
        connectionString = "URI=file:" + Application.dataPath + "/Database.s3db";
        //InsertData("dave", 23, 1, 1); // true, true
        DeleteScore(32);
        GetScores();
 
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void InsertData(string name, float newScore, int Skin1Unlock, int Skin2Unlock) // bool Skin1Unlock, bool Skin2Unlock
    {
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();

            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = String.Format ("INSERT INTO PlayerData(Name,HighScore,Skin1Unlock,Skin2Unlock) VALUES(\"{0}\", \"{1}\", \"{2}\", \"{3}\")", name,newScore,Skin1Unlock,Skin2Unlock); // \"{2}\", \"{3}\" ,Skin1Unlock,Skin2Unlock

                dbCmd.CommandText = sqlQuery;
                dbCmd.ExecuteScalar();
                dbConnection.Close();
            }
        }
            }
    private void GetScores()
    {
        dataList.Clear();
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();

            using(IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = "SELECT * FROM PlayerData";

                dbCmd.CommandText = sqlQuery;

                using (IDataReader reader = dbCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Debug.Log(reader.GetString(1) + " - " + reader.GetFloat(2) + " - " + reader.GetBoolean(3) + " - " + reader.GetBoolean(4)); //+ " - " + reader.GetBoolean(3) + " - " + reader.GetBoolean(4)
                        dataList.Add(new DataHolder(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetInt32(4)));
                    }
                    dbConnection.Close();
                    reader.Close();
                }
            }
        }
    }

    private void DeleteScore(int id)
    {
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();

            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = String.Format("DELETE FROM PlayerData WHERE PlayerID = \"{0}\"", id);

                dbCmd.CommandText = sqlQuery;
                dbCmd.ExecuteScalar();
                dbConnection.Close();
            }
        }
    }

    public void SaveScore(string name, float score, float runs_coins)
    {
        InsertData(name, score, 0, 0);
        //GetScores();
    }
}
