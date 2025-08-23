using UnityEngine;

public class CardScript : MonoBehaviour
{
    public bool up = false;
    public Vector3 startpos;
    public float upamount;
    public Vector3 Destination;
    public float smoothvalue;

    private void Start()
    {
        startpos = transform.position;
        Destination = startpos;
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
            Destination = transform.position + new Vector3(0, upamount, 0);
        }
        else
        {
            Destination = startpos;
        }
    }

    private void FixedUpdate()
    {
        if (transform.position != Destination)
        {
            transform.position = Vector3.Lerp(transform.position, Destination, Time.fixedDeltaTime * smoothvalue);
        }
    }

}
