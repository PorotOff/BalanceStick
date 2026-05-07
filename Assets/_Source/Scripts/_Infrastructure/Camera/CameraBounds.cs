using UnityEngine;

public class CameraBounds
{
    private Vector3 _bottomLeft;
    private Vector3 _topRight;

    public CameraBounds()
    {
        Camera camera = Camera.main;

        float width = camera.pixelWidth;
        float height = camera.pixelHeight;

        _bottomLeft = camera.ScreenToWorldPoint(new Vector3(0, 0, 0));
        _topRight = camera.ScreenToWorldPoint(new Vector3(width, height, 0));
    }

    public Vector2 GetRandomBoundsPosition()
    {
        int randomSide = Random.Range(0, (int)ScreenSides.Bottom + 1);

        switch (randomSide)
        {
            case (int)ScreenSides.Left:
                return new Vector2(_bottomLeft.x, Random.Range(_bottomLeft.y, _topRight.y));

            case (int)ScreenSides.Right:
                return new Vector2(_topRight.x, Random.Range(_bottomLeft.y, _topRight.y));

            case (int)ScreenSides.Top:
                return new Vector2(Random.Range(_bottomLeft.x, _topRight.x), _topRight.y);

            default:
                return new Vector2(Random.Range(_bottomLeft.x, _topRight.x), _bottomLeft.y);
        }
    }

    public enum ScreenSides
    {
        Left,
        Top,
        Right,
        Bottom
    }
}