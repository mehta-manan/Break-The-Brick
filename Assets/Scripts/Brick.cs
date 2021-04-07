using UnityEngine;

public class Brick : MonoBehaviour
{
    private float width;
    private float height;

    public GameObject prefabBrick;
    private float x;
    public float y;

    public float totalNumberOfBricks;
    public int bricksInRow;

    ScreenUtils screenUtils;

    public GameObject prefabBrickShadow;
    public float shadowOffsetX;
    public float shadowOffsetY;

    public Color32[] colors;

    private void Start()
    {
        Time.timeScale = 1f;

        // Get screen utilities
        screenUtils = FindObjectOfType<ScreenUtils>();

        // Instantiate brick to get width and height, and destroy it.
        GameObject brick = Instantiate(prefabBrick, Vector2.zero, Quaternion.identity);

        width = brick.GetComponent<BoxCollider2D>().bounds.size.x;
        height = brick.GetComponent<BoxCollider2D>().bounds.size.y;

        // Debug.Log(width);
        // Debug.Log(height);

        Destroy(brick);

        /* Algorithm to divide objects evenly:
         * blank space = total space - (width of one piece * number of pieces)
         * number of gaps = number of pieces + 1
         * space between = blank space / number of gaps
        */
        float screenWidthInWorld = screenUtils.RightBottomX - screenUtils.LeftBottomX;
        float emptySpace = screenWidthInWorld - (width * bricksInRow);
        int numberOfGaps = bricksInRow + 1;
        float spaceBetweenBricks = emptySpace / numberOfGaps;

        //Debug.Log("screenUtils.ScreenLeftBottomX: " + screenUtils.LeftBottomX);
        //Debug.Log("screenUtils.ScreenRightBottomX: " + screenUtils.RightBottomX);
        //Debug.Log("emptySpace: " + emptySpace);
        //Debug.Log("spaceBetweenBricks: " + spaceBetweenBricks);

        // screen left x + give space + (width/2) as object axis are in center of brick
        float initialX = screenUtils.LeftBottomX + spaceBetweenBricks + (width / 2);
        x = initialX;

        //Debug.Log("initialX: " + initialX);

        for (int i = 1; i <= totalNumberOfBricks; i++)
        {
            GameObject theBrick = Instantiate(prefabBrick, new Vector2(x, y), Quaternion.identity);
            theBrick.GetComponent<BoxCollider2D>().enabled = true;

            int randomColor = Random.Range(0, colors.Length);
            theBrick.GetComponent<SpriteRenderer>().color = colors[randomColor];

            GameObject theshadow = Instantiate(prefabBrickShadow, new Vector2(x + shadowOffsetX, y - shadowOffsetY), Quaternion.identity);
            theshadow.transform.parent = theBrick.transform;

            x += (width + spaceBetweenBricks);

            if (i % bricksInRow == 0)
            {
                y -= height;
                x = initialX;
                //Debug.Log("initialX: " + initialX);
            }
        }
    }
}
