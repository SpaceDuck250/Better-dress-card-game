using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;
using System.Linq;

public class SelectorScript : MonoBehaviour
{
    public Camera cam;
    Vector3 mousepos;

    public CardScript selectedobj;
    public bool flipbool = false;

    public bool isPaused = false;

    public List<GameObject> selectedobjlist = new List<GameObject>();

    public UnityEvent OnClickNewItem;

    public static SelectorScript instance;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        mousepos = cam.ScreenToWorldPoint(Input.mousePosition);
        if (!isPaused)
        {
            Collider2D hit = Physics2D.OverlapPoint(mousepos);



            if (hit != null && hit.gameObject.tag == "card" && Input.GetKeyDown(KeyCode.Mouse0))
            {
                BringCardUporDown(hit.gameObject);
                SenderScript.instance.Fill();
                OnClickNewItem.Invoke();
            }
        }

    }


    // Brings card up or down, up if new, down if we click on the same obj. Also brings down old cards
    public void BringCardUporDown(GameObject hit)
    {


        if (hit.gameObject.GetComponent<CardScript>().up)
        {
            selectedobj = hit.gameObject.GetComponent<CardScript>();
            selectedobj.GoDown();
            selectedobjlist.Remove(selectedobj.gameObject);
            //selectedobjlist.RemoveAll(n => n.gameObject == selectedobj.gameObject);
            selectedobj = null;


           
        }
        else if (TypeAlreadyExists(hit))
        {

            selectedobj = hit.gameObject.GetComponent<CardScript>();
            selectedobj.GoUp();
            selectedobjlist.Add(hit);

            

        }
        else
        {
            selectedobj = hit.gameObject.GetComponent<CardScript>();
            selectedobj.GoUp();
            selectedobjlist.Add(hit);

            if (hit.GetComponent<ClothesScript>().clothingtype == TypesScript.Clothingtype.dress)
            {
                RemoveType(TypesScript.Clothingtype.top);
                RemoveType(TypesScript.Clothingtype.bottom);
            }
            else if (hit.GetComponent<ClothesScript>().clothingtype == TypesScript.Clothingtype.top || hit.GetComponent<ClothesScript>().clothingtype == TypesScript.Clothingtype.bottom)
            {
                RemoveType(TypesScript.Clothingtype.dress);
            }


        }



        // if the card is up then set that to selected card then bring it down
        // if the new card is same type then go to our list to remove old card of same type
        // other wise if no card selected or no card of that type is selected then just select

        // selected card is just to apply effects to that current card, the list is actually all the cards we selected


    }

    // Checks if we already have a clothing type so we can switch out
    public bool TypeAlreadyExists(GameObject newitem)
    {


        foreach (GameObject clothing in selectedobjlist)
        {

            if (clothing.GetComponent<ClothesScript>().clothingtype == newitem.GetComponent<ClothesScript>().clothingtype)
            {
                clothing.GetComponent<CardScript>().GoDown();
                selectedobjlist.Remove(clothing);
                return true;
            }

            //if (clothing.GetComponent<ClothesScript>().clothingtype == newitem.GetComponent<ClothesScript>().ClothingData.secondclothingtype)
            //{
            //    clothing.GetComponent<CardScript>().GoDown();
            //    selectedobjlist.Remove(clothing);
            //    selectedobjlist.Add(newitem);
            //    check++;
            //    continue;
            //}

        }

        return false;


    }


    // no pants and shirt when having dress
    public void RemoveType(TypesScript.Clothingtype type)
    {
        foreach (GameObject n in selectedobjlist)
        {
            if (n.gameObject.GetComponent<ClothesScript>().clothingtype == type)
            {
                n.GetComponent<CardScript>().GoDown();
                selectedobjlist.Remove(n);
                return;
            }


        }
    }

    
}
