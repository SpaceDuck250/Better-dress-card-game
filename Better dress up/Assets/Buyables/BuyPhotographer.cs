using UnityEngine;

public class BuyPhotographer : MonoBehaviour
{
    public int cost;
    public GameObject photographerobj;

    // Minus the cost then add it to bought list and remove from unbought list
    public bool Buy()
    {
        if (ContextScript.instance.currentbalance >= cost)
        {
            ContextScript.instance.currentbalance -= cost;

            ContextScript.instance.notownedphotographerdatas.Remove(photographerobj);
            ContextScript.instance.notownedphotographerdatas.Add(ContextScript.instance.currentPhotographer);
            ContextScript.instance.currentPhotographer = photographerobj;


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
        photographerobj = obj;
        cost = photographerobj.GetComponent<PhotographerScript>().PhotographerData.photographercost;
    }
}
