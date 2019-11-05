using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawTriangle : Primitive
{
    public Vector2[] postion = new Vector2[3];
    protected override void OnPopulateMesh(VertexHelper vh)
    {
        vh.Clear();

        int vCount = vh.currentVertCount;
        for (int i = 0; i < postion.Length; i++)
        {
            UIVertex uiVertices = new UIVertex();
            uiVertices.color = color;
            uiVertices.position = postion[i];
            vh.AddVert(uiVertices);
        }
        vh.AddTriangle(vCount, vCount + 1, vCount + 2);
    }

}
