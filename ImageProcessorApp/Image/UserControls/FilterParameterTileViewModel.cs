using ImageProcessingApp.Image.Filters;
using ReactiveUI;
using System;

namespace ImageProcessingApp.Image.UserControls
{
    public class FilterParameterTileViewModel : ReactiveObject
    {
        public FilterParameterTileViewModel(ImageFilterParam p)
        {
            Name = p.Name;
            Min = p.Min;
            Max = p.Max;
            Default = p.Default;
            Step = p.Step;
            Value = p.Default;

            Increase = ReactiveCommand.Create();
            Increase.Subscribe(_ =>
            {
                if(Value + Step < Max)
                Value += Step;
            });

            Decrease = ReactiveCommand.Create();
            Decrease.Subscribe(_ =>
            {
                if(Value - Step > Min)
                {
                    Value -= Step;
                }
            });
        }

        public string Name { get; private set; }
        public double Min { get; private set; }
        public double Max { get; private set; }
        public double Default { get; set; }
        public double Step { get; private set; }

        public ReactiveCommand<object> Increase { get; private set; }
        public ReactiveCommand<object> Decrease { get; private set; }

        private double _Value;
        public double Value
        {
            get { return _Value; }
            set { this.RaiseAndSetIfChanged(ref _Value, value); }
        }
    }
}
