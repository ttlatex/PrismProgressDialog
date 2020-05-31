using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Module1.Models
{
    public class ProgressDialogModel : BindableBase
    {
        private int progress;

        public int Progress
        {
            get { return progress; }
            set { SetProperty(ref progress, value); }
        }

        public ProgressDialogModel(IEventAggregator eventAggregator)
        {
            this.Progress = 0;

            eventAggregator
                .GetEvent<ProgressMessage>()
                .Subscribe(x => this.Progress = x);
        }
    }
}
