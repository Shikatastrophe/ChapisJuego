using UnityEngine;

[CreateAssetMenu(fileName = "IngredientSO", menuName = "Scriptable Objects/IngredientSO")]
public class IngredientSO : ScriptableObject
{
    public Sprite ingredient;
    public int IngID;
    public enum IngredientType { other, meat, burger };
    public IngredientType type;

}
