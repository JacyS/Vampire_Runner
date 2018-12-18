using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using UnityEngine;

public class DataHolder {
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
}
