using System.Data.SqlClient;

namespace Data
{
    public class DAL
    {
        protected SqlConnection Con;
        protected SqlCommand Cmd;
        protected SqlDataReader Dr;
        protected SqlTransaction Tr;
        protected void OpenConnection()
        {
            Con = new SqlConnection("Data Source=34.151.197.105;Initial Catalog=WEB3;Persist Security Info=True;User ID=sqlserver;Password=270298cm");
            Con.Open();
        }
    }
}
