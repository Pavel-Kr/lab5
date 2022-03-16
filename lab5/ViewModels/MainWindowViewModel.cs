using System;
using System.Collections.Generic;
using System.Text;
using ReactiveUI;
using System.IO;
using System.Text.RegularExpressions;

namespace lab5.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        string text = "";
        string result = "";
        string pattern = "";
        public string? Path
        {
            set
            {
                if (value != "")
                {
                    Text = File.ReadAllText(value);
                }
            }
        }
        public string Text
        {
            get => text;
            set
            {
                search();
                this.RaiseAndSetIfChanged(ref text, value);
            }
        }
        public string? Savepath
        {
            set
            {
                if (value != "")
                {
                    File.WriteAllText(value, result);
                }
            }
        }
        public string Result
        {
            get => result;
            set => this.RaiseAndSetIfChanged(ref result, value);
        }
        public string Pattern
        {
            get => pattern;
            set
            {
                if (value != "") pattern = value;
                search();
            }
        }
        public void search()
        {
            if (Pattern != "")
            {
                Regex rgx = new Regex(Pattern);
                Result = "";
                foreach (Match match in rgx.Matches(Text))
                {
                    Result += $"{match.Value}\n";
                }
            }
        }
    }
}
