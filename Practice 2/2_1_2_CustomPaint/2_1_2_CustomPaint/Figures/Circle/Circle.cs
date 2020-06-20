using System;
using System.Text;

namespace _2_1_2_CustomPaint.Figures.Circle
{
    internal class Circle : AbstractCircle
    {
        private int _diameter;

        public Circle(int radius) : this(radius, 0, 0)
        {

        }
        public Circle(int radius, int centreX, int centreY)
        {
            _radius = radius;
            _centreX = centreX;
            _centreY = centreY;

            _diameter = _radius * 2;
        }

        public override int Aria
        {
            get => (int)(Math.PI * Math.Pow(_radius, 2));
        }
        public override int Circumference
        {
            get => (int)(2 * Math.PI * _radius);
        }

        public override string ToString()
        {
            const char space = ' ';
            const char point = 'O';

            StringBuilder builder = new StringBuilder();

            int coefficient1 = _radius % 2 == 0 ? 1 : 0;
            int coefficient2 = _radius % 2 == 0 ? 0 : 1;
            int coefficient3 = _radius / 2;
            int coefficient4 = _radius - _radius / 2;

            for (int iY = 0; iY < _diameter; iY++)
            {
                if (iY == 0 || iY == _diameter - 1)
                {
                    builder.Append(new string(space, (_radius - 1) * 2) + point);

                    builder.Append(Environment.NewLine);
                }
                else if (iY == _radius / 2 - _radius / 4 || iY == _radius + _radius / 2 + coefficient2 + _radius / 4 - 1)
                {
                    builder.Append(
                        new string(space, _radius - 1 - coefficient3) +
                        point + space +
                        new string(space, _diameter - 2 + _radius - 1 - coefficient3 - coefficient2 + coefficient1 * (_radius - 1 - coefficient3)) +
                        point
                        );

                    builder.Append(Environment.NewLine);
                }
                else if (iY == _radius - 1)
                {
                    builder.Append(
                        point +
                        new string(space, (_diameter - 3) * 2) +
                        space + point
                        );
                }
                else
                {
                    builder.Append(Environment.NewLine);
                }
            }

            return builder.ToString();
        }
    }
}