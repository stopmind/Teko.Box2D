using Box2D.NET.Bindings;

namespace Teko.Box2D;

public enum BodyType : uint
{
    Static = B2.BodyType.staticBody,
    Dynamic = B2.BodyType.dynamicBody
}