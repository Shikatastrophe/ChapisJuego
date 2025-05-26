using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class CanvasSystem : MonoBehaviour
{
    public Canvas[] canvasInScene;
    public Stack<Canvas> StackPanels;
    void Start()
    {
        StackPanels = new Stack<Canvas>();
        StackPanels.Push(canvasInScene[0]);
    }
    void Update()
    {
        if (StackPanels.Count > 1 && Input.GetKeyDown(KeyCode.Escape))
        {
            StackPanels.Pop().enabled = false;
            StackPanels.Peek().enabled = true;
        }
    }
    public void GotoPanel(int canvasToEnable)
    {
        StackPanels.Push(canvasInScene[canvasToEnable]);
        for (int indexPanels = 0; indexPanels < canvasInScene.Length; indexPanels++)
        {         
            canvasInScene[indexPanels].enabled = indexPanels == canvasToEnable;
            Debug.Log(canvasToEnable);
        }
    }
    public void GoBacktoPanel()
    {
        if (StackPanels.Count > 1 )
        {
            StackPanels.Pop().enabled = false;
            StackPanels.Peek().enabled = true;
        }
    }
}
