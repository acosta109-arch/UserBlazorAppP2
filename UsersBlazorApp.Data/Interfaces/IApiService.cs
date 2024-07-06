using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersBlazorApp.Data.Interfaces;

public interface IApiService<T>
{
	Task<List<T>> GetAllAsync();
	Task<T> GetByIdAsync(int id);
	Task<T> AddAsync(T user);
	Task<bool> UpdateAsync(T user);
	Task<bool> DeleteAsync(int id);
}
