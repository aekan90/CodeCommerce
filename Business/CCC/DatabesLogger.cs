namespace Business.CCC
{
    public class DatabesLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Veritabanına Loglandı");
        }

        public void Log(string exception)
        {
            Console.WriteLine("Databese Loglandı : " + exception);
        }
    }
}
