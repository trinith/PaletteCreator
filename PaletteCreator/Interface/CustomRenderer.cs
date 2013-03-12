using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ArbitraryPixel.Applications.PC.PaletteManager
{
    /// <summary>
    /// Provide custom rendering capabilities.
    /// </summary>
    public sealed class CustomRenderer
    {
        #region Internal Classe(s)
        /// <summary>
        /// Store information about a average colours
        /// </summary>
        internal struct ColorAvg
        {
            public float R;
            public float G;
            public float B;
            public float A;
            public int Count;

            /// <summary>
            /// Add the provided colour to the counters, incrementing the count by the weight.
            /// </summary>
            /// <param name="c">The colour to add.</param>
            /// <param name="weight">The weight of this colour. Defaults to 1.</param>
            public void Add(Color c, int weight = 1)
            {
                R += weight * c.R;
                G += weight * c.G;
                B += weight * c.B;
                A += weight * c.A;
                Count += weight;
            }

            public int AverageAlpha { get { return (int)(this.A / this.Count); } }
            public int AverageRed { get { return (int)(this.R / this.Count); } }
            public int AverageGreen { get { return (int)(this.G / this.Count); } }
            public int AverageBlue { get { return (int)(this.B / this.Count); } }
        }
        #endregion

        #region Delegate(s)
        /// <summary>
        /// Delegate for a method that will draw something.
        /// </summary>
        /// <param name="g">The Graphics objec to draw with.</param>
        /// <param name="bounds">The bounds of the object we are drawing.</param>
        public delegate void Renderer(Graphics g, Rectangle bounds);
        #endregion

        #region Public Properties
        /// <summary>
        /// The method this CustomRenderer object will use to draw.
        /// </summary>
        public Renderer RenderMethod { get; set; }
        #endregion

        #region Constructor(s)
        public CustomRenderer() { }

        public CustomRenderer(Renderer renderMethod)
        {
            RenderMethod = renderMethod;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Draw to the provided graphics object using this object's RenderMethod.
        /// </summary>
        /// <param name="g">The Graphics object to draw with.</param>
        /// <param name="bounds">The bounds of the object to draw.</param>
        public void Draw(Graphics g, Rectangle bounds)
        {
            if (RenderMethod != null)
                RenderMethod(g, bounds);
        }
        #endregion

        #region Public Static Methods
        /// <summary>
        /// Blur the provided image, using the specified parameters.
        /// </summary>
        /// <param name="bitmap">The reference to the bitmap object to blur.</param>
        /// <param name="size">The number of pixels away from any one pixel to process.</param>
        /// <param name="intensity">How much any given pixel should count towards the final weighting. More prominent on images with transparency. Higher numbers will keep the target pixel more in focus.</param>
        public static void AddBlur(ref Bitmap bitmap, int size, int intensity)
        {
            Bitmap blurredImage = new Bitmap(bitmap.Width, bitmap.Height);

            for (int x = 0; x < bitmap.Width; x++)
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    Color c = bitmap.GetPixel(x, y);

                    ColorAvg avg = new ColorAvg();

                    for (
                        int xx = (x > size - 1) ? x - size : x;
                        xx < x + size && xx < bitmap.Width;
                        xx++
                    )
                    {
                        for (
                            int yy = (y > size - 1) ? y - size : y;
                            yy < y + size && yy < bitmap.Height;
                            yy++
                        )
                        {
                            if ((xx == x) && (yy == y))
                                avg.Add(bitmap.GetPixel(xx, yy), intensity);
                            else
                                avg.Add(bitmap.GetPixel(xx, yy));
                        }
                    }

                    blurredImage.SetPixel(x, y, Color.FromArgb(avg.AverageAlpha, avg.AverageRed, avg.AverageGreen, avg.AverageBlue));
                }
            }

            bitmap = blurredImage;
        }

        /// <summary>
        /// Add a glow effect to the provided image.
        /// </summary>
        /// <param name="bitmap">The bitmap to add glow to.</param>
        /// <param name="glowColor">The colour of the glow.</param>
        /// <param name="transparentColor">The colour that defines which pixels are considered transparent.</param>
        /// <param name="size">The number of pixels away from any one pixel to process.</param>
        /// <param name="intensity">A weighting on any one pixel. Setting this higher will make the original pixel more prominent.</param>
        /// <param name="maintainSource">Whether or not the glow should appear over top of the original image, or only on the transparent parts of the image.</param>
        public static void AddGlow(ref Bitmap bitmap, Color glowColor, Color transparentColor, int size, int intensity, bool maintainSource = false)
        {
            Bitmap glowLayer = new Bitmap(bitmap.Width, bitmap.Height);

            for (int x = 0; x < bitmap.Width; x++)
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    Color c = bitmap.GetPixel(x, y);

                    if (!maintainSource || (maintainSource && c == transparentColor))
                    {
                        ColorAvg avg = new ColorAvg();

                        for (
                            int xx = (x > size - 1) ? x - size : x;
                            xx < x + size && xx < bitmap.Width;
                            xx++
                        )
                        {
                            for (
                                int yy = (y > size - 1) ? y - size : y;
                                yy < y + size && yy < bitmap.Height;
                                yy++
                            )
                            {
                                Color c2 = bitmap.GetPixel(xx, yy);

                                if (c2 != transparentColor)
                                    avg.Add(c2, intensity);
                                else
                                    avg.Add(c2);
                            }
                        }

                        glowLayer.SetPixel(x, y, Color.FromArgb(avg.AverageAlpha, glowColor.R, glowColor.G, glowColor.B));
                    }
                }
            }

            Graphics g = Graphics.FromImage(bitmap);
            g.DrawImage(glowLayer, 0, 0);
        }
        #endregion
    }
}
