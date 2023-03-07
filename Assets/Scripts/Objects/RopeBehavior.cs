using UnityEngine;

public class RopeBehavior : MonoBehaviour
{
    public bool Cut;
    public GameObject Box;
    public Transform EndLocation;
    public float DropSpeed;
    public float RotateSpeed;

    private void Update()
    {
        if (Cut)
        {
            Box.transform.position = Vector3.MoveTowards(Box.transform.position, EndLocation.position, DropSpeed * Time.deltaTime);
            Box.transform.rotation = Quaternion.RotateTowards(Box.transform.rotation, EndLocation.rotation, RotateSpeed * Time.deltaTime);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Cut = true;
            GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
