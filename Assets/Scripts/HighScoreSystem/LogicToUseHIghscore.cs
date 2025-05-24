using UnityEngine;

public class LogicToUseHIghscore : MonoBehaviour
{
    public float score;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    [ContextMenu("GuardarDatos")]
    public void ponerScore()
    {
        HighScoreSaver.SaveScore(score);
    }
    [ContextMenu("ConseguirDatos")]
    public void consguir()
    {
        HighScoreConstructor[] datos = HighScoreSaver.GetScore();
        if (datos == null) return;
        foreach (HighScoreConstructor data in datos)
        {
            Debug.Log(data.Highscores.ToString());
        }
    }
}
