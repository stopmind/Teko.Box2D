using Box2D.NET.Bindings;

namespace Teko.Box2D;

public abstract class AShape
{
    private B2.ShapeId? _id;
    public void Register(B2.BodyId bodyId)
    {
        _id = Create(bodyId);
    }

    public void Destroy()
    {
        if (_id == null)
            return;
        
        B2.DestroyShape(_id.Value);
    }

    protected abstract B2.ShapeId Create(B2.BodyId bodyId);
}