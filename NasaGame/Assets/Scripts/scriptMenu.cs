using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Importar uma imagem para o background bg_menu, onde ficara o botão
// E associar este script ao objeto Fundo
public class scriptMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Teclando ESC saira do Jogo, mas somente no executavel e nao dentro do editor
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    void OnGUI()
    {
        const int buttonWidth = 180;
        const int buttonHeight = 40;
        Rect buttonTitulo = new Rect(50, 30, 400, 30);
        // Determinar o lugar do botão na tela
        Rect buttonPrimeira = new Rect(50, 100, buttonWidth, buttonHeight);
        Rect buttonSegundo = new Rect(50, 150, buttonWidth, buttonHeight);
        Rect buttonTerceiro = new Rect(50, 200, buttonWidth, buttonHeight);
        //Screen.width / 10 - (buttonWidth / 2),
        //(2 * Screen.height / 20) - (buttonHeight / 2),
        //buttonWidth, buttonHeight);
        Rect buttonSair = new Rect(50, 250, buttonWidth, buttonHeight);
        Rect buttonCreditos = new Rect(20, 300, 450, 50);
        //GUI.Button(buttonTitulo, "Menu Principal - Jogo de Nave com o Unity3D");
        //GUI.Label(buttonCreditos, "Adaptaçao de Ribamar FS dos tutoriais do Equilibre Cursos e lessmilk.com");

        if (GUI.Button(buttonPrimeira, "Cadastro de Usuario"))
        {
            Application.LoadLevel("Cadastro");
        }

        if (GUI.Button(buttonSegundo, "Ranking"))
        {
            Application.LoadLevel("Ranking");
        }

        if (GUI.Button(buttonTerceiro, "Primeira Fase"))
        {// Rotulo do botao
            Application.LoadLevel("SampleScene");
        }

        if (GUI.Button(buttonSair, "Sair"))
        {// Rotulo do botao
            Application.Quit();
        }
    }
}
