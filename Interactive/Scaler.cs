using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaler : MonoBehaviour
{
    public float RealtiveTargetScale = 1.25f;
    public float ScaleDuration = 0.5f;
    private Vector3 _originalScale;
    private Vector3 _targetScale;
    private float _stopWatch = 0.0f;
    private bool _isScalingUp;
    private void Awake()
    {
        //add axis base scaling
        _originalScale = transform.localScale;
        _targetScale = _originalScale * RealtiveTargetScale;
    }
    private void Update()
    {
        if (_isScalingUp)
        {
            _stopWatch += Time.deltaTime;
            if (_stopWatch >= ScaleDuration)
            {
                _stopWatch = ScaleDuration;
                _isScalingUp = false;
            }
        }
        else
        {
            _stopWatch -= Time.deltaTime;
            if (_stopWatch <= 0.0f)
            {
                _stopWatch = 0.0f;
                _isScalingUp = true;
            }
        }

        transform.localScale = Vector3.Lerp(_originalScale, _targetScale, _stopWatch / ScaleDuration);//linearna interpolacija
    }
}