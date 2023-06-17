using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestOpenUI : MonoBehaviour
{

    public Chest chestToLoad;

    [Header("Sprites for ChestOpenUI")]
    public Sprite coinImage;
    public Sprite diamondImage;
    public Sprite grenadeImage;
    public Sprite phantomSwordImage;
    public Sprite rocketLauncherImage;

    Text amountText;
    chestManager chestManager;
    GameObject oneItemParent;
    Image Card_Image;
    GameObject allItemParent;

    List<string> bucketListforRewards;
    int coin;
    // Start is called before the first frame update

    public void Start()
    {
        bucketListforRewards = new List<string>();
        //Assign values of all GameObject
        chestManager = FindObjectOfType<chestManager>();
        Card_Image = transform.Find("OneItem/Card_Image").GetComponent<Image>();
        amountText = transform.Find("OneItem/amount_Text").GetComponent<Text>();

        SetUp();
    }
    public void SetUp()
    {
        bucketListforRewards = new List<string>();
        bucketListforRewards.Add( "skinPieces");
        bucketListforRewards.Add( "diamonds");

        for(int i = 0; i < chestToLoad.numberOfPowerUps; i++)
        {
            bucketListforRewards.Add("powerups");
        }
        //Coin text
        coin = Random.Range(chestToLoad.min_coins, chestToLoad.max_coins);
        Card_Image.sprite = coinImage;
        amountText.text = "X " + coin.ToString();
    }
    public void NextCard()
    {
        //Next card
        if (bucketListforRewards[0] == "powerups")
        {
            //Add PowerUps
            int powerupType = Random.Range(1, 6);
            string powerUp = "grenade";
            int numberOfPowerUps = 0;
            #region DecingPowerUp
            if (powerupType <= 3)
            {
                powerUp = "grenade";
            } 
            else if (powerupType > 3 && powerupType <= 5)
            {
                powerUp = "phantomSword";

            }
            else if (powerupType == 6)
            {
                powerUp = "rocket";
            }

            int numberDecider = Random.Range(1, 10);
            if (numberDecider <= 4)
            {
                numberOfPowerUps = 1;
            }
            else if (numberDecider > 3 && numberDecider <= 9)
            {
                numberOfPowerUps = 2;

            }
            else if (numberDecider == 10)
            {
                numberOfPowerUps = 5;
            }
            #endregion


            if(powerUp == "grenade")
            {
                Card_Image.sprite = grenadeImage;
            } else if (powerUp == "phantomSword")
            {
                Card_Image.sprite = phantomSwordImage;
            }
            else if (powerUp == "rocket")
            {
                Card_Image.sprite = rocketLauncherImage;
            }


            amountText.text = "X " + numberOfPowerUps.ToString();
            bucketListforRewards.RemoveAt(0);

        }
        else if (bucketListforRewards[0] == "diamonds")
        {
            //Display Diamonds
            int diamonds = Random.Range(chestToLoad.min_diamonds, chestToLoad.max_diamonds);
            Card_Image.sprite = diamondImage;
            amountText.text = "X " + diamonds.ToString();
            bucketListforRewards.RemoveAt(0);
        }
        else if(bucketListforRewards[0] == "skinPieces")
        {
            int numberOfSkinPieces = 0;
            //SkinPieces
            int numberDecider = Random.Range(1, 10);
            if (numberDecider <= 4)
            {
                numberOfSkinPieces = 1;
            }
            else if (numberDecider > 3)
            {
                numberOfSkinPieces = 2;

            }
            else if (numberDecider == 10)
            {
                numberOfSkinPieces = 5;
            }

            Skin skinToGive;
            int SkinDecider = Random.Range(1, 10);
            if (SkinDecider <= 6)
            {
                List<Skin> givenRaritySkinList = new List<Skin>();

                foreach(Skin s in SkinStorage.Instance.allSkins)
                {
                    if (!SkinStorage.Instance.ownedSkins.Contains(s) && s.skinRarity.ToString() == "Common")
                    {
                        givenRaritySkinList.Add(s);
                    }
                }

                skinToGive = givenRaritySkinList[Random.Range(0, givenRaritySkinList.Count - 1)];

                Card_Image.sprite = skinToGive.skinPieceSprite;

                //SkinStorage.Instance.addSkinPieces(skinToGive);
                
                amountText.text = "X " + numberOfSkinPieces.ToString();

                if(givenRaritySkinList.Count == 0)
                {
                    SkinDecider = 7;
                }
            }
            if (SkinDecider > 6 && SkinDecider <= 9)
            {
                List<Skin> givenRaritySkinList = new List<Skin>();

                foreach (Skin s in SkinStorage.Instance.allSkins)
                {
                    if (!SkinStorage.Instance.ownedSkins.Contains(s) && s.skinRarity.ToString() == "Rare")
                    {
                        givenRaritySkinList.Add(s);
                    }
                }

                skinToGive = givenRaritySkinList[Random.Range(0, givenRaritySkinList.Count - 1)];

                Card_Image.sprite = skinToGive.skinPieceSprite;

                //SkinStorage.Instance.addSkinPieces(skinToGive);

                amountText.text = "X " + numberOfSkinPieces.ToString();

                if (givenRaritySkinList.Count == 0)
                {
                    SkinDecider = 7;
                }
            }
            if (SkinDecider == 10)
            {
                List<Skin> givenRaritySkinList = new List<Skin>();

                foreach (Skin s in SkinStorage.Instance.allSkins)
                {
                    if (!SkinStorage.Instance.ownedSkins.Contains(s) && s.skinRarity.ToString() == "Rare")
                    {
                        givenRaritySkinList.Add(s);
                    }
                }

                skinToGive = givenRaritySkinList[Random.Range(0, givenRaritySkinList.Count - 1)];

                Card_Image.sprite = skinToGive.skinPieceSprite;

                //SkinStorage.Instance.addSkinPieces(skinToGive);

                amountText.text = "X " + numberOfSkinPieces.ToString();
            }
            bucketListforRewards.RemoveAt(0);
        }
        if(bucketListforRewards.Count == 0)
        {
            gameObject.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
