namespace API_Hospital_Boca.Utilities
{
    public class Utils
    {
        public static bool isTheSame(object obj1,object obj2)
        {
            if (obj1 == null && obj2 == null)
            {
                return true;
            }

            if (obj1 == null || obj2 == null)
            {
                return false;
            }

            return obj1.Equals(obj2);
        }
    }
}