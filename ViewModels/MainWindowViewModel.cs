using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using ReactiveUI;

namespace tutorial.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        string textIn = "";
        string textOut = "";
        string pattern = "";
        string patternStream = "";

        private void UpdateValues()
        {
            TextOut = "";
            foreach (Match match in Regex.Matches(textIn, pattern))
            {
                TextOut += $"{match.Value}\n";
            }
        }

        public string TextIn
        {
            get {
                return textIn;
            }

            set {
                this.RaiseAndSetIfChanged(ref textIn, value);
                UpdateValues();
            }
        }

        public string TextOut
        {
            get {
                return textOut;
            }

            set {
                this.RaiseAndSetIfChanged(ref textOut, value);
            }
        }

        public string Pattern
        {
            get {
                return pattern;
            }

            set {
                pattern = value;
                UpdateValues();
            }
        }

        public string PatternStream
        {
            get {
                return patternStream;
            }

            set {
                patternStream = value;
            }
        }

        string pathIn = "";
        string pathOut = "";

        public string PathIn
        {
            get {
                return pathIn;
            }

            set {
                pathIn = value;
                TextIn = File.ReadAllText(pathIn);
            }
        }

        public string PathOut
        {
            get {
                return pathOut;
            }

            set {
                pathOut = value;
                File.AppendAllText(pathOut, textOut);
            }
        }
    }
}
