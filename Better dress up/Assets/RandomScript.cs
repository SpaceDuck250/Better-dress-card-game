using UnityEngine;
using System.Collections.Generic;

public class RandomScript : MonoBehaviour
{
    public ClothingData[] shopclothingitems = new ClothingData[4];
    public GameObject cardtemplate;
    public Transform container;

    public GameObject locationtemplate;
    public GameObject modeltemplate;
    public GameObject photographertemplate;

    //So we dont get the same item twice
    public List<int> possibleindices = new List<int>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GenerateRandomItems();
        GenerateRandomLocation();
        GenerateRandomModel();
        GenerateRandomPhotographer();
    }

    // Like the old system we made, dynamically make each and change stats after
    public void GenerateRandomItems()
    {
        int a = 0;
        foreach (var clothing in ContextScript.instance.notownedclothingdatas)
        {
            possibleindices.Add(a);
            a++;
        }


        for (int i = 0; i < shopclothingitems.Length; i++)
        {
            int randomindex = Random.Range(0, possibleindices.Count);
            randomindex = possibleindices[randomindex];
            possibleindices.Remove(randomindex);

            GameObject newclothingitem = Instantiate(cardtemplate, container);

            newclothingitem.transform.position += new Vector3(3.5f * i, 0, 0);
            newclothingitem.GetComponent<ClothesScript>().ClothingData = ContextScript.instance.notownedclothingdatas[randomindex];
            newclothingitem.GetComponent<ClothesScript>().FillData();
            newclothingitem.GetComponent<IBuyable>().FillData(newclothingitem); // works for other types of items too
            newclothingitem.SetActive(true);

        }
    }

    // Search about this later if theres an easier way to do this kinda stuff

    public void GenerateRandomLocation()
    {
        int randomindex = Random.Range(0, ContextScript.instance.notownedlocationdatas.Count);
        locationtemplate.GetComponent<LocationScript>().location = ContextScript.instance.notownedlocationdatas[randomindex];
        locationtemplate.GetComponent<IBuyable>().FillData(locationtemplate);

        locationtemplate.GetComponent<SpriteRenderer>().sprite = ContextScript.instance.notownedlocationdatas[randomindex].LocationImage;

    }

    public void GenerateRandomModel()
    {
        int randomindex = Random.Range(0, ContextScript.instance.notownedmodeldatas.Count);
        modeltemplate.GetComponent<ModelScript>().ModelData = ContextScript.instance.notownedmodeldatas[randomindex];
        modeltemplate.GetComponent<IBuyable>().FillData(modeltemplate);

        modeltemplate.GetComponent<SpriteRenderer>().sprite = ContextScript.instance.notownedmodeldatas[randomindex].modelpic;

    }

    public void GenerateRandomPhotographer()
    {
        int randomindex = Random.Range(0, ContextScript.instance.notownedphotographerdatas.Count);
        photographertemplate.GetComponent<PhotographerScript>().PhotographerData = ContextScript.instance.notownedphotographerdatas[randomindex].GetComponent<PhotographerScript>().PhotographerData;
        photographertemplate.GetComponent<IBuyable>().FillData(ContextScript.instance.notownedphotographerdatas[randomindex]);

        photographertemplate.GetComponent<SpriteRenderer>().sprite = ContextScript.instance.notownedphotographerdatas[randomindex].GetComponent<PhotographerScript>().PhotographerData.pic;

    }
}
