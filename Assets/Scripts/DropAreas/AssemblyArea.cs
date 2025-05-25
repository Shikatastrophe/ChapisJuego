using UnityEngine;

public class AssemblyArea : DropAreas
{
    public bool burgeronPlace;

    public GameObject oldburger;

    public float offset;

    public int rendereroffset;

    private void Start()
    {
        burgeronPlace = false;
    }

    public override void OnObjectDrop(DragAndDrop obj)
    {
        if (!burgeronPlace)
        {
            obj.transform.position = transform.position;
            obj.type = DragAndDrop.IngredientType.burger;
            burgeronPlace=true;

            if(oldburger == null || oldburger != obj.gameObject)
            {
                oldburger = obj.gameObject;
                offset = 0.2f;
                rendereroffset = 6;
                Debug.Log("NEW BURGER");
            }
        }
        else
        {
            if (obj.type != DragAndDrop.IngredientType.burger)
            {
                obj.gameObject.GetComponent<SpriteRenderer>().sortingOrder = rendereroffset;
                obj.gameObject.GetComponent<Collider2D>().enabled = false;
                obj.gameObject.GetComponent<CookingSystem>().enabled = false;
                obj.transform.position = new Vector2(oldburger.transform.position.x, oldburger.transform.position.y + offset);
                obj.transform.parent = oldburger.transform;
                offset += 0.2f;
                rendereroffset ++;
                obj.enabled = false;
            }
        }
    }

    public override void OnInteract(GameObject obj)
    {
        base.OnInteract(obj);   
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<DragAndDrop>(out var ing))
        {
            if (ing.type == DragAndDrop.IngredientType.burger)
            {
                burgeronPlace = false;
            }
        }
    }
}
