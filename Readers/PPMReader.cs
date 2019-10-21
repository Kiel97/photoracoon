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
        public enum PPM_TYPE
        {
            UNKNOWN, P3, P6
        }

        public static Bitmap ReadBitmapFromPPM(string file)
        {
            var reader = new BinaryReader(new FileStream(file, FileMode.Open));

            PPM_TYPE type = GetPPMtype(reader.ReadChar(), reader.ReadChar());
            
            if (type == PPM_TYPE.UNKNOWN)
                throw new ArgumentOutOfRangeException("Invalid PPM type");

            Bitmap bitmap = new Bitmap(200, 100);
            //Read in the pixels
            //for (int y = 0; y < 100; y++)
            //    for (int x = 0; x < 200; x++)
            //        bitmap.SetPixel(x, y, Color.FromArgb(255, reader.ReadByte(), reader.ReadByte(), reader.ReadByte()));

            return bitmap;
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
    }
}
