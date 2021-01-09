using System;
using Prism.Commands;
using Prism.Mvvm;
using Xamboarding.WPF;
using XamboardingDemo.WPF;

namespace OnboardingDemo
{
    public class MainDataContext : BindableBase
    {
        private XambStoryline _demoStoryLine;
        private DemoType _customType;

        public MainDataContext(XambEngine xambEngine)
        {
            XambEngine = xambEngine;
            StartDemo = new DelegateCommand(ExecuteDemo);
            CreateOnboardingStory();
        }

        private async void ExecuteDemo()
        {
            _customType.Count++;
            _customType.Description = Text ?? _customType.Description;
            var storyPlayer = new XambStoryPlayer(XambEngine);
            await storyPlayer.PlayStory(_demoStoryLine);
        }

        private void CreateOnboardingStory()
        {
            // This could be a deserialized object
            _demoStoryLine = new XambStoryline();
            _customType = new DemoType { Count = 0, Description = "This is the custom type. change this text using text field" };
            
            _demoStoryLine.AddStoryFrameAt(0, new XambStoryFrame { Actor = "demo", Content = "Click this button to start Demo", TransitionDelay = TimeSpan.FromSeconds(2) });
            _demoStoryLine.AddStoryFrameAt(1, new XambStoryFrame { Actor = "entry", Content = "This is an entry field to enter some demo text", TransitionDelay = TimeSpan.FromSeconds(4) });
            _demoStoryLine.AddStoryFrameAt(2, new XambStoryFrame { Actor = "end", Content = _customType, TransitionDelay = TimeSpan.FromSeconds(2) });
        }

        public XambEngine XambEngine { get; }
        public DelegateCommand StartDemo { get; }
        private string _text;
        public string Text
        {
            get { return _text; }
            set { SetProperty(ref _text, value); }
        }
    }
}
