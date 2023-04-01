using _4;

class Program
{
    static void Main(string[] args)
    {
        Counter Counter = new Counter();
        Handler1 Handler1 = new Handler1();
        Handler2 Handler2 = new Handler2();

        Counter.desiredNumber += Handler1.Message;
        Counter.desiredNumber += Handler2.Message;

        Counter.Count();
    }
}