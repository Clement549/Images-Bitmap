using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Drawing;
using System.Numerics;

namespace LectureImage
{
    class Program
    {
        
        static void Main(string[] args)
        {

            MyImage myImage = new MyImage("./Images/coco.bmp"); 
            //MyImage myImage2 = new MyImage("./Images/old.bmp");

            byte[] myfile = myImage.GetTab();      //myfile est un vecteur composé d'octets représentant les métadonnées et les données de l'image
            //byte[] myfile2 = myImage2.GetTab();



            /////////  TEST ////////
           
            //Métadonnées du fichier
           Console.WriteLine("\n Header \n");

            for (int i = 0; i < 14; i++)
                Console.Write(myfile[i] + " ");
            //Métadonnées de l'image
          Console.WriteLine("\n HEADER INFO \n");
          for (int i = 14; i< 54; i++)
               Console.Write(myfile[i] + " ");
            //L'image elle-même
            //Console.WriteLine("\n IMAGE \n");
            for (int i = 54; i < myfile.Length; i = i + 60)
            {
                for (int j = i; j < i + 60; j++)
                {
                 // Console.Write(myfile[j] + " ");

                }
               // Console.WriteLine();
            }

            /////////  FIN TEST ////////



            File.WriteAllBytes("./Images/newImage.bmp", myfile);
            //File.WriteAllBytes("./Images/newImageOld.bmp", myfile2);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Nouvelle Image crée");
  
            Console.ReadLine();
        }
    }

    class Pixel
    {
        byte[] rgb;

        public Pixel(byte[] _rgb)
        {
            rgb = _rgb;
        }

        public byte[] GetRgb()
        {
            return rgb;
        }

        public void SetRgb(byte[] _rgb)
        {
            rgb = _rgb;                  //R et B inversés
            byte temp = rgb[0];
            rgb[0] = rgb[2];
            rgb[2] = temp;
        }
    }


    class MyImage
    {
        string imageType;
        int fileSize;
        int offsetSize;
        int width;
        int height;
        int colorNumber;
        byte[] tab;
        // byte[] tabEND;

        public MyImage(string myFile)
        {

            tab = File.ReadAllBytes(myFile);
            //tabEND = tab;

            imageType = convertASCII(0);
            fileSize = ExtractInt(2);
            offsetSize = ExtractInt(14);
            width = ExtractInt(18);
            height = ExtractInt(22);
            colorNumber = ExtractInt(28);

            Pixel[,] matrix = new Pixel[height, width];
            matrix = CreateMatrix(matrix);

            Console.WriteLine("Select an Effect:");
            Console.WriteLine("1- Black & White");
            Console.WriteLine("2- Mirror Effect");
            Console.WriteLine("3- Flou");
            Console.WriteLine("4- Detection de contour");
            Console.WriteLine("5- Renforcement des bords");
            Console.WriteLine("6- Repoussage");
            Console.WriteLine("7- Agrandissement / Retrecissement");
            Console.WriteLine("8- Rotation");
            Console.WriteLine();
            Console.WriteLine("9- Create fractal");
            Console.WriteLine("10- Create Histogram");
            Console.WriteLine("11- Sterenographie");
            Console.WriteLine();
            Console.WriteLine("12- Create QR Code");

            int input = Convert.ToInt32(Console.ReadLine());

            switch (input)
            {
                case 1:
                    matrix = BlackAndWhite(matrix);
                    tab = CreateVect(matrix);
                    break;
                case 2:
                    matrix = Mirror(matrix);
                    tab = CreateVect(matrix);
                    break;
                case 3:
                    int[,] convo1 = new int[,] { { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 } };    //Flou
                    matrix = Convolution(matrix, convo1, 4);
                    tab = CreateVect(matrix);
                    break;
                case 4:
                    int[,] convo2 = new int[,] { { 0, 1, 0 }, { 1, -4, 1 }, { 0, 1, 0 } };   //Detection Contour
                    matrix = Convolution(matrix, convo2, 1);
                    tab = CreateVect(matrix);
                    break;
                case 5:
                    int[,] convo3 = new int[,] { { 0, -1, 0 }, { -1, 5, -1 }, { 0, -1, 0 } };    //Renforcement Bords
                    matrix = Convolution(matrix, convo3, 3);
                    tab = CreateVect(matrix);
                    break;
                case 6:
                    int[,] convo4 = new int[,] { { -2, -1, 0 }, { -1, 1, 1 }, { 0, 1, 2 } };    //Repoussage
                    matrix = Convolution(matrix, convo4, 5);
                    tab = CreateVect(matrix);
                    break;
                case 7:
                    Console.Clear();
                    Console.WriteLine("Choose:");
                    Console.WriteLine("1 - Agrandissement");
                    Console.WriteLine("2 - Réduction");
                    int type = Convert.ToInt32(Console.ReadLine());

                    Console.Clear();
                    Console.WriteLine("Entrez le facteur d'agrandissement / reduction");
                    int ratio = Convert.ToInt32(Console.ReadLine());

                    tab = Resize(tab, ratio, height, width, matrix, type);
                    break;
                case 8:
                    Console.Clear();
                    Console.WriteLine("Choose:");
                    Console.WriteLine("1 - Gauche");
                    Console.WriteLine("2 - Droite");
                    Console.WriteLine("3 - Retourner");
                    int angle = Convert.ToInt32(Console.ReadLine());

                    tab = Rotation(matrix, angle, width, height, tab);
                    break;
                case 9:
                    Console.Clear();

                    tab = Fractal(matrix, tab);
                    break;
                case 10:
                    Console.Clear();

                    tab = Histogram(matrix, tab);
                    break;
                case 11:
                    Console.Clear();

                    tab = Sterenographie(matrix, tab);
                    break;
                case 12:
                    Console.Clear();
                    Console.WriteLine("Enter your word");
                    string motString = Console.ReadLine().ToLower();

                    tab = CreateQRCode(matrix, tab, motString);
                    break;
                default:
                    Console.WriteLine("ERROR: Enter a Number between 1 and 8");
                    break;

            }

            Console.WriteLine();
            Console.WriteLine(imageType);
            Console.WriteLine(fileSize);
            Console.WriteLine(offsetSize);
            Console.WriteLine(width);
            Console.WriteLine(height);
            Console.WriteLine(colorNumber);
        }


