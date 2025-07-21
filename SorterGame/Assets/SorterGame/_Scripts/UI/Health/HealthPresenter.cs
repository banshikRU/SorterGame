namespace SorterGame._Scripts.UI.Health
{
    public class HealthPresenter
    {
        private readonly HealthView _view;
        private readonly EventBus.EventBus _eventBus;
        private int _health;

        public HealthPresenter(HealthView view, GameStatsService service)
        {
            _view = view;
            _view.SetHealth(service.Health);
            service.OnHealthChanged += _view.SetHealth;
            
            _view.SetHealth(service.Health);
        }
    }
}