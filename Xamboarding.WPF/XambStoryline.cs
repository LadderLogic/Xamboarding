using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace Xamboarding.WPF
{
    public class XambStoryline : IEnumerable<XambStoryFrame>
    {
        private readonly Dictionary<int, XambStoryFrame> _storyLine;

        public XambStoryline()
        {
            _storyLine = new Dictionary<int, XambStoryFrame>();
        }

        public void AddStoryFrameAt(int storyIndex, XambStoryFrame storyFrame)
        {
            _storyLine[storyIndex] = storyFrame;
        }

        public IEnumerator<XambStoryFrame> GetEnumerator()
        {
            return _storyLine.ToImmutableSortedDictionary().Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _storyLine.ToImmutableSortedDictionary().Values.GetEnumerator();
        }
    }
}
