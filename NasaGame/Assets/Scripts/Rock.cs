using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public GameController _gameController;
    public Rock thisRock;
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
            thisRock.transform.position = new Vector3(thisRock.transform.position.x, thisRock.transform.position.y - 2 * Time.smoothDeltaTime, -1);
        }
    }
        
    private void OnTriggerEnter2D(Collider2D colisor)
    {
        if (colisor.gameObject.tag == "Player")
        {
            thisRock.transform.position = new Vector3(thisRock.transform.position.x, thisRock.transform.position.y - 2 * Time.smoothDeltaTime, 300);

            isVisible = false;
            Debug.Log(string.Format("Colidiu"));
        }
    }
}
