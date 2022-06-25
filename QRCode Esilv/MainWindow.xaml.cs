//Clément_Roure_TdK

using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Drawing;
using System.Numerics;
using System.Text.RegularExpressions;
using System.Net;
using ReedSolomon;


namespace QRCode_Esilv
{

    public partial class MainWindow : Window
    {
        string fileSelected;

        /// <summary>
        /// Initialise la fenetre WPF
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Ouvre l'explorateur de fichiers windows afin de choisir l'image a modifier (affecte valeur a fileSelected)
        /// </summary>
        /// <param name="sender">permet a la fonction d'etre appellé par un boutton en xaml</param>
        /// <param name="e">permet a la fonction d'etre appellé par un boutton en xaml</param>
        private void ChangeImg_Click(object sender, RoutedEventArgs e)
        {

            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Choisissez une Image";
            op.Filter = "Image files (*.bmp)|*.bmp|All files (*.*)|*.*";   //Seul les fichiers de type Bitmap seront affichés dans l'explorateur de fichiers windows

            string CombinedPath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "..\\images");  //Le dossier de selection d'images sera ouvert par default dans le repertoire Debug/images (chemin relatif)
            op.InitialDirectory = System.IO.Path.GetFullPath(CombinedPath);


            if (op.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                fileSelected = op.FileName;
            }
        }

        /// <summary>
        /// 1) Cree une classe MyImage et appelle la fonction choisit par l'utilisateur 2)Ecrit l'image obtenue sur le disque dur et ouvre le dossier contenant la nouvelle image
        /// </summary>
        /// <param name="sender">permet a la fonction d'etre appellé par un boutton en xaml</param>
        /// <param name="e">permet a la fonction d'etre appellé par un boutton en xaml</param>
        private void Button1_Click(object sender, RoutedEventArgs e)
        {

            MyImage myImage = new MyImage(fileSelected, 1);

            byte[] myfile = myImage.GetTab();

            if (myfile != null)
            {
                File.WriteAllBytes("./Images/newImage.bmp", myfile);

                Process.Start("explorer.exe", @"images");
            }

        }
        private void Button2_Click(object sender, RoutedEventArgs e)
        {

            MyImage myImage = new MyImage(fileSelected, 2);

            byte[] myfile = myImage.GetTab();

            if (myfile != null)
            {
                File.WriteAllBytes("./Images/newImage.bmp", myfile);

                Process.Start("explorer.exe", @"images");
            }

        }
        private void Button3_Click(object sender, RoutedEventArgs e)
        {

            MyImage myImage = new MyImage(fileSelected, 3);

            byte[] myfile = myImage.GetTab();

            if (myfile != null)
            {
                File.WriteAllBytes("./Images/newImage.bmp", myfile);

                Process.Start("explorer.exe", @"images");
            }

        }
        private void Button4_Click(object sender, RoutedEventArgs e)
        {

            MyImage myImage = new MyImage(fileSelected, 4);

            byte[] myfile = myImage.GetTab();

            if (myfile != null)
            {
                File.WriteAllBytes("./Images/newImage.bmp", myfile);

                Process.Start("explorer.exe", @"images");
            }

        }
        private void Button5_Click(object sender, RoutedEventArgs e)
        {

            MyImage myImage = new MyImage(fileSelected, 5);

            byte[] myfile = myImage.GetTab();

            if (myfile != null)
            {
                File.WriteAllBytes("./Images/newImage.bmp", myfile);

                Process.Start("explorer.exe", @"images");
            }

        }
        private void Button6_Click(object sender, RoutedEventArgs e)
        {

            MyImage myImage = new MyImage(fileSelected, 6);

            byte[] myfile = myImage.GetTab();

            if (myfile != null)
            {
                File.WriteAllBytes("./Images/newImage.bmp", myfile);

                Process.Start("explorer.exe", @"images");
            }

        }

