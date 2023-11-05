namespace Plot.MiniGame
{
    public interface IMiniGamePlot
    {
        void ExecutePlot();

        bool CheckCompletionCondition();

        void CompletePlot();
    }
}