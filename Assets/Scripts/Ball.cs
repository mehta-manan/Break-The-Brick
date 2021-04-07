using UnityEngine;

public class Ball : MonoBehaviour
{
    public float xForce;
    public float yForce;

    public GameObject paddle;
    public GameObject loseUI;
    public GameObject winUI;

    Rigidbody2D rb;

    Score score;

    AudioSource audioS;

    public AudioClip[] clips;

    private void Start()
    {
        transform.position = new Vector3(paddle.transform.position.x, transform.position.y, transform.position.z);
        rb = GetComponent<Rigidbody2D>();
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>();
        audioS = GetComponent<AudioSource>();
    }

    private void Update()
    {
        Debug.Log("Velocity: " + rb.velocity);
        if (GameObject.FindGameObjectsWithTag("Brick").Length == 0)
        {
            Time.timeScale = 0f;
            winUI.SetActive(true);
        }

        Debug.Log("timescale:" + Time.timeScale);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Brick"))
        {
            Destroy(collision.gameObject);
            score.CurrentScore++;
            score.scoreText.text = "Score      " + score.CurrentScore.ToString();
            ChangeAudio(0);
        }

        if (collision.gameObject.CompareTag("Bottom"))
        {
            Time.timeScale = 0f;
            loseUI.SetActive(true);
            ChangeAudio(1);
        }

        if (collision.gameObject.CompareTag("Paddle"))
        {
            Vector2 paddleCenter = paddle.transform.position;
            Vector2 hitPoint = collision.contacts[0].point;
            rb.velocity = Vector2.zero;

            float difference = paddleCenter.x - hitPoint.x;

            int direction;
            if (hitPoint.x < paddleCenter.x)
                direction = -1;
            else
                direction = 1;

            rb.AddForce(new Vector2(direction * Mathf.Abs(difference * xForce), yForce));

            ChangeAudio(0);
        }
    }

    private void ChangeAudio(int ac)
    {
        audioS.clip = clips[ac];
        audioS.Play();
    }
}
