
using _22_NguyenThaiThinh_Assignment2.DataAccess;

namespace _22_NguyenThaiThinh_Assignment2.Repository
{
    public class AccountRepository
    {
        public AccountRepository() { }
        public Account GetAccount(string username, string password)
        {
            Account account = null;
            try
            {
                var dbcontext = new Ass2_Prn221_Bl5Context();
                account = dbcontext.Accounts.FirstOrDefault(a => a.Password == password && a.UserName == username);
                if (account == null)
                {
                    throw new Exception("Wrong Account!");
                }
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return account;
        }
    }
}
