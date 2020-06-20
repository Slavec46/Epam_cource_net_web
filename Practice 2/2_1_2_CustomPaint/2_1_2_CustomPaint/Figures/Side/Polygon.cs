using System;
using System.Text;

namespace _2_1_2_CustomPaint.Figures.Side
{
    internal enum TypeFigure
    {
        None,
        Triangle,
        Quadrangle
    }

    internal class Poligon : AbstractPoligon
    {
        private TypeFigure _typeFigure;

        public Poligon(TypeFigure typeFigure, params AbstractSide[] sides) : this(0, 0, typeFigure, sides)
        {

        }
        public Poligon(int centreX, int centreY, TypeFigure typeFigure, params AbstractSide[] sides) : this(centreX, centreY)
        {
            _typeFigure = typeFigure;

            foreach (var item in sides)
            {
                _sides.Add(item);
            }
        }
        protected Poligon(int centreX, int centreY)
        {
            _centreX = centreX;
            _centreY = centreY;

            _sides = new System.Collections.Generic.List<AbstractSide>();
        }


        public override int Aria
        {
            get
            {
                switch (_sides.Count)
                {
                    case 1 when _typeFigure == TypeFigure.Quadrangle: return (int)Math.Pow(_sides[0].Long, 2);
                    case 2 when _typeFigure == TypeFigure.Quadrangle: return _sides[0].Long * _sides[1].Long;

                    case 1 when _typeFigure == TypeFigure.Triangle: return (int)(Math.Pow(_sides[0].Long, 2) * Math.Sqrt(3)) / 4;
                    case 2 when _typeFigure == TypeFigure.Triangle: return (_sides[0].Long * _sides[1].Long) / 2;
                    case 3 when _typeFigure == TypeFigure.Triangle:
                        double P = (_sides[0].Long + _sides[1].Long + _sides[2].Long) / 2;
                        return (int)Math.Sqrt(P * (P - _sides[0].Long) * (P - _sides[1].Long) * (P - _sides[2].Long));

                    default: return 0;
                }
            }
        }

        public override int Circumference
        {
            get
            {
                switch (_sides.Count)
                {
                    case 1 when _typeFigure == TypeFigure.Quadrangle: return (int)(Math.PI * _sides[0].Long);
                    case 2 when _typeFigure == TypeFigure.Quadrangle: return (int)(Math.Pow(_sides[0].Long + _sides[1].Long, 2) * Math.PI);

                    case 1 when _typeFigure == TypeFigure.Triangle: return (int)(2 * Math.PI * _sides[0].Long / Math.Sqrt(3));
                    case 2 when _typeFigure == TypeFigure.Triangle: return (int)((Math.Sqrt(Math.Pow(_sides[0].Long + _sides[1].Long, 2)) / 2) * Math.PI * 2);
                    case 3 when _typeFigure == TypeFigure.Triangle:
                        double P = (_sides[0].Long + _sides[1].Long + _sides[2].Long) / 2;
                        return (int)(2 * Math.PI * (Aria / P));

                    default: return 0;
                }
            }
        }

        public override string ToString()
        {
            const char space = ' ';
            const char point = 'O';

            StringBuilder builder = new StringBuilder();

            switch (_sides.Count)
            {
                case 1 when _typeFigure == TypeFigure.Quadrangle:

                    for (int iY = 0; iY < _sides[0].Long; iY++)
                    {
                        if (iY == 0 || iY == _sides[0].Long - 1)
                        {
                            builder.Append(new string(point, _sides[0].Long * 2));
                            builder.Append(Environment.NewLine);
                        }
                        else
                        {
                            builder.Append(point + new string(space, (_sides[0].Long - 1) * 2) + point);
                            builder.Append(Environment.NewLine);
                        }
                    }

                    break;

                case 2 when _typeFigure == TypeFigure.Quadrangle:

                    for (int iY = 0; iY < _sides[1].Long; iY++)
                    {
                        if (iY == 0 || iY == _sides[1].Long - 1)
                        {
                            builder.Append(new string(point, _sides[0].Long * 2));
                            builder.Append(Environment.NewLine);
                        }
                        else
                        {
                            builder.Append(point + new string(space, (_sides[0].Long - 1) * 2) + point);
                            builder.Append(Environment.NewLine);
                        }
                    }

                    break;

                case 1 when _typeFigure == TypeFigure.Triangle:

                    for (int iY = 0; iY < _sides[0].Long; iY++)
                    {

                        if (iY == 0)
                        {
                            builder.Append(new string(space, _sides[0].Long - 1) +
                                           new string(point, 2));
                        }
                        else if (iY == _sides[0].Long - 1)
                        {
                            builder.Append(new string(point, _sides[0].Long * 2));
                        }
                        else
                        {
                            builder.Append(new string(space, _sides[0].Long - iY - 1) +
                                           point +
                                           new string(space, iY * 2) +
                                           point);
                        }

                        builder.Append(Environment.NewLine);
                    }

                    break;
                case 2 when _typeFigure == TypeFigure.Triangle:

                    int coeficient1 = _sides[1].Long % 2 == 0 ? 1 : 0;

                    for (int iY = 0, count = 0; iY < _sides[1].Long; iY++, count++)
                    {

                        builder.Append(point);

                        if (iY > 0)
                        {
                            if ((_sides[1].Long - 1) / 4 == iY)
                            {
                                builder.Append(new string(space, (_sides[0].Long * 2 - 2) / 4) + point);
                            }
                            if (((_sides[1].Long - 1) / 4 + (_sides[1].Long - 1) / 2) == iY)
                            {
                                builder.Append(new string(space, (_sides[0].Long * 2 - 2) / 4 + (_sides[0].Long * 2 - 2) / 2) + point);
                            }
                            if (iY == _sides[1].Long - 1)
                            {
                                builder.Append(new string(point, _sides[0].Long * 2 - 1));
                            }
                        }

                        builder.Append(Environment.NewLine);
                    }

                    break;
                case 3 when _typeFigure == TypeFigure.Triangle:
                    break;

                default:
                    break;
            }

            return builder.ToString();
        }
    }
}