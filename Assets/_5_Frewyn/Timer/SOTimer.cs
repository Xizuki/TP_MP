using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]

public class SOTimer : ScriptableObject
{
    [SerializeField]
    private float _value;

    public float value
    {
        get { return _value; } //Getter
        set { _value = value; } //Set _value to new value
    }


}
