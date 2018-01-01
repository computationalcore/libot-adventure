using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    [Header("Options")]
    [Range(0f, 2f)] public float handleLimit = 1f;

    [HideInInspector] public Vector2 inputVector = Vector2.zero;

    [Header("Components")]
    public RectTransform background;
    public RectTransform handle;

    public float Horizontal { get { return inputVector.x; } }
    public float Vertical { get { return inputVector.y; } }

    public virtual void OnDrag(PointerEventData eventData)
    {

    }

    public virtual void OnPointerDown(PointerEventData eventData)
    {

    }

    public virtual void OnPointerUp(PointerEventData eventData)
    {

    }
}
