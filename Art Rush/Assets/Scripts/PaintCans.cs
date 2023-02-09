using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintCans : Interactable
{
    
    [SerializeField]
    private Color my_color;
    private MeshRenderer my_mesh;

    [SerializeReference]
    private Material origin_mat;
    [SerializeReference]
    private Renderer brush_mesh;

    private void Start()
    {
        my_mesh = GetComponent<MeshRenderer>();
        my_mesh.material.color = my_color;
    }
    public override void Interact()
    {
        base.Interact();
        ChangePaint();
    }

    void ChangePaint()
    {
        if (brush_mesh.material.color == origin_mat.color)
        { brush_mesh.material.color = my_color; }
    }
}
