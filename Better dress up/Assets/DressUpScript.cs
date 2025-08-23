using Unity.VisualScripting;
using UnityEngine;

public class DressUpScript : MonoBehaviour
{
    public Transform container;

    public void DressUp()
    {
        foreach (Transform child in container)
        {
            child.gameObject.GetComponent<DressUp>().SetEmpty();
        }



        foreach (ClothesScript clothing in SenderScript.instance.clothesselection)
        {
            foreach (Transform child in container)
            {
                if (child.gameObject.GetComponent<DressUp>().searchtype == clothing.clothingtype)
                {
                    Debug.Log(child.position);
                    child.gameObject.GetComponent<DressUp>().ApplyClothing(clothing.ClothingData);
                    Debug.Log(child.position);
                    Debug.Log(clothing.ClothingData.settransform.position);
                }
                Debug.Log(child.name);
            }
        }
    }
}
