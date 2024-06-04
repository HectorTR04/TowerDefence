using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using TowerDefence.Managers;
using System.Windows.Forms;
using TowerDefence.Base;

namespace TowerDefence
{
    public partial class PauseMenu : Form
    {
        public PauseMenu()
        {
            InitializeComponent();
        }

        private void Resume_Click(object sender, EventArgs e)
        {
            GameManager.Instance.CurrentRuntimeState = GameManager.RuntimeState.Playing;
            Close();
        }

        private void Quit_Click(object sender, EventArgs e)
        {
            GameManager.Instance.Exit = true;
            Close();
        }
    }
}
