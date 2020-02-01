using UnityEngine;
using UnityEngine.Analytics;

public class DoorOperation : MonoBehaviour
{
    public float openSpeed = 5f;
    public float closeSpeed = -5f;
    private float originalPosition;
    // Use this for initialization

    private void Start()
    {
        originalPosition = transform.position.y;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.WordMade == true)
        {
            if (transform.position.y < originalPosition + 3)
            {
                //GetComponentInChildren<AudioSource>().Play();
                float step = openSpeed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position,
                    new Vector3(transform.position.x, 5.8f, transform.position.z), step);
            }
        }
    }
}