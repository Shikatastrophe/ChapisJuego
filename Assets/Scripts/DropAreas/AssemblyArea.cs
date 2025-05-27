using UnityEngine;

public class AssemblyArea : DropAreas
{
    public bool burgeronPlace;

    public GameObject oldburger;

    public float offset;

    public int rendereroffset,side1Offset, side2Offset;

    public bool side1;


    public float mainoffset;

    private void Start()
    {
        burgeronPlace = false;
    }

    public override void OnObjectDrop(DragAndDrop obj)
    {
        if (!burgeronPlace && obj.type != DragAndDrop.IngredientType.side)
        {
            obj.transform.position = transform.position;
            obj.type = DragAndDrop.IngredientType.burger;
            burgeronPlace=true;

            if(oldburger == null || oldburger != obj.gameObject)
            {
                oldburger = obj.gameObject;
                offset = mainoffset;
                rendereroffset = 6;
                Debug.Log("NEW BURGER");

                side1 = false;

                oldburger.GetComponent<DragAndDrop>().AddIngredient(obj.ingId);
            }
        }
        else
        {
            
            if (obj.type != DragAndDrop.IngredientType.burger)
            {
                if (obj.type == DragAndDrop.IngredientType.side)
                {
                    if (side1==false)
                    {
                        obj.gameObject.GetComponent<SpriteRenderer>().sortingOrder = side1Offset;
                        side1 = true;
                        obj.transform.position = new Vector2(oldburger.transform.position.x + side1Offset, oldburger.transform.position.y);

                    }
                    else
                    {
                        obj.gameObject.GetComponent<SpriteRenderer>().sortingOrder = side2Offset;
                        obj.transform.position = new Vector2(oldburger.transform.position.x + side2Offset, oldburger.transform.position.y);

                    }
                    obj.gameObject.GetComponent<Collider2D>().enabled = false;
                    obj.gameObject.GetComponent<CookingSystem>().enabled = false;
                    obj.transform.parent = oldburger.transform;
                    //offset += mainoffset;
                    //rendereroffset++;
                    obj.enabled = false;

                    //Add the new ingredient to the burger
                    oldburger.GetComponent<DragAndDrop>().AddIngredient(obj.ingId);
                }
                else
                {
                    obj.gameObject.GetComponent<SpriteRenderer>().sortingOrder = rendereroffset;
                    obj.gameObject.GetComponent<Collider2D>().enabled = false;
                    obj.gameObject.GetComponent<CookingSystem>().enabled = false;
                    obj.transform.position = new Vector2(oldburger.transform.position.x, oldburger.transform.position.y + offset);
                    obj.transform.parent = oldburger.transform;
                    offset += mainoffset;
                    rendereroffset++;
                    obj.enabled = false;

                    //Add the new ingredient to the burger
                    oldburger.GetComponent<DragAndDrop>().AddIngredient(obj.ingId);

                }

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
