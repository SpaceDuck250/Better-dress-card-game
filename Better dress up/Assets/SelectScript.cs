using UnityEngine;
using System.Collections.Generic;
using System.ComponentModel;


public class SelectScript : MonoBehaviour
{
    public Camera cam;
    public Vector3 mousepos;
    public List<ClothingData> selectedClothes = new List<ClothingData>();

    public Dictionary<TypesScript.Clothingtype, int> typebasket = new Dictionary<TypesScript.Clothingtype, int>();

    public static SelectScript instance;

    public GameObject SubmitButton;
    private void Awake()
    {
        instance = this;
    }

    public void TryAdd(GameObject hit)
    {
        if (selectedClothes.Contains(hit.GetComponent<ClothesScript>().ClothingData))
        {
            selectedClothes.Remove(hit.GetComponent<ClothesScript>().ClothingData);
            hit.transform.Find("gray").gameObject.SetActive(false);
            Debug.Log("SAME OBJECT");
            AudioScript.instance.PlayFx(AudioScript.instance.click);
            OnSelectNewCard();

            return;
        }

        if (selectedClothes.Count == 5)
        {
            return;


        }

        selectedClothes.Add(hit.GetComponent<ClothesScript>().ClothingData);
        hit.gameObject.transform.Find("gray").gameObject.SetActive(true);
        AudioScript.instance.PlayFx(AudioScript.instance.click);

        OnSelectNewCard();
    }

    public void OnSubmit()
    {
        AudioScript.instance.PlayFx(AudioScript.instance.click);
        ContextScript.instance.selectedclothes.Clear();
        foreach (ClothingData c in selectedClothes)
        {
            ContextScript.instance.ownedclothingdatas.Remove(c);
            ContextScript.instance.selectedclothes.Add(c);
        }
    }

    public void OnSelectNewCard()
    {
        Debug.Log("New Card");
        if (CheckIfViable())
        {
            SubmitButton.SetActive(true);
        }
        else
        {
            SubmitButton.SetActive(false);
        }
    }

    public bool CheckIfViable()
    {
        typebasket.Clear();

        foreach (ClothingData item in selectedClothes)
        {
            if (!typebasket.ContainsKey(item.clothingtype))
            {
                typebasket.Add(item.clothingtype, 1);
            }
            else
            {
                typebasket[item.clothingtype]++;
            }
        }

        int sumclothes = 0;
        foreach (var data in typebasket)
        {
            sumclothes += data.Value;
        }

        if (sumclothes == 5)
        {
            if (typebasket.ContainsKey(TypesScript.Clothingtype.top)
            && typebasket.ContainsKey(TypesScript.Clothingtype.bottom)
            && typebasket.ContainsKey(TypesScript.Clothingtype.shoes))
            {
                return true;
            }
            else if (typebasket.ContainsKey(TypesScript.Clothingtype.shoes)
                && typebasket.ContainsKey(TypesScript.Clothingtype.dress))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
}
