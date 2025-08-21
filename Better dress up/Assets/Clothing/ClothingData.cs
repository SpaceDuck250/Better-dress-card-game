using UnityEngine;

[CreateAssetMenu(fileName = "ClothingData", menuName = "Scriptable Objects/ClothingData")]
public class ClothingData : ScriptableObject
{
    public TypesScript.Clothingtype clothingtype;

    public TypesScript.Clothingstyle clothingstyle;

    public TypesScript.Clothingcolour clothingcolour;

    public int basepoints;

    public Sprite pic;

    public int cost;
}
