using UnityEngine;

public class LeftPaddle : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    

    void Start()
    {
        transform.position = new Vector3(-9f, 0f, 0f);
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKey(KeyCode.W)))
        {
            if (transform.position.y < 3.5)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + .02f, transform.position.z);
            }
        }
        if ((Input.GetKey(KeyCode.S)))
        {
            if (transform.position.y > -3.5)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - .02f, transform.position.z);
            }
        }
    }
}
