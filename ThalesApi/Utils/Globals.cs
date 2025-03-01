namespace ThalesApi.Utils
{
    public class Globals
    {
        public static DateTime SystemDate() => DateTime.UtcNow.AddHours(-5);
    }
}
