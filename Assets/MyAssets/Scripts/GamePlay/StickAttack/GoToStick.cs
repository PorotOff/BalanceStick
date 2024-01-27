using UnityEngine;

public class GoToStick : MonoBehaviour
{
    public delegate Vector3 GetObjectPositionEventHandler();
    public static GetObjectPositionEventHandler GetObjectPosition;

    private Rigidbody2D thisObject;
    [SerializeField] private float speedOnPC = 15f;
    //[SerializeField] private float speedOnMobile = 6.5f;

    private void Awake() => thisObject = GetComponent<Rigidbody2D>();

    private void OnEnable()
    {
        //float speed = YandexGame.EnvironmentData.isMobile ? speedOnMobile : speedOnPC;
        Vector3 direction;
        Vector3 handPosition = Vector3.zero;

        if (GetObjectPosition != null) handPosition = GetObjectPosition.Invoke();
        direction = (handPosition - thisObject.transform.position).normalized;

        thisObject.AddForce(direction * speedOnPC, ForceMode2D.Impulse);
    }
}