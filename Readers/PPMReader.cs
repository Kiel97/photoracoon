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
                        throw new NotSupportedException("Not implemented yet.");

                    int width = getNumber();
                    int height = getNumber();

                    Bitmap bitmap = new Bitmap(width, height);
                    //Read in the pixels
                    //for (int y = 0; y < 100; y++)
                    //    for (int x = 0; x < 200; x++)
                    //        bitmap.SetPixel(x, y, Color.FromArgb(255, reader.ReadByte(), reader.ReadByte(), reader.ReadByte()));

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
