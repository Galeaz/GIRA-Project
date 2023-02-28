using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    [SerializeField]
    private Graphic color_indicator;

    private void Start()
    {
        // Change bucket color on start since each paint bucket is different
        my_mesh = GetComponent<MeshRenderer>();
        my_mesh.material.color = my_color;
        my_color.a = 1;
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
        { brush_mesh.material.color = my_color; color_indicator.color = my_color;  }
    }
}
