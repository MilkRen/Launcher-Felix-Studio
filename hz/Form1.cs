using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hz
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            //Убираю панель - верх
            this.Text = string.Empty;
            this.ControlBox = false;
            //Указал предел максимального Рабочей площади стола. Чтобы при полном экране, не съедало нижнею панель
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

            costomizeDesing();

            //курсор
            this.Cursor = new Cursor(LoadCursorFromFile("pointer.cur"));

            //Для анимации загрузки
            timer1.Start();
            panelMotherP.BackColor = Color.FromArgb(41, 53, 65);
            
        }

        //выключаю панель выхода
        private void costomizeDesing()
        {
            panelMenuHome.Visible = false;
        }

        //для скрытия меню
        private void HideSubMenu()
        {
            if (panelMenuHome.Visible == true)
                panelMenuHome.Visible = false;


        }
        //для отображения меню
        private void ShowSubMenu(Panel panelTitle)
        {
            if(panelTitle.Visible == false)
            {
                HideSubMenu();
                panelTitle.BackColor = Color.FromArgb(100, 88, 44, 55);
                panelTitle.Visible = true;
            }
            else
            {
                panelTitle.Visible = false;
            }    
        }






        // 1для передвижения окна
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        



        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        
      

        
        private void panelTitle_Paint(object sender, PaintEventArgs e)
        {
            
        }

        //2Передвижение окна, через панель. Вызов MouseDown
        private void panelTitle_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        //2Передвижение окна, через панель. Вызов MouseDown
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);

        }

        //кнопка выхода
        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
            HideSubMenu();
        }

        //Кнопка фулл скрин
        private void buttonMax_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
            HideSubMenu();
        }

        //кнопка сворачивания
        private void buttonMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            HideSubMenu();
        }

        
        private void panelUp_MouseDown(object sender, MouseEventArgs e)
        {

        }

        

        private void panelMenuHome_Paint(object sender, PaintEventArgs e)
        {

        }


        //вызов панели через кнопку
        private void buttonMenuHome_Click(object sender, EventArgs e)
        {
            ShowSubMenu(panelMenuHome);
        }

        //вызов формы
        private Form activeForm = null;
        private void OpenPanelMotherP(Form PanelMather)
        {
            if (activeForm != null)
                activeForm.Close();
            PanelMather.TopLevel = false;
            PanelMather.FormBorderStyle = FormBorderStyle.None;
            PanelMather.Dock = DockStyle.Fill;
            panelMotherP.Controls.Add(PanelMather);
            panelMotherP.Tag = PanelMather;
            PanelMather.BringToFront();
            PanelMather.Show();
        }




        private void panelMotherP_Paint(object sender, PaintEventArgs e)
        {

        }

        //открытие формы
        private void buttonOne_Click(object sender, EventArgs e)
        {
            OpenPanelMotherP(new Forms.Calcul());
            // Forms.Calcul OneBut = new Forms.Calcul();
            // OneBut.Show();
            labelHOME.Text = "Calculator";
        }

        private void buttonGame_Click(object sender, EventArgs e)
        {
            OpenPanelMotherP(new Game());
            labelHOME.Text = "Game";
        }

       //курсор
        [DllImport("User32.dll", CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        private static extern IntPtr LoadCursorFromFile(String str);

        Cursor result = new Cursor(LoadCursorFromFile("pointer.cur"));



        
        //Анимация загрузки!

        private void timer1_Tick(object sender, EventArgs e)
        {
            panelHome.Visible = false;
            panelTitle.Visible = false;

           



            int length = 5;
            for (int time = 0; time <= length; time++)
            {
                if (time == length)
                {
                    
                    panelHome.Visible = true;
                    panelTitle.Visible = true;

                    

                    panelMotherP.BackColor = Color.FromArgb(39, 39, 58);

                    labelLoader.Visible = false;

                    
                    timer1.Stop();
                }

                System.Threading.Thread.Sleep(700);

                

                


            }
            
               
               
            

        }

       
    }
}
