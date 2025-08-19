using UnityEngine;
using static TypesScript;

public class LocationScript : MonoBehaviour
{
    public Location location;

    // Will check if same style as styleboosted and will boost if so
    public int TryBoost(Clothingstyle style)
    {
        if (style == location.styleboosted)
        {
            return location.boostamount;
        }
        return 1;
    }
}
