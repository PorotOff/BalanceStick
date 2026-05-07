using UnityEngine;

public class LimitObjectPosition : MonoBehaviour
{
    [SerializeField]
    private float objectSize;

    private void Update() => Limit();

    public void Limit()
    {
        float newLimitedX = Mathf.Clamp(transform.position.x, CameraBoundaries.LeftCameraBorder + objectSize, CameraBoundaries.RightCameraBorder - objectSize);
        float newLimitedY = Mathf.Clamp(transform.position.y, CameraBoundaries.BottomCameraBorder + objectSize, CameraBoundaries.TopCameraBorder - objectSize);
        transform.position = new Vector3(newLimitedX, newLimitedY, transform.position.z);
    }
}
