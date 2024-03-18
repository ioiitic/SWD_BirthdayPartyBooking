using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Impl
{
    public class AccountRepo : BaseRepo<Account>, IAccountRepo
    {
        private readonly BirthdayPartyBookingContext _context;

        public AccountRepo(BirthdayPartyBookingContext context) : base(context)
        {
            _context = context;
        }

        public List<Account> GetAllActiveHosts()
        {
            try
            {
                return _context.Accounts.AsNoTracking().Where(a => a.Role == 2 && a.DeleteFlag == 0).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving all active hosts: {ex.Message}", ex);
            }
        }

        public async Task<Account> CheckLogin(string Email, string Password)
        {
            try
            {
                return await _context.Accounts.AsNoTracking().FirstOrDefaultAsync(s => s.Email == Email && s.Password == Password && s.DeleteFlag == 0);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error checking login: {ex.Message}", ex);
            }
        }
        public Account GetAccountById(Guid Id)
        {
            try
            {
                return _context.Accounts.AsNoTracking().Where(s => s.Id == Id).SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool CheckEmailExist(string email)
        {
            try
            {
                return _context.Accounts.AsNoTracking().Any(s => s.DeleteFlag == 0 && s.Email == email);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error checking if email exists: {ex.Message}", ex);
            }
        }
        public async Task AddNew(Account account)
        {
           account.DeleteFlag = 0;
           _context.Accounts.Add(account);
           await _context.SaveChangesAsync();   
        }
        public async Task Remove(Guid Id)
        {
            try
            {
                Account _Account = _context.Accounts.Where(a => a.Id == Id).FirstOrDefault();
                if (_Account != null)
                {
                    _Account.DeleteFlag = 1;
                    _context.Entry<Account>(_Account).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("The Account not found.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }

}
