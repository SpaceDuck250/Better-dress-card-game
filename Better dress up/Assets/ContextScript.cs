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
    }



}
