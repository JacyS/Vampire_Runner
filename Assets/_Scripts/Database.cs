﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Data;
using Mono.Data.Sqlite;

public class Database : MonoBehaviour {

    string connectionString;
    private List<DataHolder> dataList = new List<DataHolder>();
    public GameObject scorePrefab;
    public Transform scoreParent;

	// Use this for initialization
	void Start () {
        connectionString = "URI=file:" + Application.dataPath + "/" + "Database.s3db"; //Only use this for the windows build and use in the editor, I don't know why they dont work interchangeably but I don't care because it's a simple workaround.
        //connectionString = "URI=file:" + Application.persistentDataPath + "/" + "Database.s3db"; - THIS MUST BE SET BEFORE THE ANDROID BUILD, AS IT IS THE ONLY WAY IT WILL WORK PROPERLY IN UNITY
        CreateDataBase();
        InsertData("dave", 21, 1, 1); // true, true
        //DeleteScore();
        ShowScores(); 
        
	}

    private void CreateDataBase()
    {
        IDbConnection dbcon = new SqliteConnection(connectionString);
        dbcon.Open();
        IDbCommand dbcmd;
        IDataReader reader;

        dbcmd = dbcon.CreateCommand();
        string q_createTable =
          "CREATE TABLE IF NOT EXISTS " + "PlayerData" + " (" +
          "PlayerID" + " INTEGER  NOT NULL PRIMARY KEY AUTOINCREMENT, " +
          "Name" + " TEXT  NOT NULL, " + "HighScore" + " FLOAT  NOT NULL, " + "Skin1Unlock" + " BOOLEAN DEFAULT '0' NOT NULL, " + "Skin2Unlock" + " BOOLEAN DEFAULT '0' NOT NULL)";

        dbcmd.CommandText = q_createTable;
        reader = dbcmd.ExecuteReader();
    }//the database and table creation code


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
                        //Debug.Log(reader.GetString(1) + " - " + reader.GetFloat(2) + " - " + reader.GetBoolean(3) + " - " + reader.GetBoolean(4)); //+ " - " + reader.GetBoolean(3) + " - " + reader.GetBoolean(4)
                        dataList.Add(new DataHolder(reader.GetFloat(0), reader.GetString(1), reader.GetFloat(2), reader.GetFloat(3), reader.GetFloat(4)));
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
    private void ShowScores()
    {
        GetScores();
        for (int i = 0; i < dataList.Count; i++)
        {
            GameObject tmpObjec = Instantiate(scorePrefab);

            DataHolder tmpScore = dataList[i];

            tmpObjec.GetComponent<HighScoreScript>().SetScore(tmpScore.Name, tmpScore.HighScore.ToString(), "#" + (i + 2).ToString());
            tmpObjec.transform.SetParent(scoreParent);
            tmpObjec.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        }
    }


    public void SaveScore(string name, float score, float runs_coins)
    {
        InsertData(name, score, 0, 0);
        //GetScores();
    }
}
