using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.HID;

public class DressUpScript : MonoBehaviour
{
    public Transform container;
    public Transform[] dressupslots = new Transform[5];

    public void DressUp()
    {
        foreach (Transform child in dressupslots)
        {
            child.gameObject.GetComponent<DressUp>().SetEmpty();
        }


        int i = 0;
        foreach (ClothesScript clothing in SenderScript.instance.clothesselection)
        {
            //foreach (Transform child in container)
            //{
            //    if (child.gameObject.GetComponent<DressUp>().searchtype == clothing.clothingtype)
            //    {
            //        Debug.Log(child.position);
            //        child.gameObject.GetComponent<DressUp>().ApplyClothing(clothing.ClothingData);
            //        Debug.Log(child.position);
            //        Debug.Log(clothing.ClothingData.settransform.position);
            //    }
            //    Debug.Log(child.name);
            //}

            dressupslots[i].gameObject.GetComponent<DressUp>().ApplyClothing(clothing.ClothingData);
            i++;
        }
    }
}
