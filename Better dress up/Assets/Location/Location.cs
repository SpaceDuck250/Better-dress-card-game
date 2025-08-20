using UnityEngine;

[CreateAssetMenu(fileName = "Location", menuName = "Scriptable Objects/Location")]
public class Location : ScriptableObject
{
    public string LocationName;
    public Sprite LocationImage;
    public int boostamount;
    public TypesScript.Clothingstyle styleboosted;
    public int locationcost;
}
