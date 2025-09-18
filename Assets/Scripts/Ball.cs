using UnityEngine;

public class Ball : MonoBehaviour
{
    // variable declaration
    public float ballSpeed;
    public Vector2 direction;
    AudioSource paddleHit;
    AudioSource borderHit;

    void Start()
    {
        //variable assignment
        transform.position = new Vector3(0f, 0f, 0f);
        ballSpeed = newSpeed();
        direction = launch(true);
        paddleHit = GetComponents<AudioSource>()[0];
        borderHit = GetComponents<AudioSource>()[1];
    }

    //acquires a new direction for the ball to go, keeping track of who scored last
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
        //vector calculation
        Vector2 direction = new Vector2(Mathf.Cos(angle * Mathf.PI), Mathf.Sin(angle * Mathf.PI));
        return direction;
    }

    //acquires a random speed for the ball
    public float newSpeed() {
        return 8*Random.Range(1f, 1.4f);
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().linearVelocity = direction * ballSpeed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //handles ball collisions with various game objects
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
