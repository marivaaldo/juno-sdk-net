using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juno.Sdk.Services
{
    public abstract class AbstractService
    {
        protected JunoClient Client { get; }

        public AbstractService(JunoClient client)
        {
            Client = client;
        }
    }
}
