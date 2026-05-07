using UnityEngine;

public class BarrierFollowHand : MonoBehaviour
{
    [SerializeField]
    private Transform hand;

    private void Update() => FollowToHand();

    private void FollowToHand()
    {
        Vector3 newBarriersXPosition = new Vector3(hand.position.x, transform.position.y, transform.position.z);
        transform.position = newBarriersXPosition;
    }
}
