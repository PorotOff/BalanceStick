using UnityEngine;

public class OffEnemyOutsideTheScreen : MonoBehaviour
{
    [Header("For correct enemy spawn")]
    [SerializeField]
    private int borderRetreat = 5;

    private void Update()
    {
        if (transform.position.x < CameraBoundaries.LeftCameraBorder - borderRetreat || transform.position.x > CameraBoundaries.RightCameraBorder + borderRetreat ||
            transform.position.y < CameraBoundaries.TopCameraBorder - borderRetreat || transform.position.y > CameraBoundaries.BottomCameraBorder + borderRetreat)
        {
            gameObject.SetActive(false);
        }
    }
}
