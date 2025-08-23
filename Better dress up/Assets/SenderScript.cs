using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;
using TMPro;
using System.Collections;

public class SenderScript : MonoBehaviour
{
    public List<ClothesScript> clothesselection = new List<ClothesScript>();
    public SelectorScript selector;
    public TextMeshProUGUI scoretext;

    public static SenderScript instance;

    public Dictionary<TypesScript.Clothingtype, int> typebasket = new Dictionary<TypesScript.Clothingtype, int>();

    // If 3 slots are filled
    public UnityEvent OnFill;
    public UnityEvent OnNotFilled;

    private void Awake()
    {
        instance = this;
    }

    public void Fill()
    {
        clothesselection.Clear();
        foreach (GameObject clothingitem in selector.selectedobjlist)
        {
            clothesselection.Add(clothingitem.GetComponent<ClothesScript>());
        }

        if (MeetsRequirements())
        {
            OnFill?.Invoke();
        }
        else
        {
            OnNotFilled?.Invoke();
        }
    }

    public bool MeetsRequirements()
    {
        typebasket.Clear();

        foreach (GameObject item in SelectorScript.instance.selectedobjlist)
        {
            if (!typebasket.ContainsKey(item.GetComponent<ClothesScript>().clothingtype))
            {
                typebasket.Add(item.GetComponent<ClothesScript>().clothingtype, 1);
            }
            else
            {
                typebasket[item.GetComponent<ClothesScript>().clothingtype]++;
            }
        }



        if (typebasket.ContainsKey(TypesScript.Clothingtype.top) 
            && typebasket.ContainsKey(TypesScript.Clothingtype.bottom) 
            && typebasket.ContainsKey(TypesScript.Clothingtype.shoes) 
            && clothesselection.Count >= 3
            && !typebasket.ContainsKey(TypesScript.Clothingtype.dress))
        {
            return true;
        }
        else if (typebasket.ContainsKey(TypesScript.Clothingtype.dress)
        && typebasket.ContainsKey(TypesScript.Clothingtype.shoes) 
        && clothesselection.Count == 2
        || clothesselection.Count == 3 
        && typebasket.ContainsKey(TypesScript.Clothingtype.shoes) 
        && typebasket.ContainsKey(TypesScript.Clothingtype.dress) 
        && typebasket.ContainsKey(TypesScript.Clothingtype.accessory))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
