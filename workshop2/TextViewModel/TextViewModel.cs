class ViewModel
{
    private string inputText;
    public string outputText { get; private set; }

    public ViewModel(string inputText)
    {
        this.inputText = inputText;
    }

    public void ConvertCommand()
    {
        var converter = new TextConverter();
        this.outputText = converter.ConvertToUpper(this.inputText);
    }
}
