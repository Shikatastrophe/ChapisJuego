using UnityEngine;

public class CanvasRendererDefaultAsset : MonoBehaviour
{
    GameObject CanvasReference;
    int CanvasNumber;
    private void Awake()
    {
        CanvasNumber = Random.Range(1, 100000);
        if(CanvasNumber== 25372)
        {
            gameObject.SetActive(false);
        }
    }

}
