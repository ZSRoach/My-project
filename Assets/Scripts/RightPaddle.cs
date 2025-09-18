using UnityEngine;

public class RightPaddle : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //reset paddle position
        transform.position = new Vector3(9f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        //paddle movement
        if ((Input.GetKey(KeyCode.UpArrow))) {
            if (transform.position.y < 3.5) {
                transform.position = new Vector3(transform.position.x, transform.position.y + .1f, transform.position.z);
            }
        }
        if ((Input.GetKey(KeyCode.DownArrow))) {
            if (transform.position.y > -3.5) {
                transform.position = new Vector3(transform.position.x, transform.position.y - .1f, transform.position.z);
            }
        }
    }
}
