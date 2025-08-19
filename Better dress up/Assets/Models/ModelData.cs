using UnityEngine;

[CreateAssetMenu(fileName = "ModelData", menuName = "Scriptable Objects/ModelData")]
public class ModelData : ScriptableObject
{
    public string modelname;
    public TypesScript.Clothingtype boosttype;
    public int boostamount;
}
