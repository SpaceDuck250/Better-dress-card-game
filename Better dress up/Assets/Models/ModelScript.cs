using UnityEngine;
using static TypesScript;

public class ModelScript : MonoBehaviour
{
    public ModelData ModelData;

    public int TryBoost(Clothingtype type)
    {
        if (ModelData.boosttype == type)
        {
            return ModelData.boostamount;
        }
        else
        {
            return 1;
        }
    }
}
