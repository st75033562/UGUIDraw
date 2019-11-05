using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawRectAngle : Primitive
{
    [SerializeField]
    protected Vector2[] postion = new Vector2[4];

    protected override void OnPopulateMesh(VertexHelper vh)
    {
        vh.Clear();

        RectAngle(vh, postion);
    }
}
