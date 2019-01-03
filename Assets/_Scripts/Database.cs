using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Data;
using Mono.Data.Sqlite;
using UnityEngine.UI;

public class Database : MonoBehaviour {

    string connectionString;
    private List<DataHolder> dataList = new List<DataHolder>();
    public GameObject scorePrefab;
    public Transform scoreParent;
    public int scoreLimit;
    public InputField enterName;
    public GameObject nameDialogue;
    public GameObject highScoreTable;

    public float skin1unlocked = 0;
    public float skin2unlocked = 0;
    public float coinsowned = 0;
    public float batcoinsowned = 0;
    public float rezowned = 0;
    public float timeowned = 0;
    public float set_skin = 0;

    float this_runs_score;

	// Use this for initialization
	void Start () {
        //connectionString = "URI=file:" + Application.dataPath + "/" + "Database.s3db"; //Only use this for the windows build and use in the editor, I don't know why they dont work interchangeably but I don't care because it's a simple workaround.
        connectionString = "URI=file:" + Application.persistentDataPath + "/" + "Database.s3db";// - THIS MUST BE SET BEFORE THE ANDROID BUILD, AS IT IS THE ONLY WAY IT WILL WORK PROPERLY IN UNITY
        CreateDataBase();
        DeleteExtraScore();
        //InsertData("test", 4334, 1, 1);
        // true, true
        //CreateSave();
        //LoadSave();
        //DeleteScore();
        ShowScores();

        DataHolder current = LoadSave();
        Debug.Log("current save score " +current.HighScore.ToString());
	}

    private void Update()
    {
        
        //if (Input.GetButton("Fire1"))
        //{
          //  LoadSave();
         //   buySkin1();
        //    LoadSave();
       // }
    }

    public void EnterName()
    {
        if (enterName.text != string.Empty)
        {
            float score = this_runs_score;//UnityEngine.Random.Range(1, 500); // replace this with the actual score that is found on the death of a player
            InsertData(enterName.text, score, (int)skin1unlocked, (int)skin2unlocked, (int)set_skin, (int)coinsowned, (int)batcoinsowned, (int)rezowned, (int)timeowned);//0 , 0, 100 ,200, 300, 400, 500); //Read Comments below for variable meanings.
            enterName.text = string.Empty;

            //SaveScore(enterName.text,score, 0);

            ShowScores();

            nameDialogue.SetActive(false);
        }
       
    }
    //3rd and 4th numbers (0's) are the skin unlocks
    // 100 = Skin that is set, so assign a number value for each skin from 0-3, using the highest ID from the DataHolder datalist, 
    //the same can be pretty much said for all of these and the skin unlocks.
    //200 = amount of coins owned
    //300 = amount of batcoins owned
    //400 = amount of Rez Powerups Owned
    //500 = amount of Time Powerups Owned

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
          "Name" + " TEXT, " + "HighScore" + " FLOAT, " + "Skin1Unlock" + " BOOLEAN DEFAULT '0' NOT NULL, " + "Skin2Unlock" + " BOOLEAN DEFAULT '0' NOT NULL," + "SkinSet" + " INTEGER DEFAULT '0' NOT NULL," + "CoinsOwned" + " INTEGER DEFAULT '0' NOT NULL," 
          + "BatCoinsOwned" + " INTEGER DEFAULT '0' NOT NULL," + "RezPowerUpsOwned" + " INTEGER DEFAULT '0' NOT NULL," + "TimePowerUpsOwned" + " INTEGER DEFAULT '0' NOT NULL)";

