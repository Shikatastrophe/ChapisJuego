using UnityEngine;

public class DropAreas : MonoBehaviour, IObjectDropArea
{
    public enum DrpAreas { Assembly, Cooking, Trash }
    public DrpAreas dropArea;

    public void OnObjectDrop(DragAndDrop obj)
    {
        switch (dropArea)
        {
            case DrpAreas.Assembly:
                obj.transform.position = transform.position;
                break;
            case DrpAreas.Cooking:
                switch (obj.type)
                {
                    case DragAndDrop.IngredientType.meat:
                        obj.transform.position = transform.position;
                        obj.StartCooking();
                        break;
                    case DragAndDrop.IngredientType.other:
                        //obj.Kill();
                        break;
                    case DragAndDrop.IngredientType.burger:
                        //obj.transform.position = obj.cachedPosition;
                        obj.ReturnToSender();
                        break;
                }
                break;
            case DrpAreas.Trash:
                obj.transform.position = transform.position;
                obj.Kill();
                break;
        }
    }
}
