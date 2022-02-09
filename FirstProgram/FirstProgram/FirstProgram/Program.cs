// See https://aka.ms/new-console-template for more information


var filePath = "C:\\Users\\sulkowk\\OneDrive - Jacobs\\Documents\\C#\\FirstProgram\\FirstProgram\\FirstProgram\\imiona.txt";
if (File.Exists(filePath))
{
    var fileContent = File.ReadAllText(filePath);
    if (fileContent.Length > 0)
    {
        Console.WriteLine("Imię zapisane to: " + fileContent);
        Console.WriteLine("Czy chcesz usunąć to imię?");
        var userAnswer = Console.ReadLine();
        if (userAnswer == "Tak")
        {
            File.Delete(filePath);
        }
        else
        {
            return;
        }
    }
}
Console.WriteLine("Podaj proszę swoje imię?");
var userAnswer1 = Console.ReadLine();
File.WriteAllText(filePath, userAnswer1);
