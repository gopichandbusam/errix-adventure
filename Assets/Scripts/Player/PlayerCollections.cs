using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerCollections : MonoBehaviour
{

    //=========================================================================================//

    
    public int Bullets;//We Can keep these as internal to hide from Unity 
    public int goldCoins;// To hide Change public to internal From Unity
    public int gems;
    public int Keys;
    public int openChests;
    [Header("UI Elements")]
    [SerializeField]
    public Text goldCoinScoreText;
    public Text gemsScoreText;
    public Text keysText;
    public Text treasureOpenedText;
    public Text noOfBulletsText;
    // [Header("Game Over Panel Text ")]
    // private Text PanelgoldCoinScoreText;
    // private Text PanelgemsScoreText;
    // private Text PaneltreasureOpenedText;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        // coins = PlayerPrefs.GetInt("Coins");
        goldCoinScoreText = GameObject.Find("Gold Coin Score/Gold Coin Score").GetComponent<Text>();
        gemsScoreText = GameObject.Find("Gems Score/Gems Score").GetComponent<Text>();
        // keysText = GameObject.Find("Keys Score/Keys Score").GetComponent<Text>();
        treasureOpenedText  = GameObject.Find("Treasure Score/Treasure Score").GetComponent<Text>();
        noOfBulletsText   = GameObject.Find("Axes Score/Axes Score").GetComponent<Text>();
        goldCoinScoreText.text = "" ; //goldcoins
        gemsScoreText.text = ""; //gems
        keysText.text = ""; //keys
        treasureOpenedText.text = "";//Treasures opened
        noOfBulletsText.text = ""; //bullets
        // PaneltreasureOpenedText.text = "";
        // PanelgoldCoinScoreText.text = "";
        // PanelgemsScoreText.text = "";
        
    }

    // Update is called once per frame
    
    void Update()
    {
        // goldCoins = PlayerPrefs.GetInt("Coins");
        // coins = PlayerPrefs.GetInt("Coins");
        
        goldCoinScoreText.text = "" + goldCoins;//working
        gemsScoreText.text = "" + gems;//not working
        // keysText.text = "" + Keys;//working
        noOfBulletsText.text = "" + Bullets;// working
        treasureOpenedText.text = "" + openChests;
        // PaneltreasureOpenedText.text = "" + openChests;
        // PanelgoldCoinScoreText.text = "" + goldCoins;
        // PanelgemsScoreText.text = "" + gems;
        
    }
    internal void NoofGoldCoins()
    {
        goldCoins = goldCoins +1;
        // coins += 1 ;
        // PlayerPrefs.SetInt("Coins", coins);
        
        
        // goldCoins = PlayerPrefs.GetInt("Coins");
        // goldCoins += PlayerPrefs.GetInt("Coins");
        // PlayerPrefsManager.UpdateCoins();
        
        // goldCoins = goldCoins + 1;
        // goldCoins = PlayerPrefsManager.coins;

    }
    internal void NoOfAxes(int NoOfAxes1)
    {
        
        Bullets += NoOfAxes1;
    }
    internal void NoofKeys(int NoofKeys1)
    {
        Keys += NoofKeys1;
    }
    internal void OpenTreasure(int NoofCoins1)
    {
        Keys -= 1;
    }
    internal void ChestOpen()
    {
        openChests =  + 1;
        
    }
    internal void NoOfgems()
    {
        gems = gems + 1;
    }
    internal void BulletHandler()
    {
        Bullets -= 1;
    }

}
