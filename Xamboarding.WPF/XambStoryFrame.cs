using System;
using System.Collections.Generic;
using System.Text;

namespace Xamboarding.WPF
{
    public class XambStoryFrame
    {
        public string Actor { get; set; }
        public object Content { get; set; }
        public TimeSpan TransitionDelay { get; set; }
    }
}
