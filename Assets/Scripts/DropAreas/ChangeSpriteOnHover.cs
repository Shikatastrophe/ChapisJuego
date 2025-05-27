using UnityEngine;

public class ChangeSpriteOnHover : MonoBehaviour
{
    public Sprite hoverSprite;
    private Sprite originalSprite;

    private void Start()
    {
        originalSprite = GetComponent<SpriteRenderer>().sprite;
    }

    private void OnMouseEnter()
    {
        if (hoverSprite != null)
        {
            GetComponent<SpriteRenderer>().sprite = hoverSprite;
        }
    }
    private void OnMouseExit()
    {
        if (originalSprite != null)
        {
            GetComponent<SpriteRenderer>().sprite = originalSprite;
        }
    }
}