        /// <summary>
        /// Permet a une TextBox xaml de n'accepter que des caracteres numeriques
        /// </summary>
        /// <param name="sender">permet a la fonction d'etre appellé par un boutton en xaml</param>
        /// <param name="e">permet a la fonction d'etre appellé par un boutton en xaml</param>
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Button7_Click(object sender, RoutedEventArgs e)
        {
            string ratio = Box7.Text;

            if (ratio != "0" && Convert.ToInt32(ratio) <= 20)
            {

                MyImage myImage = new MyImage(fileSelected, 7, ratio);

                byte[] myfile = myImage.GetTab();

                if (myfile != null)
                {
                    File.WriteAllBytes("./Images/newImage.bmp", myfile);

                    Process.Start("explorer.exe", @"images");
                }
            }

            else
            {
                System.Windows.MessageBox.Show("L'image n'a pas été modifiée (valeur saisie nulle ou invalide)", "Attention", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }
        private void Button27_Click(object sender, RoutedEventArgs e)
        {
            string ratio = Box27.Text;

            if (ratio != "0" && Convert.ToInt32(ratio) <= 20)
            {

                MyImage myImage = new MyImage(fileSelected, 27, ratio);

                byte[] myfile = myImage.GetTab();

                if (myfile != null)
                {
                    File.WriteAllBytes("./Images/newImage.bmp", myfile);

                    Process.Start("explorer.exe", @"images");
                }
            }

            else
            {
                System.Windows.MessageBox.Show("L'image n'a pas été modifiée (valeur saisie nulle ou invalide)", "Attention", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }
        private void Button8_Click(object sender, RoutedEventArgs e)
        {
            string angle = Box8.Text;

            if (angle == "90" || angle == "180" || angle == "270" || angle == "360")
            {

                MyImage myImage = new MyImage(fileSelected, 8, angle);

                byte[] myfile = myImage.GetTab();

                if (myfile != null)
                {
                    File.WriteAllBytes("./Images/newImage.bmp", myfile);

                    Process.Start("explorer.exe", @"images");
                }
            }

            else
            {
                System.Windows.MessageBox.Show("L'image n'a pas été modifiée (valeur saisie nulle ou incorrecte)", "Attention", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }
        private void Button9_Click(object sender, RoutedEventArgs e)
        {

            MyImage myImage = new MyImage(fileSelected, 9);

            byte[] myfile = myImage.GetTab();

            if (myfile != null)
            {
                File.WriteAllBytes("./Images/newImage.bmp", myfile);

                Process.Start("explorer.exe", @"images");
            }

        }
        private void Button10_Click(object sender, RoutedEventArgs e)
        {

            MyImage myImage = new MyImage(fileSelected, 10);

            byte[] myfile = myImage.GetTab();

            if (myfile != null)
            {
                File.WriteAllBytes("./Images/newImage.bmp", myfile);

                Process.Start("explorer.exe", @"images");
            }

        }
        private void Button11_Click(object sender, RoutedEventArgs e)
        {
            string text = Box14.Text;

            if (text != "" && text != "0")
            {

                MyImage myImage = new MyImage(fileSelected, 11, text);

                byte[] myfile = myImage.GetTab();

                if (myfile != null)
                {
                    File.WriteAllBytes("./Images/newImage.bmp", myfile);

                    Process.Start("explorer.exe", @"images");
                }
            }

            else
            {
                System.Windows.MessageBox.Show("L'image n'a pas été modifiée (valeur saisie nulle ou incorrecte)", "Attention", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }
        private void Button12_Click(object sender, RoutedEventArgs e)
        {
            string text = Box12.Text;

            if (text.Length <= 15 && text.Length >= 2)
            {

                if (text != "" && text != "0")
                {

                    MyImage myImage = new MyImage(fileSelected, 12, text);  //  "./Images/coco.bmp"

                    byte[] myfile = myImage.GetTab();

                    if (myfile != null)
                    {
                        File.WriteAllBytes("./Images/newImage.bmp", myfile);

                        Process.Start("explorer.exe", @"images");
                    }
                }

                else
                {
                    System.Windows.MessageBox.Show("L'image n'a pas été modifiée (valeur saisie nulle ou incorrecte)", "Attention", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }

            else
            {
                System.Windows.MessageBox.Show("L'image n'a pas été modifiée (nombre de caractère non valide)", "Attention", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Button13_Click(object sender, RoutedEventArgs e)
        {
            string borderSize = Box13.Text;

            if (borderSize != "" && borderSize != "0")
            {

                MyImage myImage = new MyImage(fileSelected, 13, borderSize);  //  "./Images/coco.bmp"

                byte[] myfile = myImage.GetTab();

                if (myfile != null)
                {
                    File.WriteAllBytes("./Images/newImage.bmp", myfile);

                    Process.Start("explorer.exe", @"images");
                }
            }

            else
            {
                System.Windows.MessageBox.Show("L'image n'a pas été modifiée (valeur saisie nulle ou incorrecte)", "Attention", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }


        private void Button15_Click(object sender, RoutedEventArgs e)
        {
            string borderSize = Box15.Text;

            if (borderSize != "" && borderSize != "0")
            {

                MyImage myImage = new MyImage(fileSelected, 15, borderSize);  //  "./Images/coco.bmp"

                byte[] myfile = myImage.GetTab();

                if (myfile != null)
                {
                    //File.WriteAllBytes("./Images/imageCompressée.bmp", myfile);

                    Process.Start("explorer.exe", @"images");
                }
            }

            else
            {
                System.Windows.MessageBox.Show("L'image n'a pas été modifiée (valeur saisie nulle ou incorrecte)", "Attention", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }



    /// <summary>
    /// Chaque objet pixel contient 3 bits: 1 pour le rouge, 1 pour le vert, 1 pour le bleu
    /// </summary>
    public class Pixel
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
            rgb = _rgb;    
        }
    }

    /// <summary>
    /// Classe principale permettant la creation d'une nouvelle image ou la modification de l'image selectionné
    /// </summary>
    public class MyImage
    {

        string imageType;  //.bmp
        int fileSize;
        int offsetSize;    //taille du header
        int width;
        int height;
        int colorNumber;
        byte[] tab;        //La liste de bit definissant une image en incluant son header

        /// <summary>
        /// Initialisation de la nouvelle image
        /// </summary>
        /// <param name="myFile">Chemin d'acces vers l'image selectionné</param>
        /// <param name="input">Choix de l'utilisateur</param>
        /// <param name="textInput">Dans certaines modifications d'image, ce parametre permet d'avoir l'angle ou le mot a encoder</param>
        public MyImage(string myFile, int input, string textInput = "")
        {
            if (myFile == null)
            {
                System.Windows.MessageBox.Show("Aucune image n'a été selectionnée", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {

                tab = File.ReadAllBytes(myFile);   //Tous les bytes constituant une image sont places dans cet array

                //On innitialise les variables dont on aura besoin en les prenant dans le header de l'image puis en les convertissant
                imageType = convertASCII(0);
                fileSize = ExtractInt(2);
                offsetSize = ExtractInt(14);
                width = ExtractInt(18);
                height = ExtractInt(22);
                colorNumber = ExtractInt(28);

                Pixel[,] matrix = new Pixel[height, width];
                matrix = CreateMatrix(matrix);

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
                        matrix = Convolution(matrix, convo1, 9);
                        tab = CreateVect(matrix);
                        break;
                    case 4:
                        int[,] convo2 = new int[,] { { 0, 1, 0 }, { 1, -4, 1 }, { 0, 1, 0 } };   //Detection Contour
                        matrix = Convolution(matrix, convo2, 1);
                        tab = CreateVect(matrix);
                        break;
                    case 5:
                        int[,] convo3 = new int[,] { { 0, -1, 0 },
                                                 {-1, 5, -1 },
                                                 { 0, -1, 0 } };    //Renforcement Bords
                        matrix = Convolution(matrix, convo3, 1);
                        tab = CreateVect(matrix);
                        break;
                    case 6:
                        int[,] convo4 = new int[,] { { -2, -1, 0 }, { -1, 1, 1 }, { 0, 1, 2 } };    //Repoussage
                        matrix = Convolution(matrix, convo4, 1);
                        tab = CreateVect(matrix);
                        break;
                    case 7:

                            int ratio = Convert.ToInt32(textInput);
                            tab = Resize(tab, ratio, height, width, matrix, 1);
                        
                  
                        break;
                    case 27:

                      
                            int ratio2 = Convert.ToInt32(textInput);
                            tab = Resize(tab, ratio2, height, width, matrix, 2);
                     
                        break;
                    case 8:

                   
                            int angle = Convert.ToInt32(Convert.ToInt32(textInput));

                            if (angle == 90) { angle = 2; }
                            if (angle == 180) { angle = 3; }
                            if (angle == 270) { angle = 1; }

                            tab = Rotation(matrix, angle, width, height, tab);
                        
                     
                        break;
                    case 9:

                        tab = Fractal(tab);
                        break;
                    case 10:

                        tab = Histogram(matrix, tab);
                        break;
                    case 11:

                      
                            string motString = textInput;
                            tab = Steganographie(matrix, tab, motString);
                        
  

                        break;
                    case 12:

                     
                            string motString2 = textInput;
                            tab = CreateQRCode(matrix, tab, motString2);
                        
           
                        break;

                    case 13:


                            int borderSize = Convert.ToInt32(textInput);
                            tab = Innovation(matrix, tab, borderSize);
                        

                        break;

                    case 15:
     
                            int quality = Convert.ToInt32(textInput);
                            
                            Compression(quality, myFile);


                        break;

                    default:

                        break;

                }
            }
        }

        /// <summary>
        /// Extrait dans le header le type d'image
        /// </summary>
        /// <param name="index">Position dans le header de l'image</param>
        /// <returns>Retourne un string definissant le type d'image</returns>
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

        /// <summary>
        /// Convertit la valeur Little Endian en Int
        /// </summary>
        /// <param name="index">Position dans le header</param>
        /// <returns>Retourne un int donnant la hauteur ou la largeur...</returns>
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

        /// <summary>
        /// Convertit un int en little endian sur 4 bits
        /// </summary>
        /// <param name="data">int a convertir</param>
        /// <returns>little endian sur 4 bits</returns>
        public byte[] INT2LE(int data)
        {
            byte[] b = new byte[4];
            b[0] = (byte)data;
            b[1] = (byte)(((uint)data >> 8) & 0xFF);
            b[2] = (byte)(((uint)data >> 16) & 0xFF);
            b[3] = (byte)(((uint)data >> 24) & 0xFF);
            return b;
        }

        /// <summary>
        /// Retourne la liste de bit definissant une image
        /// </summary>
        /// <returns>la liste de bit definissant une image</returns>
        public byte[] GetTab()
        {
            return tab;
        }


        /// <summary>
        /// Modifie le rgb de chaque pixel de facon a obtenir une image en noir et blanc
        /// </summary>
        /// <param name="matrix">matrice de pixel</param>
        /// <returns>matrice de pixel en noir et blanc</returns>
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

        /// <summary>
        /// Inverse les pixels a droite et a gauche afin d'obtenir un effet miroir
        /// </summary>
        /// <param name="matrix">Matrice de pixel</param>
        /// <returns>matrice de pixel avec effet miroir</returns>
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

        /// <summary>
        /// Permet d'agrandir ou de retrecir une image selon le facteur entrée. Cree une nouvelle image avec une largeur hauteur et fileSize differente
        /// </summary>
        /// <param name="tab">tableau de bit de l'image de base</param>
        /// <param name="ratio">facteur d'agrandissement/reduction (nombre entier)</param>
        /// <param name="_height">hauteur de l'image de base</param>
        /// <param name="_width">largeur de l'image de base</param>
        /// <param name="matrix">matrice de pixel de l'image de base</param>
        /// <param name="type">Agrandissement ou Retrecissement</param>
        /// <returns>la liste de bits decrivant la meme image mais avec une echelle differente</returns>
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

            int newFileSize = (offsetSize + 14) + (newHeight * newWidth) * 3;
            fileSize = newFileSize;

            Byte[] newTab = new byte[newFileSize];  //Nouveau tableau de bit avec la taille de la nouvelle image

            for (int i = 0; i < (offsetSize + 14); i++) //On copie le header de l'image de base
            {
                newTab[i] = tab[i];
            }

            byte[] fileSizeB = INT2LE(newFileSize);  //Puis on modifie certains parametres (hauteur, largeur, taille de l'image)
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

            if (type == 2) //reduction
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
            else //Agrandissement
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

        /// <summary>
        /// Effectue une rotation de l'image de base (90,180,ou270) et creer une nouvelle image avec les nouvelles dimensions
        /// </summary>
        /// <param name="matrix">matrice de pixel de l'image de base</param>
        /// <param name="angle">angle de rotation</param>
        /// <param name="_width">largeur image de base</param>
        /// <param name="_height">hauteur imgae de base</param>
        /// <param name="tab">tableau de bit de l'image de base</param>
        /// <returns>la liste de bits decrivant la meme image mais avec une rotation differente</returns>
        public byte[] Rotation(Pixel[,] matrix, int angle, int _width, int _height, Byte[] tab)
        {
            int newHeight;
            int newWidth;

            if (angle == 1 || angle == 2) //rotation 90 ou 270 = nouvelles dimensions
            {
                newHeight = (width);
                newWidth = (height);
            }
            else                          //rotation 180 = meme dimensions
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

            if (angle == 1) //90
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
            else if (angle == 2) //270 
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        int newAngle = Convert.ToInt32(Math.PI / 180) * angle;

                        int newX = Convert.ToInt32((matrix.GetLength(0) - i - 1) * Math.Cos(newAngle) - (j) * Math.Sin(newAngle));
                        int newY = Convert.ToInt32((i) * Math.Sin(newAngle) + (matrix.GetLength(1) - j - 1) * Math.Cos(newAngle));

                        matrixRotation[matrix.GetLength(1) - j - 1, i] = matrix[i, j];
                    }

                newTab = CreateVect(matrixRotation);
            }
            else  //180
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        int newAngle = Convert.ToInt32(Math.PI / 180) * angle;

                        int newX = Convert.ToInt32((matrix.GetLength(0) - i - 1) * Math.Cos(newAngle) - (j) * Math.Sin(newAngle));
                        int newY = Convert.ToInt32((i) * Math.Sin(newAngle) + (matrix.GetLength(1) - j - 1) * Math.Cos(newAngle));

                        matrixRotation[i, j] = matrix[newX, newY];
                    }

                newTab = CreateVect(matrixRotation);
            }


            return newTab;
        }


        /// <summary>
        /// Applique un effet sur la matrice de pixel de base (detection de bords, flou...)
        /// </summary>
        /// <param name="matrix">matrice de pixel de depart</param>
        /// <param name="convo">la matrice de convolution</param>
        /// <param name="factor">Pour appliquer certaines matrices, il faut diviser le resultat(flou -> diviser par 9)</param>
        /// <returns>Nouvelle matrice avec l'effet appliqué</returns>
        public Pixel[,] Convolution(Pixel[,] matrix, int[,] convo, int factor)
        {
            Pixel[,] matrixFlou = new Pixel[height, width];


            for (int i = 1; i < matrix.GetLength(0) - 1; i++)
                for (int j = 1; j < matrix.GetLength(1) - 1; j++)
                {
                    int r = 0;
                    int g = 0;
                    int b = 0;

                    for (int x = 0; x < convo.GetLength(0); x++)
                    {
                        for (int y = 0; y < convo.GetLength(1); y++)
                        {
                            r += matrix[i + x - 1, j + y - 1].GetRgb()[0] * convo[x, y];
                            g += matrix[i + x - 1, j + y - 1].GetRgb()[1] * convo[x, y];
                            b += matrix[i + x - 1, j + y - 1].GetRgb()[2] * convo[x, y];

                            //Console.WriteLine(x + " " + y +" | " + (i + x - 1) + " " + (j + y - 1));
                            //Console.WriteLine(convo[x, y] + ": " + x + " " + y);
                        }
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

                    byte _r = Convert.ToByte((r));
                    byte _g = Convert.ToByte((g));
                    byte _b = Convert.ToByte((b));

                    byte[] rgb = new byte[] { _r, _g, _b };

                    matrixFlou[i, j] = new Pixel(rgb);
                    //matrixFlou[i, j].SetRgb(rgb);
                }

            return matrixFlou;
        }

        /// <summary>
        /// Creer un Fractal de Mandelbrot sur une nouvelle image
        /// </summary>
        /// <param name="tab">tableau de bit de l'image selectionné (permet de copier le header puis de le modifier pour la nouvelle image)</param>
        /// <returns></returns>
        public byte[] Fractal(byte[] tab)
        {
            //Dimensions et taille de la nouvelle image
            height = 300;
            width = 400;
            fileSize = height * width * 3 + (offsetSize + 14);

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

            int maxIterations = 100; // Plus on augmente, plus le fractal est detaillé

            Complex Z;
            Complex C;
            int iterations;

            for (int i = 0; i < matrixFractal.GetLength(0); i++)
            {
                for (int j = 0; j < matrixFractal.GetLength(1); j++)
                {
                    iterations = 0;
                    C = new Complex(i, j);
                    Z = new Complex(0, 0);
                    while (Complex.Abs(Z) < 2 && iterations < maxIterations)
                    {
                        Z = Z * Z + C / 500;
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

                        matrixFractal[i, j] = new Pixel(rgb);
                    }
                    else
                    {
                        r = iterations * 255 / maxIterations;
                        g = 0;
                        b = 0;

                        byte _r = Convert.ToByte((r));
                        byte _g = Convert.ToByte((g));
                        byte _b = Convert.ToByte((b));

                        byte[] rgb = new byte[] { _r, _g, _b };

                        matrixFractal[i, j] = new Pixel(rgb);
                    }
                }
            }

            newTab = CreateVect(matrixFractal);

            return newTab;
        }


        /// <summary>
        /// Créer un histogramme de luminosité de l'image selectionné sur une nouvelle image (256 de largeur, basse luminosite a gauche, haute luminosite a droite)
        /// </summary>
        /// <param name="matrix">matrice de pixel de l'image selectionné</param>
        /// <param name="tab">tableau de bit de l'image selectionné</param>
        /// <returns>Le tableau de bit decrivant l'histogramme sur une nouvelle image</returns>
        public byte[] Histogram(Pixel[,] matrix, byte[] tab)
        {
            int initialImageHeight = height;

            fileSize = height * width * 3 + (offsetSize + 14);

            height = (height * width) / 256;
            width = 256;


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

            Pixel[,] matrixHisto = new Pixel[height, width];

            byte[] histo = new byte[width * height];
            int index = 0;

            for (int i = 0; i < matrix.GetLength(1); i++)   //On convertit chaque pixel de l'image de base en niveau de gris puis on les ajoute a un tableau de bit
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    byte r = matrix[j, i].GetRgb()[0];
                    byte g = matrix[j, i].GetRgb()[1];
                    byte b = matrix[j, i].GetRgb()[2];

                    byte _rgb = Convert.ToByte((r * 0.2989 + g * 0.5870 + b * 0.1140));

                    histo[j + index] = _rgb;
                }

                index += initialImageHeight;
            }


            for (int i = 0; i < matrixHisto.GetLength(1); i++)   //Un bit avec un nombre eleve sera place a gauche et un nombre faiblre proche de 0 sera place a droite
            {
                int curentRgbCount = 0;
                foreach (byte b in histo)                        //Plus ils sont nombreux dans le tableau, plus la colonne sur la nouvelle image sera haute (car cette luminosite est tres presente dans l'image)
                {
                    if (i == b)
                    {
                        curentRgbCount++;
                    }
                }


                for (int j = 0; j < matrixHisto.GetLength(0); j++)
                {

                    if (j < curentRgbCount / 8)
                    {
                        matrixHisto[j, i] = new Pixel(new byte[] { 0, 0, 0 });
                    }
                    else
                    {
                        matrixHisto[j, i] = new Pixel(new byte[] { 255, 255, 255 });
                    }
                }
            }

            foreach (byte b in histo)
            {
                // Console.WriteLine(b);
            }

            newTab = CreateVect(matrixHisto);

            return newTab;
        }


        /// <summary>
        /// Creer une image similaire a celle selectionné mais avec moins d'informations
        /// </summary>
        /// <param name="matrix">matrice de pixel de l'image selectionné</param>
        /// <param name="tab">tableau de bit de l'image selectionné</param>
        /// <returns>la liste de bits decrivant la meme image mais avec moins d'informations</returns>
        public byte[] Steganographie(Pixel[,] matrix, byte[] tab, string mot)
        {

            //Encode l'image mais ne décode pas une image encryptée
            //Voir console

            string binary = "";  //conversion du mot en binaire  Verifier: https://www.rapidtables.com/convert/number/ascii-to-binary.html


            for (int i = 0; i < mot.Length; i++)
            {

                string s = ((int)mot[i]).ToString();    //conversion du charactere en nombre ASCII
                                                        //Console.WriteLine(s);

                string binaryC = Convert.ToString(Convert.ToInt32(s), 2).PadLeft(8, '0');  //conversion du nombre ASCII en binaire sur 8 bits
                binary += binaryC;

            }

            Console.WriteLine("binary: " + binary);

            char[] motC = new char[binary.Length];
            for (int i = 0; i < binary.Length; i++)  //on cree une liste de char a partir du mot en binaire
            {
                motC[i] = binary[i];
            }


            Console.WriteLine();


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

                    //On decompose en binaire sur 8bits
                    char[] rc = Convert.ToString(rgb[0], 2).PadLeft(8, '0').ToCharArray();
                    char[] gc = Convert.ToString(rgb[1], 2).PadLeft(8, '0').ToCharArray();
                    char[] bc = Convert.ToString(rgb[2], 2).PadLeft(8, '0').ToCharArray();

                    if (j < motC.Length / 2)
                    {
                        for (int a = 0; a < 8; a++) //On enleve de l'information sur les 2 derniers bits
                        {
                            if (a == 6)
                            {
                                rc[a] = motC[j * 2];
                                gc[a] = motC[j * 2];
                                bc[a] = motC[j * 2];
                            }

                            if (a == 7)
                            {
                                rc[a] = motC[j * 2 + 1];
                                gc[a] = motC[j * 2 + 1];
                                bc[a] = motC[j * 2 + 1];
                            }
                        }
                    }

                    string rBinary = new string(rc);
                    string gBinary = new string(gc);
                    string bBinary = new string(bc);

                    if (i == 0)
                    {
                        Console.WriteLine(rBinary);
                        Console.WriteLine("j: " + j);
                    }

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




        /// <summary>
        /// Creer un cadre decoratif autour de l'image
        /// </summary>
        /// <param name="matrix">La matrice de pixel de l'image choisit</param>
        /// <param name="tab">Le tableau de bytes de l'image choisit</param>
        /// <param name="borderSize">La largeur du bord choisit par l'utilisateur</param>
        /// <returns></returns>
        public byte[] Innovation(Pixel[,] matrix, byte[] tab, int borderSize)
        {

            borderSize = borderSize * 2;
            //On definit les dimensions de la nouvelle image
            height = height + (borderSize * 2) + (width - height);
            width = width + (borderSize * 2);
            fileSize = height * width * 3 + (offsetSize + 14);

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



            //SEPIA
            for (int j = 0; j < matrix.GetLength(0); j++)
            {
                for (int i = 0; i < matrix.GetLength(1); i++)
                {

                    int r = (int)Math.Min(255, matrix[j, i].GetRgb()[0] * 0.393f + matrix[j, i].GetRgb()[1] * 0.769f + matrix[j, i].GetRgb()[2] * 0.189f);
                    int g = (int)Math.Min(255, matrix[j, i].GetRgb()[0] * 0.349f + matrix[j, i].GetRgb()[1] * 0.686f + matrix[j, i].GetRgb()[2] * 0.168f);
                    int b = (int)Math.Min(255, matrix[j, i].GetRgb()[0] * 0.272f + matrix[j, i].GetRgb()[1] * 0.534f + matrix[j, i].GetRgb()[2] * 0.131f);

                    byte _r = Convert.ToByte(r);
                    byte _g = Convert.ToByte(g);
                    byte _b = Convert.ToByte(b);

                    byte[] rgb = new byte[] { _b, _g, _r };

                    matrix[j, i] = new Pixel(rgb);
                }
            }




            Pixel[,] newMatrix = new Pixel[height, width];

            int test = borderSize;
            Random rnd = new Random();

            for (int i = 0; i < newMatrix.GetLength(0); i++)
            {
                for (int j = 0 + test; j < newMatrix.GetLength(1) - test; j++)
                {
                    if (i < matrix.GetLength(0) + borderSize * 2)
                    {
                        //On definit les contours du cadre
                        if ((i < borderSize || i > matrix.GetLength(0) + borderSize - 1 || j < borderSize || j > matrix.GetLength(1) + borderSize - 1))
                        {
                            int _rnd = rnd.Next(0, 2);
                            if (_rnd == 0)
                            {
                                byte[] rgb = { 80, 82, 120 };
                                newMatrix[i, j] = new Pixel(rgb);
                            }
                            else
                            {
                                byte[] rgb = { 45, 82, 160 };
                                newMatrix[i, j] = new Pixel(rgb);
                            }

                        }
                        else
                        {
                            newMatrix[i, j] = matrix[i - borderSize, j - borderSize];
                        }
                    }
                    //On cree les fils auxquels est suspendu le cadre
                    else
                    {
                        if ((j == 80 || j == newMatrix.GetLength(1) - 80) && (i > matrix.GetLength(0) && i < newMatrix.GetLength(1) - 2))
                        {
                            int _rnd = rnd.Next(0, 2);
                            byte[] rgb = { 80, 133, 205 };

                            if (_rnd == 0)
                            {
                                rgb = new byte[] { 70, 123, 195 };
                            }
                            else
                            {
                                rgb = new byte[] { 55, 102, 180 };
                            }


                            newMatrix[i, j - 1] = new Pixel(rgb);
                            newMatrix[i, j] = new Pixel(rgb);
                            newMatrix[i, j + 1] = new Pixel(rgb);
                            newMatrix[i, j - 2] = new Pixel(rgb);
                            newMatrix[i, j + 2] = new Pixel(rgb);



                        }
                        //Le reste de l'image est blanc
                        else
                        {
                            byte[] rgb = { 255, 255, 255 };
                            newMatrix[i, j] = new Pixel(rgb);
                        }
                    }

                }

                if (i >= matrix.GetLength(0) + borderSize)
                {
                    if (test <= borderSize)
                    {
                        test++;
                    }
                }
                else
                {
                    if (test > 0)
                    {
                        test--;
                    }
                }

            }

            newTab = CreateVect(newMatrix);

            return newTab;
        }

        /// <summary>
        /// Convertit une image, en une image compressé de type jpeg
        /// L'utilisateur peut choisir la qualité de compression
        /// </summary>
        public void Compression(long quality, string path)
        {
            // Je n'ai pas réussit à compresser sans bitmap car en utilisant la méthode de compression NLE décrite dans le rapport, la taille du fichier final était toujours égal à la taille du fichier initial

            Bitmap image = new Bitmap(path,true);

            using (var mss = new MemoryStream())
            {
                EncoderParameter qualityParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
                ImageCodecInfo imageCodec = ImageCodecInfo.GetImageEncoders().FirstOrDefault(o => o.FormatID == ImageFormat.Jpeg.Guid);
                EncoderParameters parameters = new EncoderParameters(1);
                
                parameters.Param[0] = qualityParam;
                //image.Save(mss, imageCodec, parameters);

                image.Save("./Images/imageCompressée.jpeg", imageCodec, parameters); //Enregistre l'image compressée avec le codec jpeg et une qualité de compression choisit par l'utilisateur

                //return Image.FromStream(mss);
            }
        }

        /// <summary>
        /// Creer un QR Code ayant pour information le texte entré par l'utilisateur
        /// </summary>
        /// <param name="matrix">matrice de pixel de l'image selectionné</param>
        /// <param name="tab">tableau de bit de l'image selectionné</param>
        /// <param name="motString">Mot a encoder</param>
        /// <returns>Un tabeau de bits de la nouvelle image cree (representant le QR Code)</returns>
        public byte[] CreateQRCode(Pixel[,] matrix, byte[] tab, string motString)
        {

            height = 108;
            width = 108;
            fileSize = height * width * 3 + (offsetSize + 14);

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

            for (int i = 0; i < tailleBinaire.Count(); i++)
            {   //Nombre de caracteres du mot

                if (Convert.ToByte(tailleBinaire[i]) == 48)
                {
                    mot[4 + i] = 0;
                }
                if (Convert.ToByte(tailleBinaire[i]) == 49)
                {
                    mot[4 + i] = 1;
                }
            }

            string[] data = new string[(tailleMot / 2) + 1];       //Separe le mot en liste de 2 caracteres
            int index2 = 0;

            for (int i = 0; i < tailleMot; i += 2)
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

            char[] alphanumeric = new char[45] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', ' ', '$', '%', '*', '+', '-', '.', '/', ':' };

            for (int i = 0; i < binaryData.Count(); i++)                         //HE -> 799 -> Binaire
            {
                int data0 = 0;
                int data1 = 0;
                int intData = 0;
                if (data[i] != null && data[i].Count() > 1)
                {
                    for (int j = 0; j < alphanumeric.Count(); j++)
                    {
                        if (alphanumeric[j] == data[i][0])
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
                        if (data[i] != null && alphanumeric[j] == data[i][0])
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
            for (int i = 0; i < binaryData.Count(); i++)               //On place les valeurs binaires de chaque doublet de lettre dans le mot[]
            {
                for (int j = 0; j < binaryData[i].Count(); j++)
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

            for (int i = 74; i < 4; i++)   //Terminaison  0000
            {
                mot[i] = 0;
            }
            for (int i = 78; i < 2; i++)   //Avoir multiple de 8   00
            {
                mot[i] = 0;
            }

            int redNb = ((152 - 80) / 8);
            int index4 = 0;// = 9
            char[] rednb1 = new char[8] { '1', '1', '1', '0', '1', '1', '0', '0' };
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
            for (int i = 0; i < 7; i++)      //Ajouter correction d'erreur a la fin
            {
                for (int j = 0; j < 8; j++)
                {

                    if (c[i][j] == '0')
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



            for (int j = matrixByte.GetLength(1) - 1; j > 0; j -= xValue)      //PLacer les bits sur la matrice dans le bon ordre
            {
                div_j = j / 2;

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
                            matrixByte[i, j - 1] = mot[index + 1];
                            index += 2;
                        }
                    }
                }
                else
                {
                    for (int i = matrixByte.GetLength(0) - 1; i >= 0; i--)
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
                            matrixByte[i, j - 1] = mot[index + 1];
                            index += 2;
                        }
                    }
                }
            }


            for (int i = 0; i < matrixByte.GetLength(0); i++)    //On initialise les caracteres fixes du QR Codes
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

                    matrixByte[16, 16] = 1; matrixByte[17, 16] = 1; matrixByte[18, 16] = 1; matrixByte[16, 17] = 1; matrixByte[17, 17] = 1; matrixByte[18, 17] = 1; matrixByte[16, 18] = 1; matrixByte[17, 18] = 1; matrixByte[18, 18] = 1;

                    //PONTS

                    matrixByte[8, 6] = 1; matrixByte[9, 6] = 0; matrixByte[10, 6] = 1; matrixByte[11, 6] = 0; matrixByte[12, 6] = 1;
                    matrixByte[14, 8] = 1; matrixByte[14, 9] = 0; matrixByte[14, 10] = 1; matrixByte[14, 11] = 0; matrixByte[14, 12] = 1;
                    matrixByte[7, 8] = 1;

                    //CODES         1110111 11000100 

                    matrixByte[0, 8] = 1; matrixByte[1, 8] = 1; matrixByte[2, 8] = 1; matrixByte[3, 8] = 0; matrixByte[4, 8] = 1; matrixByte[5, 8] = 1; matrixByte[6, 8] = 1;
                    matrixByte[12, 13] = 1; matrixByte[12, 14] = 1; matrixByte[12, 15] = 0; matrixByte[12, 16] = 0; matrixByte[12, 17] = 0; matrixByte[12, 18] = 1; matrixByte[12, 19] = 0; matrixByte[12, 20] = 0;

                    matrixByte[12, 0] = 1; matrixByte[12, 1] = 1; matrixByte[12, 2] = 1; matrixByte[12, 3] = 0; matrixByte[12, 4] = 1; matrixByte[12, 5] = 1; matrixByte[12, 7] = 1;
                    matrixByte[20, 8] = 0; matrixByte[19, 8] = 0; matrixByte[18, 8] = 1; matrixByte[17, 8] = 0; matrixByte[16, 8] = 0; matrixByte[15, 8] = 0; matrixByte[13, 8] = 1; matrixByte[12, 8] = 1;

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


        /// <summary>
        /// Convertit un tableau de bit en matrice de pixel
        /// </summary>
        /// <param name="matrix">La matrice (initialisé avec des valeurs nul) a remplir avec les valeurs contenues dans le tableau de bits</param>
        /// <returns></returns>
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

        /// <summary>
        /// Convertit une matrice de Pixel en tableau de bits
        /// </summary>
        /// <param name="matrix">La matrice a convertir</param>
        /// <returns>Un tableau de bits decrivant la matrice</returns>
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


        /// <summary>
        /// 
        /// </summary>
    }
}
