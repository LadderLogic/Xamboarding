// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Xamboarding.WPF;

namespace XamboardingDemo.WPF
{
    public class DemoOnboardinTemplateSelector : DataTemplateSelector
    {
        public DataTemplate DemoTypeTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if(item is DemoType)
            {
                return DemoTypeTemplate;
            }
            return base.SelectTemplate(item, container);
        }
    }

    public class DemoType
    {
        public int Count { get; set; }

        public string Description { get; set; }
    }
}
