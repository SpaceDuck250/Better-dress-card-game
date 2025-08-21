using UnityEngine;

public class BuyModel : MonoBehaviour, IBuyable
{
    public int cost;
    public ModelScript modelscript;
    public ModelData modeldata;
    public GameObject modelobj;

    // Minus the cost then add it to bought list and remove from unbought list
    public bool Buy()
    {
        if (ContextScript.instance.currentbalance >= cost)
        {
            ContextScript.instance.currentbalance -= cost;

            ContextScript.instance.notownedmodeldatas.Remove(modeldata);
            ContextScript.instance.notownedmodeldatas.Add(ContextScript.instance.currentmodel.ModelData);
            ContextScript.instance.currentmodel.ModelData = this.modeldata;

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
        modelobj = obj;
        modelscript = obj.GetComponent<ModelScript>();
        modeldata = modelscript.ModelData;
        cost = modeldata.modelcost;
    }
}
