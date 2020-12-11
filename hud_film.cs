using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;


namespace lab14Serialization
{   
    [Serializable]
    public class hud_film:film
    {   
        private string main_cherecter;
        public string antogonist;
        public int average_number_of_film;
        public string screenwriter;
        [NonSerialized]
        public string request;

        public string Main_cherecter { get => main_cherecter; set => main_cherecter = value; }

        public hud_film()
        {
        }
        
        public hud_film(string name_of_film, int year_of_release, int times_of_film, int count_of_adverts)
        {
            strct.name_of_film = name_of_film;
            strct.year_of_release = year_of_release;
            strct.times_of_film = times_of_film;
            strct.count_of_adverts = count_of_adverts;

        }
        

        
    }
}
