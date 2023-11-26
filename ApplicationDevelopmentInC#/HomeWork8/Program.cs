namespace HomeWork8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "C:\\Users\\admin\\Desktop\\C#TechnologicalSpecialization\\ApplicationDevelopmentInC#\\HomeWorks";
            string extension = "*.txt";
            string text = "Hello";

            FindText findText = new FindText();
            //findText.findTextFromFile(path, extension, text);
            findText.findTextFromFile(args[0], args[1], args[2]);

        }
    }
}
