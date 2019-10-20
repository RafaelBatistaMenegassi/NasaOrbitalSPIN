using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text : MonoBehaviour
{
    public Text thisText;

    // Start is called before the first frame update
    void Start()
    {
        thisText = this;
    }

    // Update is called once per frame
    void Update()
    {
        thisText.transform.position = new Vector3(thisText.transform.position.x, thisText.transform.position.y, thisText.transform.position.z);


    }
}
