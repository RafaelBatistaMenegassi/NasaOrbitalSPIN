using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{

    public Background thisBack;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        thisBack.transform.position = new Vector3(thisBack.transform.position.x, thisBack.transform.position.y - Time.smoothDeltaTime, 0);
    }
}
