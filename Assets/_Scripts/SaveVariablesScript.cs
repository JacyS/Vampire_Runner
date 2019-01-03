using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveVariablesScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    public void LoadPref()
    {

    }
	
    //Batcoins
    public float ReadBatcoins()
    {
        return PlayerPrefs.GetFloat("batcoins");
    }

    public void SetBatcoins(float batcoins)
    {
        PlayerPrefs.SetFloat("batcoins", batcoins);
    }



    //coins
    public float ReadCoins()
    {
        return PlayerPrefs.GetFloat("coins");
    }

    public void SetCoins(float coins)
    {
        PlayerPrefs.SetFloat("coins", coins);
    }




    //skin1
    public float ReadSkin1()
    {
        return PlayerPrefs.GetFloat("skin1");
    }

    public void SetSkin1()
    {
        PlayerPrefs.SetFloat("skin1", 1);
    }

    //skin2
    public float ReadSkin2()
    {
        return PlayerPrefs.GetFloat("skin2");
    }

    public void SetSkin2()
    {
        PlayerPrefs.SetFloat("skin2", 1);
    }



    //Res 
    public float ReadRes()
    {
        return PlayerPrefs.GetFloat("res");
    }

    public void SetRes(float res)
    {
        PlayerPrefs.SetFloat("res", res);
    }


    //Time 
    public float ReadTime()
    {
        return PlayerPrefs.GetFloat("time");
    }

    public void SetTime(float timeamount)
    {
        PlayerPrefs.SetFloat("time", timeamount);
    }


    //Skin Equipped
    public float ReadCurrentSkin()
    {
        return PlayerPrefs.GetFloat("CurrentSkin");
    }

    public void SetCurrentSkin(float CurrentSkinValue)
    {
        PlayerPrefs.SetFloat("CurrentSkin", CurrentSkinValue);
    }

}
