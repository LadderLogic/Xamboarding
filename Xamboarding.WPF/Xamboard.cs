using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Xamboarding.WPF
{
    public class Xamboard
    {
        private static readonly Dictionary<Window, XambEngine> s_xambEngines = new Dictionary<Window, XambEngine>();

        public static string GetActorName(DependencyObject obj)
        {
            return (string)obj.GetValue(ActorNameProperty);
        }

        public static void SetActorName(DependencyObject obj, string value)
        {
            obj.SetValue(ActorNameProperty, value);

            if (obj is FrameworkElement frameworkElement)
            {
                var window = Window.GetWindow(frameworkElement);
                if (!s_xambEngines.ContainsKey(window))
                {
                    SetXambEngine(window, new XambEngine());
                }
                s_xambEngines[window].AddActor(value, frameworkElement);
            }
        }

        public static readonly DependencyProperty ActorNameProperty =
            DependencyProperty.RegisterAttached("ActorName", typeof(string), typeof(FrameworkElement), new PropertyMetadata(null));




        public static XambEngine GetXambEngine(DependencyObject obj)
        {
            return (XambEngine)obj.GetValue(XambEngineProperty);
        }

        public static void SetXambEngine(DependencyObject obj, XambEngine value)
        {
            obj.SetValue(XambEngineProperty, value);
            if (obj is Window hostWindow)
            {
                s_xambEngines[hostWindow] = value;
            }
        }

        public static readonly DependencyProperty XambEngineProperty =
            DependencyProperty.RegisterAttached("XambEngine", typeof(XambEngine), typeof(Window), new PropertyMetadata(null));

    }
}
