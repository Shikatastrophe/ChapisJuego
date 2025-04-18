using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    Collider2D col;

    public Vector3 startDragPosition;

    Camera cam;

    public bool isGrabbing;

    private Vector3 velocity = Vector3.zero;

    public enum IngredientType { normal,meat };
    public IngredientType type;

    private void Start()
    {
        cam = Camera.main;
        col = GetComponent<Collider2D>();
        isGrabbing = true;
        startDragPosition = transform.position;
    }

    private void OnMouseDown()
    {
        startDragPosition = transform.position;
        transform.position = GetMousePosInWorldSpace();
        isGrabbing = true;
    }

    private void Update()
    {

        Debug.Log(startDragPosition);
        if (isGrabbing)
        {
            transform.position = Vector3.SmoothDamp(transform.position, GetMousePosInWorldSpace(), ref velocity , 0.1f);
            //transform.position = GetMousePosInWorldSpace();
        }
        if (Input.GetMouseButtonUp(0))
        {
            MouseRelease();
        }
    }

    private void OnMouseUp()
    {
        MouseRelease();
    }

    public void MouseRelease()
    {
        isGrabbing = false;
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
