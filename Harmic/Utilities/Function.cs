namespace Harmic.Utilities
{
    public class Function
    {
        // ==== Các biến static ====
        public static int _AccountId = 0;
        public static string _Username = string.Empty;
        public static string _Email = string.Empty;
        public static string _Message = string.Empty;
        public static string _MessageEmail = string.Empty;
        // ==========================

        // ==== Hàm kiểm tra login ====
        public static bool IsLogin()
        {
            if (string.IsNullOrEmpty(Function._Username) || Function._AccountId <= 0)
            {
                return false;
            }
            return true;
        }
        // =============================

        public static string TitleSlugGenerationAlias(string title)
        {
            return SlugGenerator.SlugGenerator.GenerateSlug(title);
        }
    }
}
