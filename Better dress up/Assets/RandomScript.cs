using UnityEngine;
using System.Collections.Generic;

public class RandomScript : MonoBehaviour
{
    public ClothingData[] shopclothingitems = new ClothingData[4];
    public GameObject cardtemplate;
    public Transform container;

    public GameObject locationtemplate;

    //So we dont get the same item twice
    public List<int> possibleindices = new List<int>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GenerateRandomItems();
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
            newclothingitem.SetActive(true);

        }
    }

    public void GenerateRandomLocation()
    {
        int randomindex = Random.Range(0, ContextScript.instance.notownedlocationdatas.Count);
        locationtemplate.GetComponent<LocationScript>().location = ContextScript.instance.notownedlocationdatas[randomindex];
        locationtemplate.GetComponent<SpriteRenderer>().sprite = ContextScript.instance.notownedlocationdatas[randomindex].LocationImage;

    }
}
