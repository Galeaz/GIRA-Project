using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sink : Interactable
{
    // Reference to what the brush originally is colored
    [SerializeReference]
    private Material origin_mat;
    // Reference to brush's mesh renderer
    [SerializeReference]
    private Renderer brush_mesh;

    [SerializeReference]
    private Graphic color_indicator;

    public Transform brush;

    public override void Interact()
    {
        base.Interact();
        // Washing brush function
        CleanBrush();
    }

    void CleanBrush()
    {
        brush = player.transform.Find("Brush Handle");
        brush_mesh = brush.GetChild(0).GetComponent<MeshRenderer>();
        // Only reset brush if its not its default color
        if (brush_mesh.material.color != origin_mat.color)
        {
            brush_mesh.material.color = origin_mat.color;
            color_indicator.color = new Color32(212, 173, 138, 255);
        }
    }
}