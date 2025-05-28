using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public Canvas canvasToEnable;
    void Update()
    {
        canvasToEnable.enabled = true;
        Time.timeScale = 0;
    }
}
