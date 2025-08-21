using UnityEngine;

public class BuyClothing : MonoBehaviour, IBuyable
{
    public ClothesScript clothing;
    public ClothingData clothingdata;
    public int cost;

    public bool Buy()
    {
        if (ContextScript.instance.currentbalance >= cost)
        {
            ContextScript.instance.currentbalance -= cost;

            ContextScript.instance.notownedclothingdatas.Remove(clothingdata);
            ContextScript.instance.ownedclothingdatas.Add(clothingdata);
            Destroy(gameObject);
            return true;
        }
        else
        {
            return false;
        }

    }

    // Fills data after something is filled
    public void FillData(GameObject obj)
    {
        clothing = obj.GetComponent<ClothesScript>();
        clothingdata = clothing.ClothingData;
        cost = clothingdata.cost;
    }


}
