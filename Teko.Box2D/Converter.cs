using Box2D.NET.Bindings;
using Teko.Core;

namespace Teko.Box2D;

public static class Converter
{
    private static int _meterSize = 100;

    public static B2.Vec2 ToB2Vec(Vector2f vec2)
        => new B2.Vec2
        {
            x = vec2.X / _meterSize,
            y = vec2.Y / _meterSize,
        };

    public static Vector2f ToGameVec(B2.Vec2 vec2)
        => new(vec2.x * _meterSize, vec2.y * _meterSize);

    public static float ToB2Distance(float distance)
        => distance / _meterSize;
}