using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class MobileInput : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField] protected UnityEvent onPointerDown;
    [SerializeField] protected UnityEvent onPointerUp;

    public void OnPointerDown(PointerEventData eventData)
    {
        onPointerDown?.Invoke();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        onPointerUp?.Invoke();
    }
}
