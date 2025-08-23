using UnityEngine;

// used for the clothing slots
public class DressUp : MonoBehaviour
{
    public TypesScript.Clothingtype searchtype;

    // Dependency injection via the dress up manager
    public void ApplyClothing(ClothingData clothing)
    {
        transform.position = clothing.settransform.position;
        GetComponent<SpriteRenderer>().sortingOrder = clothing.sortinglayer;
        GetComponent<SpriteRenderer>().sprite = clothing.applypic;
    }

    public void SetEmpty()
    {
        GetComponent<SpriteRenderer>().sprite = null;
    }
}
