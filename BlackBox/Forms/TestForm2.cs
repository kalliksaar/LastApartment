using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace BlackBox.Forms
{
    public partial class TestForm2 : Form
    {
        public TestForm2()
        {
            InitializeComponent();
        }

        public int GetPopulation(TestForm2 form)
        {
            Int32.TryParse(form.PopulationTxtBox.Text, out int population);
            return population;
        }

        public void InsertOverStockValue(TestForm2 form, int value)
        {
            form.OverStockValue.Text = value.ToString();
        }

        private void TestForm2_Load(object sender, EventArgs e)
        {
            CenterToParent();
        }

        #region Unmanaged Methods


        /// <summary>
        /// Determines whether the specified window is enabled for mouse and keyboard input.
        /// </summary>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsWindowEnabled(IntPtr hWnd);


        /// <summary>
        /// Enables or disables mouse and keyboard input to the specified window or control. 
        /// When input is disabled, the window does not receive input such as mouse clicks 
        /// and key presses. When input is enabled, the window receives all input.
        /// </summary>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool EnableWindow(IntPtr hWnd, bool bEnable);


        [Flags]
        private enum SetWindowPosFlags : uint
        {
            SWP_NOMOVE = 0x0002,
            SWP_NOSIZE = 0x0001,
        }


        /// <summary>
        /// Changes the size, position, and Z order of a child, pop-up, or top-level window. 
        /// These windows are ordered according to their appearance on the screen. The 
        /// topmost window receives the highest rank and is the first window in the Z order.
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, SetWindowPosFlags uFlags);

        #endregion

        private void PopolationSliderScroll(object sender, EventArgs e)
        {
            PopulationTxtBox.Text = "" + PopulationSlider.Value;
        }

        private void OkBtn_Click(object sender, EventArgs e)
        {

        }

        private void CalcBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
