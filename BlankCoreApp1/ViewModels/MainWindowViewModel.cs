using Module1.Models;
using Module1.Views;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System.Threading.Tasks;

namespace BlankCoreApp1.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public DelegateCommand ShowDialogCommand { get; }

        public MainWindowViewModel(IDialogService dialogService, IEventAggregator eventAggregator)
        {
            this.ShowDialogCommand =
                new DelegateCommand(() =>
                {
                    _ = Task.Run(async () =>
                    {
                        eventAggregator.GetEvent<ProgressMessage>().Publish(0);
                        await Task.Delay(1000);
                        eventAggregator.GetEvent<ProgressMessage>().Publish(33);
                        await Task.Delay(1000);
                        eventAggregator.GetEvent<ProgressMessage>().Publish(66);
                        await Task.Delay(1000);
                        eventAggregator.GetEvent<ProgressMessage>().Publish(100);
                    })
                    .ContinueWith(x => x.Exception /* エラー処理 */, TaskContinuationOptions.OnlyOnFaulted);

                    dialogService.ShowDialog(nameof(ProgressDialog), new DialogParameters(), null);
                });
        }
    }
}
