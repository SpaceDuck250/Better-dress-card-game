using UnityEngine;

public class OtherCardScript : MonoBehaviour
{
    public bool up = false;
    public Vector3 startpos;
    public float upamount;
    public Vector3 Destination;
    public float smoothvalue;
    public RectTransform rect;

    private void Start()
    {
        startpos = transform.position;
        Destination = startpos;
        rect = GetComponent<RectTransform>();
    }

    public void GoUp()
    {
        up = true;
        LerpDownOrUp();

    }

    public void GoDown()
    {
        up = false;
        LerpDownOrUp();
    }

    public void LerpDownOrUp()
    {
        if (up)
        {
            Destination = rect.position + new Vector3(0, upamount, 0);

        }
        else
        {
            Destination = startpos;
        }
    }

    private void FixedUpdate()
    {
        if (rect.position != Destination)
        {
            GetComponent<RectTransform>().position = Vector3.Lerp(rect.position, Destination, Time.fixedDeltaTime * smoothvalue);
            Debug.Log("not same pos");
        }
    }
}
