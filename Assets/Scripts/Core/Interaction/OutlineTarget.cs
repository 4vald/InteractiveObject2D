using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class OutlineTarget : MonoBehaviour
{
    private static readonly int OutlineEnabled = Shader.PropertyToID("_OutlineEnabled");

    private SpriteRenderer spriteRenderer;
    private Material material;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

       
        material = Instantiate(spriteRenderer.sharedMaterial);
        spriteRenderer.material = material;

        DisableOutline();
    }

    public void EnableOutline()
    {
        material.SetFloat(OutlineEnabled, 1f);
    }

    public void DisableOutline()
    {
        material.SetFloat(OutlineEnabled, 0f);
    }
}