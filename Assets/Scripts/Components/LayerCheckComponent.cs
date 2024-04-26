using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerCheckComponent : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;

    private Collider2D _collider;

    public bool IsTouchinLayer;

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();   
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        IsTouchinLayer = _collider.IsTouchingLayers(_layerMask);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        IsTouchinLayer = _collider.IsTouchingLayers(_layerMask);
    }
}
