using UnityEngine;

public class DragHand : MonoBehaviour
{
    private Vector3 offset;

    void OnMouseDown()
    {
        Vector3 cursorWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
        offset = gameObject.transform.position - cursorWorldPosition;
    }
    void OnMouseDrag()
    {
        if (!DontStartGameIfPlayerInSettings.playerInSettings)
        {
            Vector3 newPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f);
            transform.position = Camera.main.ScreenToWorldPoint(newPosition) + offset;
        }
    }
}