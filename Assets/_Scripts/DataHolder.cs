using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System;
using UnityEngine;

public class DataHolder : IComparable<DataHolder>  {
    public int ID { get; set; }

    public float HighScore { get; set; }

    public string Name { get; set; }

    public float Skin1Unlock { get; set; }

    public float Skin2Unlock { get; set; }

    public int SetSkin { get; set; }

    public int CoinsOwned { get; set; }

    public int RezPowerUpsOwned { get; set; }

    public int TimePowerUpsOwned { get; set; }

    public int BatCoinsOwned { get; set; }
    public DataHolder(int id, string name, float highScore,   float skin1Unlock, float skin2Unlock, int setSkin, int coinsOwned, int batCoinsOwned, int rezPowerUpsOwned, int timePowerUpsOwned)
    {
        this.HighScore = highScore;
        this.Name = name;
        this.ID = id;
        this.Skin1Unlock = skin1Unlock;
        this.Skin2Unlock = skin2Unlock;
        this.SetSkin = setSkin;
        this.CoinsOwned = coinsOwned;
        this.BatCoinsOwned = batCoinsOwned;
        this.RezPowerUpsOwned = rezPowerUpsOwned;
        this.TimePowerUpsOwned = timePowerUpsOwned;

    }
    public int CompareTo(DataHolder other)
    {
        if (other.HighScore < this.HighScore)
        {
            return -1;
        }
        else if (other.HighScore > this.HighScore)
        {
            return 1;
        }

        if (other.ID > this.ID)
        {
            return -1;
        }
        else if (other.ID < this.ID)
        {
            return 1;
        }

        return 0;
    }
}
