using UnityEngine;
using System.Collections.Generic;

//For the games current location, photographer, model, etc;
public class ContextScript : MonoBehaviour
{
    public GameObject currentlocationobj;
    public GameObject currentmodelobj;

    public LocationScript currentlocation;
    public GameObject currentPhotographer;
    public ModelScript currentmodel;

    public List<ClothingData> notownedclothingdatas = new List<ClothingData>();


    public List<ModelData> notownedmodeldatas = new List<ModelData>();
    public List<Location> notownedlocationdatas = new List<Location>();
    public List<GameObject> notownedphotographerdatas = new List<GameObject>();

    public List<ClothingData> ownedclothingdatas = new List<ClothingData>();

    public List<ClothingData> selectedclothes = new List<ClothingData>();


    public List<ClothingData> allshoes = new List<ClothingData>();
    public List<ClothingData> alldresses = new List<ClothingData>();
    public List<ClothingData> allelse = new List<ClothingData>();



    //money
    public int currentbalance = 0;

    public int currentround = 0;

    public static ContextScript instance;

    private void Awake() // Add a singleton
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    private void Start()
    {
        currentlocation = currentlocationobj.GetComponent<LocationScript>();
        currentmodel = currentmodelobj.GetComponent<ModelScript>();
        PickRandomLocation();
        Randomize(allshoes, 2, 1);
        Randomize(alldresses, 1, 1);
        Randomize(allelse, 2, 1);

        

    }

    public void Randomize(List<ClothingData> clothings, int amountselect, int amountowned)
    {
        if (amountselect > 0)
        {
            for (int i = 0; i < amountselect; i++)
            {
                int randomindex = Random.Range(0, clothings.Count);
                selectedclothes.Add(clothings[randomindex]);
                clothings.RemoveAt(randomindex);
            }
        }

        if (amountowned > 0)
        {
            for (int i = 0; i < amountowned; i++)
            {
                int randomindex = Random.Range(0, clothings.Count);
                ownedclothingdatas.Add(clothings[randomindex]);
                clothings.RemoveAt(randomindex);
            }
        }


        foreach (ClothingData clothing in clothings)
        {
            notownedclothingdatas.Add(clothing);
        }

        clothings.Clear();
    }

    public void PickRandomLocation()
    {
        int randomindex = Random.Range(0, 4);

        currentlocationobj.GetComponent<LocationScript>().location = notownedlocationdatas[randomindex];
        notownedlocationdatas.RemoveAt(randomindex);
    }

}
