using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public Canvas[] canvasInScene;
    public Stack<Canvas> stackPanels;
    public Queue<int> intQueue;
    public Stack<int> intStack;
    public Dictionary<string, int> intDictionary;

    public int[] figuraReceta;
    public int[] figuraJugador;

    AudioManager audioManager;

    private void Start()
    {
        
        // Este es un stack para paneles
        stackPanels = new Stack<Canvas>();
        stackPanels.Push(canvasInScene[0]);
        
        Stack<int> stackReceta = new Stack<int>();
        Stack<int> stackJugador = new Stack<int>();


        // Este es un ejemplo de stack de enteros
        /*
        for (int i = 0; i < figuraReceta.Length; i++)
        {
            stackReceta.Push(figuraReceta[i]);
        }

        for (int i = 0; i < figuraJugador.Length; i++)
        {
            stackJugador.Push(figuraJugador[i]);
        }

        if (stackReceta.Count != stackJugador.Count)
        {
            Debug.Log("No bro, no son iguales");
            return;
        }

        for (int i = 0; i < figuraJugador.Length; i++)
        {
            if (stackReceta.Pop() != stackJugador.Pop())
            {
                Debug.Log("JA JA Fallaste");
                return;
            }
        }

        Debug.Log("Receta igual");
        */

        // Este es un ejemplo de queue
        
        Debug.Log("Aqui comienza Queue");
        intQueue = new Queue<int> ();
        for (int i = 0; i < 10; i++)
        {
            intQueue.Enqueue(i);
        }

        Debug.Log("La Queue contiene 0: " + intQueue.Contains(25));
         
        for (int i = 0; i < 10; i++)
        {
            Debug.Log(intQueue.Dequeue());
        }

        Debug.Log("Aqui comienza Stack");
        intStack = new Stack<int> ();
        for (int i = 0; i < 10; i++)
        {
            intStack.Push(i);
        }

        for (int i = 0; i < 10; i++)
        {
            Debug.Log(intStack.Pop());
        }
        
        intDictionary = new Dictionary<string, int> ();
        //intDictionary.Add("Vidas", 3);
        //Debug.Log(intDictionary["Vidas"]);
        intDictionary["Vidas"] = 5;
        Debug.Log(intDictionary["Vidas"]);

        

    }

    public void GoToPanel(int canvasToEnable)
    {
        for (int indexPanels = 0; indexPanels < canvasInScene.Length; indexPanels++)
        {
            stackPanels.Push(canvasInScene[indexPanels]);
            canvasInScene[indexPanels].enabled = indexPanels == canvasToEnable;
        }
    }

    private void Update()
    {
        if (stackPanels.Count > 1 && Input.GetKeyDown(KeyCode.Escape))
        {
            
            stackPanels.Pop().enabled = false;
            stackPanels.Peek().enabled = true;
        }
    }
}
