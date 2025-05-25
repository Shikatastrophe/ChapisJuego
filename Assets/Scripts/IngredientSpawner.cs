using UnityEngine;

public class IngredientSpawner : MonoBehaviour
{
    public GameObject objectPrefab;
    bool hasSpawned;
    public IngredientSO IngredientSO;
    private void Start()
    {
        hasSpawned = false;
    }
    private void OnMouseDown()
    {
        if (hasSpawned) { return; }

        GameObject ingredient = Instantiate(objectPrefab, transform.position, Quaternion.identity);
        ingredient.GetComponent<DragAndDrop>().ingredientdata = IngredientSO;

        hasSpawned = true;
    }

    private void OnMouseUp()
    {
        hasSpawned = false;
    }
}
