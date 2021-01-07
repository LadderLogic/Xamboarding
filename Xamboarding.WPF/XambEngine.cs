using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Xamboarding.WPF
{
    public class XambEngine
    {
        private readonly Dictionary<string, FrameworkElement> _actors;

        public XambEngine()
        {
            _actors = new Dictionary<string, FrameworkElement>();
        }

        public DataTemplateSelector TemplateSelector { get; set; }

        internal FrameworkElement GetActor(string actor)
        {
            return _actors[actor];
        }

        internal void AddActor(string actorName, FrameworkElement frameworkElement)
        {
            _actors[actorName] = frameworkElement;
        }
    }
}
