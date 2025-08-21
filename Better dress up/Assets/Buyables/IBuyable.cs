using UnityEngine;

public interface IBuyable
{
    bool Buy();

    // Fills the data for the buy function when item is being picked in shop
    void FillData(GameObject obj);
}
