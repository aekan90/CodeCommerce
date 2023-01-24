namespace Business.CCC
{
    public class FileLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Dosyaya Loglandı");
        }

        public void Log(string ex)
        {
            Console.WriteLine("Dosyaya Loglandı : " + ex);
        }
    }
}
