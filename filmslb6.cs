using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab14Serialization
{
    public enum parts { one, two, three, four, five, six }
    [Serializable]
    public struct filmslb6
    {
        public string name_of_film;
        public int year_of_release;
        public int times_of_film;
        public int count_of_adverts;
        public parts pr;
    }
}
