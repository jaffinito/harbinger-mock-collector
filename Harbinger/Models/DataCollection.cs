namespace Harbinger.Models
{
    public class DataCollection
    {
        private readonly Dictionary<string, IMergeableData> _data = new();

        public void Merge(string id, IMergeableData collection)
        {
            if(collection == null)
            {
                return;
            }

            if (_data.ContainsKey(id))
            {
                _data[id].Merge(collection);
                return;
            }

            _data.Add(id, collection);
        }

        public IMergeableData GetData(string id)
        {
            return _data[id];
        }

        public T GetData<T>(string id)
        {
            return (T)_data[id];
        }
    }
}
