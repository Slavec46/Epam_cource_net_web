using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _2_1_2_CustomPaint.Figures.Circle
{
    internal class Ring : AbstractFigure
    {
        private AbstractCircle _outCircle;
        private AbstractCircle _inCircle;

        public Ring(AbstractCircle outCircle, AbstractCircle inCircle) : this(outCircle, inCircle, 0, 0)
        {

        }
        public Ring(AbstractCircle outCircle, AbstractCircle inCircle, int centreX, int centreY)
        {
            _centreX = centreX;
            _centreY = centreY;

            _outCircle = outCircle;
            _inCircle = inCircle;
        }

        public override int Aria
        {
            get => _outCircle.Aria;
        }
        public override int Circumference
        {
            get => _outCircle.Circumference + _inCircle.Circumference;
        }

        public override string ToString()
        {
            string[] outStr = _outCircle.ToString().Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            string[] inStr = _inCircle.ToString().Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

            int inStrToOutStrIndex = (outStr.Length / 2) - (inStr.Length / 2);
            int interSize;

            for (int iY = 0; iY < outStr.Length; iY++)
            {
                if (iY >= inStrToOutStrIndex && iY < inStrToOutStrIndex + inStr.Length)
                {
                    if (outStr[iY].Length > inStr[iY - inStrToOutStrIndex].Length)
                    {
                        interSize = (outStr[iY].Length - inStr[iY - inStrToOutStrIndex].Length) / 2;

                        outStr[iY] = Regex.Replace(outStr[iY],
                            "(?<a>\\D{" + interSize + "})(?<b>\\D{" + inStr[iY - inStrToOutStrIndex].Length + "})(?<c>\\D{" + interSize + "})",
                            "${a}" + inStr[iY - inStrToOutStrIndex] + "${c}"
                            );
                    }
                    else
                    {
                        outStr[iY] = new string(' ', inStrToOutStrIndex * 2) + inStr[iY - inStrToOutStrIndex];
                    }
                }
            }

            StringBuilder builder = new StringBuilder();

            foreach (var item in outStr)
            {
                builder.Append(item);
                builder.Append(Environment.NewLine);
            }

            return builder.ToString();
        }
    }
}