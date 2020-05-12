# Ray2D

[Source code](../../Src/Sbazuo.Geometry/Ray2D.cs)

Класс, представляющий луч на 2-мерной поверхности

Наследование: [object](https://docs.microsoft.com/ru-ru/dotnet/api/system.object) -> [Ray2D](#Ray2D)

| Свойство | Тип | Описание |
| :------: | :---: | ------ |
| StartPoint | [Point2D](Point2D.md) | Возвращает или задаёт начало луча |
| RayDirection | [Vector2D](Vector2D.md) | Возвращает или задаёт направление луча |

| Конструктор | Описание |
| :---: | ----- |
| Ray2D([Point2D](Point2D.md) startPoint, [Vector2D](Vector2D.md) direction) | Создаёт луч с указанными началом и направлением |
| Ray2D([Point2D](Point2D.md) a, [Point2D](Point2D.md) b) | Создаёт луч с началом в точке A и проходящий через точку B |