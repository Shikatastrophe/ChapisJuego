using UnityEngine;

public class IngredientSpawner : MonoBehaviour
{
    public GameObject objectPrefab;
    bool hasSpawned;

    private void Start()
    {
        hasSpawned = false;
    }
    private void OnMouseDown()
    {
        if (hasSpawned) { return; }
        Instantiate(objectPrefab,transform.position,Quaternion.identity);
        hasSpawned = true;
    }

    private void OnMouseUp()
    {
        hasSpawned = false;
    }
}
