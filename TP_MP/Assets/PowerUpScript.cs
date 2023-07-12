using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(JumpingPlayerScript))]
public class PowerUpScript : MonoBehaviour
{
    public JumpingPlayerScript player;
    public bool isActivated;
    private void Awake()
    {
        player = GetComponent<JumpingPlayerScript>();   
    }
    public virtual void Effect()
    {

    }
}
