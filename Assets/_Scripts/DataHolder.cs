using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using UnityEngine;

public class DataHolder {

    public int HighScore { get; set; }

    public string Name { get; set; }

    public int ID { get; set; }

    public int Skin1Unlock { get; set; }

    public int Skin2Unlock { get; set; }

    public DataHolder(int highScore, string name, int id, int skin1Unlock, int skin2Unlock)
    {
        this.HighScore = highScore;
        this.Name = name;
        this.ID = id;
        this.Skin1Unlock = skin1Unlock;
        this.Skin2Unlock = skin2Unlock;
    }
}
