using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.U2D;
using UnityEngine.UI;

public class OnHoldButtonComponent : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Sprite _defaultSprite;
    [SerializeField] private Sprite _pressedSprite;

    [SerializeField] private UnityEvent _moveState;
    [SerializeField] private UnityEvent _defaultState;

    private Image _image;
    private bool _isPressed = false;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    private void Update()
    {
        if (_isPressed)
        {
            _image.sprite = _pressedSprite;
            _moveState?.Invoke();
        } 
        else
        {
            _image.sprite = _defaultSprite;
            _defaultState?.Invoke();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _isPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _isPressed = false;
    }
}
