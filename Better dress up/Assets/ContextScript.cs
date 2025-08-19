using UnityEngine;

//For the games current location, photographer, model, etc;
public class ContextScript : MonoBehaviour
{
    public LocationScript currentlocation;
    public GameObject currentPhotographer;

    public static ContextScript instance;

    private void Awake()
    {
        instance = this;
    }

}
