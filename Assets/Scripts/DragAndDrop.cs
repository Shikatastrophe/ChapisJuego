using System;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    [Header("DATA DO NOT TOUCH")]
    public IngredientSO ingredientdata;
    public int ingId;


    Collider2D col;

    [Header("You can touch this :)")]  //No , i dont want to touch it
    public Vector3 startDragPosition;

    public Vector3 cachedPosition;

    Camera cam;

    public bool isGrabbing;

    private Vector3 velocity = Vector3.zero;

    bool returning;

    SpriteRenderer SpRend;

    public enum IngredientType { other,meat,burger, side };
    public IngredientType type;

    public List<int> recipe = new List<int>();

    bool cookedMeat;

    private void Start()
    {
        SetData();
        isGrabbing = true;
        startDragPosition = transform.position;
        cachedPosition = startDragPosition;
        returning = false;
        cookedMeat = false;
    }

    public void SetData()
    {
        cam = Camera.main;
        col = GetComponent<Collider2D>();
        SpRend = GetComponent<SpriteRenderer>();
        SpRend.sprite = ingredientdata.ingredient;
        type = (IngredientType)ingredientdata.type;
        ingId = ingredientdata.IngID;
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
        //Debug.Log(startDragPosition);
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

    public void Kill()
    {
        Destroy(gameObject);
    }

    internal void AddIngredient(int ingID)
    {
        recipe.Add(ingID);
        Debug.Log("Added ingredient with ID: " + ingID + " to recipe. Current recipe: " + string.Join(", ", recipe));
    }
}
