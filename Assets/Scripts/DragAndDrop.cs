using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    Collider2D col;

    public Vector3 startDragPosition;

    public Vector3 cachedPosition;

    Camera cam;

    public bool isGrabbing;

    private Vector3 velocity = Vector3.zero;

    bool returning;

    public enum IngredientType { other,meat,burger };
    public IngredientType type;

    private void Start()
    {
        cam = Camera.main;
        col = GetComponent<Collider2D>();
        isGrabbing = true;
        startDragPosition = transform.position;
        cachedPosition = startDragPosition;
        returning = false;
    }

    private void OnMouseDown()
    {
        startDragPosition = transform.position;
        cachedPosition = startDragPosition;
        transform.position = GetMousePosInWorldSpace();
        isGrabbing = true;
        returning = false;
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
        if (returning)
        {
            transform.position = Vector3.SmoothDamp(transform.position, startDragPosition, ref velocity, 0.1f);
            if(Vector3.Distance(transform.position, startDragPosition) < 0.1f)
            {
                CheckForAreas();
            }
        }
    }

    private void OnMouseUp()
    {
        MouseRelease();
    }

    public void MouseRelease()
    {
        isGrabbing = false;
        CheckForAreas();
    }

    public void CheckForAreas()
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
            //transform.position = startDragPosition;
            ReturnToSender();
            //Invoke(nameof(StopReturning), 5f);
        }
        if (hit != null && hit.TryGetComponent(out IInteractable interactable))
        {
            interactable.OnInteract(this.gameObject);
        }
    }

    public void ReturnToSender()
    {
        returning = true;
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

    public void Kill()
    {
        Destroy(gameObject);
    }
}
