using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportClips.DAL
{
    public interface ISportClipsDAL
    {
        IList<Store> GetAllStores();
        int AddRequestOffToDb(RequestOff request);
        IList<RequestOff> GetAllRequests();
    }
}
