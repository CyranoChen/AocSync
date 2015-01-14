using System;
using System.Windows.Forms;

namespace AOCSync.ControlPanel
{
    public partial class NumberTextBox : TextBox
    {
        private const int WM_CHAR = 0x0102;

        public NumberTextBox()
        {
            InitializeComponent();
        }

        protected override void OnKeyPress(KeyPressEventArgs e)//屏蔽非数字键
        {
            base.OnKeyPress(e);

            if (this.ReadOnly)//只读,不处理
            {
                return;
            }

            if ((int)e.KeyChar < 32)//特殊键(不含空格32),不处理
            {
                return;
            }

            if (!char.IsDigit(e.KeyChar))//非数字键,放弃该输入
            {
                e.Handled = true;
                return;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)  // 捕获Ctrl+V
        {
            if (keyData == (Keys)Shortcut.CtrlV)  // 快捷键 Ctrl+V 粘贴操作
            {
                string text = Clipboard.GetText();
                for (int k = 0; k < text.Length; k++) // can not use SendKeys.Send
                {
                    // 通过消息模拟键盘输入, SendKeys.Send()静态方法不行
                    SendCharKey(text[k]);
                }
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void SendCharKey(char c)  // 通过消息模拟键盘录入
        {
            Message msg = new Message();

            msg.HWnd = this.Handle;
            msg.Msg = WM_CHAR;  // 输入键盘字符消息 0x0102
            msg.WParam = (IntPtr)c;
            msg.LParam = IntPtr.Zero;

            base.WndProc(ref msg);
        }
    }
}
