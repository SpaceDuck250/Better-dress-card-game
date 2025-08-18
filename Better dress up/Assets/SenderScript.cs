using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;

public class SenderScript : MonoBehaviour
{
    public List<ClothesScript> clothesselection = new List<ClothesScript>();
    public SelectorScript selector;

    public static SenderScript instance;

    public UnityEvent OnFill;

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
    }
}
