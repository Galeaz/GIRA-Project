using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sink : Interactable
{
    [SerializeReference]
    private Material origin_mat;
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
        if (brush_mesh.material.color != origin_mat.color)
        {
            brush_mesh.material.color = origin_mat.color;
        }
    }
}