using System;

class View
{
    private ViewModel viewModel;

    public void Display()
    {
        Console.Write("Input your text: ");
        string input = Console.ReadLine();

        viewModel = new ViewModel(input);
        viewModel.ConvertCommand();

        Console.WriteLine(viewModel.outputText);
        Console.ReadKey();
    }
}
