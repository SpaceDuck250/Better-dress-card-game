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

    // Single calculations
    public int CalculatePoints(int matches)
    {
        if (matches == 1) // No Matches
        {
            return -5;
        }
        else if (matches == 2) // 1 Match
        {
            return 10;
        }
        else if (matches >= 3) // 2 Matches
        {
            return 20;
        }
        else // Other cases that idk
        {
            return 0;
        }
    }

    // Final score calculation
    public void CalculateFinalScore()
    {


        finalscore = 0; // Might change base score depending on other stuff like game stuff


        // (BASE SCORE + STYLE MATCH POINTS) * LOCATION BOOST
        // Storing the sum of style match points + base then * by location then adding that cachedsum to the final
        foreach (ClothesScript clothing in clothingitems)
        {
            int cachedsum = clothing.basepoints;
            cachedsum += CalculatePoints(stylematches[clothing.clothingstyle]);
            cachedsum *= ContextScript.instance.currentlocation.TryBoost(clothing.clothingstyle);
            cachedsum *= ContextScript.instance.currentmodel.TryBoost(clothing.clothingtype);
            finalscore += cachedsum;

            // Photographer bonus
            if (ContextScript.instance.currentPhotographer.GetComponent<IAddPerItemPhotographer>() != null)
            {
                Debug.Log("added bonus to score");
                finalscore += ContextScript.instance.currentPhotographer.GetComponent<IAddPerItemPhotographer>().SendPerItemBonus(clothing);
            }
            Debug.Log("Fi");
            Debug.Log("Final Score " + finalscore);
        }

        // COLOUR MATCHES
        // Finds max value of colourmatches then * the final score after all additions
        int maxvalue = 1;
        foreach (var colour in colourmatches)
        {
            if (colour.Value > maxvalue)
            {
                maxvalue = colour.Value;
            }
        }

        finalscore *= maxvalue;

        // Photographer bonus
        if (ContextScript.instance.currentPhotographer.GetComponent<IAddTotalPhotographer>() != null)
        {
            finalscore += ContextScript.instance.currentPhotographer.GetComponent<IAddTotalPhotographer>().SendBonus(this);
        }

        if (finalscore < 0)
        {
            finalscore = 0;
        }


        StatSetterScript.instance.SetScore(finalscore);
    }

    public int CalculateMoney()
    {
        int moneymade = Mathf.RoundToInt((finalscore - StatSetterScript.instance.target)/2);
        return moneymade;
    }

}
