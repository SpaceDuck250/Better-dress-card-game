using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

//For the games current location, photographer, model, etc;
public class ContextScript : MonoBehaviour
{
    public LocationScript currentlocation;
    public GameObject currentPhotographer;
    public ModelScript currentmodel;

    public List<ClothingData> notownedclothingdatas = new List<ClothingData>();
    public List<ModelData> notownedmodeldatas = new List<ModelData>();
    public List<Location> notownedlocationdatas = new List<Location>();
    public List<PhotographerData> notownedphotographerdatas = new List<PhotographerData>();

    public List<ClothingData> ownedclothingdatas = new List<ClothingData>();

    //money
    public int currentbalance = 0;

    public static ContextScript instance;

    private void Awake() // Add a singleton
    {
        instance = this;
    }

    // Remove those items from our inventory + give money
    public void OnClothingSubmit()
    {
        currentbalance += PointsManagerScript.instance.CalculateMoney();
        SceneManager.LoadScene("Shop");
    }



}
