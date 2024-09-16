using Box2D.NET.Bindings;
using Teko.Core;

namespace Teko.Box2D;

public class CapsuleShape(Vector2f pos1, Vector2f pos2, float radius) : AShape
{
    protected override B2.ShapeId Create(B2.BodyId bodyId)
    {
        unsafe
        {
            var def = B2.DefaultShapeDef();
            var capsule = new B2.Capsule
            {
                center1 = Converter.ToB2Vec(pos1),
                center2 = Converter.ToB2Vec(pos2),
                radius = Converter.ToB2Distance(radius)
            };
            return B2.CreateCapsuleShape(bodyId, &def, &capsule);
        }
    }
}