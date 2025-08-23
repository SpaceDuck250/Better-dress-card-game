using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class ItemGeneratorScript : MonoBehaviour
{
    public GameObject clothingtemplate;
    public Transform container;

    public bool filled = false;
    public sorttype sortby;

    public enum sorttype
    {
        colour,
        style,
        clothingtype
    }

    public List<ClothingData> clothingsunsorted = new List<ClothingData>();
    public List<ClothingData> sortedclothes = new List<ClothingData>();

    public static ItemGeneratorScript instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        GenerateClothing(ContextScript.instance.ownedclothingdatas);
    }

    public void GenerateClothing(List<ClothingData> clothingstogenerate)
    {
        ClearContainer();

        int xindex = 0;
        int yindex = 0;


        foreach (ClothingData clothing in clothingstogenerate)
        {
            GameObject newclothingitem = Instantiate(clothingtemplate, container);
            RectTransform newclothingrect = newclothingitem.GetComponent<RectTransform>();

            newclothingitem.GetComponent<ClothesScript>().ClothingData = clothing;
            newclothingitem.GetComponent<ClothesScript>().FillData();
            newclothingitem.GetComponent<Image>().sprite = clothing.pic;

            newclothingrect.position += new Vector3(xindex * 200, yindex * -270f, 0);

            GameObject cacheddata = newclothingitem;
            newclothingitem.GetComponent<Button>().onClick.AddListener(() => { SelectScript.instance.TryAdd(cacheddata); });


            if (!filled)
            {
                clothingsunsorted.Add(newclothingitem.GetComponent<ClothesScript>().ClothingData);

            }


            newclothingitem.SetActive(true);

            xindex++;
            if (xindex == 3)
            {
                xindex = 0;
                yindex++;
            }

        }

        filled = true;
    }

    public void ClearContainer()
    {
        foreach (Transform child in container)
        {
            if (child.tag == "ignore")
            {
                continue;
            }
            Destroy(child.gameObject);
        }
    }

    public void SortBy(sorttype sortby) // yeah yeah i know i could use interfaces
    {
        sortedclothes.Clear();

        if (sortby == sorttype.colour)
        {
            var sorted = clothingsunsorted.OrderBy(a => a.clothingcolour);
            sortedclothes = sorted.ToList();
        }
        else if (sortby == sorttype.style)
        {
            var sorted = clothingsunsorted.OrderBy(a => a.clothingstyle);
            sortedclothes = sorted.ToList();
        }
        else if (sortby == sorttype.clothingtype)
        {
            var sorted = clothingsunsorted.OrderBy(a => a.clothingtype);
            sortedclothes = sorted.ToList();
        }

        GenerateClothing(sortedclothes);
    }

    

    
}
