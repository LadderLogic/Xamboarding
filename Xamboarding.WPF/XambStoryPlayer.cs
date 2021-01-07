using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

namespace Xamboarding.WPF
{
    public class XambStoryPlayer
    {
        public XambStoryPlayer(XambEngine xambEngine)
        {
            XambEngine = xambEngine;
        }

        public XambEngine XambEngine { get; }

        public async Task PlayStory(XambStoryline story)
        {
            foreach (XambStoryFrame storyFrame in story)
            {
                FrameworkElement actor = XambEngine.GetActor(storyFrame.Actor);
                var adornerLayer = AdornerLayer.GetAdornerLayer(actor);
                var adorner = new XambAdorner(actor, storyFrame.Content, XambEngine.TemplateSelector);
                adornerLayer.Add(adorner);
                await Task.Delay(storyFrame.TransitionDelay);
                adornerLayer.Remove(adorner);
            }
        }
    }
}
