using Harbinger.Models.Connect;

namespace Harbinger.Data
{
    public static partial class Api
    {
        public static ConnectMethodRequest ConnectRequest()
        {
            return DataStore.Instance.ConnectRequest;
        }
    }
}
