using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneButton : MonoBehaviour
{
    public void SceneSwitch(int scene)
    {
        SceneManager.LoadScene(sceneBuildIndex:scene);
    }
}
