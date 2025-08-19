using UnityEngine;

//For the games current location, photographer, model, etc;
public class ContextScript : MonoBehaviour
{
    public LocationScript currentlocation;

    public static ContextScript instance;

    private void Awake()
    {
        instance = this;
    }
}
