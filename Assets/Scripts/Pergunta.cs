using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //Para aparecer tudo no inspetor
public class Pergunta : MonoBehaviour
{
    //Variaveis
    public int id; //Numero da pergunta
    public string pergunta; //Aqui escreve a pergunta
    public int indexRespostaCerta; //Aqui qual vai ser o numero da resposta certa
    public List<string> listaRespostas; //Aqui a lista de respostas
}