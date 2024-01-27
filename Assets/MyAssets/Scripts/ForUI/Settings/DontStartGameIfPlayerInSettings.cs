using UnityEngine;

public class DontStartGameIfPlayerInSettings : MonoBehaviour
{
    public static bool playerInSettings = false;

    public void PlayerGettedInSettings()
    {
        playerInSettings = true;
    }
    public void PlayerGettedOutFromSettings()
    {
        playerInSettings = false;
    }
}
