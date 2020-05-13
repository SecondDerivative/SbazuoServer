# GeometryUtils

[Source code](../../Src/Sbazuo.Geometry/GeometryUtils.cs)

Статический класс утилит для расчёта расстояния между геометрическими объектами

| Методы | Параметры | Описание | Возвращаемое значение |
| :----: | :-------: | -------- | :-------------------: |
| *static* DistanceToLine | [Point2D](Point2D.md) point, [Line2D](Line2D.md) line | Возвращает ориентированное расстояние от точки до прямой | ``double`` |
| *static* DistanceToSegment | [Point2D](Point2D.md) point, [Segment2D](Segment2D.md) segment | Возвращает расстояние от точки до отрезка | ``double`` |
| *static* DistanceBetweenSegments | [Segment2D](Segment2D.md) a, [Segment2D](Segment2D.md) b | Возвращает расстояние между двумя отрезками | ``double`` |
| *static* DistanceBetweenLines | [Line2D](Line2D.md) a, [Line2D](Line2D.md) b | Возвращает расстояние между двумя прямыми | ``double`` |
| *static* DistanceFromSegmentToLine | [Segment2D](Segment2D.md) segment, [Line2D](Line2D.md) line | Возвращает расстояние от отрезка до линии | ``double`` |
| *static* DistanceFromSegmentToRay | [Segment2D](Segment2D.md) segment, [Ray2D](Ray2D.md) ray | Возвращает расстояние от отрезка до луча | ``double`` |