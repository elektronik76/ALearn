using Avalonia.Controls;
using ReactiveUI;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ANote.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private string? data;
        public string Data
        {
            get => data;
            set => this.RaiseAndSetIfChanged(ref data, value);
        }

        public async Task Open()
        {
            var dialog = new OpenFileDialog();
            string[] result = null;
            dialog.Filters.Add(new FileDialogFilter() { Name = ".txt", Extensions = { "txt" } });
            result = await dialog.ShowAsync(new Window());
            if(result != null)
            {
                Data = File.ReadAllText(result.First());
            }
        }

        public async Task Save()
        {
            var dialog = new SaveFileDialog();
            dialog.Filters.Add(new FileDialogFilter() { Name = ".txt", Extensions = { "txt" } });
            var result = await dialog.ShowAsync(new Window());
            if(result != null)
            {
                File.WriteAllText(result, Data);
            }
        }
    }
}