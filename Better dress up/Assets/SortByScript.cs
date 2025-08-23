using UnityEngine;

public class SortByScript : MonoBehaviour
{
    public ItemGeneratorScript.sorttype sorttype;

    public void Sort()
    {
        SelectScript.instance.selectedClothes.Clear();
        ItemGeneratorScript.instance.SortBy(sorttype);
    }
}
