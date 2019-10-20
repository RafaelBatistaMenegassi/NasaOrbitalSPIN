using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum gameState
{
    QUIZ, GAMEOVER, GAMEPLAY, END
}

public class GameController : MonoBehaviour
{
    // GENERAL
    public gameState currentState;
    public GameObject PanelQuiz, PanelGameOver;

    // AUDIO
    [Header("Audio")]
    public AudioSource sfxSource;
    public AudioSource musicSource; 
    public AudioClip sfxJump;
    public AudioClip sfxAtack;
    public AudioClip sfxCoin;
    public AudioClip sfxEnemyDead;
    public AudioClip[] sfxStep;
    public AudioClip sfxDamage;

    // SCORE
    public int countTrash;
    public UnityEngine.UI.Text countText;
    public UnityEngine.UI.Text scoreFinal;

    // LIFE
    public Heart[] heart = new Heart[3];
    public int lifeCount;

    // GAME OVER
    public GameOver imgGameOver;

    // QUIZ
    public bool quizEnabled = true;
    
    public Question quizQuestion;
    public RightAnswer quizRight;
    public WrongAnswer quizWrong;
    

    // Start is called before the first frame update
    void Start()
    {
        countTrash = 0;

        countText.text = countTrash.ToString();

        lifeCount = 3;

        quizEnabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        countText.text = countTrash.ToString();

        if(currentState == gameState.GAMEOVER)
        {
            //Debug.Log("Order" + imgGameOver.renderer.sortingOrder);

            imgGameOver.GetComponent<Renderer>().sortingOrder = 1000;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);

                Time.timeScale = 1;

                currentState = gameState.GAMEPLAY;
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene("menu");

                Time.timeScale = 1;

                currentState = gameState.GAMEPLAY;
            }

        }
        else if(currentState == gameState.END && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (countTrash == 3)
        {            
            if (quizEnabled)
            {
                quizQuestion.GetComponent<Renderer>().sortingOrder = 1000;

                Time.timeScale = 0;

                if (Input.GetKeyDown("a"))
                {
                    quizRight.GetComponent<Renderer>().sortingOrder = 1001;
                    quizEnabled = false;
                }
                else if (!Input.GetKeyDown("a"))
                {
                    quizWrong.GetComponent<Renderer>().sortingOrder = 1001;
                    quizEnabled = false;
                }

                if (!quizEnabled)
                {
                    Waiter();

                    quizQuestion.GetComponent<Renderer>().sortingOrder = 0;
                    quizRight.GetComponent<Renderer>().sortingOrder = 0;
                    quizWrong.GetComponent<Renderer>().sortingOrder = 0;

                    Time.timeScale = 1;
                }
            }
            
        }
    }

    public void playSFX(AudioClip sfxClip, float volume)
    {
        sfxSource.PlayOneShot(sfxClip, volume);
    }

    IEnumerator Waiter()
    {
        yield return new WaitForSeconds(2.0f);
    }
}
