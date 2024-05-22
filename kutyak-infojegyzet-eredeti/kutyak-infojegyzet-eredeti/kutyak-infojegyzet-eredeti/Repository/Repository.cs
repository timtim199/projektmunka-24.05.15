using kutyak_infojegyzet_eredeti.Repository.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kutyak_infojegyzet_eredeti.Repository
{
    internal abstract class Repository<T>  where T : IModel, new()
    {
        List<T> dataset;
        public virtual string datasetPath => "r";

        internal virtual Task LoadDataset()
        {
            Console.WriteLine(datasetPath);
            dataset = new List<T>();
            if(File.Exists(datasetPath))
            {
                string[] lines = File.ReadAllLines(datasetPath);
                lines.GetEnumerator().MoveNext();
                foreach (string line in lines)
                {
                    T data = new T();
                    data = (T)data.Serialize(line);
                    dataset.Add(data);
                }
            }
            return Task.CompletedTask;
        }
    }
}
