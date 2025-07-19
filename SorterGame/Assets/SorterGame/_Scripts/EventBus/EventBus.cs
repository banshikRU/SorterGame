using System;

namespace SorterGame._Scripts.EventBus
{
    public class EventBus
    {
        public event Action OnCorrectDrop;
        public event Action OnWrongDrop;
        public event Action OnMissedFigure;

        public void FigureDroppedCorrectly() => OnCorrectDrop?.Invoke();
        public void FigureDroppedWrongly() => OnWrongDrop?.Invoke();
        public void FigureMissed() => OnMissedFigure?.Invoke();
    }
}