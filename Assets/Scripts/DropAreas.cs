using UnityEngine;

public class DropAreas : MonoBehaviour, IObjectDropArea
{
    public enum DrpAreas { Assembly, Cooking, Trash }
    public DrpAreas dropArea;

    public void OnObjectDrop(DragAndDrop obj)
    {
        obj.transform.position = transform.position;
        switch (dropArea)
        {
            case DrpAreas.Assembly:
                break;
            case DrpAreas.Cooking:
                obj.StartCooking();
                break;
            case DrpAreas.Trash:
                break;
        }
    }
}
