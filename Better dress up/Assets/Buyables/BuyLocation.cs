using UnityEngine;

public class BuyLocation : MonoBehaviour, IBuyable
{
    public int cost;
    public LocationScript locationscript;
    public Location location;
    public GameObject locationobj;

    // Minus the cost then add it to bought list and remove from unbought list
    public bool Buy()
    {
        if (ContextScript.instance.currentbalance >= cost)
        {
            ContextScript.instance.currentbalance -= cost;

            ContextScript.instance.notownedlocationdatas.Remove(location);
            ContextScript.instance.notownedlocationdatas.Add(ContextScript.instance.currentlocation.location);
            ContextScript.instance.currentlocation.location = this.location;


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
        locationobj = obj;
        locationscript = obj.GetComponent<LocationScript>();
        location = locationscript.location;
        cost = location.locationcost;
    }

}
