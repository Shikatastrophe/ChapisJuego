using UnityEngine;

public class EntrgarButton : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    public Sprite normalSprite;
    public Sprite pressedSprite;

    public ClientController clientController;
    public AssemblyArea assemblyArea;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        normalSprite = spriteRenderer.sprite;
    }
    private void OnMouseDown()
    {
        spriteRenderer.sprite = pressedSprite;
        if (assemblyArea.oldburger == null)
        {
            Debug.LogWarning("No burger to deliver!");
            return;
        }
        clientController.CompleteOrder(assemblyArea.oldburger.GetComponent<DragAndDrop>());
    }
    private void OnMouseUp()
    {
        spriteRenderer.sprite = normalSprite;
    }
}
