using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class StatSetterScript : MonoBehaviour
{
    public TextMeshProUGUI statstext;
    public TextMeshProUGUI targettext;
    public TextMeshProUGUI scoretext;
    public TextMeshProUGUI moneytext;
    public int round;
    public int target;
    public GameObject scorebutton;

    public GameObject winscreen;
    public TextMeshProUGUI wintext;

    public static StatSetterScript instance;

    public TextMeshProUGUI infotext;
    public GameObject background;

    private void Awake()
    {
        instance = this;
    }


    private void Start()
    {
        round = ContextScript.instance.currentround;
        SetTargetScore();
        SetBackground();
        SetStatText();
        //SetStats();
    }

    public void SetBackground()
    {
        background.GetComponent<SpriteRenderer>().sprite = ContextScript.instance.currentlocation.location.LocationImage;
    }

    public void SetStatText()
    {
        infotext.text = "Round: " + ContextScript.instance.currentround + "\r\nLocation Boost: " + ContextScript.instance.currentlocation.location.styleboosted.ToString() + "\r\nCurrent Balance: " + ContextScript.instance.currentbalance;
    }

    public void SetTargetScore()
    {
        target = ContextScript.instance.currentPhotographer.GetComponent<PhotographerScript>().PhotographerData.photographercost + ContextScript.instance.currentmodel.ModelData.modelcost + ContextScript.instance.currentlocation.location.locationcost;
        target = Mathf.RoundToInt(target * round * 1.12f);
        targettext.text = "target score: " + target;
    }

    public void SetStats()
    {
        statstext.text = "Photographer: " + ContextScript.instance.currentPhotographer.name;
    }

    public void SetScore(int score)
    {
        scoretext.text = "score: " + score;
    }

    public void ResetScore()
    {
        scoretext.text = "score: ";
    }

    public void ShowScoreButton()
    {
        scorebutton.SetActive(true);
    }

    public void HideScoreButton()
    {
        scorebutton.SetActive(false);
    }

    // Set the money text to the amount of money when we click the score button and do other stuff like go to shop
    public void SubmitButton()
    {
        AudioScript.instance.PlayFx(AudioScript.instance.click);
        ContextScript.instance.currentbalance += PointsManagerScript.instance.CalculateMoney();
        moneytext.text = "money: " + ContextScript.instance.currentbalance;
        ContextScript.instance.currentround++;

        DoItemLogic();
        SelectorScript.instance.isPaused = true;

        if (PointsManagerScript.instance.CalculateMoney() >= 0)
        {
            wintext.text = "You gained.. " + PointsManagerScript.instance.CalculateMoney() + " money";
        }
        else
        {
            wintext.text = "You lost.. " + -PointsManagerScript.instance.CalculateMoney() + " money";
        }

        winscreen.SetActive(true);
        AudioScript.instance.musicsrc.Pause();
        AudioScript.instance.PlayFx(AudioScript.instance.win);
    }


    public void DoItemLogic()
    {
        foreach (ClothesScript selected in SenderScript.instance.clothesselection)
        {
            ContextScript.instance.notownedclothingdatas.Add(selected.ClothingData);
            ContextScript.instance.selectedclothes.Remove(selected.ClothingData);
        }

        foreach (ClothingData unselected in ContextScript.instance.selectedclothes)
        {
            ContextScript.instance.ownedclothingdatas.Add(unselected);
        }
    }
}


                                               

//c0)
//( > )



