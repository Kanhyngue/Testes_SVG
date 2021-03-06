﻿ using UnityEngine;
 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine.Experimental.Rendering.LWRP;
 
 public class FlameFlickering : MonoBehaviour
 {
     public float MaxReduction;
     public float MaxIncrease;
     public float RateDamping;
     public float Strength;
     public bool StopFlickering;
 
     private UnityEngine.Experimental.Rendering.Universal.Light2D _lightSource;
     private float _baseIntensity;
     private bool _flickering;
 
     public void Reset()
     {
         MaxReduction = 0.2f;
         MaxIncrease = 0.2f;
         RateDamping = 0.1f;
         Strength = 300;
     }
 
     public void Start()
     {
         _lightSource = GetComponent<UnityEngine.Experimental.Rendering.Universal.Light2D>();
         if (_lightSource == null || _lightSource.enabled == false)
         {
            //Debug.LogError("Flicker script must have a Light Component on the same GameObject or must be enabled.");
            return;
         }
         else
         {
            _baseIntensity = _lightSource.intensity;
         }
     }
 
     void Update()
     {
        if (Time.frameCount % 2 == 0)
        {
            if (!StopFlickering && !_flickering && _lightSource != null && _lightSource.enabled)
            {
             StartCoroutine(DoFlicker());
            }
        }
     }
 
     private IEnumerator DoFlicker()
     {
         _flickering = true;
         while (!StopFlickering)
         {
             _lightSource.intensity = Mathf.Lerp(_lightSource.intensity, Random.Range(_baseIntensity - MaxReduction, _baseIntensity + MaxIncrease), Strength * Time.deltaTime);
             yield return new WaitForSeconds(RateDamping);
         }
         _flickering = false;
     }
 }
