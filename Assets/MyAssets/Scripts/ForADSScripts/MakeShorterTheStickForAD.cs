using UnityEngine;
using YG;

public class MakeShorterTheStickForAD : MonoBehaviour
{
    [SerializeField] private YandexGame sdk;
    [SerializeField] private GameObject stick;
    [SerializeField] private float makeStickShorterOn = 0.5f;

    private bool lookingAD = false;

    public void ADButton()
    {
        lookingAD = true;
        sdk._RewardedShow(1);
    }
    public void MakeShorterTheStick()
    {
        if (lookingAD)
        {
            makeStickShorterOn = (YandexGame.EnvironmentData.isMobile) ? makeStickShorterOn = 0.25f : makeStickShorterOn = 0.5f; 
            stick.GetComponent<Transform>().localScale = new Vector3(stick.transform.localScale.x, stick.transform.localScale.y - makeStickShorterOn, stick.transform.localScale.z);

            lookingAD = false;
        }
    }
}