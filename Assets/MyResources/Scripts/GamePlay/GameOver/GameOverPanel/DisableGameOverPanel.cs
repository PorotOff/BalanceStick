using UnityEngine;

public class DisableGameOverPanel : MonoBehaviour
{
    public void Deactivate()
    {
        gameObject.SetActive(false);
    }
}