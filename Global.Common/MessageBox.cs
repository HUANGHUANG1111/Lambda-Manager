﻿using System.Windows;
using System.Windows.Controls;

namespace Global.Common
{

    //
    // 摘要:
    //     Displays a message box.
    public sealed class MessageBox1
    {
        //icon 的部分建议移除，目前采用了已经淘汰的system.drawing.Common,如果放在其他地方，需要重置图像


        private static MessageBoxResult Initialize(string messageBoxText, string caption ="提示", MessageBoxButton button =MessageBoxButton.OK, MessageBoxImage icon = MessageBoxImage.None, MessageBoxResult defaultResult = MessageBoxResult.None)
        {
            Controls.MessageBox1 messageBox1 = new Controls.MessageBox1(messageBoxText, caption, button, icon, defaultResult);
            messageBox1.ShowDialog();
            return messageBox1.MessageBoxResult;
        }

        public static MessageBoxResult Show(string messageBoxText)
        {
            return Initialize(messageBoxText);
        }

        public static MessageBoxResult Show(string messageBoxText, string caption)
        {
            return Initialize(messageBoxText, caption);
        }

        public static MessageBoxResult Show(string messageBoxText, string caption, MessageBoxButton button)
        {
            return Initialize(messageBoxText, caption, button);
        }

        public static MessageBoxResult Show(string messageBoxText, string caption, MessageBoxButton button, MessageBoxImage icon)
        {
            return Initialize(messageBoxText, caption, button, icon);
            //return MessageBox.Show(messageBoxText, caption, button, icon);
        }

        public static MessageBoxResult Show(string messageBoxText, string caption, MessageBoxButton button, MessageBoxImage icon, MessageBoxResult defaultResult)
        {
            return Initialize(messageBoxText, caption, button, icon, defaultResult);
            //return MessageBox.Show(messageBoxText, caption, button, icon, defaultResult);
        }

        public static MessageBoxResult Show(string messageBoxText, string caption, MessageBoxButton button, MessageBoxImage icon, MessageBoxResult defaultResult, MessageBoxOptions options)
        {
            return MessageBox.Show(messageBoxText, caption, button, icon, defaultResult);
        }

        public static MessageBoxResult Show(Window owner, string messageBoxText)
        {
            return MessageBox.Show(owner, messageBoxText);
        }

        public static MessageBoxResult Show(Window owner, string messageBoxText, string caption)
        {
            return MessageBox.Show(owner, messageBoxText, caption);
        }

        public static MessageBoxResult Show(Window owner, string messageBoxText, string caption, MessageBoxButton button)
        {
            return MessageBox.Show(owner, messageBoxText, caption, button);
        }

        public static MessageBoxResult Show(Window owner, string messageBoxText, string caption, MessageBoxButton button, MessageBoxImage icon)
        {
            return MessageBox.Show(owner, messageBoxText, caption, button, icon);
        }

        public static MessageBoxResult Show(Window owner, string messageBoxText, string caption, MessageBoxButton button, MessageBoxImage icon, MessageBoxResult defaultResult)
        {
            return MessageBox.Show(owner, messageBoxText, caption, button, icon, defaultResult);
        }

        public static MessageBoxResult Show(Window owner, string messageBoxText, string caption, MessageBoxButton button, MessageBoxImage icon, MessageBoxResult defaultResult, MessageBoxOptions options)
        {
            return MessageBox.Show(owner, messageBoxText, caption, button, icon, defaultResult);
        }
    }
}
