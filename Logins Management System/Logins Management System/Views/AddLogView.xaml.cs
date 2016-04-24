using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace LoginsManagementSystem.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddLogView : Page
    {
        public AddLogView()
        {
            this.InitializeComponent();

            // I want this page to be always cached so that we don't have to add logic to save/restore state.
            this.NavigationCacheMode = NavigationCacheMode.Enabled;
        }


        private void BoldButton_Click(object sender, RoutedEventArgs e)
        {
            ITextSelection selectedText = editor.Document.Selection;
            if (selectedText != null)
            {
                ITextCharacterFormat charFormatting = selectedText.CharacterFormat;
                charFormatting.Bold = FormatEffect.Toggle;
                selectedText.CharacterFormat = charFormatting;
            }
        }

        private void ItalicButton_Click(object sender, RoutedEventArgs e)
        {
            ITextSelection selectedText = editor.Document.Selection;
            if (selectedText != null)
            {
                ITextCharacterFormat charFormatting = selectedText.CharacterFormat;
                charFormatting.Italic = FormatEffect.Toggle;
                selectedText.CharacterFormat = charFormatting;
            }
        }

        private void ColorButton_Click(object sender, RoutedEventArgs e)
        {
            Button clickedColor = (Button)sender;

            ITextCharacterFormat charFormatting = editor.Document.Selection.CharacterFormat;
            switch (clickedColor.Name)
            {
                case "black":
                    {
                        charFormatting.ForegroundColor = Colors.Black;
                        break;
                    }

                case "gray":
                    {
                        charFormatting.ForegroundColor = Colors.Gray;
                        break;
                    }

                case "greenyellow":
                    {
                        charFormatting.ForegroundColor = Colors.GreenYellow;
                        break;
                    }

                case "green":
                    {
                        charFormatting.ForegroundColor = Colors.Green;
                        break;
                    }

                case "blue":
                    {
                        charFormatting.ForegroundColor = Colors.Blue;
                        break;
                    }

                case "red":
                    {
                        charFormatting.ForegroundColor = Colors.Red;
                        break;
                    }

                default:
                    {
                        charFormatting.ForegroundColor = Colors.Black;
                        break;
                    }
            }
            editor.Document.Selection.CharacterFormat = charFormatting;

            editor.Focus(Windows.UI.Xaml.FocusState.Keyboard);
            FontColorButton.Flyout.Hide();
        }


    }
}
