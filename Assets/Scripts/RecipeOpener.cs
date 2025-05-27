using UnityEngine;

public class RecipeOpener : MonoBehaviour
{
    public Canvas Canvas;

    private void OnMouseDown()
    {
        Canvas.enabled = true;
    }
}
