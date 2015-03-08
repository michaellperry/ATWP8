using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlarmingTrafficWP8.Model
{
    // Mexico
    [Table("LocationsMX")]
    public class LocationMX : Location
    {
        private string _Village;
        private string _Postcode;
        private string _Locality;
        private string _Province;


        public string Village
        {
            get { return _Village; }
            set
            {
                if (Set(() => Village, ref _Village, value))
                {
                    IsDirty = true;
                }
            }
        }


        [MaxLength(5)]
        public string Postcode
        {
            get { return _Postcode; }
            set
            {
                if (Set(() => Postcode, ref _Postcode, value))
                {
                    IsDirty = true;
                }
            }
        }



        public string Locality
        {
            get { return _Locality; }
            set
            {
                if (Set(() => Locality, ref _Locality, value))
                {
                    IsDirty = true;
                }
            }
        }


        [MaxLength(5)]
        public string Province
        {
            get { return _Province; }
            set
            {
                if (Set(() => Province, ref _Province, value))
                {
                    IsDirty = true;
                }
            }
        }


        /// <summary>
        /// Create a return string with the whole address
        /// </summary>
        [Ignore]
        public string FullAddress
        {
            get
            {
                return String.Format("{0}, {1}, {2}, {3}, {4}",
                    LocationStreetAddress, Village, Postcode, Locality, Province);
            }

        }


        // Create a copy of an location to save.
        // If your object is databound, this copy is not databound.        
        public LocationMX GetCopy()
        {
            LocationMX copy = (LocationMX)this.MemberwiseClone();
            return copy;
        }
    }
}


/*   
 * 
 * 
Alonso Reyes Diáz	 
Super Manzana 3 – 403	street number and name – apartment no.
Puerto Juarez	village
77520 CANCUN, Q. ROO	postcode + locality name, province abbrev.
MEXICO	 

 Province abbreviations:

AGS = Aguascalientes
BC = Baja California
BCS = Baja California Sur
CAM = Campeche
COAH = Coahuila
COL = Colima
CHIS = Chiapas
CHIH = Chihuahua
DF = Distrito Federal
DGO = Durango
GTO = Guanajuato
GRO = Guerrero
HGO = Hidalgo
JAL = Jalisco
MEX = Mexico
MICH = Michoacan
MOR = Morelos
NAY = Nayarit
NL = Nuevo Leon
OAX = Oaxaca
PUE = Puebla
QRO = Queretaro
Q ROO = Quintana Roo
SLP = San Luis Potosi
SIN = Sinaloa
SON = Sonora
TAB = Tabasco
TAMPS = Tamaulipas
TLAX = Tlaxcala
VER = Veracruz
YUC = Yucatan
ZAC = Zacatecas
 
 */
