using Box2D.NET.Bindings;

namespace Teko.Box2D;

public abstract class APolygonShape : AShape
{
    private B2.ShapeDef _def;
    protected B2.Polygon Polygon;

    protected override B2.ShapeId Create(B2.BodyId bodyId)
    {
        unsafe
        {
            fixed (B2.ShapeDef* def = &_def)
            fixed (B2.Polygon* polygon = &Polygon)
                return B2.CreatePolygonShape(bodyId, def, polygon);
        }
    }

    public APolygonShape(B2.Polygon polygon)
    {
        Polygon = polygon;
        _def = B2.DefaultShapeDef();
        _def.friction = 0f;
    }
}