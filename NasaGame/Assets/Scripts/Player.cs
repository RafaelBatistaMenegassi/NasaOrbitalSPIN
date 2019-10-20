using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameController _gameController;
 
    //public Text numText;

    public float Speed;
    //public Rock thisRock;
    //public int countTrash;
    //public Text countText;

    // Start is called before the first frame update
    void Start()
    {
        //countTrash = 0;

        //Vida
        //vida.guiText.color = new Vector4(0.25f, 0.5f, 0.25f, 1f);
        //vida.guiText.text = "HP: " + vidaAtual + "/" + maxVida;

       
    }

    // Update is called once per frame
    void Update()
    {
        /*if (_gameController.currentState != gameState.GAMEPLAY)
        {
            return;
        }*/


        Move();

        if (_gameController.lifeCount == 0)
        {
            _gameController.currentState = gameState.GAMEOVER;

            _gameController.lifeCount = 3;

            Time.timeScale = 0;
        }

    }

    void Move()
    {
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.Translate(Vector2.right * Speed * Time.deltaTime);
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.Translate(-Vector2.right * Speed * Time.deltaTime);
        }
        if (Input.GetAxisRaw("Vertical") > 0)
        {
            transform.Translate(Vector2.up * Speed * Time.deltaTime);
        }
        else if (Input.GetAxisRaw("Vertical") < 0)
        {
            transform.Translate(-Vector2.up * Speed * Time.deltaTime);
        }
    }

    // int i = 2;

    private void OnTriggerEnter2D(Collider2D colisor)
    {
            if (colisor.gameObject.tag == "Enemy")
            {
               _gameController.playSFX(_gameController.sfxDamage, 0.5f);

                StartCoroutine(ChangeColor());

                Destroy(_gameController.heart[_gameController.lifeCount - 1].gameObject);

                _gameController.lifeCount -= 1;

                Destroy(colisor.gameObject);

                // i--;
            }

            if (colisor.gameObject.tag == "Friend")
            {
                _gameController.countTrash += 1;

                //Debug.Log("\ncontagem: " + _gameController.countTrash);

                Destroy(colisor.gameObject);
            }
        }

        IEnumerator ChangeColor()
        {
            //Debug.Log(GetComponent<SpriteRenderer>().color.ToString());
            GetComponent<SpriteRenderer>().color = Color.red;
            //Debug.Log(GetComponent<SpriteRenderer>().color.ToString());

            yield return new WaitForSeconds(0.3f);
            GetComponent<SpriteRenderer>().color = Color.white;
            yield return new WaitForSeconds(0.3f);
            GetComponent<SpriteRenderer>().color = Color.red;
            yield return new WaitForSeconds(0.3f);
            GetComponent<SpriteRenderer>().color = Color.white;
            yield return new WaitForSeconds(0.3f);
            GetComponent<SpriteRenderer>().color = Color.red;
            yield return new WaitForSeconds(0.3f);
            GetComponent<SpriteRenderer>().color = Color.white;
            yield return new WaitForSeconds(0.3f);
        }
    }
