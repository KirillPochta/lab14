using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab14Serialization
{
    [Serializable]
    public class film
    {
        public film()
        {

        }
        public int release;
        public int times_of_film;

        public filmslb6 strct = new filmslb6();

        public film(string name_of_film, int year_of_release, int times_of_film, int count_of_adverts, parts pr = parts.one)
        {
            strct.name_of_film = name_of_film;
            strct.year_of_release = year_of_release;
            strct.times_of_film = times_of_film;
            strct.count_of_adverts = count_of_adverts;
            strct.pr = pr;
        }
        public film(string name_of_film, int release, int times_of_film, int count_of_adverts, int a)
        {
            strct.name_of_film = name_of_film;
            this.release = release;
            this.times_of_film = times_of_film;
            strct.count_of_adverts = count_of_adverts;
        }
        public override string ToString()
        {
            return $"name  {strct.name_of_film}, release {release}";
        }
    }
}
