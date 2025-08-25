using UnityEngine;

public class SortByScript : MonoBehaviour
{
    public ItemGeneratorScript.sorttype sorttype;

    public void Sort()
    {
        SelectScript.instance.selectedClothes.Clear();
        ItemGeneratorScript.instance.SortBy(sorttype);
        SelectScript.instance.SubmitButton.SetActive(false);
    }

    // Pass its gameobject to the anim
    public void PassGameObject()
    {
        SortAnimScript.instance.OnSelectNew(gameObject);
    }
}
