﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Data;
using Mono.Data.Sqlite;

public class Database : MonoBehaviour {

    string connectionString;

	// Use this for initialization
	void Start () {
        connectionString = "URI=file:" + Application.dataPath + "/Database.s3db";
        InsertData("dave", 23); // true, true
        GetScores();
 
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void InsertData(string name, int newScore) // bool Skin1Unlock, bool Skin2Unlock
    {
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();

            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = String.Format ("INSERT INTO PlayerData(Name,HighScore) VALUES(\"{0}\", \"{1}\")", name,newScore); // \"{2}\", \"{3}\" ,Skin1Unlock,Skin2Unlock

                dbCmd.CommandText = sqlQuery;
                dbCmd.ExecuteScalar();
                dbConnection.Close();
            }
        }
            }
    private void GetScores()
    {
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
                        Debug.Log(reader.GetString(1) + " - " + reader.GetFloat(2)); //+ " - " + reader.GetBoolean(3) + " - " + reader.GetBoolean(4)

                    }
                    dbConnection.Close();
                    reader.Close();
                }
            }
        }
    }
}