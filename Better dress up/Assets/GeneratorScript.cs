using UnityEngine;

public class GeneratorScript : MonoBehaviour
{
    public GameObject template;
    public Transform container;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GenerateDeck();
    }

    public void GenerateDeck()
    {
        int xindex = 0;

        foreach (ClothingData cdata in ContextScript.instance.selectedclothes)
        {
            GameObject newitem = Instantiate(template, container);
            newitem.GetComponent<ClothesScript>().ClothingData = cdata;
            newitem.GetComponent<ClothesScript>().FillData();

            newitem.transform.position += new Vector3(xindex * 4f, 0, 0);
            xindex++;

            newitem.SetActive(true);
        }
    }
}
