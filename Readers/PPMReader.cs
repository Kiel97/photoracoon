using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoRacoon.Readers
{
    public static class PPMReader
    {
        // http://netpbm.sourceforge.net/doc/ppm.html

        private static BinaryReader reader;
        private static char read = ' ';

        public enum PPM_TYPE
        {
            UNKNOWN, P3, P6
        }

        public static Bitmap ReadBitmapFromPPM(string file)
        {
            using(FileStream fs = new FileStream(file, FileMode.Open))
            {
                using(reader = new BinaryReader(fs))
                {
                    PPM_TYPE type = GetPPMtype(reader.ReadChar(), reader.ReadChar());

                    if (type == PPM_TYPE.UNKNOWN)
                        throw new ArgumentOutOfRangeException("Invalid PPM type");
                    else if (type == PPM_TYPE.P6)
                        throw new NotSupportedException("P6 format is not implemented yet");

                    int width = getNumber();
                    int height = getNumber();
                    int limit = getNumber();

                    if (limit < 0 || limit > 65535)
                        throw new ArgumentOutOfRangeException($"Invalid maximum color value: {limit}");

                    Bitmap bitmap = new Bitmap(width, height);


                    for (int y = 0; y < height; y++)
                    {
                        for (int x = 0; x < width; x++)
                        {
                            int red = getNumber();
                            if (red < 0 || red > limit)
                                throw new ArgumentOutOfRangeException($"Invalid red color value: {red}");

                            int green = getNumber();
                            if (green < 0 || green > limit)
                                throw new ArgumentOutOfRangeException($"Invalid green color value: {green}");

                            int blue = getNumber();
                            if (blue < 0 || blue > limit)
                                throw new ArgumentOutOfRangeException($"Invalid blue color value: {blue}");

                            bitmap.SetPixel(x, y, Color.FromArgb(255, red, green, blue));
                        }
                    }

                    return bitmap;
                }
            }
        }

        private static PPM_TYPE GetPPMtype(char p, char n)
        {
            if (p != 'P' && p != 'p')
                return PPM_TYPE.UNKNOWN;

            if (n == '3')
                return PPM_TYPE.P3;
            else if (n == '6')
                return PPM_TYPE.P6;
            else
                return PPM_TYPE.UNKNOWN;
        }

        private static void skipToFirstDigit()
        {
            bool isComment = false;

            do
            {
                read = reader.ReadChar();

                if (read == '#')
                    isComment = true;
                if (read == '\n')
                    isComment = false;
            }
            while (char.IsWhiteSpace(read) || isComment);
        }

        private static int getNumber()
        {
            skipToFirstDigit();

            StringBuilder s = new StringBuilder();
            while (char.IsDigit(read))
            {
                s.Append(read);
                read = reader.ReadChar();
            }

            return int.Parse(s.ToString());
        }
    }
}
