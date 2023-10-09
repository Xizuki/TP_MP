using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    public bool isIceLand;
    public List<GameObject> enemiesOnPlatform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [ContextMenu("blast")]
    public void BlastOff()
    {
        if (!isIceLand) return;
        foreach(GameObject go in enemiesOnPlatform)
        {
            if(go==null) continue;
            Vector3 camDir = Camera.main.transform.position - transform.position;
            Vector3 flyDir = new Vector3(camDir.x, camDir.y, camDir.z) * 2.5f;
            go.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            go.GetComponent<Rigidbody>().AddForce(flyDir, ForceMode.Impulse);

            print("ASDASDASFASFASF");
        }
    }
}
