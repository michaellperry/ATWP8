using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace $rootnamespace$
{
    public class $safeitemname$DataService : I$safeitemname$DataService
    {
        public async Task Save$safeitemname$($safeitemname$ new$safeitemname$)
        {
            await App.Connection.InsertAsync(newTask);
        }

        public async Task<IList<$safeitemname$>> Load$safeitemname$s()
        {
            return await App.Connection.Table<$safeitemname$>().ToListAsync();
        }

        public async Task Update$safeitemname$($safeitemname$ selected$safeitemname$)
        {
            await App.Connection.UpdateAsync(selected$safeitemname$);
        }

        public async Task Delete$safeitemname$($safeitemname$ selected$safeitemname$)
        {
            await App.Connection.DeleteAsync(selected$safeitemname$);
        }

        
    }

    
