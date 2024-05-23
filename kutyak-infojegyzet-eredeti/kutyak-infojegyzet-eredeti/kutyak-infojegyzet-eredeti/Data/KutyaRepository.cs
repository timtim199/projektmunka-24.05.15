using kutyak_infojegyzet_eredeti.Data.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace kutyak_infojegyzet_eredeti.Data
{
    internal class KutyaRepository : Repository<Kutya>
    {
        public override string datasetPath => "assets/Kutyak.csv";

        public KutyaRepository()
        {
        }

        public override void ApplicationReady(object sender, EventArgs e)
        {
            AverageAge();
            MaxAge();
            GroupByDay(DateTime.Parse("2018.01.10"));
            BusiestDay();
            GenerateNevStatisticsFile();
        }

        // 6. feladat
        void AverageAge()
        {
            decimal average = Math.Round((decimal)dataset.Sum((k) => k.Age) / dataset.Count, 2);
            Console.WriteLine($"[6.feladat] Átlagéletkor: {average}");

        }

        // 7. Felaat
        void MaxAge()
        {
            uint max = dataset.Max((k) => k.Age);
            Kutya kutya = dataset.Find((k) => k.Age >= max);
            Console.WriteLine($"[7.feladat] Legidősebb neve: {kutya.Nev.Nev}; Fajtája: {kutya.Fajta.Nev}");
        }

        // 8. Feladat
        void GroupByDay(DateTime day)
        {

            Console.WriteLine($"[8. Feladat] kutyák száma fajták szerint a renelőben az adott napon ({day})");
            var q = from kutya in dataset where kutya.LastMedicalCheck == day group kutya by kutya.Fajta;
            foreach (IGrouping<KutyaFajta, Kutya> item in q)
            {
                Console.WriteLine($"{item.Key.Nev} : {item.Count()}");
            }
        }

        // 9. Feladat
        void BusiestDay()
        {
            IGrouping<DateTime, Kutya> groupping = (from kutya in dataset group kutya by kutya.LastMedicalCheck).OrderBy(g => g.Count()).Last();
            Console.WriteLine($"[9. feladat] Legforgalmasabb nap: {groupping.Key}; Ellátott kutyák száma: {groupping.Count()}");
        }

        // 10. Feladat
        void GenerateNevStatisticsFile()
        {
            var q = (from kutya in dataset group kutya by kutya.Nev).OrderByDescending(g => g.Count());
            List<NevStatisticsEntry> statisticsEntries = new List<NevStatisticsEntry>();
            foreach (var item in q)
            {
                statisticsEntries.Add(new NevStatisticsEntry(item.Key, item.Count()));
            }

            File.WriteAllText("nevstatisztika.txt", string.Join<NevStatisticsEntry>("\n", statisticsEntries.ToArray()));
            Console.WriteLine($"[10. feladat] Névstatisztika elmentve, nevstatisztika.txt néven.");
        }


    }
}
