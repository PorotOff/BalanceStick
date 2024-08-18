using UnityEngine;

public class DetectStickPosition : MonoBehaviour
{
    private void OnEnable() => GoToStick.GetObjectPosition += GiveStickPosition;
    private void OnDisable() => GoToStick.GetObjectPosition -= GiveStickPosition;

    private Vector3 GiveStickPosition()
    {
        return transform.position;
    }
}