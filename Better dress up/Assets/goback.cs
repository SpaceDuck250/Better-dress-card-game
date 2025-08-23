using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goback : MonoBehaviour
{
    public Dictionary<TypesScript.Clothingtype, int> typebasket = new Dictionary<TypesScript.Clothingtype, int>();

    public void Back()
    {
        if (CheckIfViable())
        {
            SceneManager.LoadScene("Select");
        }
        else
        {
            Destroy(ContextScript.instance.gameObject);
            SceneManager.LoadScene("StartMenu");
            // Later change to start menu
        }
    }

    public void BackToPlay()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public bool CheckIfViable()
    {
        typebasket.Clear();

        foreach (ClothingData item in ContextScript.instance.ownedclothingdatas)
        {
            if (!typebasket.ContainsKey(item.clothingtype))
            {
                typebasket.Add(item.clothingtype, 1);
            }
            else
            {
                typebasket[item.clothingtype]++;
            }
        }

        int sumclothes = 0;
        foreach (var data in typebasket)
        {
            sumclothes += data.Value;
        }

        if (sumclothes >= 5)
        {
            if (typebasket.ContainsKey(TypesScript.Clothingtype.top)
            && typebasket.ContainsKey(TypesScript.Clothingtype.bottom)
            && typebasket.ContainsKey(TypesScript.Clothingtype.shoes))
            {
                return true;
            }
            else if (typebasket.ContainsKey(TypesScript.Clothingtype.shoes)
                && typebasket.ContainsKey(TypesScript.Clothingtype.dress))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }

    }

}


