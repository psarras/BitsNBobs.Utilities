namespace BitsNBobs.Manage
{
    public static class ListManagerExtensions
    {
        public static bool Next<T>(this ListManager<T> listManager, out T value)
        {
            value = default;
            if (listManager.IsMax()) 
                return false;
            listManager.Next();
            value = listManager.Get();
            return true;
        }
        
        public static bool Back<T>(this ListManager<T> listManager, out T value)
        {
            value = default;
            if (listManager.IsMin()) 
                return false;
            listManager.Back();
            value = listManager.Get();
            return true;
        }

        public static bool IsMax<T>(this ListManager<T> listManager)
        {
            return listManager.Index >= listManager.Count - 1;
        }
        
        public static bool IsMin<T>(this ListManager<T> listManager)
        {
            return listManager.Index == 0;
        }
    }
}