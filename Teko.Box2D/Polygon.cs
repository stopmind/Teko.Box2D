using Box2D.NET.Bindings;
using Teko.Core;

namespace Teko.Box2D;

public class Polygon
{
    public List<Vector2f> Points = [];
    
    public B2.Polygon ToB2Polygon()
    {
        var points = Points.Select(Converter.ToB2Vec).ToArray();
        unsafe
        {
            fixed (B2.Vec2* pointsPtr = &points[0])
            {
                var hull = B2.ComputeHull(pointsPtr, points.Length);
                return B2.MakePolygon(&hull, 0);
            }
        }
    }
}