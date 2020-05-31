using Prism.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Module1.Models
{
    public class ProgressMessage : PubSubEvent<int>
    {
    }
}
