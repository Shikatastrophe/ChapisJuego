using UnityEngine;

public class TrashArea : DropAreas
{
    public override void OnObjectDrop(DragAndDrop obj)
    {
        obj.transform.position = transform.position;
        obj.Kill();
    }

    public override void OnInteract(GameObject obj)
    {
        base.OnInteract(obj);
    }
}
