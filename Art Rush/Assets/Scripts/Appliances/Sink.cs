using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sink : Interactable
{
    // Reference to what the brush originally is colored
    [SerializeReference]
    private Material origin_mat;
    // Reference to brush's mesh renderer
    [SerializeReference]
    private Renderer brush_mesh;

    public override void Interact()
    {
        base.Interact();
        // Washing brush function
        CleanBrush();
    }

    void CleanBrush()
    {
        // Only reset brush if its not its default color
        if (brush_mesh.material.color != origin_mat.color)
        {
            brush_mesh.material.color = origin_mat.color;
        }
    }
}