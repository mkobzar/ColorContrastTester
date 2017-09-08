using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ColorContrastTester
{
    public partial class Form1 : Form
    {
        private readonly Timer _getColorTimer;
        private Bitmap _sampleBitmap;
        private bool _hasSampled;
        private const int SampleSize = 5;
        private readonly Color[,] _previewColors;
        private Color _sampleColor = Color.Black;

        private Color SampleColor
        {
            get => _sampleColor;
            set
            {
                _sampleColor = value;
                if (_isColor1)
                {
                    color1btn.BackColor = _sampleColor;
                    color2btn.ForeColor = _sampleColor;
                }
                else
                {
                    color1btn.ForeColor = _sampleColor;
                    color2btn.BackColor = _sampleColor;
                }
                BackColor = _sampleColor;
            }
        }

        private bool _isColor1 = true;
        private const int PreviewSize = 200;
        private const int PreviewX = 20;
        private const int PreviewY = 30;
        public const int WmNclbuttondown = 0xA1;
        public const int HtCaption = 0x2;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();


        public Form1()
        {
            InitializeComponent();
            TopMost = true;
            _getColorTimer = new Timer {Interval = 10};
            _getColorTimer.Tick += GetColorTimerTick;
            _previewColors = new Color[PreviewSize, PreviewSize];
        }


        /// <summary>
        /// Populates textboxes with correct color values.
        /// </summary>
        private void TranslateColor()
        {
            if (!_hasSampled)
                return;

            try
            {
                var htmlColor = ColorTranslator.ToHtml(SampleColor).TrimStart('#');
                if (_isColor1)
                    txtColor1.Text = htmlColor;
                else
                    txtColor2.Text = htmlColor;
            }
            catch
            {
                //ignore
            }
        }


        void GetColorTimerTick(object sender, EventArgs e)
        {
            try
            {
                Screen.FromRectangle(new Rectangle(MousePosition.X, MousePosition.Y, 1, 1));
                _sampleBitmap = GetSampleRegion(MousePosition.X, MousePosition.Y);
                var newColor = _sampleBitmap.GetPixel(SampleSize / 2, SampleSize / 2);
                SampleColor = newColor;
                TranslateColor();
                if (BackColor == newColor) Invalidate(new Rectangle(PreviewX, PreviewY, PreviewSize, PreviewSize));
            }
            catch
            {
                // ignore
            }
        }


        /// <summary>
        /// Returns the sample region.
        /// </summary>
        /// <param name="mouseX">Mouse x position.</param>
        /// <param name="mouseY">Mouse y position.</param>
        /// <returns></returns>
        private Bitmap GetSampleRegion(int mouseX, int mouseY)
        {
            var bmp = new Bitmap(SampleSize, SampleSize, PixelFormat.Format32bppArgb);
            var gfxScreenshot = Graphics.FromImage(bmp);
            gfxScreenshot.CopyFromScreen(mouseX - SampleSize / 2, mouseY - SampleSize / 2, 0, 0,
                new Size(SampleSize, SampleSize));
            gfxScreenshot.Save();
            gfxScreenshot.Dispose();
            return bmp;
        }

        private static Color GetContrastColor(Color color)
        {
            var yiq = (color.R * 299 + color.G * 587 + color.B) / 1000;
            return yiq >= 131.5 ? Color.FromArgb(255, 33, 33, 33) : Color.White;
        }

        protected override void
            OnPaint(PaintEventArgs paintEvnt)
        {
            var gfx = paintEvnt.Graphics;
            var pen = new Pen(Color.FromArgb(255, 255, 0, 0), 2);
            const int blockSize = PreviewSize / SampleSize;

            color1btn.FlatAppearance.BorderColor = color2btn.FlatAppearance.BorderColor = GetContrastColor(SampleColor);

            for (var i = 0; i < SampleSize; i++)
            {
                for (var j = 0; j < SampleSize; j++)
                {
                    if (_sampleBitmap != null)
                    {
                        _previewColors[i, j] = _sampleBitmap.GetPixel(i, j);
                    }
                    Brush brush = new SolidBrush(_previewColors[i, j]);
                    gfx.FillRectangle(brush,
                        new Rectangle(PreviewX + i * blockSize, PreviewY + j * blockSize, blockSize, blockSize));

                }
            }

            if (_hasSampled)
            {
                gfx.DrawRectangle(pen, PreviewX + blockSize * (SampleSize / 2), PreviewY + blockSize * (SampleSize / 2),
                    blockSize, blockSize);
            }

            if (_sampleBitmap == null) return;
            _sampleBitmap.Dispose();
            _sampleBitmap = null;
        }


        private void color1btn_MouseDown(object sender, MouseEventArgs e)
        {
            _isColor1 = true;
            _getColorTimer.Start();
            if (!_hasSampled)
            {
                color1btn.BackgroundImage = null;
                _hasSampled = true;
            }
            Cursor = Cursors.Cross;
        }


        private void color2btn_MouseDown(object sender, MouseEventArgs e)
        {
            _isColor1 = false;
            _getColorTimer.Start();
            if (!_hasSampled)
            {
                color2btn.BackgroundImage = null;
                _hasSampled = true;
            }
            Cursor = Cursors.Cross;
        }


        private void color1btn_MouseUp(object sender, MouseEventArgs e)
        {
            color1btn.BackColor = _sampleColor;
            colorbtn_MouseUp();
        }

        private void colorbtn_MouseUp()
        {
            _getColorTimer.Stop();
            Cursor = Cursors.Default;

            if (_sampleBitmap != null)
            {
                _sampleBitmap.Dispose();
                _sampleBitmap = null;
            }
            GC.Collect();
            BackColor = Color.Black;
            if (!string.IsNullOrEmpty(txtColor1.Text) && !string.IsNullOrEmpty(txtColor2.Text))
                txtRatio.Text = GetContrastRatio(txtColor1.Text, txtColor2.Text);
        }

        private void color2btn_MouseUp(object sender, MouseEventArgs e)
        {
            color2btn.BackColor = _sampleColor;
            colorbtn_MouseUp();
        }

        private string GetContrastRatio(string color1, string color2)
        {
            try
            {
                var luminance1 = GetLums(color1);
                var luminance2 = GetLums(color2);
                return Math.Round(
                           (Math.Max(luminance1, luminance2) + 0.05) /
                           (Math.Min(luminance1, luminance2) + 0.05) * 10,
                           1) / 10 + ":1";
            }
            catch
            {
                return "";
            }
        }

        private static double GetLums(string colorHex)
        {
            colorHex = colorHex.TrimStart('#');
            if (string.IsNullOrEmpty(colorHex) || colorHex.Length != 6)
                return Double.NaN;
            var r8Bit = Convert.ToInt32(colorHex.Substring(0, 2), 16);
            var g8Bit = Convert.ToInt32(colorHex.Substring(2, 2), 16);
            var b8Bit = Convert.ToInt32(colorHex.Substring(4, 2), 16);

            var rsRgb = r8Bit / 255.0;
            var gsRgb = g8Bit / 255.0;
            var bsRgb = b8Bit / 255.0;
            // Calculate luminance
            var r = rsRgb <= 0.03928 ? rsRgb / 12.92 : Math.Pow((rsRgb + 0.055) / 1.055, 2.4);
            var g = gsRgb <= 0.03928 ? gsRgb / 12.92 : Math.Pow((gsRgb + 0.055) / 1.055, 2.4);
            var b = bsRgb <= 0.03928 ? bsRgb / 12.92 : Math.Pow((bsRgb + 0.055) / 1.055, 2.4);
            var ret = 0.2126 * r + 0.7152 * g + 0.0722 * b;
            return ret;
        }


        private void Form_MouseDown(MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            ReleaseCapture();
            SendMessage(Handle, WmNclbuttondown, HtCaption, 0);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Form_MouseDown(e);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            Form_MouseDown(e);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            const string tip = "press mouse button here and hover mouse cursor over area of evaluation";
            var toolTip = new ToolTip();
            toolTip.SetToolTip(color1btn, tip);
            toolTip.SetToolTip(color2btn, tip);
        }
    }
}
