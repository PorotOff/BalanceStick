using UnityEngine;
using YG;

public class HandScale : MonoBehaviour
{
    private Transform hand;
    public static Vector3 handLocalScale = new Vector3(1f, 1f, 1f);

    private void Awake() => hand = GetComponent<Transform>();

    private void Start()
    {
        if (!YandexGame.EnvironmentData.isDesktop)
        {
            ChangeHandLocalScale(new Vector3(0.3f, 0.3f, 0.3f));
        }
    }
    

    private void ChangeHandLocalScale(Vector3 newHandLocalScale)
    {
        hand.transform.localScale = newHandLocalScale;
    }
}
