namespace Movies.Infrastructure
{
    public class AppConfig
    {
        /// <summary>
        /// Aes密钥
        /// </summary>
        public string AesKey { get; set; }

        /// <summary>
        /// 数据库链接字符串
        /// </summary>
        public string DbConn { get; set; }

    }
}
