using UnityEngine;

public class AssemblyArea : DropAreas
{
    public override void OnObjectDrop(DragAndDrop obj)
    {
        obj.transform.position = transform.position;
    }

    public override void OnInteract(GameObject obj)
    {
        base.OnInteract(obj);   
    }
}
