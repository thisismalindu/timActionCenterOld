using Microsoft.Win32;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace timActionCenter
{
    public partial class Form1 : Form
    {

        // FOR ACCENT COLOR STUFF
        //private UserPreferenceChangedEventHandler UserPreferenceChanged; 


        // ROUNDED CORNERS STUFF COPIED FROM MS DOCS
        // The enum flag for DwmSetWindowAttribute's second parameter, which tells the function what attribute to set.
        // Copied from dwmapi.h
        public enum DWMWINDOWATTRIBUTE
        {
            DWMWA_WINDOW_CORNER_PREFERENCE = 33
        }

        // The DWM_WINDOW_CORNER_PREFERENCE enum for DwmSetWindowAttribute's third parameter, which tells the function
        // what value of the enum to set.
        // Copied from dwmapi.h
        public enum DWM_WINDOW_CORNER_PREFERENCE
        {
            DWMWCP_DEFAULT = 0,
            DWMWCP_DONOTROUND = 1,
            DWMWCP_ROUND = 2,
            DWMWCP_ROUNDSMALL = 3
        }

        // Import dwmapi.dll and define DwmSetWindowAttribute in C# corresponding to the native function.
        [DllImport("dwmapi.dll", CharSet = CharSet.Unicode, PreserveSig = false)]
        internal static extern void DwmSetWindowAttribute(IntPtr hwnd,
                                                         DWMWINDOWATTRIBUTE attribute,
                                                         ref DWM_WINDOW_CORNER_PREFERENCE pvAttribute,
                                                         uint cbAttribute);
        // END OF ROUNDED CORNERS STUFF COPIED FROM MS DOCS


        private bool hidden; //TO ANIMATE THE FORM
        private Color themeColor; //ACCENT COLOR

        //Process process; //THE PROCESS THAT RUNS FOR EACH BUTTON CLICK

        public Form1()
        {
            InitializeComponent();
            this.Location = new System.Drawing.Point(Screen.PrimaryScreen.WorkingArea.Width - (this.Width + 10), Screen.PrimaryScreen.Bounds.Height);
            hidden = true;

            // ROUNDED CORNERS STUFF COPIED FROM MS DOCS
            var attribute = DWMWINDOWATTRIBUTE.DWMWA_WINDOW_CORNER_PREFERENCE;
            var preference = DWM_WINDOW_CORNER_PREFERENCE.DWMWCP_ROUND;
            DwmSetWindowAttribute(this.Handle, attribute, ref preference, sizeof(uint));
            // END OF ROUNDED CORNERS STUFF COPIED FROM MS DOCS


            // GET USER'S ACCENT COLOR
            LoadTheme();
            //UserPreferenceChanged = new UserPreferenceChangedEventHandler(SystemEvents_UserPreferenceChanged);
            //SystemEvents.UserPreferenceChanged += UserPreferenceChanged;
            //this.Disposed += new EventHandler(Form_Disposed);

            // END OF ACCENT COLOR 


            // ACRYLIC TRY, ON WHITE BACKGROUNDS IT LOOKS NOT GOOD, SO DISABLED FOR NOW
            //BackColor = Color.FromArgb(55, 55, 55);

            //var accent = new AccentPolicy { AccentState = AccentState.ACCENT_ENABLE_BLURBEHIND };

            //var accentStructSize = Marshal.SizeOf(accent);

            //var accentPtr = Marshal.AllocHGlobal(accentStructSize);
            //Marshal.StructureToPtr(accent, accentPtr, false);

            //var data = new WindowCompositionAttributeData
            //{
            //    Attribute = WindowCompositionAttribute.WCA_ACCENT_POLICY,
            //    SizeOfData = accentStructSize,
            //    Data = accentPtr
            //};

            //User32.SetWindowCompositionAttribute(Handle, ref data);
            //Marshal.FreeHGlobal(accentPtr);
            // END OF ACRYLIC STUFF

        }


        // SETS ACCENT COLOR
        private void LoadTheme()
        {
            themeColor = Color.FromArgb(WinTheme.GetAccentColor().R + 10, WinTheme.GetAccentColor().G + 10, WinTheme.GetAccentColor().B + 10);

        }

        // AN EVENT TO HANDLE THE ACCENT COLOR WHEN USER CHANGES IT IN SYSTEM. BUGGY RIGHT NOW, SO DISABLED FOR NOW.
        //private void SystemEvents_UserPreferenceChanged(object sender, UserPreferenceChangedEventArgs e)
        //{
        //    if (e.Category == UserPreferenceCategory.General || e.Category == UserPreferenceCategory.VisualStyle)
        //    {
        //        LoadTheme();
        //    }
        //}
        //private void Form_Disposed(object sender, EventArgs e)
        //{
        //    SystemEvents.UserPreferenceChanged -= UserPreferenceChanged;
        //}


        // CHANGE BUTTONS COLORS IF CLICKED
        private void btnColorChanger(object sender)
        {
            if (((Button)sender).BackColor == Color.FromArgb(55, 55, 55))
            {


                ((Button)sender).BackColor = themeColor;
                ((Button)sender).FlatAppearance.BorderColor = Color.FromArgb(themeColor.R + 5, themeColor.G + 5, themeColor.B + 5);
                ((Button)sender).FlatAppearance.MouseDownBackColor = Color.FromArgb(themeColor.R + 5, themeColor.G + 5, themeColor.B + 5);
                ((Button)sender).FlatAppearance.MouseOverBackColor = Color.FromArgb(themeColor.R - 10, themeColor.G - 10, themeColor.B - 10);
            }
            else
            {
                ((Button)sender).BackColor = Color.FromArgb(55, 55, 55);
                ((Button)sender).FlatAppearance.BorderColor = Color.FromArgb(60, 60, 60);
                ((Button)sender).FlatAppearance.MouseDownBackColor = Color.FromArgb(60, 60, 60);
                ((Button)sender).FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 50, 50);
            }
        }

        // DO NOT TOUCH THESE - These will handle the button click events and fire the appropriate function found at the end of this file.
        // So please don't change these. You don't need to worry about what's in here. 
        private void button1_Click(object sender, EventArgs e)
        {
            btnColorChanger(sender);
            if (((Button)sender).BackColor == Color.FromArgb(55, 55, 55))
            {
                button1_Logic(0);
            }
            else
            {
                button1_Logic(1);
            }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            btnColorChanger(sender);
            if (((Button)sender).BackColor == Color.FromArgb(55, 55, 55))
            {
                button2_Logic(0);
            }
            else
            {
                button2_Logic(1);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            btnColorChanger(sender);
            if (((Button)sender).BackColor == Color.FromArgb(55, 55, 55))
            {
                button3_Logic(0);
            }
            else
            {
                button3_Logic(1);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            btnColorChanger(sender);
            if (((Button)sender).BackColor == Color.FromArgb(55, 55, 55))
            {
                button4_Logic(0);
            }
            else
            {
                button4_Logic(1);
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            btnColorChanger(sender);
            if (((Button)sender).BackColor == Color.FromArgb(55, 55, 55))
            {
                button5_Logic(0);
            }
            else
            {
                button5_Logic(1);
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            btnColorChanger(sender);
            if (((Button)sender).BackColor == Color.FromArgb(55, 55, 55))
            {
                button6_Logic(0);
            }
            else
            {
                button6_Logic(1);
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            btnColorChanger(sender);
            if (((Button)sender).BackColor == Color.FromArgb(55, 55, 55))
            {
                button7_Logic(0);
            }
            else
            {
                button7_Logic(1);
            }
        }
        private void button8_Click(object sender, EventArgs e)
        {
            btnColorChanger(sender);
            if (((Button)sender).BackColor == Color.FromArgb(55, 55, 55))
            {
                button8_Logic(0);
            }
            else
            {
                button8_Logic(1);
            }
        }
        private void button9_Click(object sender, EventArgs e)
        {
            btnColorChanger(sender);
            if (((Button)sender).BackColor == Color.FromArgb(55, 55, 55))
            {
                button9_Logic(0);
            }
            else
            {
                button9_Logic(1);
            }
        }

        // When Form lost focus
        private void Form1_Deactivate(object sender, EventArgs e)
        {
            hidden = false;
            animationTimer.Start();

        }

        // When Clicked on Tray Icon
        private void notifyIcon_Click(object sender, EventArgs e)
        {
            animationTimer.Start();
            this.Focus();
        }

        // This animates the form's entrance and exit
        private void animationTimer_Tick(object sender, EventArgs e)
        {

            int animationSpeed = 50;

            if (hidden)
            {

                if (this.Top <= (Screen.PrimaryScreen.WorkingArea.Height - (this.Height - 40)))
                {
                    this.Top = Screen.PrimaryScreen.WorkingArea.Height - (this.Height + 10);
                    hidden = false;
                    animationTimer.Stop();
                }
                else
                {
                    this.Top -= animationSpeed;
                }
            }
            else
            {

                if (this.Top >= (Screen.PrimaryScreen.Bounds.Height))
                {
                    this.Top = Screen.PrimaryScreen.Bounds.Height;

                    hidden = true;
                    animationTimer.Stop();
                }
                else
                {
                    this.Top += animationSpeed;
                }
            }
        }


        // ADD BUTTON LOGIC HERE
        private void button1_Logic(int state)
        {

            RegistryKey k = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Default);
            var wr = k.OpenSubKey(@"Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings", true);

            wr.SetValue("ProxyEnable", state, RegistryValueKind.DWord);

        }
        private void button2_Logic(int state)
        {
            // ENABLE DARK/LIGHT THEME
            // Has some quirks.
            // This app is always dark, sucks.
            // Has to restart explorer to make changes to system.

            if (button2.BackColor == Color.FromArgb(55, 55, 55))
            {
                button2.Text = "";
            }
            else
            {
                button2.Text = "";

            }


            [DllImport("user32.dll", SetLastError = true)]
            static extern bool SendNotifyMessage(IntPtr hWnd, uint Msg, UIntPtr wParam, string lParam);

            RegistryKey k = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Default);
            var wr = k.OpenSubKey(@"Software\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize", true);

            wr.SetValue("AppsUseLightTheme", state, RegistryValueKind.DWord);
            wr.SetValue("SystemUsesLightTheme", state, RegistryValueKind.DWord);
            SendNotifyMessage((IntPtr)0xffff /* Broadcast */, 0x031A, (UIntPtr)0, ""); //WM_THEMECHANGED


            // Restart  Explorer - I don't know any other workaround, for now let's just restart Explorer to apply the theme.
            Process.Start("taskkill.exe", "/f /im explorer.exe");
            Thread.Sleep(2000);
            Process.Start("explorer.exe");
            Thread.Sleep(10000);

        }
        private void button3_Logic(int state) { }
        private void button4_Logic(int state) { }
        private void button5_Logic(int state) { }
        private void button6_Logic(int state) { }
        private void button7_Logic(int state) { }
        private void button8_Logic(int state) { }
        private void button9_Logic(int state) { }

        private void restartAppToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}