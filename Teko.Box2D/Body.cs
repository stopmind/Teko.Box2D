using Box2D.NET.Bindings;
using Teko.Core;

namespace Teko.Box2D;

public class Body
{
    private B2.BodyId _id;
    private List<AShape> _shapes = [];

    public bool IsActive { get; private set; } = true;
    
    public Body(B2.WorldId worldId, Vector2f position, BodyType type, bool fixedRotation)
    {
        var def = B2.DefaultBodyDef();

        def.position = Converter.ToB2Vec(position);
        def.type = (B2.BodyType)type;
        def.fixedRotation = fixedRotation ? (byte)1 : (byte)0;
        
        unsafe
        {
            _id = B2.CreateBody(worldId, &def);
        }
    }

    public void AddShape(AShape aShape)
    {
        _shapes.Add(aShape);
        aShape.Register(_id);
    }

    public void RemoveShape(AShape aShape)
    {
        _shapes.Remove(aShape);
        aShape.Destroy();
    }

    public void SetActive(bool active)
    {
        IsActive = active;
        if (active) B2.BodyEnable(_id);
        else        B2.BodyDisable(_id);
    }

    public Vector2f GetPosition()
        => Converter.ToGameVec(B2.BodyGetPosition(_id));

    public void LinearImpulse(Vector2f impulse)
    {
        B2.BodyApplyLinearImpulseToCenter(_id, Converter.ToB2Vec(impulse), 1);
    }
}