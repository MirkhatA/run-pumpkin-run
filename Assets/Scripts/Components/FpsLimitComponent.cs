using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsLimitComponent : MonoBehaviour
{
    [SerializeField] private int _targetFrameRate = 100;

    private void Awake()
    {
        Application.targetFrameRate = _targetFrameRate;
    }
}
