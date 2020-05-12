# Vector2D

[Source code](../../Src/Sbazuo.Geometry/Vector2D.cs)

Структура, представляющий вектор на 2-мерной поверхности

Наследование: [object](https://docs.microsoft.com/ru-ru/dotnet/api/system.object) -> [Vector2D](#Vector2D)

| Свойство | Тип | Описание |
| :------: | :---: | ------ |
| X | ``double`` | Возвращает или задаёт x координату вектора |
| Y | ``double`` | Возвращает или задаёт y координату вектора |
| Length | ``double`` | Возвращает длину вектора |
| Normalized | [Vector2D](#Vector2D) | Возвращает нормализованный вектор или дефолтный вектор, если его координаты равны 0 |
| Normal | [Vector2D](#Vector2D) | Возвращает нормаль к данному вектору |

| Конструктор | Описание |
| :---: | ----- |
| Vector2D() | Создаёт дефолтный экземпляр вектора |
| Vector2D(double x, double y) | Создаёт экземпляр вектора с указанными координатами |
| Vector2D([Point2D](Point2D.md) a, [Point2D](Point2D.md) b) | Создаёт вектор, направленный от точки A к точке B |

| Методы | Параметры | Описание | Возвращаемое значение |
| :----: | :-------: | -------- | :-------------------: |
| GetRotatedVector | ``double`` angle | Возвращает вектор, повёрнутый на ориентированный угол angle (в радианах), относитально данного вектора | [Vector2D](#Vector2D) |
| *static* ScalarProduct | [Vector2D](#Vector2D) a, [Vector2D](#Vector2D) b | Возвращает скалярное произведение векторов | ``double`` |
| *static* VectorProduct | [Vector2D](#Vector2D) a, [Vector2D](#Vector2D) b | Возвращает векторное произведение векторов | ``double`` |
| *static* GetAngle | [Vector2D](#Vector2D) a, [Vector2D](#Vector2D) b | Возвращает ориентированный угол от вектора A к вектору B | ``double`` |
| *static* AreCollinear | [Vector2D](#Vector2D) a, [Vector2D](#Vector2D) b | Возвращает true, если вектора A и B коллинеарны | ``bool`` |
| *static* AreParallel | [Vector2D](#Vector2D) a, [Vector2D](#Vector2D) b | Возвращает true, если вектора A и B паралельны | ``bool`` |


