using Box2D.NET.Bindings;
using Teko.Core;
using static Box2D.NET.Bindings.B2;

namespace Teko.Box2D;

public class CollisionsService : AService
{
    private WorldId? _world;
    private List<Body> _bodies = [];
    
    protected override void OnSetup()
    {
        GameInner.UpdateEvent += CollisionUpdate;
        GameInner.ExitEvent += OnExit;
    }

    public void CreateWorld()
    {
        DestroyWorld();

        var worldDef = DefaultWorldDef();
        worldDef.gravity = Converter.ToB2Vec(Vector2f.Down * 200);

        unsafe
        {
            _world = B2.CreateWorld(&worldDef);
        }
    }

    public void DestroyWorld()
    {
        if (_world == null)
            return;
        
        B2.DestroyWorld(_world.Value);
        _world = null;
        _bodies.Clear();
    }

    private void OnExit()
        => DestroyWorld();

    private void CollisionUpdate(float delta)
    {
        if (_world == null)
            return;
        
        WorldStep(_world.Value, delta, 4);
    }

    public Body CreateBody(Vector2f position, BodyType type = BodyType.Static, bool fixedRotation = false)
    {
        if (_world == null)
            throw new Exception("World doesn't exist");
        
        var body = new Body(_world!.Value, position, type, fixedRotation);
        _bodies.Add(body);
        return body;
    }
}