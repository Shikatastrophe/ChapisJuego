using UnityEngine;

public class CookingArea : DropAreas
{
    public override void OnObjectDrop(DragAndDrop obj)
    {
        switch (obj.type)
        {
            case DragAndDrop.IngredientType.meat:
                obj.transform.position = transform.position;
                break;
            case DragAndDrop.IngredientType.other:
                obj.Kill();
                break;
            case DragAndDrop.IngredientType.burger:
                //obj.transform.position = obj.cachedPosition;
                obj.ReturnToSender();
                break;
        }
    }

    public override void OnInteract(GameObject obj)
    {
        base.OnInteract(obj);
    }
}
