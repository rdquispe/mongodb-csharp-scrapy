using mongocsharp.Scrapy;

namespace mongocsharp
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            MetalArchives metalArchives = new MetalArchives();
            metalArchives.SaveKingDiamond();
        }
    }
}
