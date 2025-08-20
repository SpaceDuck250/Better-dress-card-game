using UnityEngine;

public class ClothesScript : MonoBehaviour
{
    public ClothingData ClothingData;

    private void Awake()
    {
        if (ClothingData != null)
        {
            FillData();
        }
        else
        {
            Debug.Log(gameObject.name + " doesnt have any data");
        }
    }

    public TypesScript.Clothingtype clothingtype;

    public TypesScript.Clothingstyle clothingstyle;

    public TypesScript.Clothingcolour clothingcolour;

    public int basepoints;

    // Fills Data
    public void FillData()
    {
        clothingtype = ClothingData.clothingtype;
        clothingstyle = ClothingData.clothingstyle;
        clothingcolour = ClothingData.clothingcolour;
        basepoints = ClothingData.basepoints;
        gameObject.GetComponent<SpriteRenderer>().sprite = ClothingData.pic;
    }

}
