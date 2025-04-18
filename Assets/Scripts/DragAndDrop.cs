using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    Collider2D col;

    Vector3 startDragPosition;

    Camera cam;

    public enum IngredientType { normal,meat };
    public IngredientType type;

    private void Start()
    {
        cam = Camera.main;
        col = GetComponent<Collider2D>();
    }

    private void OnMouseDown()
    {
        startDragPosition = transform.position;
        transform.position = GetMousePosInWorldSpace();
    }

    private void OnMouseDrag()
    {
        transform.position = GetMousePosInWorldSpace();
    }

    private void OnMouseUp()
    {
        col.enabled = false;
        Collider2D hit = Physics2D.OverlapPoint(transform.position);
        col.enabled = true;
        if (hit != null && hit.TryGetComponent(out IObjectDropArea objectDropArea))
        {
            objectDropArea.OnObjectDrop(this);
        }
        else
        {
            transform.position = startDragPosition;
        }
    }

    public Vector3 GetMousePosInWorldSpace()
    {
        Vector3 p = cam.ScreenToWorldPoint(Input.mousePosition);
        p.z = 0f;
        return p;
    }

    public void StartCooking()
    {
        if (type != IngredientType.meat) { return; }
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        sprite.color = Color.black;
    }
}
