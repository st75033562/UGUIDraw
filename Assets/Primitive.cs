using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Primitive : MaskableGraphic
{

    public void RectAngle(VertexHelper vh, Vector2[] postion)
    {
        int vCount = vh.currentVertCount;
        for (int i = 0; i < postion.Length; i++)
        {
            UIVertex uiVertices = new UIVertex();
            uiVertices.color = color;
            uiVertices.position = postion[i];
            vh.AddVert(uiVertices);
        }

        vh.AddTriangle(vCount, vCount + 1, vCount + 2);
        vh.AddTriangle(vCount + 2, vCount + 3, vCount);
    }
}
