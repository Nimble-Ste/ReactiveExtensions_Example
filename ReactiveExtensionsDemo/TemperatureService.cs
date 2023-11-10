namespace ReactiveExtensionsDemo
{
    using System.Reactive.Linq;
    using System.Reactive.Subjects;

    public class TemperatureService
    {
        private Subject<int> Temperature { get; } = new();

        public IObservable<int> TemperatureObservable => this.Temperature.AsObservable();

        public TemperatureService()
        {
            Observable
                .Interval(TimeSpan.FromSeconds(1)).StartWith(0).Subscribe(async _ =>
                {
                    var rnd = new Random();
                    Temperature.OnNext(rnd.Next(-20, 30));
                });
        }
    }
}