        dbcmd.CommandText = q_createTable;
        reader = dbcmd.ExecuteReader();
    }//the database and table creation code

    private void InsertData(string name, float newScore, int Skin1Unlock, int Skin2Unlock, int SkinSet, int CoinsOwned, int BatCoinsOwned, int RezPowerUpsOwned, int TimePowerUpsOwned) // bool Skin1Unlock, bool Skin2Unlock
    {
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            GetScores();
            int hsCount = dataList.Count;
            if (dataList.Count > 0)
            {
                DataHolder lowestScore = dataList[dataList.Count - 1];
                if (lowestScore != null && scoreLimit > 0 && dataList.Count >= scoreLimit && newScore > lowestScore.HighScore)
                {
                    DeleteScore(lowestScore.ID);
                    hsCount--;
                }
            }
            if (hsCount < scoreLimit)
            {
                using (IDbCommand dbCmd = dbConnection.CreateCommand())
                {
                    dbConnection.Open();
                    string sqlQuery = String.Format("INSERT INTO PlayerData(Name,HighScore,Skin1Unlock,Skin2Unlock, SkinSet, CoinsOwned, BatCoinsOwned, RezPowerUpsOwned, TimePowerUpsOwned) VALUES(\"{0}\", \"{1}\", \"{2}\", \"{3}\", \"{4}\",\"{5}\", \"{6}\", \"{7}\", \"{8}\")", name, newScore, Skin1Unlock, Skin2Unlock, SkinSet, CoinsOwned, BatCoinsOwned, RezPowerUpsOwned, TimePowerUpsOwned); // \"{2}\", \"{3}\" ,Skin1Unlock,Skin2Unlock

                    dbCmd.CommandText = sqlQuery;
                    dbCmd.ExecuteScalar();
                    dbConnection.Close();
                }
            }
        }
    }

    float FindHighestIDColumn()
    {

        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {

            float currentHighest = 0;
            int position = 0;
            
            GetScores();
            int hsCount = dataList.Count;

            if (dataList.Count > 0)
            {
                DataHolder lowestScore = dataList[dataList.Count - 1];

                for (int i = 0; i < dataList.Count; i++)//loop through list and find the one with the highest id value.
                {
                    DataHolder current = dataList[i];
                    if (current.ID > currentHighest)
                    {
                        currentHighest = current.ID;
                        position = i;
                    }
                }
                return position;//currentHighest;
            }
        }

        return 0;//else return 0

    }


    float FindHighestID()
    {

        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {

            float currentHighest = 0;
            int position = 0;

            GetScores();
            int hsCount = dataList.Count;

            if (dataList.Count > 0)
            {
                DataHolder lowestScore = dataList[dataList.Count - 1];

                for (int i = 0; i < dataList.Count; i++)//loop through list and find the one with the highest id value.
                {
                    DataHolder current = dataList[i];
                    if (current.ID > currentHighest)
                    {
                        currentHighest = current.ID;
                        position = i;
                    }
                }
                return currentHighest;
            }
        }

        return 0;//else return 0

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
                        dataList.Add(new DataHolder(reader.GetInt16(0), reader.GetString(1), reader.GetFloat(2), reader.GetFloat(3), reader.GetFloat(4), reader.GetInt16(5), reader.GetInt16(6), reader.GetInt16(7), reader.GetInt16(8), reader.GetInt16(9)));
                    }
                    dbConnection.Close();
                    reader.Close();
                }
            }
        }
        dataList.Sort();
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

        foreach (GameObject score in GameObject.FindGameObjectsWithTag("Score"))
        {
            Destroy(score);
        }
        for (int i = 0; i < dataList.Count; i++)
        {
            GameObject tmpObjec = Instantiate(scorePrefab);

            DataHolder tmpScore = dataList[i];

            tmpObjec.GetComponent<HighScoreScript>().SetScore(tmpScore.Name, tmpScore.HighScore.ToString(), "#" + (i + 1).ToString());
            tmpObjec.transform.SetParent(scoreParent);
            tmpObjec.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        }
    }


    public void SaveScore(string name, float score, float runs_coins)
    {
        DataHolder tmp = LoadSave();
        InsertData(name, score, (int)tmp.Skin1Unlock, (int)tmp.Skin2Unlock, tmp.SetSkin, tmp.CoinsOwned, tmp.BatCoinsOwned, tmp.RezPowerUpsOwned, tmp.TimePowerUpsOwned);
        this_runs_score = score;
        //GetScores();

    }

    public void SendScore(float score)
    {
        this_runs_score = score;
    }

    // broken, plz fix.

    public void CreateSave()
    {
        //Debug.Log("save created");
        //InsertData("skin", 0, 0, 0);
    }

    DataHolder LoadSave()
    {
        dataList.Clear();
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();

            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = "SELECT * FROM PlayerData WHERE PlayerID = " + FindHighestID().ToString();//get the one
     
                dbCmd.CommandText = sqlQuery;

                using (IDataReader reader = dbCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //empty here as we only need to run the sql string
                        //Debug.Log(reader.GetString(1) + " - " + reader.GetFloat(2) + " - " + reader.GetBoolean(3) + " - " + reader.GetBoolean(4)); //+ " - " + reader.GetBoolean(3) + " - " + reader.GetBoolean(4)
                      //dataList.Add(new DataHolder(reader.GetFloat(0), reader.GetString(1), reader.GetFloat(2), reader.GetFloat(3), reader.GetFloat(4), reader.GetFloat(5), reader.GetFloat(6), reader.GetFloat(7), reader.GetFloat(8)));
                    }
                    dbConnection.Close();
                    reader.Close();
                }
            }
        }

        //this actually works by just getting the highest here, the only reason for the bit above is to get the latest verison of the database into dataholder
        DataHolder tmpScore = dataList[(int)FindHighestIDColumn()];
        //Debug.Log("temp score " + tmpScore.HighScore.ToString());

        //this happens here each time so that when we overwrite we can LoadSave first then overwrite what we want using the below script variabels
        coinsowned = tmpScore.CoinsOwned;
        rezowned = tmpScore.RezPowerUpsOwned;
        timeowned = tmpScore.TimePowerUpsOwned;
        batcoinsowned = tmpScore.BatCoinsOwned;
        skin1unlocked = tmpScore.Skin1Unlock;
        skin2unlocked = tmpScore.Skin2Unlock;

        return tmpScore;

    }

    public void SaveOverwrite()
    {

        /*using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();

            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                //string sqlQuery = String.Format("INSERT INTO PlayerData(Name,HighScore,Skin1Unlock,Skin2Unlock) VALUES(\"{0}\", \"{1}\", \"{2}\", \"{3}\")", name, newScore, Skin1Unlock, Skin2Unlock); // \"{2}\", \"{3}\" ,Skin1Unlock,Skin2Unlock

                string sqlQuery = "";
                ////////string sqlQuery = String.Format("INSERT INTO PlayerData(Skin1Unlock = \"{0}\", Skin2Unlock = \"{1}\", BatCoinsOwned = \"{3}\", CoinsOwned = \"{4}\" , TimePowerUpsOwned = \"{5}\" , RezPowerUpsOwned = \"{6}\"; ", skin1unlocked, skin2unlocked, FindHighestID().ToString() ,batcoinsowned, coinsowned, timeowned, rezowned);

                //string sqlQuery = String.Format("INSERT INTO PlayerData Set Skin1Unlock = \"{0}\", Skin2Unlock = \"{1}\", BatCoinsOwned = \"{3}\", CoinsOwned = \"{4}\" , TimePowerUpsOwned = \"{5}\" , RezPowerUpsOwned = \"{6}\" ,  WHERE PlayerID = \"{2}\"; ", skin1unlocked, skin2unlocked, FindHighestID().ToString(), batcoinsowned, coinsowned, timeowned, rezowned);


                dbCmd.CommandText = sqlQuery;
                dbCmd.ExecuteScalar();
                dbConnection.Close();
            }
        }*/

        //InsertData(null,0, (int)skin1unlocked, (int)skin2unlocked, (int)set_skin, (int)coinsowned, (int)batcoinsowned, (int)rezowned, (int)timeowned);

        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();
            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                dbConnection.Open();
                string sqlQuery = String.Format("INSERT INTO PlayerData(Skin1Unlock,Skin2Unlock, SkinSet, CoinsOwned, BatCoinsOwned, RezPowerUpsOwned, TimePowerUpsOwned) VALUES(\"{0}\", \"{1}\", \"{2}\", \"{3}\", \"{4}\",\"{5}\", \"{6}\")", skin1unlocked, skin2unlocked, set_skin, coinsowned, batcoinsowned, rezowned, timeowned); // \"{2}\", \"{3}\" ,Skin1Unlock,Skin2Unlock

                dbCmd.CommandText = sqlQuery;
                dbCmd.ExecuteScalar();
                dbConnection.Close();
            }
        }
    }

    public void buySkin1()
    {
        LoadSave();
        skin1unlocked = 1;
        SaveOverwrite();
    }

    public void buySkin2()
    {
        LoadSave();
        skin1unlocked = 1;
        SaveOverwrite();
    }

    public void buyBatCoins(float batcoinamount)
    {
        LoadSave();
        batcoinsowned = batcoinamount;
        SaveOverwrite();
    }

    public float GetBatCoins()
    {
        LoadSave();
        batcoinsowned = 100;
        return batcoinsowned;
    }

    public void ResetSkinsBought()
    {
        skin1unlocked = 0;
        skin2unlocked = 0;
        SaveOverwrite();
    }
    private void DeleteExtraScore()
    {
        GetScores();
        if (scoreLimit <= dataList.Count)
        {
            int deleteCount = dataList.Count - scoreLimit;
            dataList.Reverse();

            using (IDbConnection dbConnection = new SqliteConnection(connectionString))
            {
                dbConnection.Open();

                using (IDbCommand dbCmd = dbConnection.CreateCommand())
                {
                    for (int i = 0; i < deleteCount; i++)
                    {
                        string sqlQuery = String.Format("DELETE FROM PlayerData WHERE PlayerID = \"{0}\"", dataList[i].ID);

                        dbCmd.CommandText = sqlQuery;
                        dbCmd.ExecuteScalar();
                    }
                    dbConnection.Close();
                }
            }
        }
    }
}


