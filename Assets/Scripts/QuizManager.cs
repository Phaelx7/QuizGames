using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    //Variaveis
    public Text txtPerguntas;
    public Text txtPontos;
    private Pergunta perguntaAtual;
    [SerializeField] private Text button1Text;
    [SerializeField] private Text button2Text;
    [SerializeField] private Text button3Text;
    [SerializeField] private Text button4Text;
    private int pontos = 0;
    public List<Pergunta> listaPerguntas; //Criar uma lista de perguntas com base na classe <Pergunta>
    private List<int> perguntasUsadas = new List<int>(); // Lista para armazenar os índices das perguntas já usadas

    void Start()
    {
        txtPontos.text = "Pontos: " + pontos;
        if (txtPerguntas != null && listaPerguntas.Count > 0)
        {
            gerarPergunta();
        }
    }

    public void ButtonClick(int indexBotao) //Ao apertar um botão
    {
        if (indexBotao == perguntaAtual.indexRespostaCerta) //Se o numero do botão for igual ao numero da resposta
        { //Soma pontos e gera uma nova pergunta
            pontos++;
            txtPontos.text = "Pontos: " + pontos;
            gerarPergunta();
            txtPerguntas.text = perguntaAtual.pergunta;
            Debug.Log("Resposta Correta!"); //Aqui é so para aparecer no console se a resposta está correta
        }
        else //Se não gera uma pergunta
        {
            gerarPergunta();
            txtPerguntas.text = perguntaAtual.pergunta;
            Debug.Log("Resposta Errada!"); //Aqui é so para aparecer no console se a resposta está errada
        }
    }

    public void gerarPergunta() //Meto para gerar pergunta
    {
        if (perguntasUsadas.Count == listaPerguntas.Count)
        {
            // Salva a pontuação final antes de mudar de cena
            PlayerPrefs.SetInt("Pontos", pontos);
            PlayerPrefs.Save();  // Salva os dados permanentemente
            Debug.Log("Pontuação salva: " + pontos);  // Verifica a pontuação salva
            SceneManager.LoadScene("Pontuacao"); //Vai pra cena de pontuação
            return; //Retorna para não travar
        }
        int randomIndex;
        do
        {
            randomIndex = Random.Range(0, listaPerguntas.Count);  // Escolhe um índice aleatório
        } while (perguntasUsadas.Contains(randomIndex));  // Repete até escolher uma pergunta que não tenha sido usada

        //A variavel recebe um numero aleatório entre 0 e a quantidade de perguntas
        //int randomIndex = Random.Range(0, listaPerguntas.Count); 

        perguntaAtual = listaPerguntas[randomIndex]; //A pergunta atual recebe a pergunta da lista com o index da variavel

            // Marca a pergunta como usada
        perguntasUsadas.Add(randomIndex);

        txtPerguntas.text = perguntaAtual.pergunta; //Aqui coloca a resposta da pergunta nos botões
        button1Text.text = perguntaAtual.listaRespostas[0];
        button2Text.text = perguntaAtual.listaRespostas[1];
        button3Text.text = perguntaAtual.listaRespostas[2];
        button4Text.text = perguntaAtual.listaRespostas[3];
    }
    public int GetPoints() //Metodo para retornar os pontos
    {
        return pontos;
    }
}