using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;
using TMPro;

public class PointsManagerScript : MonoBehaviour
{
    // Add a check to see if even all of the slots are taken like top bottom and shoes

    public static PointsManagerScript instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            stylematches.Clear();
            colourmatches.Clear();
        }
    }

    public TextMeshProUGUI scoretext;

    public UnityEvent OnCalculate;

    public List<ClothesScript> clothingitems = new List<ClothesScript>();

    public Dictionary<TypesScript.Clothingstyle, int> stylematches = new Dictionary<TypesScript.Clothingstyle, int>();

    public Dictionary<TypesScript.Clothingcolour, int> colourmatches = new Dictionary<TypesScript.Clothingcolour, int>();

    public int finalscore = 0;

    public int basescore = 0;

    public void Fill()
    {
        clothingitems.Clear();
        foreach (ClothesScript clothing in SenderScript.instance.clothesselection)
        {
            clothingitems.Add(clothing);
        }
    }

    public void Calculate()
    {
        Debug.Log("work");
        Fill(); // For the selected clothing
        AddToBasket(); // For counting matches
        CalculateBaseScore(); // Base score
        CalculateFinalScore(); // Final Score calculations
    }

    // We add all the clothes from slots into the style and colour lists and count how many
    public void AddToBasket()
    {

        stylematches.Clear();
        colourmatches.Clear();

        foreach (ClothesScript clothing in clothingitems)
        {
            if (clothing == null)
            {
                continue;
            }
            ClothesScript clothesscript = clothing;


            if (stylematches.ContainsKey(clothesscript.clothingstyle))
            {
                stylematches[clothesscript.clothingstyle] += 1;
            }
            else
            {
                stylematches.Add(clothesscript.clothingstyle, 1);
            }

            if (colourmatches.ContainsKey(clothesscript.clothingcolour))
            {
                colourmatches[clothesscript.clothingcolour] += 1;
            }
            else
            {
                colourmatches.Add(clothesscript.clothingcolour, 1);
            }
        }

    }

    public int CalculatePoints(int matches)
    {
        if (matches == 1) // No Matches
        {
            return -5*matches;
        }
        else if (matches == 2) // 1 Match
        {
            return 10*matches;
        }
        else if (matches == 3) // 2 Matches
        {
            return 20*matches;
        }
        else // Other cases that idk
        {
            return 0;
        }
    }

    public void CalculateFinalScore()
    {


        finalscore = 0; // Might change base score depending on other stuff like game stuff

        foreach (var style in stylematches)
        {
            finalscore += CalculatePoints(style.Value);
            Debug.Log("Final score is: " + finalscore);
        }


        int maxvalue = 1;
        foreach (var colour in colourmatches)
        {
            if (colour.Value > maxvalue)
            {
                maxvalue = colour.Value;
            }
        }

        finalscore += basescore;
        finalscore *= maxvalue;

        if (finalscore < 0)
        {
            finalscore = 0;
        }

        Debug.Log("Final score is: " + finalscore);
        scoretext.text = "Score: " + finalscore;
    }

    public void CalculateBaseScore()
    {
        basescore = 0;
        foreach (ClothesScript clothing in clothingitems)
        {
            basescore += clothing.basepoints;
        }
    }

}
