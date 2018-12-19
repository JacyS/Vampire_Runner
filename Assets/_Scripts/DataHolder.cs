using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System;
using UnityEngine;

public class DataHolder : IComparable<DataHolder>  {
    public float ID { get; set; }

    public float HighScore { get; set; }

    public string Name { get; set; }

    public float Skin1Unlock { get; set; }

    public float Skin2Unlock { get; set; }

    public DataHolder(float id, string name, float highScore,   float skin1Unlock, float skin2Unlock)
    {
        this.HighScore = highScore;
        this.Name = name;
        this.ID = id;
        this.Skin1Unlock = skin1Unlock;
        this.Skin2Unlock = skin2Unlock;
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
