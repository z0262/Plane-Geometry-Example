# Plane-Geometry-Example
Example of plane geometry


Библиотека, которая умеет вычислять площадь круга по радиусу и треугольника по трем сторонам, определять является ли треугольник прямоугольным.
Может определять тип фигуры по количеству входных параметров.
Содержит также юнит тесты, лаунчер из командной строки.
Библиотека использует .Net Standard 2.0.
Юнит-тесты и лаунчер используют .Net Core 2.2.
Решение выполнено в MSVS2019 с использованием C# 7.

Для добавления фигуры требуется реализовать интерфейс IPlaneFigure и разместить реализацию в одной из загруженных Assembly.
Создавать фигуры возможно четырьмя способами:
1. Непосредственное создание экземпляра через вызов конструктора.
2. Вызов метода FigureFactory.CreatePlaneFigures(double[] pars, Type outputType = null) с указанием параметров фигуры. Результатом будет перечисление всех подходящих экземпляров или пустое значение.
3. Вызов метода FigureFactory.CreatePlaneFigure<<T>>(double[] pars) с указанием типа и параметров фигуры. Результатом будет первый подходящий экземпляр или пустое значение.
4. Вызов метода FigureFactory.CreatePlaneFigure(double[] pars) с указанием параметров фигуры. Результатом будет первый подходящий экземпляр или пустое значение.

Примеры использования библиотеки:

```C#
double circleArea = new Circle(0.51).Area;

bool isRightTriangle = new Triangle(0.51, 1.1, 0.9).IsRightTriangle;

string ellipseName = new Ellipse(1.1, 1.1).FigureName;

IEnumerable<IPlaneFigure> figures = new FigureFactory().CreatePlaneFigures(new[]{ 1.0 });

Circle circle = new FigureFactory().CreatePlaneFigure<Circle>(new[]{ 1.0 });

IPlaneFigure triangle = new FigureFactory().CreatePlaneFigure(new[]{ 1.0, 1.0, 0.5 });
```

Примечания:
Фильтрация по типу осуществляется до вызова конструктора.
Первое исключение прекращает вызов создания фигур. 
Сортировка фигур происходит по наименованию класса реализации.

