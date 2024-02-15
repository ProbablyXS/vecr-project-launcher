public partial class sdfhfdshdfs
{
    public sdfhfdshdfs()
    {
        InitializeComponent();
    }

    private AudioSwitcher.clsIni ini = new AudioSwitcher.clsIni(Environment.CurrentDirectory + @"\data\conf.ini");

    // 'MOUVE FORM WITH MOUSE'
    private bool drag;
    private int mousex;
    private int mousey;
    public object WantApplicationExit = false;
    public int access = 0;

    private void Panel1_MouseDown(object sender, MouseEventArgs e)
    {
        drag = true;
        mousex = Cursor.Position.X - this.Left;
        mousey = Cursor.Position.Y - this.Top;
    }

    private void Panel1_MouseMove(object sender, MouseEventArgs e)
    {
        if (drag)
        {
            this.Top = Cursor.Position.Y - mousey;
            this.Left = Cursor.Position.X - mousex;
        }
    }

    private void Panel1_MouseUp(object sender, MouseEventArgs e)
    {
        drag = false;
    }
    // MOUVE FORM WITH MOUSE'

    private void Button7_MouseEnter(object sender, EventArgs e)
    {
        AudioSwitcher.My.MyProject.Forms.treyrteyu.CleanImage(sender); // Optimization clean backgroundimage from the memory
        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(sender.Name, this.ezrtezrt.Name, false)))
        {
            sender.backgroundimage = AudioSwitcher.My.Resources.Resources.hgjhgj;
        }
    }

    private void Button7_MouseLeave(object sender, EventArgs e)
    {
        AudioSwitcher.My.MyProject.Forms.treyrteyu.CleanImage(sender); // Optimization clean backgroundimage from the memory
        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(sender.Name, this.ezrtezrt.Name, false)))
        {
            sender.backgroundimage = AudioSwitcher.My.Resources.Resources.azetazet;
        }
    }

    private void fdfqsdf_Click(object sender, EventArgs e)
    {
        if (access == 1)
        {
            if ((this.yrjuytrj.Text ?? "") == (AudioSwitcher.My.MyProject.Forms.treyrteyu.read_code ?? ""))
            {
                ini.WriteString("LINK", "START_KEY", this.yrjuytrj.Text);
                AudioSwitcher.My.MyProject.Forms.treyrteyu.locked = false;
                this.Close();
            }
            else
            {
                this.ghjghfkj.Text = "Status: Wrong code";
                this.ghjghfkj.ForeColor = Color.DarkRed;
            }
        }
    }

    private void ezrtezrt_Click(object sender, EventArgs e)
    {
        AudioSwitcher.My.MyProject.Forms.treyrteyu.locked = false;
        this.Close();
    }

    private void Button1_MouseEnter(object sender, EventArgs e)
    {
        sender.ForeColor = Color.FromArgb(255, 128, 0);
    }

    private void Button1_MouseLeave(object sender, EventArgs e)
    {
        sender.ForeColor = Color.WhiteSmoke;
    }

    private void sdfhfdshdfs_Load(object sender, EventArgs e)
    {
        this.Owner = AudioSwitcher.My.MyProject.Forms.treyrteyu;
        this.Owner = AudioSwitcher.My.MyProject.Forms.qsdfqsdf;
        AudioSwitcher.My.MyProject.Forms.treyrteyu.SendToBack();
        AudioSwitcher.My.MyProject.Forms.qsdfqsdf.SendToBack();
        access = 1;
    }

    private void sdfgdfhdh_Click(object sender, EventArgs e)
    {
        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(WantApplicationExit, true, false)))
        {
            Application.Exit();
        }
        else
        {
            Application.Restart();
        }
    }

    private void sdfgdfhdh_MouseEnter(object sender, EventArgs e)
    {
        sender.ForeColor = Color.FromArgb(255, 128, 0);
    }

    private void sdfgdfhdh_MouseLeave(object sender, EventArgs e)
    {
        sender.ForeColor = Color.WhiteSmoke;
    }

    private void sdfhfdshdfs_FormClosing(object sender, FormClosingEventArgs e)
    {
        AudioSwitcher.My.MyProject.Forms.treyrteyu.locked = false;
    }
}
