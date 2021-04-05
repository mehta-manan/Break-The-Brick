using UnityEngine;

public class ScreenUtils : MonoBehaviour
{
    Camera mainCamera;

    float leftTopX;
    float leftTopY;

    float leftBottomX;
    float leftBottomY;

    float rightTopX;
    float rightTopY;

    float rightBottomX;
    float rightBottomY;

    float centerX;
    float centerY;

    Vector2 center;

    public float LeftTopX
    {
        get
        {
            return leftTopX;
        }
    }

    public float LeftTopY
    {
        get
        {
            return leftTopY;
        }
    }

    public float LeftBottomX
    {
        get
        {
            return leftBottomX;
        }
    }

    public float LeftBottomY
    {
        get
        {
            return leftBottomY;
        }
    }

    public float RightTopX
    {
        get
        {
            return rightTopX;
        }
    }

    public float RightTopY
    {
        get
        {
            return rightTopY;
        }
    }

    public float RightBottomX
    {
        get
        {
            return rightBottomX;
        }
    }

    public float RightBottomY
    {
        get
        {
            return rightBottomY;
        }
    }

    public float CenterX
    {
        get
        {
            return centerX;
        }
    }

    public float CenterY
    {
        get
        {
            return centerY;
        }
    }

    public Vector2 Center
    {
        get
        {
            return center;
        }
    }

    private void Awake()
    {
        mainCamera = Camera.main;

        Vector2 lowerLeftCornerS = new Vector2(0, 0);
        Vector2 lowerLeftCornerW = mainCamera.ScreenToWorldPoint(lowerLeftCornerS);

        Vector2 upperRightCornerS = new Vector2(Screen.width, Screen.height);
        Vector2 upperRightCornerW = mainCamera.ScreenToWorldPoint(upperRightCornerS);

        leftBottomX = lowerLeftCornerW.x;
        leftBottomY = lowerLeftCornerW.y;

        leftTopX = lowerLeftCornerW.x;
        leftTopY = upperRightCornerW.y;

        rightTopX = upperRightCornerW.x;
        rightTopY = upperRightCornerW.y;

        rightBottomX = upperRightCornerW.x;
        rightBottomY = lowerLeftCornerW.y;

        centerX = (rightBottomX - leftBottomX) / 2;
        centerY = (rightBottomY - leftBottomY) / 2;

        center = new Vector2(centerX, centerY);
    }
}
