using UnityEngine;

public class VariableIngredientSpawner : MonoBehaviour
{
    public GameObject objectPrefab;
    bool hasSpawned;
    public IngredientSO IngredientSO1;
    public IngredientSO IngredientSO2;

    bool firstIngredient;
    private void Start()
    {
        hasSpawned = false;
        firstIngredient = true;
    }
    private void OnMouseDown()
    {
        if (hasSpawned) { return; }


        if (firstIngredient)
        {
            GameObject ingredient = Instantiate(objectPrefab, transform.position, Quaternion.identity);
            ingredient.GetComponent<DragAndDrop>().ingredientdata = IngredientSO1;
            firstIngredient = false;
            hasSpawned = true;
        }
        else if (!firstIngredient)
        {
            GameObject ingredient = Instantiate(objectPrefab, transform.position, Quaternion.identity);
            ingredient.GetComponent<DragAndDrop>().ingredientdata = IngredientSO2;
            firstIngredient = true;
            hasSpawned = true;
        }
    }

    private void OnMouseUp()
    {
        hasSpawned = false;
    }
}
