# Line2D

[Source code](../../Src/Sbazuo.Geometry/Line2D.cs)

Класс, представляющий прямую на 2-мерной поверхности

Наследование: [object](https://docs.microsoft.com/ru-ru/dotnet/api/system.object) -> [Line2D](#Line2D)

| Свойство | Тип | Описание |
| :------: | :---: | ------ |
| LinePoint | [Point2D](Point2D.md) | Возвращает или задаёт точку, принадлежащую прямой |
| LineDirection | [Vector2D](Vector2D.md) | Возвращает или задаёт направление прямой |

| Конструктор | Описание |
| :---: | ----- |
| Line2D([Point2D](Point2D.md) linePoint, [Vector2D](Vector2D.md) lineDirection) | Создаёт экземпляр прямой с указанной начальной точкой и заданным направлением |
| Line2D([Point2D](Point2D.md) a, [Point2D](Point2D.md) b) | Создаёт прямую, проходящую через указанные точки |
| Line2D([Segment2D](Segment2D.md) prototype) | Создаёт прямую, проходящую через данный отрезок |