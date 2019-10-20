using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    public Trash thisTrash;
    public bool isVisible = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isVisible)
        {
            thisTrash.transform.position = new Vector3(thisTrash.transform.position.x, thisTrash.transform.position.y - 2 * Time.smoothDeltaTime, -1);  
        }
    }

    private void OnTriggerEnter2D(Collider2D colisor)
    {
        if (colisor.gameObject.tag == "Player")
        {
            thisTrash.transform.position = new Vector3(thisTrash.transform.position.x, thisTrash.transform.position.y - 2 * Time.smoothDeltaTime, 300);

            isVisible = false;

        }
    }
}
