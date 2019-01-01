﻿using System.Collections;
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


    GameObject DatabaseManager;

    void Awake()
    {
        //Sets the button text values to the correct amount
        skin1CoinsText.text = skin1Coins + " Coins";
        skin1BatsText.text = skin1Bats + " BatCoins";
        skin2CoinsText.text = skin2Coins + " Coins";
        skin2BatsText.text = skin2Bats + " BatCoins";
    }

    /* void Start()
     {
         DatabaseManager = GameObject.Find("DatabaseManager");

         Skin1Bought = DatabaseManager.GetComponent<Database>().skin1unlocked;
         Skin2Bought = DatabaseManager.GetComponent<Database>().skin2unlocked;
         batcoins = DatabaseManager.GetComponent<Database>().GetBatCoins();

         Debug.Log("batcoins " + batcoins.ToString());
     }*/

    private void Start()
    {
        DatabaseManager = GameObject.Find("DatabaseManager");

        Skin1Bought = DatabaseManager.GetComponent<Database>().skin1unlocked;
        Skin2Bought = DatabaseManager.GetComponent<Database>().skin2unlocked;
        batcoins = DatabaseManager.GetComponent<Database>().GetBatCoins();

        Debug.Log("batcoins " + batcoins.ToString());// I don't know why this code isn't running!
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
            Skin1Bought = 1;
            DatabaseManager.GetComponent<Database>().buySkin1();
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
            DatabaseManager.GetComponent<Database>().buySkin2();
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
            Skin2Bought = 1;
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
            ResBatsText.text = "Purchased";
            ResPowerUps = ResPowerUps + 1 * multiplier;

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
            TimeBatsText.text = "Purchased";
            TimePower = TimePower + 1 * multiplier;

        }
    }



    //Currency, Simple adding fake transaction when they press each button

    public void CurrencyPack1()
    {
        batcoins = batcoins + 500;
        DatabaseManager.GetComponent<Database>().buyBatCoins(batcoins);
    }
    public void CurrencyPack2()
    {
        batcoins = batcoins + 2000;
    }
    public void CurrencyPack3()
    {
        batcoins = batcoins + 5000;
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


}
