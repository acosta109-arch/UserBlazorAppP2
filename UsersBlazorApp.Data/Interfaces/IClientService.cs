using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersBlazorApp.Data.Interfaces;

public interface IClientService<T>
{
	Task<List<T>> GetAllAsync();
	Task<T> GetByIdAsync(int id);
	Task<T> AddAsync(T entity);
	Task<bool> UpdateAsync(T entity);
	Task<bool> DeleteAsync(int id);
}
