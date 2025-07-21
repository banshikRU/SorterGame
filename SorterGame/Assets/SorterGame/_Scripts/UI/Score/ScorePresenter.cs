using SorterGame._Scripts;
using SorterGame._Scripts.UI;

public class ScorePresenter
{
    private readonly ScoreView _view;

    public ScorePresenter(ScoreView view, GameStatsService model)
    {
        _view = view;
        _view.SetScore(model.Score);

        model.OnScoreChanged += score =>
        {
            _view.SetScore(score);
        };
        
        _view.SetScore(model.Score);
    }
}