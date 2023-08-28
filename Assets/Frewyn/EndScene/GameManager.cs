using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject endSceneObject;
  

    void Start()
    {
        
    }


    private void Update()
    {
        if (Input.GetKeyDown("j"))
        {
            Debug.Log("Change");
            
            endSceneObject.SetActive(true);
        }
    }

  

}
