using UnityEngine;
using UnityEngine.UI;

public class DrawSquald : Primitive
{
    public int radius;
    //是否填充
    public bool fill = true;
    //圆弧厚度
    public int thickness = 5;
    
    //分段数值越小精度越差
    [Range(15, 360)]
    public int segments = 360;

    // Using arrays is a bit more efficient 使用数组更有效率
    UIVertex[] uiVertices = new UIVertex[4];
    Vector2[] pos = new Vector2[4];

    protected override void OnPopulateMesh(VertexHelper vh)
    {
        float outer = radius;
        float inner = radius - thickness;

        float degrees = 360f / segments;
        int fa = (int)(segments + 1);

        // Updated to new vertexhelper
        vh.Clear();

        // Changed initial values so the first polygon is correct when circle isn't filled
        float x = outer * Mathf.Cos(0);
        float y = outer * Mathf.Sin(0);
        Vector2 prevX = new Vector2(x, y);

        // Changed initial values so the first polygon is correct when circle isn't filled
        x = inner * Mathf.Cos(0);
        y = inner * Mathf.Sin(0);
        Vector2 prevY = new Vector2(x, y);

        for (int i = 0; i < fa - 1; i++)
        {
            // Changed so there isn't a stray polygon at the beginning of the arc
            //改变了，所以在圆弧的开头没有一个杂散多边形
            float rad = Mathf.Deg2Rad * ((i + 1) * degrees);
            float c = Mathf.Cos(rad);
            float s = Mathf.Sin(rad);


            pos[0] = prevX;
            pos[1] = new Vector2(outer * c, outer * s);

            if (fill)
            {
                pos[2] = Vector2.zero;
                pos[3] = Vector2.zero;
            }
            else
            {
                pos[2] = new Vector2(inner * c, inner * s);
                pos[3] = prevY;
            }
            // Set values for uiVertices
            for (int j = 0; j < 4; j++)
            {
                uiVertices[j].color = color;
                uiVertices[j].position = pos[j];
            }

            // Get the current vertex count
            int vCount = vh.currentVertCount;

            // If filled, we only need to create one triangle
            vh.AddVert(uiVertices[0]);
            vh.AddVert(uiVertices[1]);
            vh.AddVert(uiVertices[2]);

            // Create triangle from added vertices
            vh.AddTriangle(vCount, vCount + 2, vCount + 1);

            // If not filled we need to add the 4th vertex and another triangle
            if (!fill)
            {
                vh.AddVert(uiVertices[3]);
                vh.AddTriangle(vCount, vCount + 3, vCount + 2);
            }

            prevX = pos[1];
            prevY = pos[2];
        }
    }
}