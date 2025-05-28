using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public Canvas canvasToEnable;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Resume();
            
        }
    }
    public void PauseGame()
    {
        canvasToEnable.enabled = true;
        Time.timeScale = 0;
    }
    public void Resume()
    {
        canvasToEnable.enabled = false;
        Time.timeScale = 1;
    }
}
