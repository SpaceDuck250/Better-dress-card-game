using UnityEngine;

public class ShopSelect : MonoBehaviour
{
    public Camera cam;
    public Vector3 mousepos;
    public IBuyable buyable;

    public GameObject buypanel;

    private void Update()
    {
        mousepos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Collider2D hit = Physics2D.OverlapPoint(mousepos);
            if ((hit != null && hit.gameObject.tag == "shopitem")) // Calls the try buy function (interface)
            {
                buyable = hit.GetComponent<IBuyable>();
                buypanel.SetActive(true);
            }
        }

    }

    // tries to buy (if enough money) item
    public void TryBuy()
    {
        if (buyable.Buy())
        {
            Debug.Log("Bought");
            CloseBuyPanel();
        }
        else
        {
            Debug.Log("Too expensive");
        }
    }

    public void CloseBuyPanel()
    {
        buypanel.SetActive(false);
    }

}
