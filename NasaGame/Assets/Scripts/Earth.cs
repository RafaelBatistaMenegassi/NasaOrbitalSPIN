using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth : MonoBehaviour
{
    public Earth thisEarth;
    public float x;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //thisEarth.transform.rotation = new Vector3(0, 0, thisEarth.transform.rotation.z + 2 * Time.smoothDeltaTime);

        //thisEarth.transform.rotation = new Quaternion(0, 0, thisEarth.transform.rotation.z + 2 * Time.smoothDeltaTime, 1);

        x += Time.deltaTime * 3;
        transform.rotation = Quaternion.Euler(0, 0, -x);
    }
}
