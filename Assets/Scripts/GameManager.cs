using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    QuizManager quiz;
    public Text pontuacao;

    void Start()
    {
        // Recupera a pontuação salva
        int pontos = PlayerPrefs.GetInt("Pontos", 0); // O segundo parâmetro é o valor padrão caso a chave não exista
        pontuacao.text = pontos.ToString() + " / 20";  // Atualiza o texto com a pontuação final

        if(pontos < 10)
        {
            pontuacao.color = Color.red;
        } else
        {
            pontuacao.color = Color.blue;
        }
    }
    public static void CarregarCena(string nomeCena)
    {
        SceneManager.LoadScene(nomeCena);
    }
    public static void Sair()
    {
        Application.Quit();
    }
}