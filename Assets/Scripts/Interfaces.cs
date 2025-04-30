using UnityEngine;

public interface IObjectDropArea
{
    void OnObjectDrop(DragAndDrop dragAndDrop);
}

public interface IInteractable
{
    void OnInteract(GameObject obj);
}
