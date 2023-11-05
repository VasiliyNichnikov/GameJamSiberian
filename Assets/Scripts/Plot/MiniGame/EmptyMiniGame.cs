namespace Plot.MiniGame
{
    public class EmptyMiniGame : IMiniGamePlot
    {
        public void ExecutePlot()
        {
        }

        public bool CheckCompletionCondition()
        {
            return false;
        }

        public void CompletePlot()
        {
        }
    }
}