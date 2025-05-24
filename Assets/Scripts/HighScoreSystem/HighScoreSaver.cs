using System.IO;
using UnityEngine;
[System.Serializable]
public class HighScoreSaver
{
    //funcion para guardar, solo le tenemos que pasar un float con el score de la partida y queda
    public static void SaveScore(float Score)
    {
        string rute = Application.dataPath + "/StreamingAssets/ChapisHighScore.json";
        if (File.Exists(rute))
        {
            string JsonScoreGetter = File.ReadAllText(rute);
            HighScoreConstructor[] ScoreConstuctor = JsonHelper.FromJson<HighScoreConstructor>(JsonScoreGetter);
            string newJsonScore = JsonHelper.ToJson(newScoreLogic(ScoreConstuctor), true);
            File.WriteAllText(rute, newJsonScore);
        }
        else
        {
            //setter
            HighScoreConstructor[] highScores = new HighScoreConstructor[5];
            highScores[0] = new HighScoreConstructor(Score);
            highScores[1] = new HighScoreConstructor(0);
            highScores[2] = new HighScoreConstructor(0);
            highScores[3] = new HighScoreConstructor(0);
            highScores[4] = new HighScoreConstructor(0);
            string JsonScoreSaver = JsonHelper.ToJson(highScores, true);
            File.WriteAllText(rute, JsonScoreSaver);
        }

        HighScoreConstructor[] newScoreLogic(HighScoreConstructor[] ScoreConstructor)
        {
            HighScoreConstructor[] newHighScore = ScoreConstructor;
            for (int indexScores = 0; indexScores < newHighScore.Length; indexScores++)
            {
                //Debug.Log("Vuelta al for index scores, Pasando por el index: " + indexScores);
                if (newHighScore[indexScores].Highscores < Score)
                {
                    //Debug.Log("El index: " + indexScores + " Es menor entrando al nuevo for");
                    for (int indexMoveScore = 4; indexMoveScore > indexScores; indexMoveScore--)
                    {
                        //Debug.Log("Vuelta de for por el index: " + indexMoveScore);
                        if (newHighScore[indexMoveScore - 1] != null)
                        {
                            //Debug.Log("El dato no es nulo Siguiendo la asigancion");
                            //Debug.Log("Asiganndo: " + newHighScore[indexMoveScore].Highscores + " al en el index: " + indexMoveScore + " al indice " + (indexMoveScore - 1) + " que antes contenia " + newHighScore[indexMoveScore - 1].Highscores);
                            newHighScore[indexMoveScore].Highscores = newHighScore[indexMoveScore - 1].Highscores;
                            //Debug.Log("Ahora el index " + (indexMoveScore - 1) + " contiene: " + newHighScore[indexMoveScore - 1].Highscores + " que al momento de este ciclo deberia ser: " + newHighScore[indexMoveScore].Highscores);
                        }
                    }
                    //Debug.Log("El score es menor guardando " + Score + " en el index " + indexScores);
                    newHighScore[indexScores].Highscores = Score;
                    break;
                }
                //Debug.Log("Score no almacenado en el index " + ScoreConstuctor[indexScores].Highscores);
            }
            return newHighScore;
        }
        
    }
    //esto es para imprimir lo que tenga dentro del score
    public static HighScoreConstructor[] GetScore()
    {
        string rute = Application.dataPath + "/StreamingAssets/ChapisHighScore.json";
        if (File.Exists(rute))
        {
            string JsonScore = File.ReadAllText(rute);
            HighScoreConstructor[] scoreConstructor = JsonHelper.FromJson<HighScoreConstructor>(JsonScore);

            return scoreConstructor;
        }
        else
        {
            return null;
        }
    }
    

}

public static class JsonHelper
{
	public static T[] FromJson<T>(string json)
	{
		Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
		return wrapper.Items;
	}
	
	public static string ToJson<T>(T[] array)
	{
		Wrapper<T> wrapper = new Wrapper<T>();
		wrapper.Items = array;
		return JsonUtility.ToJson(wrapper);
	}
	
	public static string ToJson<T>(T[] array, bool prettyPrint)
	{
		Wrapper<T> wrapper = new Wrapper<T>();
		wrapper.Items = array;
		return JsonUtility.ToJson(wrapper, prettyPrint);
	}
	
	[System.Serializable]
	private class Wrapper<T>
	{
		public T[] Items;
	}
}