using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreController : MonoBehaviour
{
    //Currencys
    public Text coinsCurrency;
    public Text batcoinsCurrency;
    public float coins;
    float batcoins;//not public

    //PowerUps

    public Text ResPowerUpsText;
    public float ResPowerUps;
    public Text TimePowerText;
    public float TimePower;

    //Skins Costs button text
    public Text skin1CoinsText;
    public Text skin1BatsText;
    public Text skin2CoinsText;
    public Text skin2BatsText;

    //Skins cost floats can be private
    public float skin1Coins = 5000;
    public float skin1Bats = 500;
    public float skin2Coins = 7500;
    public float skin2Bats = 750;

    //PurchaseButtons
    public Button skin1CoinButton;
    public Button skin1BatButton;
    public Button skin2CoinButton;
    public Button skin2BatButton;

    //PurchasePowerUps
    public Text ResCoinsText;
    public Text ResBatsText;
    public float ResCoins = 1000;
    public float ResBats = 50;
    public Text TimeCoinsText;
    public Text TimeBatsText;
    public float TimeCoins = 1000;
    public float TimeBats = 50;

    public Button ResCoinButton;
    public Button ResBatsButton;
    public Button TimeCoinButton;
    public Button TimeBatsButton;

    //SkinBoughtBools

    float Skin1Bought = 0;
    float Skin2Bought = 0;

    //Multiplier
   public float multiplier = 1;
    public Button Multiplier1;
    public Button Multiplier2;
    public Button Multiplier5;
    public Button Multiplier10;

    //OwnedSkins

    public Text OwnedDefault;
    public Text OwnedSkin1;
    public Text OwnedSkin2;
    public Button BDefault;
    public Button BSkin1;
    public Button BSkin2;
    bool DefaultEquipped;
    bool Skin1Equipped;
    bool Skin2Equipped;



    //GameObject DatabaseManager;
    GameObject SaveObj;
    SaveVariablesScript SaveScript;

    void Awake()
    {
        //Sets the button text values to the correct amount
        skin1CoinsText.text = skin1Coins + " Coins";
        skin1BatsText.text = skin1Bats + " BatCoins";
        skin2CoinsText.text = skin2Coins + " Coins";
        skin2BatsText.text = skin2Bats + " BatCoins";
        OwnedDefault.text = "Use";
    }

    /* void Start()
     {
        
     }*/

    private void Start()
    {
        SaveObj = GameObject.Find("SaveObj");
        SaveScript = SaveObj.GetComponent<SaveVariablesScript>();

        batcoins = SaveScript.ReadBatcoins();
        ResPowerUps = SaveScript.ReadRes();
        TimePower = SaveScript.ReadTime();
    }

    void Update()
    {
        //Updates amount of currency the player has
        coinsCurrency.text = "Coins: " + coins;
        batcoinsCurrency.text = "BatCoins: " + batcoins;
        ResPowerUpsText.text = "Resurrection Tokens: " + ResPowerUps;
        TimePowerText.text = "Time Tokens: " + TimePower;

        if (Skin1Bought == 1)
        {
            //Disables button so the player cannot buy it twice 
            skin1CoinButton.interactable = false;
            skin1BatButton.interactable = false;
            //changes text to purchased when it has been bought
            skin1BatsText.text = "Purchased";
            skin1CoinsText.text = "Purchased";
        }
        if (Skin2Bought == 1)
        {
            skin2CoinButton.interactable = false;
            skin2BatButton.interactable = false;
            skin2BatsText.text = "Purchased";
            skin2CoinsText.text = "Purchased";
        }

        //Different from wake values because multiplier and it will update throughout the game.
        ResCoinsText.text = ResCoins * multiplier + " Coins";
        ResBatsText.text = ResBats * multiplier + " BatCoins";
        TimeCoinsText.text = TimeCoins * multiplier + " Coins";
        TimeBatsText.text = TimeBats * multiplier + " BatCoins";
        
        if (Skin1Bought == 0)
        {
            BSkin1.interactable = false;
            OwnedSkin1.text = "Not Owned";
            
        }
        else if (Skin1Bought == 1)
        {
            BSkin1.interactable = true;
            //OwnedSkin1.text = "Owned";
        }

        if (Skin2Bought == 0)
        {
            BSkin2.interactable = false;
            OwnedSkin2.text = "Not Owned";
        }
        else if (Skin2Bought == 1)
        {
            BSkin2.interactable = true;
            //OwnedSkin2.text = "Owned";
        }





    }

    public void PurchaseSkin1Coins()
    {
        //If the player does not have enough coins and try to purchase it will change text
        if (coins < skin1Coins)
        {
            skin1CoinsText.text = "Insufficient Coins";
        }
        else//if they have enough will take away the coins and add the skin to the player
        {
            coins = coins - skin1Coins;
            Skin1Bought = 1;
            SaveScript.SetSkin1();
            OwnedSkin1.text = "Use";
        }

    }
    public void PurchaseSkin1Bat()
    {
        if (batcoins < skin1Bats)
        {
            skin1BatsText.text = "Insufficient BatCoins";
        }
        else
        {
            batcoins = batcoins - skin1Bats;
            SaveScript.SetBatcoins(batcoins);
            Skin1Bought = 1;
            OwnedSkin1.text = "Use";
            SaveScript.SetSkin1();
            //DatabaseManager.GetComponent<Database>().buySkin1();
        }
    }
    public void PurchaseSkin2Coins()
    {
        if (coins < skin2Coins)
        {
            skin2CoinsText.text = "Insufficient Coins";
        }
        else
        {
            coins = coins - skin2Coins;
            Skin2Bought = 1;
            OwnedSkin2.text = "Use";
            SaveScript.SetSkin2();
        }

    }
    public void PurchaseSkin2Bat()
    {
        if (batcoins < skin2Bats)
        {
            skin2BatsText.text = "Insufficient BatCoins";
        }
        else
        {
            batcoins = batcoins - skin2Bats;
            OwnedSkin2.text = "Use";
            SaveScript.SetBatcoins(batcoins);
            Skin2Bought = 1;
            SaveScript.SetSkin2();
        }
    }


    public void PurchaseResCoins()
    {
        //Check if they have enough coins to purchase will the amount they want to buy with the multiplier
        if (coins < ResCoins * multiplier)
        {
            ResCoinsText.text = "Insufficient Coins";
        }
        else
        {
            //takes away the coins with the selected multiplier value and then add the powerup when purchased with the chosen multiplier
            coins = coins - ResCoins * multiplier;
            ResCoinsText.text = "Purchased";
            ResPowerUps = ResPowerUps + 1 * multiplier;
            SaveScript.SetRes(ResPowerUps);
           
        }
    }

    public void PurchaseResBats()
    {
        if (batcoins < ResBats * multiplier)
        {
            ResBatsText.text = "Insufficient BatCoins";
        }
        else
        {
            batcoins = batcoins - ResBats * multiplier;
            SaveScript.SetBatcoins(batcoins);
            ResBatsText.text = "Purchased";
            ResPowerUps = ResPowerUps + 1 * multiplier;
            SaveScript.SetRes(ResPowerUps);
        }
    }

    public void PurchaseTimeCoins()
    {
        if (coins < TimeCoins * multiplier)
        {
            TimeCoinsText.text = "Insufficient Coins";
        }
        else
        {
            coins = coins - TimeCoins * multiplier;
            TimeCoinsText.text = "Purchased";
            TimePower = TimePower + 1 * multiplier;
            SaveScript.SetTime(TimePower);
        }
    }

    public void PurchaseTimeBats()
    {
        if (batcoins < ResBats * multiplier)
        {
            TimeBatsText.text = "Insufficient BatCoins";
        }
        else
        {
            batcoins = batcoins - TimeBats * multiplier;
            SaveScript.SetBatcoins(batcoins);
            TimeBatsText.text = "Purchased";
            TimePower = TimePower + 1 * multiplier;
            SaveScript.SetTime(TimePower);
        }
    }



    //Currency, Simple adding fake transaction when they press each button

    public void CurrencyPack1()
    {
        batcoins = SaveScript.ReadBatcoins() + 500;
        SaveScript.SetBatcoins(batcoins);
        //DatabaseManager.GetComponent<Database>().buyBatCoins(batcoins);
    }
    public void CurrencyPack2()
    {
        batcoins = SaveScript.ReadBatcoins() + 2000;
        SaveScript.SetBatcoins(batcoins);
        //DatabaseManager.GetComponent<Database>().buyBatCoins(batcoins);
    }
    public void CurrencyPack3()
    {
        batcoins = SaveScript.ReadBatcoins() + 5000;
        SaveScript.SetBatcoins(batcoins);
        //DatabaseManager.GetComponent<Database>().buyBatCoins(batcoins);
    }


    public void Multiplier1x()
    {
        //Setting the selected multiplier to false to see what one in enabled and making others usable
        Multiplier1.interactable = false;
        Multiplier2.interactable = true;
        Multiplier5.interactable = true;
        Multiplier10.interactable = true;

        multiplier = 1;
    }

    public void Multiplier2x()
    {
        Multiplier1.interactable = true;
        Multiplier2.interactable = false;
        Multiplier5.interactable = true;
        Multiplier10.interactable = true;

        multiplier = 2;
    }
    public void Multiplier5x()
    {
        Multiplier1.interactable = true;
        Multiplier2.interactable = true;
        Multiplier5.interactable = false;
        Multiplier10.interactable = true;

        multiplier = 5;
    }
    public void Multiplier10x()
    {
        Multiplier1.interactable = true;
        Multiplier2.interactable = true;
        Multiplier5.interactable = true;
        Multiplier10.interactable = false;

        multiplier = 10;
    }

    public void DefaultButton()
    {
        DefaultEquipped = true;
        Skin1Equipped = false;
        Skin2Equipped = false;
        OwnedDefault.text = "Using";
        OwnedSkin1.text = "Use";
        OwnedSkin2.text = "Use";
    }

    public void Skin1Button()
    {
        DefaultEquipped = false;
        Skin1Equipped = true;
        Skin2Equipped = false;
        OwnedDefault.text = "Use";
        OwnedSkin1.text = "Using";
        OwnedSkin2.text = "Use";

        SaveScript.SetCurrentSkin(1);
    }

    public void Skin2Button()
    {
        DefaultEquipped = false;
        Skin1Equipped = false;
        Skin2Equipped = true;
        OwnedDefault.text = "Use";
        OwnedSkin1.text = "Use";
        OwnedSkin2.text = "Using";
        SaveScript.SetCurrentSkin(2);
    }

}
