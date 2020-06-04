using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace TemplateMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            ScoringAlgorithm algorithm;
            Console.WriteLine("Men");
            algorithm = new MenScoringAlgorithm();
            Console.WriteLine(algorithm.GenerateScore(10,new TimeSpan(0,2,34)));

            Console.WriteLine("Women");
            algorithm = new WomenScoringAlgorithm();
            Console.WriteLine(algorithm.GenerateScore(10, new TimeSpan(0, 2, 34)));

            Console.WriteLine("Children");
            algorithm = new ChildrenScoringAlgorithm();
            Console.WriteLine(algorithm.GenerateScore(10, new TimeSpan(0, 2, 34)));

            Console.ReadLine();
        }
    }
    abstract class ScoringAlgorithm
    {
        public int GenerateScore(int hits, TimeSpan time)
        {
            int score = CalculateBaseScore(hits);
            int reduction = CalculateReduction(time);
            return CalculateOverAllScore(score, reduction);
        }

        protected abstract int CalculateOverAllScore(int score, int reduction);
        protected abstract int CalculateBaseScore(int hits);
        protected abstract int CalculateReduction(TimeSpan time);
    }

    class MenScoringAlgorithm : ScoringAlgorithm
    {
        protected override int CalculateBaseScore(int hits)
        {
            return hits * 100;
        }

        protected override int CalculateOverAllScore(int score, int reduction)
        {
            return score - reduction;
        }

        protected override int CalculateReduction(TimeSpan time)
        {
            return (int)time.TotalSeconds / 5;
        }
    }
    class WomenScoringAlgorithm : ScoringAlgorithm
    {
        protected override int CalculateBaseScore(int hits)
        {
            return hits * 100;
        }

        protected override int CalculateOverAllScore(int score, int reduction)
        {
            return score - reduction;
        }

        protected override int CalculateReduction(TimeSpan time)
        {
            return (int)time.TotalSeconds / 3;
        }
    }
    class ChildrenScoringAlgorithm : ScoringAlgorithm
    {
        protected override int CalculateBaseScore(int hits)
        {
            return hits * 80;
        }

        protected override int CalculateOverAllScore(int score, int reduction)
        {
            return score - reduction;
        }

        protected override int CalculateReduction(TimeSpan time)
        {
            return (int)time.TotalSeconds / 2;
        }
    }
}
