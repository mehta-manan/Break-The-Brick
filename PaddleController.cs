using UnityEngine;

public class PaddleController : MonoBehaviour
{
    private float speed;
    private Rigidbody2D rb;

    public float Speed = 1;

    private float width;

    ScreenUtils screenUtils;

    private void Start()
    {
        screenUtils = FindObjectOfType<ScreenUtils>();

        width = GetComponent<BoxCollider2D>().bounds.size.x;

        transform.position = new Vector3(Random.Range(screenUtils.LeftBottomX + width/2, screenUtils.RightBottomX - width/2), transform.position.y, transform.position.z);
        
        rb = GetComponent<Rigidbody2D>();
    }

    public void MoveLeft()
    {
        speed = -Speed;
    }

    public void MoveRight()
    {
        speed = Speed;
    }

    public void Stop()
    {
        speed = 0;
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(speed, 0);
    }
}


