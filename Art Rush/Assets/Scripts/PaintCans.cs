using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintCans : Interactable
{
    // Color of the Paint can Instance
    [SerializeField]
    private Color my_color;
    private MeshRenderer my_mesh;

    // Original Color of Brush (ie default)
    [SerializeReference]
    private Material origin_mat;
    // Reference to brush's mesh renderer
    [SerializeReference]
    private Renderer brush_mesh;

    private void Start()
    {
        // Change bucket color on start since each paint bucket is different
        my_mesh = GetComponent<MeshRenderer>();
        my_mesh.material.color = my_color;
    }
    public override void Interact()
    {
        base.Interact();
        // Call ChangePaint
        ChangePaint();
    }

    void ChangePaint()
    {
        // Only change color if the brush is "washed", not a color besides its default
        if (brush_mesh.material.color == origin_mat.color)
        { brush_mesh.material.color = my_color; }
    }
}