        public string convertASCII(int index)
        {
            List<int> listSize = new List<int>();

            listSize.Add(tab[index]);
            listSize.Add(tab[index + 1]);

            List<string> listLetter = new List<string>();

            for (int i = 0; i < 2; i++)
            {
                if (listSize[i] != 0)
                {
                    char c = Convert.ToChar(listSize[i]);
                    listLetter.Add(c.ToString());
                }
            }

            string wordFinal = "";
            for (int i = 0; i < listLetter.Count(); i++)
            {
                wordFinal += listLetter[i];
            }

            return wordFinal;
        }


        public int ExtractInt(int index)
        {
            List<int> listSize = new List<int>();

            listSize.Add(tab[index]);
            listSize.Add(tab[index + 1]);
            listSize.Add(tab[index + 2]);
            listSize.Add(tab[index + 3]);


            int pos = 0;
            ulong result = 0;

            foreach (byte by in listSize)
            {
                result |= ((ulong)by) << pos;
                pos += 8;
            }

            return Convert.ToInt32(result);
        }


        byte[] INT2LE(int data)
        {
            byte[] b = new byte[4];
            b[0] = (byte)data;
            b[1] = (byte)(((uint)data >> 8) & 0xFF);
            b[2] = (byte)(((uint)data >> 16) & 0xFF);
            b[3] = (byte)(((uint)data >> 24) & 0xFF);
            return b;
        }


        public byte[] GetTab()
        {
            return tab;
        }



        public Pixel[,] BlackAndWhite(Pixel[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    byte r = matrix[i, j].GetRgb()[0];
                    byte g = matrix[i, j].GetRgb()[1];
                    byte b = matrix[i, j].GetRgb()[2];

                    byte _rgb = Convert.ToByte((r + g + b) / 3);

                    byte[] rgb = new byte[] { _rgb, _rgb, _rgb };

                    matrix[i, j].SetRgb(rgb);
                }

            return matrix;
        }


        public Pixel[,] Mirror(Pixel[,] matrix)
        {
            Pixel[,] matrixMirror = new Pixel[height, width];

            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrixMirror[i, j] = matrix[i, matrix.GetLength(1) - j - 1];
                }

            return matrixMirror;
        }


        public byte[] Resize(Byte[] tab, int ratio, int _height, int _width, Pixel[,] matrix, int type)
        {
            int newHeight;
            int newWidth;

            if (type == 2)
            {
                newHeight = (int)(_height / ratio);
                newWidth = (int)(_width / ratio);
            }
            else
            {
                newHeight = (int)(_height * ratio);
                newWidth = (int)(_width * ratio);
            }


            height = newHeight;
            width = newWidth;

            int newFileSize = (offsetSize + 14) + (newHeight * newWidth) * 3;   //768 054
            fileSize = newFileSize;

            Byte[] newTab = new byte[newFileSize];

            for (int i = 0; i < (offsetSize + 14); i++)
            {
                newTab[i] = tab[i];
            }

            byte[] fileSizeB = INT2LE(newFileSize);
            newTab[2] = fileSizeB[0];
            newTab[3] = fileSizeB[1];
            newTab[4] = fileSizeB[2];
            newTab[5] = fileSizeB[3];

            byte[] widthB = INT2LE(newWidth);
            newTab[18] = widthB[0];
            newTab[19] = widthB[1];
            newTab[20] = widthB[2];
            newTab[21] = widthB[3];

            byte[] heightB = INT2LE(newHeight);
            newTab[22] = heightB[0];
            newTab[23] = heightB[1];
            newTab[24] = heightB[2];
            newTab[25] = heightB[3];

            for (int i = 0; i < (offsetSize + 14); i++)
            {
                tab[i] = newTab[i];
            }

            if (type == 2)
            {

                Pixel[,] newMatrix = new Pixel[matrix.GetLength(0) / ratio, matrix.GetLength(1) / ratio];

                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        for (int k = 0; k < ratio; k++)
                            for (int l = 0; l < ratio; l++)
                                newMatrix[i / (ratio), j / (ratio)] = matrix[i, j];
                    }
                }


