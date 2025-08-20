using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;
using TMPro;

public class SenderScript : MonoBehaviour
{
    public List<ClothesScript> clothesselection = new List<ClothesScript>();
    public SelectorScript selector;
    public TextMeshProUGUI scoretext;

    public static SenderScript instance;

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

        if (clothesselection.Count == 3)
        {
            OnFill?.Invoke();
        }
        else
        {
            OnNotFilled?.Invoke();
        }
    }
}
