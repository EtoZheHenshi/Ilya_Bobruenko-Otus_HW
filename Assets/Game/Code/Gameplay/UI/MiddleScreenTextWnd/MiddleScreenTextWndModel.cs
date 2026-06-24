namespace Game.Code.Gameplay.UI.MiddleScreenTextWnd
{
    public sealed class MiddleScreenTextWndModel
    {
        private readonly MiddleScreenTextWndView _view;

        public MiddleScreenTextWndModel(MiddleScreenTextWndView view)
        {
            _view = view;
        }

        public void Show(string text)
        {
            _view.Text.text = text;
            _view.gameObject.SetActive(true);
        }

        public void Hide()
        {
            _view.gameObject.SetActive(false);
        }
    }
}