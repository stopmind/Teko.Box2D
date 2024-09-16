namespace Teko.Box2D;

public class PolygonShape(Polygon polygon) : APolygonShape(polygon.ToB2Polygon());