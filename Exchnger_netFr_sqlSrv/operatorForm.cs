﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exchnger_netFr_sqlSrv
{
    public partial class operatorForm : Form
    {
        public operatorForm()
        {
            InitializeComponent();
            this.Text = User.role + ": " + User.name;
        }
    }
}