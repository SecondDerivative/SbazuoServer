# Line2D

[Source code](../../Src/Sbazuo.Geometry/Ray2D.cs)

Класс, представляющий луч на 2-мерной поверхности

Наследование: [object](https://docs.microsoft.com/ru-ru/dotnet/api/system.object) -> [Ray2D](#Ray2D)

| Свойство | Тип | Описание |
| :------: | :---: | ------ |
| StartPoint | [Point2D](Point2D.md) | Возвращает или задаёт начало луча |
| RayDirection | [Vector2D](Vector2D.md) | Возвращает или задаёт направление луча |

| Конструктор | Описание |
| :---: | ----- |
| Line2D([Point2D](Point2D.md) linePoint, [Vector2D](Vector2D.md) lineDirection) | Создаёт луч с указанными началом и направлением |
| Line2D([Point2D](Point2D.md) a, [Point2D](Point2D.md) b) | Создаёт луч с началом в точке A и проходящий через точку B |