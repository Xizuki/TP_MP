using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class CameraShaker : MonoBehaviour
{
    [SerializeField] private Transform camera;
    [SerializeField] private Vector3 posStrength;
    [SerializeField] private Vector3 rotationStrength;
    public static float force;
    private static event Action Shake;
    
    public static void Invoke(float _force) //Call the script
    {
        force = _force;
        Shake?.Invoke();
    }

    private void OnEnable() => Shake += CameraShake; //Subscribe to the shake event, which where the camerashake will occur
    private void OnDisable() => Shake -= CameraShake; //Unsubscribe to the shake event, which where the camerashake will not occur

    private void CameraShake()
    {
       camera.DOComplete(); //Have to complte the previous shake before being able to shake again
       camera.DOShakePosition(0.3f, posStrength* force); //Time of shake
       camera.DOShakeRotation(0.3f, rotationStrength* force); //Strength of shake
    }
}
