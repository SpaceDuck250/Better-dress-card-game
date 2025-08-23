using UnityEngine;

public class Daisy : MonoBehaviour, IAddPerItemPhotographer
{
    public int BonusAmount;

    public int SendPerItemBonus(ClothesScript clothing)
    {
        if (clothing.clothingcolour == TypesScript.Clothingcolour.pink)
        {
            return BonusAmount;
        }
        else
        {
            return 0;
        }
    }
}
