using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace $rootnamespace$
{
    public interface I$safeitemname$DataService 
    {
        Task Save$safeitemname$($safeitemname$ new$safeitemname$);
        Task<IList<$safeitemname$>> Load$safeitemname$s();
        Task Update$safeitemname$($safeitemname$ selected$safeitemname$);
        Task Delete$safeitemname$($safeitemname$ selected$safeitemname$);
    }
}
