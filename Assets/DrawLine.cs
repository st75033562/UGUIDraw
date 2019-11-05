using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawLine : Primitive
{
    [Range(0, 100)]
    public int thickness = 5;

    public Vector2[] postion = new Vector2[2];

    protected override void OnPopulateMesh(VertexHelper vh)
    {
        vh.Clear();

        Vector2[] pos = new Vector2[4];
        pos[0] = pos[1] = postion[0];
        pos[1].y += thickness;

        pos[2] = pos[3] = postion[1];
        pos[2].y += thickness;

        vh.Clear();

        RectAngle(vh, pos);
    }
}
