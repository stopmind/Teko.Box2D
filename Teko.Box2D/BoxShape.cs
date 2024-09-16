using Box2D.NET.Bindings;
using Teko.Core;

namespace Teko.Box2D;

public class BoxShape(RectF rect, float angle = 0f) : APolygonShape(B2.MakeOffsetBox(
    Converter.ToB2Distance(rect.Size.X / 2), Converter.ToB2Distance(rect.Size.Y / 2),
    Converter.ToB2Vec(rect.Position + rect.Size / 2), angle));