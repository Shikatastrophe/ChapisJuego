using UnityEngine;

public class CookingSystem : MonoBehaviour
{
    public Sprite cookedsprite;

    public Sprite burntSprite;

    DragAndDrop dragAndDrop;

    SpriteRenderer spriteRenderer;
    
    public bool isCooking;

    public float TimeForCook;

    float TimeInStove;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        dragAndDrop = GetComponent<DragAndDrop>();
        isCooking = false;
    }

    private void OnMouseUp()
    {
        isCooking = false;
    }

    private void Update()
    {
        if (dragAndDrop.type != DragAndDrop.IngredientType.meat)
        {
            return;
        }

        if (isCooking)
        {
            TimeInStove += Time.deltaTime;
            if (TimeInStove >= TimeForCook)
            {
                spriteRenderer.sprite = cookedsprite;
                dragAndDrop.ingId = 4;
            }
            if (TimeInStove >= TimeForCook * 2)
            {
                spriteRenderer.sprite = burntSprite;
                dragAndDrop.ingId = 500;
            }
        }
    }
}
