namespace Searchfight.Utils.Helper
{
    public class GeneralHelpers
    {
        public static bool IsDebug()
        {
#if DEBUG
            return true;
#else
            return false;
#endif
        }
    }
}
