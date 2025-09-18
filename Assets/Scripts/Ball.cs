using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float ballSpeed;
    public Vector2 direction;
    AudioSource paddleHit;
    AudioSource borderHit;

    void Start()
    {
        transform.position = new Vector3(0f, 0f, 0f);
        ballSpeed = newSpeed();
        direction = launch(true);
        paddleHit = GetComponents<AudioSource>()[0];
        borderHit = GetComponents<AudioSource>()[1];
    }

    public Vector2 launch(bool right) {
        transform.position = new Vector3(0f, 0f, 0f);
        float angle = 0;
        if (!right) {
            if (Random.Range(0, 2) == 0)
            {
                angle = Random.Range(.7f, .8f);
            }
            else
            {
                angle = Random.Range(1.2f, 1.3f);
            }
        }
        else {
            if (Random.Range(0, 2) == 0)
            {
                angle = Random.Range(.2f, .3f);
            }
            else {
                angle = Random.Range(1.7f, 1.8f);
            }
        }

        Vector2 direction = new Vector2(Mathf.Cos(angle * Mathf.PI), Mathf.Sin(angle * Mathf.PI));
        return direction;
    }

    public float newSpeed() {
        return 8*Random.Range(.6f, 1.2f);
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().linearVelocity = direction * ballSpeed;
       
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Edge")) {
            direction.y = -direction.y;
            borderHit.Play();
        }
        if (collision.gameObject.CompareTag("RightGoal")) {
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().goal(true);
        }
        if (collision.gameObject.CompareTag("LeftGoal")) {
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().goal(false);
        }
        if (collision.gameObject.CompareTag("Paddle"))
        {
            direction.x = -direction.x;
            paddleHit.Play();
        }
        if (collision.gameObject.CompareTag("Paddle2"))
        {
            direction.x = -direction.x;
            paddleHit.Play();
        }
    }
}
