using UnityEngine;

public class SortAnimScript : MonoBehaviour
{
    public float smoothval;
    public RectTransform selectedobj;
    public Vector3 oripos;

    public static SortAnimScript instance;

    private void Awake()
    {
        instance = this;
    }

    public void OnSelectNew(GameObject obj)
    {
        if (selectedobj != null)
        {
            if (selectedobj.gameObject != obj)
            {
                selectedobj.position = oripos;
            }
            else if (selectedobj.gameObject == obj)
            {
                return;
            }
        }
        
        selectedobj = obj.GetComponent<RectTransform>();
        oripos = selectedobj.position;
        selectedobj.position = Vector3.Lerp(selectedobj.position, selectedobj.position + new Vector3(1500, 0, 0), smoothval * Time.deltaTime);
        //obj.transform.position = Vector3.Lerp(obj.transform.position, obj.transform.position + new Vector3(7, 0, 0), smoothval * Time.deltaTime);
        //Debug.Log("sort animation");
    }
}
