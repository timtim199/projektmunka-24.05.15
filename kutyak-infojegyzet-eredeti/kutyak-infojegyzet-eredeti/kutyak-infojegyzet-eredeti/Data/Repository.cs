using kutyak_infojegyzet_eredeti.Data.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace kutyak_infojegyzet_eredeti.Data
{
    internal abstract class Repository<T> where T : IModel, new()
    {
        protected List<T> dataset;
        public virtual string datasetPath => "r";

        public Repository()
        {
            ApplicationWorker.ApplicationReady += ApplicationReady;
        }

        public virtual void ApplicationReady(object sender, EventArgs e)
        {

        }

        internal virtual Task LoadDataset()
        {
            Console.WriteLine(datasetPath);
            dataset = new List<T>();
            if (File.Exists(datasetPath))
            {
                string[] lines = File.ReadAllLines(datasetPath);
                var enumerator = lines.GetEnumerator();
                enumerator.MoveNext();
                int count = 0;
                while (enumerator.MoveNext())
                {
                    try
                    {
                        count++;
                        string line = enumerator.Current.ToString();
                        T data = new T();
                        data = (T)data.Serialize(line);
                        dataset.Add(data);
                    }
                    catch (FormatException)
                    {

                        Console.WriteLine($"[{Path.GetFileName(datasetPath)}] Invali line at: {count};");
                    }

                }
            }
            return Task.CompletedTask;
        }

        public T FindById(uint id)
            => dataset.Where((t) => t.Id == id).First();
    }
}
