using Module1.Models;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module1.ViewModels
{
    public class ProgressDialogViewModel : BindableBase, IDialogAware
    {
        private int progress;

        public event Action<IDialogResult> RequestClose;

        public int Progress
        {
            get { return progress; }
            set { SetProperty(ref progress, value); }
        }

        public DelegateCommand CloseCommand { get; }

        public string Title => "Dialog1";

        public ProgressDialogViewModel(ProgressDialogModel model)
        {
            this.Progress = model.Progress;

            model.PropertyChanged += (_, e) =>
            {
                if (e.PropertyName == "Progress")
                {
                    this.Progress = model.Progress;
                }
            };

            this.CloseCommand =
                new DelegateCommand
                (
                    () => this.CloseDialog(),
                    () => this.Progress >= 100
                )
                .ObservesProperty(() => this.Progress);
        }

        public bool CanCloseDialog() => true;

        public void OnDialogClosed() => this.Progress = 0;

        public void OnDialogOpened(IDialogParameters parameters) { }

        private void CloseDialog()
            => RequestClose?.Invoke(new DialogResult(ButtonResult.OK));
    }
}
