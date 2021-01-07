using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace Xamboarding.WPF
{
    public class XambAdorner : Adorner
    {
        private readonly VisualCollection _visual;
        private readonly ContentControl _adornerContent;
        private Size _maxConstraint;

        public XambAdorner(UIElement adornedElement, object content, DataTemplateSelector selector) : base(adornedElement)
        {
            _visual = new VisualCollection(this);
            _adornerContent = new ContentControl
            {
                Content = content,
                ContentTemplateSelector = selector
            };
            _visual.Add(_adornerContent);
        }
        protected override Size ArrangeOverride(Size finalSize)
        {
            // arrange conent manually
            _adornerContent.Arrange(new Rect(0, AdornedElement.RenderSize.Height,
                _maxConstraint.Width, _maxConstraint.Height));
            // Return the final size.
            return finalSize;
        }

        protected override Size MeasureOverride(Size constraint)
        {
            _maxConstraint = constraint;
            return base.MeasureOverride(constraint);
        }


        // Override the VisualChildrenCount and GetVisualChild properties to interface with
        // the adorner's visual collection.
        protected override int VisualChildrenCount { get { return _visual.Count; } }
        protected override Visual GetVisualChild(int index) { return _visual[index]; }
        
    }
}
