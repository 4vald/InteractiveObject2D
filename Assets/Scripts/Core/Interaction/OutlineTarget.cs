using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class OutlineTarget : MonoBehaviour
{
    private Material material;

    private void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
        DisableOutline();
    }

    public void EnableOutline()
    {
        material.SetFloat("_Outline", 1);
    }

    public void DisableOutline()
    {
        material.SetFloat("_Outline", 0);
    }
}