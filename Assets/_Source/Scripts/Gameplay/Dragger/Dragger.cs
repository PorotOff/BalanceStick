using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Dragger : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    private Transform _transform;

    public event Action PickedUp;
    public event Action PuttedDown;

    public void Initialize(Transform transform)
    {
        _transform = transform;
    }

    private void Awake()
    {
        _transform = transform;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        MoveAtPointerPosition(eventData.position);
        PickedUp?.Invoke();
    }

    public void OnPointerUp(PointerEventData eventData)
    {        
        PuttedDown?.Invoke();
    }

    public void OnDrag(PointerEventData eventData)
    {
        MoveAtPointerPosition(eventData.position);
    }

    private void MoveAtPointerPosition(Vector2 pointerPosition)
    {
        Vector3 dragPosition = Camera.main.ScreenToWorldPoint(pointerPosition);
        dragPosition.z = _transform.position.z;

        _transform.position = dragPosition;     
    }

    // todo Прикрутить Lerp для плавного следования за курсором.
}