                newTab = CreateVect(newMatrix);
            }
            else
            {

                Pixel[,] newMatrix = new Pixel[matrix.GetLength(0) * ratio, matrix.GetLength(1) * ratio];

                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        for (int k = 0; k < ratio; k++)
                            for (int l = 0; l < ratio; l++)
                                newMatrix[i * (ratio) + k, j * (ratio) + l] = matrix[i, j];
                    }
                }


                newTab = CreateVect(newMatrix);
            }

            return newTab;
        }


        public byte[] Rotation(Pixel[,] matrix, int angle, int _width, int _height, Byte[] tab)
        {
            int newHeight;
            int newWidth;

            if (angle == 1 || angle == 2)
            {
                newHeight = (width);
                newWidth = (height);
            }
            else
            {
                newHeight = (_height);
                newWidth = (_width);
            }

            height = newHeight;
            width = newWidth;

            int newFileSize = (offsetSize + 14) + (newHeight * newWidth) * 3;
            fileSize = newFileSize;

            Byte[] newTab = new byte[newFileSize];

            for (int i = 0; i < (offsetSize + 14); i++)
            {
                newTab[i] = tab[i];
            }

            byte[] fileSizeB = INT2LE(newFileSize);
            newTab[2] = fileSizeB[0];
            newTab[3] = fileSizeB[1];
            newTab[4] = fileSizeB[2];
            newTab[5] = fileSizeB[3];

            byte[] widthB = INT2LE(newWidth);
            newTab[18] = widthB[0];
            newTab[19] = widthB[1];
            newTab[20] = widthB[2];
            newTab[21] = widthB[3];

            byte[] heightB = INT2LE(newHeight);
            newTab[22] = heightB[0];
            newTab[23] = heightB[1];
            newTab[24] = heightB[2];
            newTab[25] = heightB[3];

            for (int i = 0; i < (offsetSize + 14); i++)
            {
                tab[i] = newTab[i];
            }

            Pixel[,] matrixRotation = new Pixel[height, width];

            if (angle == 1)
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        int newAngle = Convert.ToInt32(Math.PI / 180) * angle; // Convert Degree to Radian

                        int newX = Convert.ToInt32((matrix.GetLength(0) - i - 1) * Math.Cos(newAngle) - (j) * Math.Sin(newAngle));
                        int newY = Convert.ToInt32((i) * Math.Sin(newAngle) + (matrix.GetLength(1) - j - 1) * Math.Cos(newAngle));

                        matrixRotation[j, matrix.GetLength(0) - i - 1] = matrix[i, j];
                    }

                newTab = CreateVect(matrixRotation);
            }
            else if (angle == 2)
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        int newAngle = Convert.ToInt32(Math.PI / 180) * angle; // Convert Degree to Radian

                        int newX = Convert.ToInt32((matrix.GetLength(0) - i - 1) * Math.Cos(newAngle) - (j) * Math.Sin(newAngle));
                        int newY = Convert.ToInt32((i) * Math.Sin(newAngle) + (matrix.GetLength(1) - j - 1) * Math.Cos(newAngle));

                        matrixRotation[matrix.GetLength(1) - j - 1, i] = matrix[i, j];
                    }

                newTab = CreateVect(matrixRotation);
            }
            else
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        int newAngle = Convert.ToInt32(Math.PI / 180) * angle; // Convert Degree to Radian

                        int newX = Convert.ToInt32((matrix.GetLength(0) - i - 1) * Math.Cos(newAngle) - (j) * Math.Sin(newAngle));
                        int newY = Convert.ToInt32((i) * Math.Sin(newAngle) + (matrix.GetLength(1) - j - 1) * Math.Cos(newAngle));

                        matrixRotation[i, j] = matrix[newX, newY];
                    }

                newTab = CreateVect(matrixRotation);
            }


            return newTab;
        }



        public Pixel[,] Convolution(Pixel[,] matrix, int[,] convo, int factor)
        {
            Pixel[,] matrixFlou = matrix;

            for (int i = 1; i < matrix.GetLength(0) - 1; i++)
                for (int j = 1; j < matrix.GetLength(1) - 1; j++)
                {
                    int r = 0;
                    int g = 0;
                    int b = 0;
                    int d1 = 1;
                    int d2 = 1;

                    for (int x = 0; x < convo.GetLength(0) - 1; x++)
                    {
                        for (int y = 0; y < convo.GetLength(1) - 1; y++)
                        {
                            r += matrix[i - d1, j + d2].GetRgb()[0] * convo[convo.GetLength(0) - x - 1, convo.GetLength(1) - y - 1];
                            g += matrix[i - d1, j + d2].GetRgb()[1] * convo[convo.GetLength(0) - x - 1, convo.GetLength(1) - y - 1];
                            b += matrix[i - d1, j + d2].GetRgb()[2] * convo[convo.GetLength(0) - x - 1, convo.GetLength(1) - y - 1];

                            d2--;
                        }
                        d2 = 1;
                        d1--;
                    }

                    r /= factor;
                    g /= factor;
                    b /= factor;

                    if (r > 255)
                    {
                        r = 255;
                    }
                    if (r < 0)
                    {
                        r = 0;
                    }
                    if (g > 255)
                    {
                        g = 255;
                    }
                    if (g < 0)
                    {
                        g = 0;
                    }
                    if (b > 255)
                    {
                        b = 255;
                    }
                    if (b < 0)
                    {
                        b = 0;
                    }

                    //int r1 = (matrix[i - 1, j + 1].GetRgb()[0] + matrix[i - 1, j].GetRgb()[0] + matrix[i - 1, j - 1].GetRgb()[0] + matrix[i, j + 1].GetRgb()[0] + matrix[i - 1, j - 1].GetRgb()[0] + matrix[i + 1, j + 1].GetRgb()[0] + matrix[i + 1, j + 1].GetRgb()[0] + matrix[i + 1, j - 1].GetRgb()[0] + matrix[i, j].GetRgb()[0]) / 9;
                    //int g1 = (matrix[i - 1, j + 1].GetRgb()[1] + matrix[i - 1, j].GetRgb()[1] + matrix[i - 1, j - 1].GetRgb()[1] + matrix[i, j + 1].GetRgb()[1] + matrix[i - 1, j - 1].GetRgb()[1] + matrix[i + 1, j + 1].GetRgb()[1] + matrix[i + 1, j + 1].GetRgb()[1] + matrix[i + 1, j - 1].GetRgb()[1] + matrix[i, j].GetRgb()[1]) / 9;
                    //int b1 = (matrix[i - 1, j + 1].GetRgb()[2] + matrix[i - 1, j].GetRgb()[2] + matrix[i - 1, j - 1].GetRgb()[2] + matrix[i, j + 1].GetRgb()[2] + matrix[i - 1, j - 1].GetRgb()[2] + matrix[i + 1, j + 1].GetRgb()[2] + matrix[i + 1, j + 1].GetRgb()[2] + matrix[i + 1, j - 1].GetRgb()[2] + matrix[i, j].GetRgb()[2]) / 9;

                    byte _r = Convert.ToByte((r));
                    byte _g = Convert.ToByte((g));
                    byte _b = Convert.ToByte((b));

                    byte[] rgb = new byte[] { _r, _g, _b };

                    matrix[i, j].SetRgb(rgb);
                }

            return matrixFlou;
        }


        public byte[] Fractal(Pixel[,] matrix, byte[] tab)
        {
            //height = 256;
            //width = 256;
            //fileSize = height * width * 3 + (offsetSize+14);

            byte[] newTab = new byte[fileSize];

            for (int i = 0; i < (offsetSize + 14); i++)
            {
                newTab[i] = tab[i];
            }
            for (int i = (offsetSize + 14); i < fileSize; i++)
            {
                newTab[i] = 0;
            }

            byte[] fileSizeB = INT2LE(fileSize);
            newTab[2] = fileSizeB[0];
            newTab[3] = fileSizeB[1];
            newTab[4] = fileSizeB[2];
            newTab[5] = fileSizeB[3];

            byte[] widthB = INT2LE(width);
            newTab[18] = widthB[0];
            newTab[19] = widthB[1];
            newTab[20] = widthB[2];
            newTab[21] = widthB[3];

            byte[] heightB = INT2LE(height);
            newTab[22] = heightB[0];
            newTab[23] = heightB[1];
            newTab[24] = heightB[2];
            newTab[25] = heightB[3];

            for (int i = 0; i < (offsetSize + 14); i++)
            {
                tab[i] = newTab[i];
            }

            Pixel[,] matrixFractal = new Pixel[height, width];

            int r;
            int g;
            int b;
            Random rnd = new Random();

            int maxIterations = 50; // increasing this will give you a more detailed fractal

            Complex Z;
            Complex C;
            int iterations;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    iterations = 0;
                    C = new Complex(i, j);
                    Z = new Complex(0, 0);
                    while (Complex.Abs(Z) < 2 && iterations < maxIterations)
                    {
                        Z = Z * Z + C / 200;
                        iterations++;
                        //Console.WriteLine(Complex.Abs(Z));
                        //Console.WriteLine("Itération: " + iterations);
                    }
                    if (iterations == maxIterations)
                    {
                        int _rnd = rnd.Next(1, 2);
                        r = 0;
                        g = 0;
                        b = 0;

                        byte _r = Convert.ToByte((r));
                        byte _g = Convert.ToByte((g));
                        byte _b = Convert.ToByte((b));

                        byte[] rgb = new byte[] { _r, _g, _b };

                        matrix[i, j].SetRgb(rgb);
                    }
                    else
                    {
                        r = 0;
                        g = 0;
                        b = iterations * 255 / maxIterations;

                        byte _r = Convert.ToByte((r));
                        byte _g = Convert.ToByte((g));
                        byte _b = Convert.ToByte((b));

                        byte[] rgb = new byte[] { _r, _g, _b };

                        matrix[i, j].SetRgb(rgb);
                    }
                }
            }

            newTab = CreateVect(matrix);

            return newTab;
        }



        public byte[] Histogram(Pixel[,] matrix, byte[] tab)
        {
            //height = 256;
            //width = 256;
            //fileSize = height * width * 3 + (offsetSize+14);

            byte[] newTab = new byte[fileSize];

            for (int i = 0; i < (offsetSize + 14); i++)
            {
                newTab[i] = tab[i];
            }
            for (int i = (offsetSize + 14); i < fileSize; i++)
            {
                newTab[i] = 0;
            }

            byte[] fileSizeB = INT2LE(fileSize);
            newTab[2] = fileSizeB[0];
            newTab[3] = fileSizeB[1];
            newTab[4] = fileSizeB[2];
            newTab[5] = fileSizeB[3];

            byte[] widthB = INT2LE(width);
            newTab[18] = widthB[0];
            newTab[19] = widthB[1];
            newTab[20] = widthB[2];
            newTab[21] = widthB[3];

            byte[] heightB = INT2LE(height);
            newTab[22] = heightB[0];
            newTab[23] = heightB[1];
            newTab[24] = heightB[2];
            newTab[25] = heightB[3];

            for (int i = 0; i < (offsetSize + 14); i++)
            {
                tab[i] = newTab[i];
            }

            Pixel[,] matrixFractal = new Pixel[height, width];

            byte[] histo = new byte[width * height];
            int index = 0;

            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    byte r = matrix[j, i].GetRgb()[0];
                    byte g = matrix[j, i].GetRgb()[1];
                    byte b = matrix[j, i].GetRgb()[2];

                    byte _rgb = Convert.ToByte((r * 0.2989 + g * 0.5870 + b * 0.1140));

                    histo[j + index] = _rgb;
                }

                index += height;
            }


            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                int curentRgbCount = 0;
                foreach (byte b in histo)
                {
                    if (i == b)
                    {
                        curentRgbCount++;
                    }
                }


                for (int j = 0; j < matrix.GetLength(0); j++)
                {

                    if (j < curentRgbCount / 10)
                    {
                        matrix[j, i] = new Pixel(new byte[] { 0, 0, 0 });
                    }
                    else
                    {
                        matrix[j, i] = new Pixel(new byte[] { 255, 255, 255 });
                    }
                }
            }

            foreach (byte b in histo)
            {
                // Console.WriteLine(b);
            }

            newTab = CreateVect(matrix);

            return newTab;
        }



        public byte[] Sterenographie(Pixel[,] matrix, byte[] tab)
        {

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    byte r;
                    byte g;
                    byte b;

                    r = matrix[i, j].GetRgb()[0];
                    g = matrix[i, j].GetRgb()[1];
                    b = matrix[i, j].GetRgb()[2];

                    byte[] rgb = { r, g, b };

                    char[] rc = Convert.ToString(rgb[0], 2).PadLeft(8, '0').ToCharArray();
                    char[] gc = Convert.ToString(rgb[1], 2).PadLeft(8, '0').ToCharArray();
                    char[] bc = Convert.ToString(rgb[2], 2).PadLeft(8, '0').ToCharArray();

                    for (int a = 0; a < 8; a++)
                    {
                        if (a > 3)
                        {
                            rc[a] = '0';
                            gc[a] = '0';
                            bc[a] = '0';
                        }
                    }

                    string rBinary = new string(rc);
                    string gBinary = new string(gc);
                    string bBinary = new string(bc);


                    r = Convert.ToByte(rBinary, 2);
                    g = Convert.ToByte(gBinary, 2);
                    b = Convert.ToByte(bBinary, 2);

                    byte[] rgb2 = { r, g, b };

                    matrix[i, j] = new Pixel(rgb2);
                }
            }

            tab = CreateVect(matrix);

            return tab;
        }




        public byte[] CreateQRCode(Pixel[,] matrix, byte[] tab, string motString)
        {
            height = 108;   ///9 Pixels representent 1 byte  + un contour
            width = 108;
            fileSize = height * width * 3 + (offsetSize+14);

            byte[] newTab = new byte[fileSize];

            for (int i = 0; i < (offsetSize + 14); i++)
            {
                newTab[i] = tab[i];
            }


            byte[] fileSizeB = INT2LE(fileSize);
            newTab[2] = fileSizeB[0];
            newTab[3] = fileSizeB[1];
            newTab[4] = fileSizeB[2];
            newTab[5] = fileSizeB[3];

            byte[] widthB = INT2LE(width);
            newTab[18] = widthB[0];
            newTab[19] = widthB[1];
            newTab[20] = widthB[2];
            newTab[21] = widthB[3];

            byte[] heightB = INT2LE(height);
            newTab[22] = heightB[0];
            newTab[23] = heightB[1];
            newTab[24] = heightB[2];
            newTab[25] = heightB[3];

            for (int i = 0; i < (offsetSize + 14); i++)
            {
                tab[i] = newTab[i];
            }

            byte[,] matrixByte = new byte[21, 21];
            
            Pixel[,] matrixQRCode = new Pixel[height, width];
            int indexI = 4;
            int indexJ = 4;
            byte color = 125;
            int xValue = 2;

            int index = 0;
            int div_j = 0;

            //byte[] mot = new byte[208] { 0,0,1,0,0,0,0,0, 0,1,0,1,1,0,1,1, 0,0,0,0,1,0,1,1, 0,1,1,1,1,0,0,0, 1,1,0,1,0,0,0,1, 0,1,1,1,0,0,1,0, 1,1,0,1,1,1,0,0, 0,1,0,0,1,1,0,1, 0,1,0,0,0,0,1,1, 0,1,0,0,0,0,0,0, 1,1,1,0,1,1,0,0, 0,0,0,1,0,0,0,1, 1,1,1,0,1,1,0,0 ,0,0,0,1,0,0,0,1 ,1,1,1,0,1,1,0,0 ,0,0,0,1,0,0,0,1, 1,1,1,0,1,1,0,0, 0,0,0,1,0,0,0,1, 1,1,1,0,1,1,0,0, 1,0,1,0,1,1,0,0, 0,0,0,1,0,0,0,1, 0,1,0,1,1,1,0,0 ,0,0,1,0,1,1,0,0 ,1,1,1,1,0,1,1,0  ,1,1,1,1,1,0,1,0,1, 1,0,1,1,1,1,1,1};
            byte[] mot = new byte[208];

            mot[0] = 0; mot[1] = 0; mot[2] = 1; mot[3] = 0; //Indicateur de mode tjr le meme
            
            int tailleMot = motString.Count();
            string tailleBinaire = Convert.ToString(tailleMot, 2).PadLeft(9, '0');

            for(int i = 0; i < tailleBinaire.Count(); i++) {   //Nombre de caracteres du mot

                if(Convert.ToByte(tailleBinaire[i]) == 48)
                {
                    mot[4 + i] = 0;
                }
                if (Convert.ToByte(tailleBinaire[i]) == 49)
                {
                    mot[4 + i] = 1;
                }
            }

            string[] data = new string[(tailleMot/2)+1];       //Separe le mot en liste de 2 caracteres
            int index2 = 0;

            for(int i = 0; i < tailleMot; i +=2)
            {
                if (i >= tailleMot - 2)
                {
                    data[index2] = motString[i].ToString();
                }
                else
                {
                    data[index2] = motString[i].ToString() + motString[i + 1].ToString();
                    index2++;
                }
            }

            string[] binaryData = new string[(tailleMot / 2) + 1];

            char[] alphanumeric = new char[45] {'0','1','2','3','4','5','6','7','8','9','a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z',' ', '$','%', '*', '+','-','.','/',':'};
            
            for(int i=0;i<binaryData.Count();i++)                         //HE -> 799 -> Binaire
            {
                int data0 = 0; ;
                int data1 = 0; ;
                int intData = 0;
                if (data[i].Count() > 1)
                {
                    for(int j = 0; j < alphanumeric.Count(); j++)
                    {
                        if(alphanumeric[j] == data[i][0])
                        {
                            data0 = j;
                        }
                    }
                    for (int j = 0; j < alphanumeric.Count(); j++)
                    {
                        if (alphanumeric[j] == data[i][1])
                        {
                            data1 = j;
                        }
                    }

                    intData = 45 * data0 + data1;
                    binaryData[i] = Convert.ToString(intData, 2).PadLeft(11, '0');
                }
                else
                {
                        for (int j = 0; j < alphanumeric.Count(); j++)
                        {
                            if (alphanumeric[j] == data[i][0])
                            {
                                data1 = j;
                            }
                        }

                    intData = data1; ;
                    binaryData[i] = Convert.ToString(intData, 2).PadLeft(6, '0');
                }
                //Console.WriteLine(binaryData[i]);
            }


            int index3 = 0;
            for(int i = 0; i < binaryData.Count(); i++)               //On place les valeurs binaires de chaque doublet de lettre dans le mot[]
            {
                for(int j=0; j < binaryData[i].Count(); j++)
                {
                    if (binaryData[i][j] == '0')
                    {
                        mot[j + index3 + 13] = 0;
                    }
                    else
                    {
                        mot[j + index3 + 13] = 1;
                    }
                }

                index3 += binaryData[i].Count();
            }

            for(int i = 74; i < 4; i++)   //Terminaison  0000
            {
                mot[i] = 0;
            }
            for (int i = 78; i < 2; i++)   //Avoir multiple de 8   00
            {
                mot[i] = 0;
            }

            int redNb = ((152 - 80)/8);
            int index4 = 0;// = 9
            char[] rednb1 = new char[8] {'1','1','1','0','1','1','0','0' };
            char[] rednb2 = new char[8] { '0', '0', '0', '1', '0', '0', '0', '1' };

            for (int a = 0; a < redNb; a++)     // Remplir avec les nombres rouges
            {
                for (int i = 0; i < 8; i++)        
                {
                    if (a % 2 == 0)
                    {
                        if (rednb1[i] == '0')
                        {
                            mot[80 + index4 + i] = 0;
                        }
                        else
                        {
                            mot[80 + index4 + i] = 1;
                        }
                    }
                    else
                    {
                        if (rednb2[i] == '0')
                        {
                            mot[80 + index4 + i] = 0;
                        }
                        else
                        {
                            mot[80 + index4 + i] = 1;
                        }
                    }

                    //Console.WriteLine(81 + i + index4);
                }

                index4 += 8;
            }


            char[] c1 = new char[8] { '1', '0', '1', '0', '1', '1', '0', '0' };
            char[] c2 = new char[8] { '0', '0', '0', '1', '0', '0', '0', '1' };
            char[] c3 = new char[8] { '0', '1', '0', '1', '1', '1', '0', '0' };
            char[] c4 = new char[8] { '0', '0', '1', '0', '1', '1', '0', '0' };
            char[] c5 = new char[8] { '1', '1', '1', '1', '0', '1', '1', '0' };
            char[] c6 = new char[8] { '1', '1', '1', '1', '0', '1', '0', '1' };
            char[] c7 = new char[8] { '1', '0', '1', '1', '1', '1', '1', '1' };

            char[][] c = new char[][] { c1, c2, c3, c4, c5, c6, c7 };

            int index5 = 0;
            for(int i = 0; i < 7; i++)      //Ajouter correction d'erreur a la fin
            {
                for (int j = 0; j < 8; j++) {

                    if(c[i][j] == '0')
                    {
                        mot[152 + j + index5] = 0;
                    }
                    else
                    {
                        mot[152 + j + index5] = 1;
                    }
                }

                index5 += 8;
            }


            foreach (byte b in mot) //Tester mot[]
            {
                Console.Write(" " + b);
            }
            Console.WriteLine();
            


            for (int j = matrixByte.GetLength(1)-1; j >0; j-= xValue)      //PLacer les bits sur la mtrice dans le bon ordre
            {
                div_j = j/2;

                if ((div_j) % 2 == 0) //pour modulo et recherche continue
                {
                    for (int i = 0; i < matrixByte.GetLength(0); i++)
                    {
                        if ((j < 9 && i < 8) || (j < 9 && i > 11) || (j > 12 && i > 11) || (i == 14) || (j == 6))
                        {
                            if (j == 6)
                            {
                                xValue = 1;
                            }
                        }
                        else
                        {

                            xValue = 2;
                            Console.WriteLine(i + " " + j);
                            matrixByte[i, j] = mot[index];
                            matrixByte[i, j-1] = mot[index+1];
                            index += 2;
                        }
                    }
                }
                else
                {
                    for (int i = matrixByte.GetLength(0) - 1;i >= 0; i--)
                    {
                        if ((j < 9 && i < 8) || (j < 9 && i > 11) || (j > 12 && i > 11) || (i == 14) || (j == 6))
                        {
                            if (j == 6)
                            {
                                xValue = 1;
                            }
                        }
                        else
                        {
                            xValue = 2;
                            Console.WriteLine(i + " " + j);
                            matrixByte[i, j] = mot[index];
                            matrixByte[i, j-1] = mot[index+1];
                            index += 2;
                        }
                    }
                }
            }


            for (int i = 0; i < matrixByte.GetLength(0); i++)
            {
                for (int j = 0; j < matrixByte.GetLength(1); j++)
                {
                    //BAS GAUCHE

                    matrixByte[0, 0] = 1; matrixByte[0, 1] = 1; matrixByte[0, 2] = 1; matrixByte[0, 3] = 1; matrixByte[0, 4] = 1; matrixByte[0, 5] = 1; matrixByte[0, 6] = 1;
                    matrixByte[0, 0] = 1; matrixByte[1, 0] = 1; matrixByte[2, 0] = 1; matrixByte[3, 0] = 1; matrixByte[4, 0] = 1; matrixByte[5, 0] = 1; matrixByte[6, 0] = 1;
                    matrixByte[0, 6] = 1; matrixByte[1, 6] = 1; matrixByte[2, 6] = 1; matrixByte[3, 6] = 1; matrixByte[4, 6] = 1; matrixByte[5, 6] = 1; matrixByte[6, 6] = 1;
                    matrixByte[6, 0] = 1; matrixByte[6, 1] = 1; matrixByte[6, 2] = 1; matrixByte[6, 3] = 1; matrixByte[6, 4] = 1; matrixByte[6, 5] = 1; matrixByte[6, 6] = 1;

                    matrixByte[1, 1] = 0; matrixByte[1, 2] = 0; matrixByte[1, 3] = 0; matrixByte[1, 4] = 0; matrixByte[1, 5] = 0;
                    matrixByte[5, 1] = 0; matrixByte[5, 2] = 0; matrixByte[5, 3] = 0; matrixByte[5, 4] = 0; matrixByte[5, 5] = 0;
                    matrixByte[1, 1] = 0; matrixByte[2, 1] = 0; matrixByte[3, 1] = 0; matrixByte[4, 1] = 0; matrixByte[5, 1] = 0;
                    matrixByte[1, 5] = 0; matrixByte[2, 5] = 0; matrixByte[3, 5] = 0; matrixByte[4, 5] = 0; matrixByte[5, 5] = 0;

                    matrixByte[0, 7] = 0; matrixByte[1, 7] = 0; matrixByte[2, 7] = 0; matrixByte[3, 7] = 0; matrixByte[4, 7] = 0; matrixByte[5, 7] = 0; matrixByte[6, 7] = 0; matrixByte[7, 7] = 0;
                    matrixByte[7, 0] = 0; matrixByte[7, 1] = 0; matrixByte[7, 2] = 0; matrixByte[7, 3] = 0; matrixByte[7, 4] = 0; matrixByte[7, 5] = 0; matrixByte[7, 6] = 0; matrixByte[7, 7] = 0;

                    matrixByte[2, 2] = 1; matrixByte[3, 2] = 1; matrixByte[4, 2] = 1; matrixByte[2, 3] = 1; matrixByte[3, 3] = 1; matrixByte[4, 3] = 1; matrixByte[2, 4] = 1; matrixByte[3, 4] = 1; matrixByte[4, 4] = 1;

                    //HAUT GAUCHE

                    matrixByte[14, 0] = 1; matrixByte[14, 1] = 1; matrixByte[14, 2] = 1; matrixByte[14, 3] = 1; matrixByte[14, 4] = 1; matrixByte[14, 5] = 1; matrixByte[14, 6] = 1;
                    matrixByte[14, 0] = 1; matrixByte[15, 0] = 1; matrixByte[16, 0] = 1; matrixByte[17, 0] = 1; matrixByte[18, 0] = 1; matrixByte[19, 0] = 1; matrixByte[20, 0] = 1;
                    matrixByte[14, 6] = 1; matrixByte[15, 6] = 1; matrixByte[16, 6] = 1; matrixByte[17, 6] = 1; matrixByte[18, 6] = 1; matrixByte[19, 6] = 1; matrixByte[20, 6] = 1;
                    matrixByte[20, 0] = 1; matrixByte[20, 1] = 1; matrixByte[20, 2] = 1; matrixByte[20, 3] = 1; matrixByte[20, 4] = 1; matrixByte[20, 5] = 1; matrixByte[20, 6] = 1;

                    matrixByte[15, 1] = 0; matrixByte[15, 2] = 0; matrixByte[15, 3] = 0; matrixByte[15, 4] = 0; matrixByte[15, 5] = 0;
                    matrixByte[19, 1] = 0; matrixByte[19, 2] = 0; matrixByte[19, 3] = 0; matrixByte[19, 4] = 0; matrixByte[19, 5] = 0;
                    matrixByte[15, 1] = 0; matrixByte[16, 1] = 0; matrixByte[17, 1] = 0; matrixByte[18, 1] = 0; matrixByte[19, 1] = 0;
                    matrixByte[15, 5] = 0; matrixByte[16, 5] = 0; matrixByte[17, 5] = 0; matrixByte[18, 5] = 0; matrixByte[19, 5] = 0;

                    matrixByte[13, 7] = 0; matrixByte[14, 7] = 0; matrixByte[15, 7] = 0; matrixByte[16, 7] = 0; matrixByte[17, 7] = 0; matrixByte[18, 7] = 0; matrixByte[19, 7] = 0; matrixByte[20, 7] = 0;
                    matrixByte[13, 0] = 0; matrixByte[13, 1] = 0; matrixByte[13, 2] = 0; matrixByte[13, 3] = 0; matrixByte[13, 4] = 0; matrixByte[13, 5] = 0; matrixByte[13, 6] = 0; matrixByte[13, 7] = 0;

                    matrixByte[16, 2] = 1; matrixByte[17, 2] = 1; matrixByte[18, 2] = 1; matrixByte[16, 3] = 1; matrixByte[17, 3] = 1; matrixByte[18, 3] = 1; matrixByte[16, 4] = 1; matrixByte[17, 4] = 1; matrixByte[18, 4] = 1;

                    //HAUT DROITE  (16, 15)

                    matrixByte[14, 14] = 1; matrixByte[14, 15] = 1; matrixByte[14, 16] = 1; matrixByte[14, 17] = 1; matrixByte[14, 18] = 1; matrixByte[14, 19] = 1; matrixByte[14, 20] = 1;
                    matrixByte[14, 14] = 1; matrixByte[15, 14] = 1; matrixByte[16, 14] = 1; matrixByte[17, 14] = 1; matrixByte[18, 14] = 1; matrixByte[19, 14] = 1; matrixByte[20, 14] = 1;
                    matrixByte[14, 20] = 1; matrixByte[15, 20] = 1; matrixByte[16, 20] = 1; matrixByte[17, 20] = 1; matrixByte[18, 20] = 1; matrixByte[19, 20] = 1; matrixByte[20, 20] = 1;
                    matrixByte[20, 14] = 1; matrixByte[20, 15] = 1; matrixByte[20, 16] = 1; matrixByte[20, 17] = 1; matrixByte[20, 18] = 1; matrixByte[20, 19] = 1; matrixByte[20, 20] = 1;

                    matrixByte[15, 15] = 0; matrixByte[15, 16] = 0; matrixByte[15, 17] = 0; matrixByte[15, 18] = 0; matrixByte[15, 19] = 0;
                    matrixByte[19, 15] = 0; matrixByte[19, 16] = 0; matrixByte[19, 17] = 0; matrixByte[19, 18] = 0; matrixByte[19, 19] = 0;
                    matrixByte[15, 15] = 0; matrixByte[16, 15] = 0; matrixByte[17, 15] = 0; matrixByte[18, 15] = 0; matrixByte[19, 15] = 0;
                    matrixByte[15, 19] = 0; matrixByte[16, 19] = 0; matrixByte[17, 19] = 0; matrixByte[18, 19] = 0; matrixByte[19, 19] = 0;

                    matrixByte[13, 7] = 0; matrixByte[14, 7] = 0; matrixByte[15, 7] = 0; matrixByte[16, 7] = 0; matrixByte[17, 7] = 0; matrixByte[18, 7] = 0; matrixByte[19, 7] = 0; matrixByte[20, 7] = 0;
                    matrixByte[13, 0] = 0; matrixByte[13, 1] = 0; matrixByte[13, 2] = 0; matrixByte[13, 3] = 0; matrixByte[13, 4] = 0; matrixByte[13, 5] = 0; matrixByte[13, 6] = 0; matrixByte[13, 7] = 0;

                    matrixByte[13, 13] = 0; matrixByte[14, 13] = 0; matrixByte[15, 13] = 0; matrixByte[16, 13] = 0; matrixByte[17, 13] = 0; matrixByte[18, 13] = 0; matrixByte[19, 13] = 0; matrixByte[20, 13] = 0;
                    matrixByte[13, 13] = 0; matrixByte[13, 14] = 0; matrixByte[13, 15] = 0; matrixByte[13, 16] = 0; matrixByte[13, 17] = 0; matrixByte[13, 18] = 0; matrixByte[13, 19] = 0; matrixByte[13, 20] = 0;

                    matrixByte[16, 16] = 1; matrixByte[17, 16] = 1; matrixByte[18, 16] = 1; matrixByte[16, 17] = 1; matrixByte[17, 17] = 1; matrixByte[18,17] = 1; matrixByte[16, 18] = 1; matrixByte[17, 18] = 1; matrixByte[18, 18] = 1;

                    //PONTS

                    matrixByte[8, 6] = 1; matrixByte[9, 6] = 0; matrixByte[10, 6] = 1; matrixByte[11, 6] = 0; matrixByte[12, 6] = 1;
                    matrixByte[14, 8] = 1; matrixByte[14, 9] = 0; matrixByte[14, 10] = 1; matrixByte[14, 11] = 0; matrixByte[14, 12] = 1;
                    matrixByte[7, 8] = 1;

                    //CODES         1110111 11000100 

                    matrixByte[0, 8] = 1; matrixByte[1, 8] = 1; matrixByte[2, 8] = 1; matrixByte[3, 8] = 0; matrixByte[4, 8] = 1; matrixByte[5, 8] = 1; matrixByte[6, 8] = 1;
                    matrixByte[12, 13] = 1; matrixByte[12, 14] = 1; matrixByte[12, 15] = 0; matrixByte[12, 16] = 0; matrixByte[12, 17] = 0; matrixByte[12, 18] = 1; matrixByte[12, 19] = 0; matrixByte[12, 20] = 0;

                    matrixByte[12, 0] = 1; matrixByte[12, 1] = 1; matrixByte[12, 2] = 1; matrixByte[12, 3] = 0; matrixByte[12, 4] = 1; matrixByte[12, 5] = 1; matrixByte[12, 7] = 1;
                    matrixByte[20, 8] = 0;  matrixByte[19, 8] = 0; matrixByte[18, 8] =1; matrixByte[17, 8] = 0; matrixByte[16, 8] = 0; matrixByte[15, 8] = 0; matrixByte[13, 8] = 1; matrixByte[12, 8] = 1;

                    //Creation

                    if (matrixByte[i, j] == 0)
                    {
                        color = 255;
                    }
                    else if (matrixByte[i, j] == 1)
                    {
                        color = 0;
                    }
                    else if (matrixByte[i, j] == 2)
                    {
                        color = 150;
                    }
                    else if (matrixByte[i, j] == 3)
                    {
                        color = 200;
                    }

                    matrixQRCode[i + indexI + 2, j + indexJ - 2] = new Pixel(new byte[] { color, color, color });
                        matrixQRCode[i + indexI + 2, j + indexJ - 1] = new Pixel(new byte[] { color, color, color });
                        matrixQRCode[i + indexI + 2, j + indexJ] = new Pixel(new byte[] { color, color, color });
                        matrixQRCode[i + indexI + 2, j + indexJ + 1] = new Pixel(new byte[] { color, color, color });
                        matrixQRCode[i + indexI + 2, j + indexJ + 2] = new Pixel(new byte[] { color, color, color });

                        matrixQRCode[i + indexI + 1, j + indexJ - 2] = new Pixel(new byte[] { color, color, color });
                        matrixQRCode[i + indexI + 1, j + indexJ - 1] = new Pixel(new byte[] { color, color, color });
                        matrixQRCode[i + indexI + 1, j + indexJ] = new Pixel(new byte[] { color, color, color });
                        matrixQRCode[i + indexI + 1, j + indexJ + 1] = new Pixel(new byte[] { color, color, color });
                        matrixQRCode[i + indexI + 1, j + indexJ + 2] = new Pixel(new byte[] { color, color, color });

                        matrixQRCode[i + indexI + 0, j + indexJ - 2] = new Pixel(new byte[] { color, color, color });
                        matrixQRCode[i + indexI + 0, j + indexJ - 1] = new Pixel(new byte[] { color, color, color });
                        matrixQRCode[i + indexI + 0, j + indexJ] = new Pixel(new byte[] { color, color, color });
                        matrixQRCode[i + indexI + 0, j + indexJ + 1] = new Pixel(new byte[] { color, color, color });
                        matrixQRCode[i + indexI + 0, j + indexJ + 2] = new Pixel(new byte[] { color, color, color });

                        matrixQRCode[i + indexI - 1, j + indexJ - 2] = new Pixel(new byte[] { color, color, color });
                        matrixQRCode[i + indexI - 1, j + indexJ - 1] = new Pixel(new byte[] { color, color, color });
                        matrixQRCode[i + indexI - 1, j + indexJ] = new Pixel(new byte[] { color, color, color });
                        matrixQRCode[i + indexI - 1, j + indexJ + 1] = new Pixel(new byte[] { color, color, color });
                        matrixQRCode[i + indexI - 1, j + indexJ + 2] = new Pixel(new byte[] { color, color, color });

                        matrixQRCode[i + indexI - 2, j + indexJ - 2] = new Pixel(new byte[] { color, color, color });
                        matrixQRCode[i + indexI - 2, j + indexJ - 1] = new Pixel(new byte[] { color, color, color });
                        matrixQRCode[i + indexI - 2, j + indexJ] = new Pixel(new byte[] { color, color, color });
                        matrixQRCode[i + indexI - 2, j + indexJ + 1] = new Pixel(new byte[] { color, color, color });
                        matrixQRCode[i + indexI - 2, j + indexJ + 2] = new Pixel(new byte[] { color, color, color });
                    

                    indexJ += 4;
                }

                indexJ = 4;
                indexI += 4;
            }


            newTab = CreateVect(matrixQRCode);

            return newTab;
        }



            public Pixel[,] CreateMatrix(Pixel[,] matrix)
        {

            List<Pixel> tabPixel = new List<Pixel>();

            for (int i = (offsetSize + 14); i < tab.Length - 2; i += 3)
            {
                byte[] rgb = new byte[] { tab[i], tab[i + 1], tab[i + 2] };

                Pixel pixel = new Pixel(rgb);
                tabPixel.Add(pixel);
            }

            int pixelIndex = 0;

            for (int a = 0; a < height; a++)
            {
                for (int b = 0; b < width; b++)
                {
                    matrix[a, b] = tabPixel[pixelIndex];
                    pixelIndex++;
                }
            }

            return matrix;
        }


        public byte[] CreateVect(Pixel[,] matrix)
        {
            byte[] newTab = new byte[fileSize];

            for (int i = 0; i < (offsetSize + 14); i++)
            {
                newTab[i] = tab[i];
            }

            int index = 0;

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (matrix[i, j] != null)
                    {

                        newTab[(offsetSize + 14) + index] = matrix[i, j].GetRgb()[0];
                        newTab[(offsetSize + 14) + index + 1] = matrix[i, j].GetRgb()[1];
                        newTab[(offsetSize + 14) + index + 2] = matrix[i, j].GetRgb()[2];

                        index += 3;
                    }
                    else
                    {
                        newTab[(offsetSize + 14) + index] = 255;
                        newTab[(offsetSize + 14) + index + 1] = 255;
                        newTab[(offsetSize + 14) + index + 2] = 255;

                        index += 3;
                    }
                }
            }

            return newTab;
        }
    }
}
