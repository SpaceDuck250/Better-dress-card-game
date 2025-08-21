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

    public static StatSetterScript instance;

    private void Awake()
    {
        instance = this;
    }


    private void Start()
    {
        round = ContextScript.instance.currentround;
        SetTargetScore();
        //SetStats();
    }

    public void SetTargetScore()
    {
        target = ContextScript.instance.currentPhotographer.GetComponent<PhotographerScript>().PhotographerData.photographercost + ContextScript.instance.currentmodel.ModelData.modelcost + ContextScript.instance.currentlocation.location.locationcost;
        target *= round;
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
        ContextScript.instance.currentbalance += PointsManagerScript.instance.CalculateMoney();
        moneytext.text = "money: " + ContextScript.instance.currentbalance;
        ContextScript.instance.currentround++;
        SceneManager.LoadScene("Shop");
    }
}
