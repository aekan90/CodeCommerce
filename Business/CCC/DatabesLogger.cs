namespace Business.CCC
{
    public class DatabesLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Veritabanına Loglandı");
        }

        public void Log(string ex)
        {
            Console.WriteLine("Databese Loglandı : " + ex);
        }
    }
}
