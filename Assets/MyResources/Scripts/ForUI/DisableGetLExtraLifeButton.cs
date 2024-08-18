using UnityEngine;

public class DisableGetLExtraLifeButton : MonoBehaviour
{
    public static int activationsNumber = 0;

    public void DisableGetExtraLifeForADButton()
    {
        activationsNumber = 0;
        gameObject.SetActive(false);
    }
}
