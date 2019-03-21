using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;
using Plugin.FileUploader;
using Plugin.FileUploader.Abstractions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Media;
using Xamarin.Forms.ImagePicker;
using System.IO;
using Plugin.Media.Abstractions;
using System.Net.Http.Headers;
using SocialBusinessApp.Services;
using Xamarin.Forms.Internals;
using SkiaSharp;
using SocialBusinessApp.ViewModels;
using SocialBusinessApp.Models;

namespace SocialBusinessApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Listado : ContentPage
    {
        private List<City> Ciudades;

        public List<City> GetCities(string param)
        {
            var cities = new List<City>()
            {
                new City(){Key = 1, Value = "Vacio" },
                new City(){Key = 2, Value = "otro Vacio" }
            };
            if (param == "Antioquia")
            {
                cities = new List<City>()
                {
                    new City(){Key = 1, Value = "Medellin"},
                    new City(){Key = 2, Value = "Pereira"},
                    new City(){Key = 3, Value = "Antioquia"}
                };
            }
            else
            {
                cities = new List<City>()
                {
                    new City(){Key = 1, Value = "Tunja"},
                    new City(){Key = 2, Value = "Tota"},
                    new City(){Key = 3, Value = "Boyacá"}
                };
            }
            return cities;
        }


        

        private static HttpClient client = new HttpClient();
        Respuesta Rta;
        IImagePickerService _imagePickerService;

        private ImageSource Origen1, Origen2, Origen3, Origen4, Origen5;

        List<string> _images = new List<string>();

        Queue<string> paths = new Queue<string>();
        string filePath = string.Empty;
        bool isBusy = false;
        private List<Ciudad> Antioquia = new List<Ciudad>();


        public Listado ()
		{
            //NavigationPage.SetHasNavigationBar(this, false);
            _imagePickerService = DependencyService.Get<IImagePickerService>();
            InitializeComponent ();
            btnPublicar.Clicked += (sender, e) => BtnPublicarClick();

            BindingContext = new PickerVM();

            
                /*
                Antioquia.Add("Pereira");
                Antioquia.Add("Baboon");*/

        }
        void DepartamentoSelect(object sender, EventArgs args)
        {
            Picker modePicker = (Picker)sender;
            int mode = modePicker.SelectedIndex;
            txtCiudad.Items.Clear();
            txtCiudad.IsEnabled = true;
            switch (mode)
            {
                case 0://AMAZONAS                        
                    txtCiudad.Items.Add("LETICIA");
                    txtCiudad.Items.Add("EL ENCANTO");
                    txtCiudad.Items.Add("LA CHORRERA");
                    txtCiudad.Items.Add("LA PEDRERA");
                    txtCiudad.Items.Add("MIRITI - PARANA");
                    txtCiudad.Items.Add("PUERTO ALEGRIA");
                    txtCiudad.Items.Add("PUERTO ARICA");
                    txtCiudad.Items.Add("PUERTO NARIÑO");
                    break;
                case 1://ANTIOQUIA
                    txtCiudad.Items.Add("ABEJORRAL");
                    txtCiudad.Items.Add("ABRIAQUI");
                    txtCiudad.Items.Add("ALEJANDRIA");
                    txtCiudad.Items.Add("AMAGA");
                    txtCiudad.Items.Add("AMALFI");
                    txtCiudad.Items.Add("ANDES");
                    txtCiudad.Items.Add("ANGELOPOLIS");
                    txtCiudad.Items.Add("ANGOSTURA");
                    txtCiudad.Items.Add("ANORI");
                    txtCiudad.Items.Add("SANTAFE DE ANTIOQUIA");
                    txtCiudad.Items.Add("ANZA");
                    txtCiudad.Items.Add("APARTADO");
                    txtCiudad.Items.Add("ARBOLETES");
                    txtCiudad.Items.Add("ARGELIA");
                    txtCiudad.Items.Add("BARBOSA");
                    txtCiudad.Items.Add("BELMIRA");
                    txtCiudad.Items.Add("BETANIA");
                    txtCiudad.Items.Add("BETULIA");
                    txtCiudad.Items.Add("CIUDAD BOLIVAR");
                    txtCiudad.Items.Add("BRICEÑO");
                    txtCiudad.Items.Add("BURITICA");
                    txtCiudad.Items.Add("CACERES");
                    txtCiudad.Items.Add("CAICEDO");
                    txtCiudad.Items.Add("CAMPAMENTO");
                    txtCiudad.Items.Add("CAÑASGORDAS");
                    txtCiudad.Items.Add("CARACOLI");
                    txtCiudad.Items.Add("CARAMANTA");
                    txtCiudad.Items.Add("CAREPA");
                    txtCiudad.Items.Add("EL CARMEN DE VIBORAL");
                    txtCiudad.Items.Add("CAROLINA");
                    txtCiudad.Items.Add("CAUCASIA");
                    txtCiudad.Items.Add("CHIGORODO");
                    txtCiudad.Items.Add("CISNEROS");
                    txtCiudad.Items.Add("COCORNA");
                    txtCiudad.Items.Add("CONCEPCION");
                    txtCiudad.Items.Add("CONCORDIA");
                    txtCiudad.Items.Add("COPACABANA");
                    txtCiudad.Items.Add("DABEIBA");
                    txtCiudad.Items.Add("DON MATIAS");
                    txtCiudad.Items.Add("EBEJICO");
                    txtCiudad.Items.Add("EL BAGRE");
                    txtCiudad.Items.Add("ENTRERRIOS");
                    txtCiudad.Items.Add("FREDONIA");
                    txtCiudad.Items.Add("FRONTINO");
                    txtCiudad.Items.Add("GIRALDO");
                    txtCiudad.Items.Add("GIRARDOTA");
                    txtCiudad.Items.Add("GOMEZ PLATA");
                    txtCiudad.Items.Add("GRANADA");
                    txtCiudad.Items.Add("GUADALUPE");
                    txtCiudad.Items.Add("GUARNE");
                    txtCiudad.Items.Add("GUATAPE");
                    txtCiudad.Items.Add("HELICONIA");
                    txtCiudad.Items.Add("HISPANIA");
                    txtCiudad.Items.Add("ITAGUI");
                    txtCiudad.Items.Add("ITUANGO");
                    txtCiudad.Items.Add("JARDIN");
                    txtCiudad.Items.Add("JERICO");
                    txtCiudad.Items.Add("LA CEJA");
                    txtCiudad.Items.Add("LA PINTADA");
                    txtCiudad.Items.Add("LA UNION");
                    txtCiudad.Items.Add("LIBORINA");
                    txtCiudad.Items.Add("MACEO");
                    txtCiudad.Items.Add("MONTEBELLO");
                    txtCiudad.Items.Add("MURINDO");
                    txtCiudad.Items.Add("MUTATA");
                    txtCiudad.Items.Add("NECOCLI");
                    txtCiudad.Items.Add("NECHI");
                    txtCiudad.Items.Add("OLAYA");
                    txtCiudad.Items.Add("PEÐOL");
                    txtCiudad.Items.Add("PEQUE");
                    txtCiudad.Items.Add("PUEBLORRICO");
                    txtCiudad.Items.Add("PUERTO BERRIO");
                    txtCiudad.Items.Add("PUERTO NARE");
                    txtCiudad.Items.Add("PUERTO TRIUNFO");
                    txtCiudad.Items.Add("REMEDIOS");
                    txtCiudad.Items.Add("RETIRO");
                    txtCiudad.Items.Add("RIONEGRO");
                    txtCiudad.Items.Add("SABANALARGA");
                    txtCiudad.Items.Add("SABANETA");
                    txtCiudad.Items.Add("SALGAR");
                    txtCiudad.Items.Add("SAN ANDRES DE CUERQUIA");
                    txtCiudad.Items.Add("SAN CARLOS");
                    txtCiudad.Items.Add("SAN FRANCISCO");
                    txtCiudad.Items.Add("SAN JERONIMO");
                    txtCiudad.Items.Add("SAN JOSE DE LA MONTAÑA");
                    txtCiudad.Items.Add("SAN JUAN DE URABA");
                    txtCiudad.Items.Add("SAN LUIS");
                    txtCiudad.Items.Add("SAN PEDRO");
                    txtCiudad.Items.Add("SAN PEDRO DE URABA");
                    txtCiudad.Items.Add("SAN RAFAEL");
                    txtCiudad.Items.Add("SAN ROQUE");
                    txtCiudad.Items.Add("SANTA BARBARA");
                    txtCiudad.Items.Add("SANTA ROSA DE OSOS");
                    txtCiudad.Items.Add("SANTO DOMINGO");
                    txtCiudad.Items.Add("EL SANTUARIO");
                    txtCiudad.Items.Add("SEGOVIA");
                    txtCiudad.Items.Add("SONSON");
                    txtCiudad.Items.Add("SOPETRAN");
                    txtCiudad.Items.Add("TAMESIS");
                    txtCiudad.Items.Add("TARAZA");
                    txtCiudad.Items.Add("TARSO");
                    txtCiudad.Items.Add("TITIRIBI");
                    txtCiudad.Items.Add("TOLEDO");
                    txtCiudad.Items.Add("TURBO");
                    txtCiudad.Items.Add("URAMITA");
                    txtCiudad.Items.Add("URRAO");
                    txtCiudad.Items.Add("VALDIVIA");
                    txtCiudad.Items.Add("VALPARAISO");
                    txtCiudad.Items.Add("VEGACHI");
                    txtCiudad.Items.Add("VENECIA");
                    txtCiudad.Items.Add("VIGIA DEL FUERTE");
                    txtCiudad.Items.Add("YALI");
                    txtCiudad.Items.Add("YARUMAL");
                    txtCiudad.Items.Add("YOLOMBO");
                    txtCiudad.Items.Add("YONDO");
                    txtCiudad.Items.Add("ZARAGOZA");
                    txtCiudad.Items.Add("ENVIGADO");
                    txtCiudad.Items.Add("MEDELLÍN");
                    txtCiudad.Items.Add("BELLO");
                    break;
                case 2://ARAUCA

                    txtCiudad.Items.Add("ARAUQUITA");
                    txtCiudad.Items.Add("CRAVO NORTE");
                    txtCiudad.Items.Add("FORTUL");
                    txtCiudad.Items.Add("PUERTO RONDON");
                    txtCiudad.Items.Add("SARAVENA");
                    txtCiudad.Items.Add("TAME");

                    break;
                case 3://ATLÁNTICO
                    txtCiudad.Items.Add("BARANOA");
                    txtCiudad.Items.Add("BARRANQUILLA");
                    txtCiudad.Items.Add("CAMPO DE LA CRUZ");
                    txtCiudad.Items.Add("GALAPA");
                    txtCiudad.Items.Add("JUAN DE ACOSTA");
                    txtCiudad.Items.Add("LURUACO");
                    txtCiudad.Items.Add("MALAMBO");
                    txtCiudad.Items.Add("MANATI");
                    txtCiudad.Items.Add("PALMAR DE VARELA");
                    txtCiudad.Items.Add("PIOJO");
                    txtCiudad.Items.Add("POLONUEVO");
                    txtCiudad.Items.Add("PONEDERA");
                    txtCiudad.Items.Add("PUERTO COLOMBIA");
                    txtCiudad.Items.Add("REPELON");
                    txtCiudad.Items.Add("SABANAGRANDE");
                    txtCiudad.Items.Add("SANTA LUCIA");
                    txtCiudad.Items.Add("SANTO TOMAS");
                    txtCiudad.Items.Add("SOLEDAD");
                    txtCiudad.Items.Add("SUAN");
                    txtCiudad.Items.Add("TUBARA");
                    txtCiudad.Items.Add("USIACURI");
                    break;
                case 4://BOGOTÁ
                    txtCiudad.Items.Add("BOGOTA, D.C");
                    break;
                case 5://BOLÍVAR
                    txtCiudad.Items.Add("ACHI");
                    txtCiudad.Items.Add("ALTOS DEL ROSARIO");
                    txtCiudad.Items.Add("ARENAL");
                    txtCiudad.Items.Add("ARJONA");
                    txtCiudad.Items.Add("ARROYOHONDO");
                    txtCiudad.Items.Add("BARRANCO DE LOBA");
                    txtCiudad.Items.Add("CALAMAR");
                    txtCiudad.Items.Add("CANTAGALLO");
                    txtCiudad.Items.Add("CICUCO");
                    txtCiudad.Items.Add("CLEMENCIA");
                    txtCiudad.Items.Add("EL CARMEN DE BOLIVAR");
                    txtCiudad.Items.Add("EL GUAMO");
                    txtCiudad.Items.Add("EL PEÑON");
                    txtCiudad.Items.Add("HATILLO DE LOBA");
                    txtCiudad.Items.Add("MAGANGUE");
                    txtCiudad.Items.Add("MAHATES");
                    txtCiudad.Items.Add("MARGARITA");
                    txtCiudad.Items.Add("MARIA LA BAJA");
                    txtCiudad.Items.Add("MONTECRISTO");
                    txtCiudad.Items.Add("MOMPOS");
                    txtCiudad.Items.Add("NOROSI");
                    txtCiudad.Items.Add("MORALES");
                    txtCiudad.Items.Add("PINILLOS");
                    txtCiudad.Items.Add("REGIDOR");
                    txtCiudad.Items.Add("RIO VIEJO");
                    txtCiudad.Items.Add("SAN CRISTOBAL");
                    txtCiudad.Items.Add("SAN ESTANISLAO");
                    txtCiudad.Items.Add("SAN FERNANDO");
                    txtCiudad.Items.Add("SAN JACINTO");
                    txtCiudad.Items.Add("SAN JACINTO DEL CAUCA");
                    txtCiudad.Items.Add("SAN JUAN NEPOMUCENO");
                    txtCiudad.Items.Add("SAN MARTIN DE LOBA");
                    txtCiudad.Items.Add("SAN PABLO");
                    txtCiudad.Items.Add("SANTA CATALINA");
                    txtCiudad.Items.Add("SANTA ROSA");
                    txtCiudad.Items.Add("SANTA ROSA DEL SUR");
                    txtCiudad.Items.Add("SIMITI");
                    txtCiudad.Items.Add("SOPLAVIENTO");
                    txtCiudad.Items.Add("TALAIGUA NUEVO");
                    txtCiudad.Items.Add("TIQUISIO");
                    txtCiudad.Items.Add("TURBACO");
                    txtCiudad.Items.Add("TURBANA");
                    txtCiudad.Items.Add("VILLANUEVA");
                    txtCiudad.Items.Add("ZAMBRANO");
                    txtCiudad.Items.Add("CARTAGENA");
                    break;
                case 6://BOYACÁ
                    txtCiudad.Items.Add("TUNJA");
                    txtCiudad.Items.Add("ALMEIDA");
                    txtCiudad.Items.Add("AQUITANIA");
                    txtCiudad.Items.Add("ARCABUCO");
                    txtCiudad.Items.Add("BELEN");
                    txtCiudad.Items.Add("BERBEO");
                    txtCiudad.Items.Add("BETEITIVA");
                    txtCiudad.Items.Add("BOAVITA");
                    txtCiudad.Items.Add("BUENAVISTA");
                    txtCiudad.Items.Add("BUSBANZA");
                    txtCiudad.Items.Add("CAMPOHERMOSO");
                    txtCiudad.Items.Add("CERINZA");
                    txtCiudad.Items.Add("CHINAVITA");
                    txtCiudad.Items.Add("CHIQUINQUIRA");
                    txtCiudad.Items.Add("CHISCAS");
                    txtCiudad.Items.Add("CHITA");
                    txtCiudad.Items.Add("CHITARAQUE");
                    txtCiudad.Items.Add("CHIVATA");
                    txtCiudad.Items.Add("CIENEGA");
                    txtCiudad.Items.Add("COMBITA");
                    txtCiudad.Items.Add("COPER");
                    txtCiudad.Items.Add("CORRALES");
                    txtCiudad.Items.Add("COVARACHIA");
                    txtCiudad.Items.Add("CUBARA");
                    txtCiudad.Items.Add("CUCAITA");
                    txtCiudad.Items.Add("CUITIVA");
                    txtCiudad.Items.Add("CHIQUIZA");
                    txtCiudad.Items.Add("CHIVOR");
                    txtCiudad.Items.Add("DUITAMA");
                    txtCiudad.Items.Add("EL COCUY");
                    txtCiudad.Items.Add("EL ESPINO");
                    txtCiudad.Items.Add("FIRAVITOBA");
                    txtCiudad.Items.Add("FLORESTA");
                    txtCiudad.Items.Add("GACHANTIVA");
                    txtCiudad.Items.Add("GAMEZA");
                    txtCiudad.Items.Add("GARAGOA");
                    txtCiudad.Items.Add("GUACAMAYAS");
                    txtCiudad.Items.Add("GUATEQUE");
                    txtCiudad.Items.Add("GUAYATA");
                    txtCiudad.Items.Add("GsICAN");
                    txtCiudad.Items.Add("IZA");
                    txtCiudad.Items.Add("JENESANO");
                    txtCiudad.Items.Add("LABRANZAGRANDE");
                    txtCiudad.Items.Add("LA CAPILLA");
                    txtCiudad.Items.Add("LA VICTORIA");
                    txtCiudad.Items.Add("LA UVITA");
                    txtCiudad.Items.Add("VILLA DE LEYVA");
                    txtCiudad.Items.Add("MACANAL");
                    txtCiudad.Items.Add("MARIPI");
                    txtCiudad.Items.Add("MIRAFLORES");
                    txtCiudad.Items.Add("MONGUA");
                    txtCiudad.Items.Add("MONGUI");
                    txtCiudad.Items.Add("MONIQUIRA");
                    txtCiudad.Items.Add("MOTAVITA");
                    txtCiudad.Items.Add("MUZO");
                    txtCiudad.Items.Add("NOBSA");
                    txtCiudad.Items.Add("NUEVO COLON");
                    txtCiudad.Items.Add("OICATA");
                    txtCiudad.Items.Add("OTANCHE");
                    txtCiudad.Items.Add("PACHAVITA");
                    txtCiudad.Items.Add("PAEZ");
                    txtCiudad.Items.Add("PAJARITO");
                    txtCiudad.Items.Add("PANQUEBA");
                    txtCiudad.Items.Add("PAUNA");
                    txtCiudad.Items.Add("PAYA");
                    txtCiudad.Items.Add("PAZ DE RIO");
                    txtCiudad.Items.Add("PESCA");
                    txtCiudad.Items.Add("PISBA");
                    txtCiudad.Items.Add("PUERTO BOYACA");
                    txtCiudad.Items.Add("QUIPAMA");
                    txtCiudad.Items.Add("RAMIRIQUI");
                    txtCiudad.Items.Add("RAQUIRA");
                    txtCiudad.Items.Add("RONDON");
                    txtCiudad.Items.Add("SABOYA");
                    txtCiudad.Items.Add("SACHICA");
                    txtCiudad.Items.Add("SAMACA");
                    txtCiudad.Items.Add("SAN EDUARDO");
                    txtCiudad.Items.Add("SAN JOSE DE PARE");
                    txtCiudad.Items.Add("SAN LUIS DE GACENO");
                    txtCiudad.Items.Add("SAN MATEO");
                    txtCiudad.Items.Add("SAN MIGUEL DE SEMA");
                    txtCiudad.Items.Add("SAN PABLO DE BORBUR");
                    txtCiudad.Items.Add("SANTANA");
                    txtCiudad.Items.Add("SANTA MARIA");
                    txtCiudad.Items.Add("SANTA ROSA DE VITERBO");
                    txtCiudad.Items.Add("SANTA SOFIA");
                    txtCiudad.Items.Add("SATIVANORTE");
                    txtCiudad.Items.Add("SATIVASUR");
                    txtCiudad.Items.Add("SIACHOQUE");
                    txtCiudad.Items.Add("SOATA");
                    txtCiudad.Items.Add("SOCOTA");
                    txtCiudad.Items.Add("SOCHA");
                    txtCiudad.Items.Add("SOGAMOSO");
                    txtCiudad.Items.Add("SOMONDOCO");
                    txtCiudad.Items.Add("SORA");
                    txtCiudad.Items.Add("SOTAQUIRA");
                    txtCiudad.Items.Add("SORACA");
                    txtCiudad.Items.Add("SUSACON");
                    txtCiudad.Items.Add("SUTAMARCHAN");
                    txtCiudad.Items.Add("SUTATENZA");
                    txtCiudad.Items.Add("TASCO");
                    txtCiudad.Items.Add("TENZA");
                    txtCiudad.Items.Add("TIBANA");
                    txtCiudad.Items.Add("TIBASOSA");
                    txtCiudad.Items.Add("TINJACA");
                    txtCiudad.Items.Add("TIPACOQUE");
                    txtCiudad.Items.Add("TOCA");
                    txtCiudad.Items.Add("TOGsI");
                    txtCiudad.Items.Add("TOPAGA");
                    txtCiudad.Items.Add("TOTA");
                    txtCiudad.Items.Add("TUNUNGUA");
                    txtCiudad.Items.Add("TURMEQUE");
                    txtCiudad.Items.Add("TUTA");
                    txtCiudad.Items.Add("TUTAZA");
                    txtCiudad.Items.Add("UMBITA");
                    txtCiudad.Items.Add("VENTAQUEMADA");
                    txtCiudad.Items.Add("VIRACACHA");
                    txtCiudad.Items.Add("ZETAQUIRA");
                    break;
                case 7://CALDAS
                    txtCiudad.Items.Add("MANIZALES");
                    txtCiudad.Items.Add("AGUADAS");
                    txtCiudad.Items.Add("ANSERMA");
                    txtCiudad.Items.Add("ARANZAZU");
                    txtCiudad.Items.Add("BELALCAZAR");
                    txtCiudad.Items.Add("CHINCHINA");
                    txtCiudad.Items.Add("FILADELFIA");
                    txtCiudad.Items.Add("LA DORADA");
                    txtCiudad.Items.Add("LA MERCED");
                    txtCiudad.Items.Add("MANZANARES");
                    txtCiudad.Items.Add("MARMATO");
                    txtCiudad.Items.Add("MARQUETALIA");
                    txtCiudad.Items.Add("MARULANDA");
                    txtCiudad.Items.Add("NEIRA");
                    txtCiudad.Items.Add("NORCASIA");
                    txtCiudad.Items.Add("PACORA");
                    txtCiudad.Items.Add("PALESTINA");
                    txtCiudad.Items.Add("PENSILVANIA");
                    txtCiudad.Items.Add("RIOSUCIO");
                    txtCiudad.Items.Add("SALAMINA");
                    txtCiudad.Items.Add("SAMANA");
                    txtCiudad.Items.Add("SAN JOSE");
                    txtCiudad.Items.Add("SUPIA");
                    txtCiudad.Items.Add("VICTORIA");
                    txtCiudad.Items.Add("VILLAMARIA");
                    txtCiudad.Items.Add("VITERBO");
                    break;
                case 8://CAQUETÁ
                    txtCiudad.Items.Add("FLORENCIA");
                    txtCiudad.Items.Add("ALBANIA");
                    txtCiudad.Items.Add("BELEN DE LOS ANDAQUIES");
                    txtCiudad.Items.Add("CARTAGENA DEL CHAIRA");
                    txtCiudad.Items.Add("CURILLO");
                    txtCiudad.Items.Add("EL DONCELLO");
                    txtCiudad.Items.Add("EL PAUJIL");
                    txtCiudad.Items.Add("LA MONTAÑITA");
                    txtCiudad.Items.Add("MILAN");
                    txtCiudad.Items.Add("MORELIA");
                    txtCiudad.Items.Add("PUERTO RICO");
                    txtCiudad.Items.Add("SAN JOSE DEL FRAGUA");
                    txtCiudad.Items.Add("SAN VICENTE DEL CAGUAN");
                    txtCiudad.Items.Add("SOLANO");
                    txtCiudad.Items.Add("SOLITA");
                    break;
                case 9://CASANARE
                    txtCiudad.Items.Add("YOPAL");
                    txtCiudad.Items.Add("AGUAZUL");
                    txtCiudad.Items.Add("CHAMEZA");
                    txtCiudad.Items.Add("HATO COROZAL");
                    txtCiudad.Items.Add("LA SALINA");
                    txtCiudad.Items.Add("MANI");
                    txtCiudad.Items.Add("MONTERREY");
                    txtCiudad.Items.Add("NUNCHIA");
                    txtCiudad.Items.Add("OROCUE");
                    txtCiudad.Items.Add("PAZ DE ARIPORO");
                    txtCiudad.Items.Add("PORE");
                    txtCiudad.Items.Add("RECETOR");
                    txtCiudad.Items.Add("SACAMA");
                    txtCiudad.Items.Add("SAN LUIS DE PALENQUE");
                    txtCiudad.Items.Add("TAMARA");
                    txtCiudad.Items.Add("TAURAMENA");
                    txtCiudad.Items.Add("TRINIDAD");
                    break;
                case 10://CAUCA
                    txtCiudad.Items.Add("ALMAGUER");
                    txtCiudad.Items.Add("BALBOA");
                    txtCiudad.Items.Add("BUENOS AIRES");
                    txtCiudad.Items.Add("CAJIBIO");
                    txtCiudad.Items.Add("CALDONO");
                    txtCiudad.Items.Add("CALOTO");
                    txtCiudad.Items.Add("CORINTO");
                    txtCiudad.Items.Add("EL TAMBO");
                    txtCiudad.Items.Add("GUACHENE");
                    txtCiudad.Items.Add("GUAPI");
                    txtCiudad.Items.Add("INZA");
                    txtCiudad.Items.Add("JAMBALO");
                    txtCiudad.Items.Add("LA SIERRA");
                    txtCiudad.Items.Add("LA VEGA");
                    txtCiudad.Items.Add("LOPEZ");
                    txtCiudad.Items.Add("MERCADERES");
                    txtCiudad.Items.Add("MIRANDA");
                    txtCiudad.Items.Add("PADILLA");
                    txtCiudad.Items.Add("PATIA");
                    txtCiudad.Items.Add("PIAMONTE");
                    txtCiudad.Items.Add("PIENDAMO");
                    txtCiudad.Items.Add("PUERTO TEJADA");
                    txtCiudad.Items.Add("PURACE");
                    txtCiudad.Items.Add("ROSAS");
                    txtCiudad.Items.Add("SAN SEBASTIAN");
                    txtCiudad.Items.Add("SANTANDER DE QUILICHAO");
                    txtCiudad.Items.Add("SILVIA");
                    txtCiudad.Items.Add("SOTARA");
                    txtCiudad.Items.Add("SUAREZ");
                    txtCiudad.Items.Add("TIMBIO");
                    txtCiudad.Items.Add("TIMBIQUI");
                    txtCiudad.Items.Add("TORIBIO");
                    txtCiudad.Items.Add("TOTORO");
                    txtCiudad.Items.Add("VILLA RICA");
                    txtCiudad.Items.Add("POPAYAN");
                    break;
                case 11://CESAR
                    txtCiudad.Items.Add("VALLEDUPAR");
                    txtCiudad.Items.Add("AGUACHICA");
                    txtCiudad.Items.Add("AGUSTIN CODAZZI");
                    txtCiudad.Items.Add("ASTREA");
                    txtCiudad.Items.Add("BECERRIL");
                    txtCiudad.Items.Add("BOSCONIA");
                    txtCiudad.Items.Add("CHIMICHAGUA");
                    txtCiudad.Items.Add("CHIRIGUANA");
                    txtCiudad.Items.Add("CURUMANI");
                    txtCiudad.Items.Add("EL COPEY");
                    txtCiudad.Items.Add("EL PASO");
                    txtCiudad.Items.Add("GAMARRA");
                    txtCiudad.Items.Add("GONZALEZ");
                    txtCiudad.Items.Add("LA GLORIA");
                    txtCiudad.Items.Add("LA JAGUA DE IBIRICO");
                    txtCiudad.Items.Add("MANAURE");
                    txtCiudad.Items.Add("PAILITAS");
                    txtCiudad.Items.Add("PELAYA");
                    txtCiudad.Items.Add("PUEBLO BELLO");
                    txtCiudad.Items.Add("RIO DE ORO");
                    txtCiudad.Items.Add("LA PAZ");
                    txtCiudad.Items.Add("SAN ALBERTO");
                    txtCiudad.Items.Add("SAN DIEGO");
                    txtCiudad.Items.Add("SAN MARTIN");
                    txtCiudad.Items.Add("TAMALAMEQUE");
                    break;
                case 12://CHOCÓ
                    txtCiudad.Items.Add("QUIBDO");
                    txtCiudad.Items.Add("ACANDI");
                    txtCiudad.Items.Add("ALTO BAUDO");
                    txtCiudad.Items.Add("ATRATO");
                    txtCiudad.Items.Add("BAGADO");
                    txtCiudad.Items.Add("BAHIA SOLANO");
                    txtCiudad.Items.Add("BAJO BAUDO");
                    txtCiudad.Items.Add("BOJAYA");
                    txtCiudad.Items.Add("EL CANTON DEL SAN PABLO");
                    txtCiudad.Items.Add("CARMEN DEL DARIEN");
                    txtCiudad.Items.Add("CERTEGUI");
                    txtCiudad.Items.Add("CONDOTO");
                    txtCiudad.Items.Add("EL CARMEN DE ATRATO");
                    txtCiudad.Items.Add("EL LITORAL DEL SAN JUAN");
                    txtCiudad.Items.Add("ISTMINA");
                    txtCiudad.Items.Add("JURADO");
                    txtCiudad.Items.Add("LLORO");
                    txtCiudad.Items.Add("MEDIO ATRATO");
                    txtCiudad.Items.Add("MEDIO BAUDO");
                    txtCiudad.Items.Add("MEDIO SAN JUAN");
                    txtCiudad.Items.Add("NOVITA");
                    txtCiudad.Items.Add("NUQUI");
                    txtCiudad.Items.Add("RIO IRO");
                    txtCiudad.Items.Add("RIO QUITO");
                    txtCiudad.Items.Add("SAN JOSE DEL PALMAR");
                    txtCiudad.Items.Add("SIPI");
                    txtCiudad.Items.Add("TADO");
                    txtCiudad.Items.Add("UNGUIA");
                    txtCiudad.Items.Add("UNION PANAMERICANA");
                    break;
                case 13://CÓRDOOBA
                    txtCiudad.Items.Add("AYAPEL");
                    txtCiudad.Items.Add("CANALETE");
                    txtCiudad.Items.Add("CERETE");
                    txtCiudad.Items.Add("CHIMA");
                    txtCiudad.Items.Add("CHINU");
                    txtCiudad.Items.Add("CIENAGA DE ORO");
                    txtCiudad.Items.Add("COTORRA");
                    txtCiudad.Items.Add("LA APARTADA");
                    txtCiudad.Items.Add("LORICA");
                    txtCiudad.Items.Add("LOS CORDOBAS");
                    txtCiudad.Items.Add("MOMIL");
                    txtCiudad.Items.Add("MONTELIBANO");
                    txtCiudad.Items.Add("MOÑITOS");
                    txtCiudad.Items.Add("PLANETA RICA");
                    txtCiudad.Items.Add("PUEBLO NUEVO");
                    txtCiudad.Items.Add("PUERTO ESCONDIDO");
                    txtCiudad.Items.Add("PUERTO LIBERTADOR");
                    txtCiudad.Items.Add("PURISIMA");
                    txtCiudad.Items.Add("SAHAGUN");
                    txtCiudad.Items.Add("SAN ANDRES SOTAVENTO");
                    txtCiudad.Items.Add("SAN ANTERO");
                    txtCiudad.Items.Add("SAN BERNARDO DEL VIENTO");
                    txtCiudad.Items.Add("SAN PELAYO");
                    txtCiudad.Items.Add("TIERRALTA");
                    txtCiudad.Items.Add("VALENCIA");
                    break;
                case 14://CUNDINAMARCA
                    txtCiudad.Items.Add("AGUA DE DIOS");
                    txtCiudad.Items.Add("ALBAN");
                    txtCiudad.Items.Add("ANAPOIMA");
                    txtCiudad.Items.Add("ANOLAIMA");
                    txtCiudad.Items.Add("ARBELAEZ");
                    txtCiudad.Items.Add("BELTRAN");
                    txtCiudad.Items.Add("BITUIMA");
                    txtCiudad.Items.Add("BOJACA");
                    txtCiudad.Items.Add("CABRERA");
                    txtCiudad.Items.Add("CACHIPAY");
                    txtCiudad.Items.Add("CAPARRAPI");
                    txtCiudad.Items.Add("CAQUEZA");
                    txtCiudad.Items.Add("CARMEN DE CARUPA");
                    txtCiudad.Items.Add("CHAGUANI");
                    txtCiudad.Items.Add("CHIA");
                    txtCiudad.Items.Add("CHIPAQUE");
                    txtCiudad.Items.Add("CHOACHI");
                    txtCiudad.Items.Add("CHOCONTA");
                    txtCiudad.Items.Add("COGUA");
                    txtCiudad.Items.Add("CUCUNUBA");
                    txtCiudad.Items.Add("EL COLEGIO");
                    txtCiudad.Items.Add("EL ROSAL");
                    txtCiudad.Items.Add("FACATATIVA");
                    txtCiudad.Items.Add("FOMEQUE");
                    txtCiudad.Items.Add("FOSCA");
                    txtCiudad.Items.Add("FUNZA");
                    txtCiudad.Items.Add("FUQUENE");
                    txtCiudad.Items.Add("GACHALA");
                    txtCiudad.Items.Add("GACHANCIPA");
                    txtCiudad.Items.Add("GACHETA");
                    txtCiudad.Items.Add("GAMA");
                    txtCiudad.Items.Add("GIRARDOT");
                    txtCiudad.Items.Add("GUACHETA");
                    txtCiudad.Items.Add("GUADUAS");
                    txtCiudad.Items.Add("GUASCA");
                    txtCiudad.Items.Add("GUATAQUI");
                    txtCiudad.Items.Add("GUATAVITA");
                    txtCiudad.Items.Add("GUAYABAL DE SIQUIMA");
                    txtCiudad.Items.Add("GUAYABETAL");
                    txtCiudad.Items.Add("GUTIERREZ");
                    txtCiudad.Items.Add("JERUSALEN");
                    txtCiudad.Items.Add("JUNIN");
                    txtCiudad.Items.Add("LA PALMA");
                    txtCiudad.Items.Add("LA PEÑA");
                    txtCiudad.Items.Add("LENGUAZAQUE");
                    txtCiudad.Items.Add("MACHETA");
                    txtCiudad.Items.Add("MANTA");
                    txtCiudad.Items.Add("MEDINA");
                    txtCiudad.Items.Add("MOSQUERA");
                    txtCiudad.Items.Add("NEMOCON");
                    txtCiudad.Items.Add("NILO");
                    txtCiudad.Items.Add("NIMAIMA");
                    txtCiudad.Items.Add("NOCAIMA");
                    txtCiudad.Items.Add("PACHO");
                    txtCiudad.Items.Add("PAIME");
                    txtCiudad.Items.Add("PANDI");
                    txtCiudad.Items.Add("PARATEBUENO");
                    txtCiudad.Items.Add("PASCA");
                    txtCiudad.Items.Add("PUERTO SALGAR");
                    txtCiudad.Items.Add("PULI");
                    txtCiudad.Items.Add("QUEBRADANEGRA");
                    txtCiudad.Items.Add("QUETAME");
                    txtCiudad.Items.Add("QUIPILE");
                    txtCiudad.Items.Add("APULO");
                    txtCiudad.Items.Add("RICAURTE");
                    txtCiudad.Items.Add("SAN ANTONIO DEL TEQUENDAMA");
                    txtCiudad.Items.Add("SAN BERNARDO");
                    txtCiudad.Items.Add("SAN CAYETANO");
                    txtCiudad.Items.Add("SAN JUAN DE RIO SECO");
                    txtCiudad.Items.Add("SASAIMA");
                    txtCiudad.Items.Add("SESQUILE");
                    txtCiudad.Items.Add("SIBATE");
                    txtCiudad.Items.Add("SILVANIA");
                    txtCiudad.Items.Add("SIMIJACA");
                    txtCiudad.Items.Add("SOACHA");
                    txtCiudad.Items.Add("SOPO");
                    txtCiudad.Items.Add("SUBACHOQUE");
                    txtCiudad.Items.Add("SUESCA");
                    txtCiudad.Items.Add("SUPATA");
                    txtCiudad.Items.Add("SUSA");
                    txtCiudad.Items.Add("SUTATAUSA");
                    txtCiudad.Items.Add("TAUSA");
                    txtCiudad.Items.Add("TENA");
                    txtCiudad.Items.Add("TIBACUY");
                    txtCiudad.Items.Add("TIBIRITA");
                    txtCiudad.Items.Add("TOCAIMA");
                    txtCiudad.Items.Add("TOCANCIPA");
                    txtCiudad.Items.Add("TOPAIPI");
                    txtCiudad.Items.Add("UBALA");
                    txtCiudad.Items.Add("UBAQUE");
                    txtCiudad.Items.Add("VILLA DE SAN DIEGO DE UBATE");
                    txtCiudad.Items.Add("UNE");
                    txtCiudad.Items.Add("UTICA");
                    txtCiudad.Items.Add("VERGARA");
                    txtCiudad.Items.Add("VIANI");
                    txtCiudad.Items.Add("VILLAGOMEZ");
                    txtCiudad.Items.Add("VILLAPINZON");
                    txtCiudad.Items.Add("VILLETA");
                    txtCiudad.Items.Add("VIOTA");
                    txtCiudad.Items.Add("YACOPI");
                    txtCiudad.Items.Add("ZIPACON");
                    txtCiudad.Items.Add("ZIPAQUIRA");
                    txtCiudad.Items.Add("CAJICA");
                    txtCiudad.Items.Add("LA VEGA.");
                    txtCiudad.Items.Add("MADRID");
                    txtCiudad.Items.Add("LA CALERA");
                    txtCiudad.Items.Add("COTA");
                    txtCiudad.Items.Add("FUSAGASUGÁ");
                    break;
                case 15://GUAINÍA
                    txtCiudad.Items.Add("INIRIDA");
                    txtCiudad.Items.Add("BARRANCO MINAS");
                    txtCiudad.Items.Add("MAPIRIPANA");
                    txtCiudad.Items.Add("SAN FELIPE");
                    txtCiudad.Items.Add("LA GUADALUPE");
                    txtCiudad.Items.Add("CACAHUAL");
                    txtCiudad.Items.Add("PANA PANA");
                    txtCiudad.Items.Add("MORICHAL");
                    break;
                case 16://GUAVIARE    
                    txtCiudad.Items.Add("SAN JOSE DEL GUAVIARE");
                    txtCiudad.Items.Add("EL RETORNO");
                    break;
                case 17://HUILA
                    txtCiudad.Items.Add("ACEVEDO");
                    txtCiudad.Items.Add("AGRADO");
                    txtCiudad.Items.Add("AIPE");
                    txtCiudad.Items.Add("ALGECIRAS");
                    txtCiudad.Items.Add("ALTAMIRA");
                    txtCiudad.Items.Add("BARAYA");
                    txtCiudad.Items.Add("CAMPOALEGRE");
                    txtCiudad.Items.Add("COLOMBIA");
                    txtCiudad.Items.Add("ELIAS");
                    txtCiudad.Items.Add("GARZON");
                    txtCiudad.Items.Add("GIGANTE");
                    txtCiudad.Items.Add("HOBO");
                    txtCiudad.Items.Add("IQUIRA");
                    txtCiudad.Items.Add("ISNOS");
                    txtCiudad.Items.Add("LA ARGENTINA");
                    txtCiudad.Items.Add("LA PLATA");
                    txtCiudad.Items.Add("NATAGA");
                    txtCiudad.Items.Add("OPORAPA");
                    txtCiudad.Items.Add("PAICOL");
                    txtCiudad.Items.Add("PALERMO");
                    txtCiudad.Items.Add("PITAL");
                    txtCiudad.Items.Add("PITALITO");
                    txtCiudad.Items.Add("RIVERA");
                    txtCiudad.Items.Add("SALADOBLANCO");
                    txtCiudad.Items.Add("SAN AGUSTIN");
                    txtCiudad.Items.Add("SUAZA");
                    txtCiudad.Items.Add("TARQUI");
                    txtCiudad.Items.Add("TESALIA");
                    txtCiudad.Items.Add("TELLO");
                    txtCiudad.Items.Add("TERUEL");
                    txtCiudad.Items.Add("TIMANA");
                    txtCiudad.Items.Add("VILLAVIEJA");
                    txtCiudad.Items.Add("YAGUARA");
                    break;
                case 18://LA GUAJIRA
                    txtCiudad.Items.Add("RIOHACHA");
                    txtCiudad.Items.Add("BARRANCAS");
                    txtCiudad.Items.Add("DIBULLA");
                    txtCiudad.Items.Add("DISTRACCION");
                    txtCiudad.Items.Add("EL MOLINO");
                    txtCiudad.Items.Add("FONSECA");
                    txtCiudad.Items.Add("HATONUEVO");
                    txtCiudad.Items.Add("LA JAGUA DEL PILAR");
                    txtCiudad.Items.Add("MAICAO");
                    txtCiudad.Items.Add("SAN JUAN DEL CESAR");
                    txtCiudad.Items.Add("URIBIA");
                    txtCiudad.Items.Add("URUMITA");
                    break;
                case 19://MAGDALENA
                    txtCiudad.Items.Add("ALGARROBO");
                    txtCiudad.Items.Add("ARACATACA");
                    txtCiudad.Items.Add("ARIGUANI");
                    txtCiudad.Items.Add("CERRO SAN ANTONIO");
                    txtCiudad.Items.Add("CHIBOLO");
                    txtCiudad.Items.Add("CIENAGA");
                    txtCiudad.Items.Add("EL BANCO");
                    txtCiudad.Items.Add("EL PIÑON");
                    txtCiudad.Items.Add("EL RETEN");
                    txtCiudad.Items.Add("FUNDACION");
                    txtCiudad.Items.Add("GUAMAL");
                    txtCiudad.Items.Add("NUEVA GRANADA");
                    txtCiudad.Items.Add("PEDRAZA");
                    txtCiudad.Items.Add("PIJIÑO DEL CARMEN");
                    txtCiudad.Items.Add("PIVIJAY");
                    txtCiudad.Items.Add("PLATO");
                    txtCiudad.Items.Add("PUEBLOVIEJO");
                    txtCiudad.Items.Add("REMOLINO");
                    txtCiudad.Items.Add("SABANAS DE SAN ANGEL");
                    txtCiudad.Items.Add("SAN SEBASTIAN DE BUENAVISTA");
                    txtCiudad.Items.Add("SAN ZENON");
                    txtCiudad.Items.Add("SANTA ANA");
                    txtCiudad.Items.Add("SANTA BARBARA DE PINTO");
                    txtCiudad.Items.Add("SITIONUEVO");
                    txtCiudad.Items.Add("TENERIFE");
                    txtCiudad.Items.Add("ZAPAYAN");
                    txtCiudad.Items.Add("ZONA BANANERA");
                    txtCiudad.Items.Add("SANTA MARTA");
                    break;
                case 20://META
                    txtCiudad.Items.Add("VILLAVICENCIO");
                    txtCiudad.Items.Add("ACACIAS");
                    txtCiudad.Items.Add("BARRANCA DE UPIA");
                    txtCiudad.Items.Add("CABUYARO");
                    txtCiudad.Items.Add("CASTILLA LA NUEVA");
                    txtCiudad.Items.Add("CUBARRAL");
                    txtCiudad.Items.Add("CUMARAL");
                    txtCiudad.Items.Add("EL CALVARIO");
                    txtCiudad.Items.Add("EL CASTILLO");
                    txtCiudad.Items.Add("EL DORADO");
                    txtCiudad.Items.Add("FUENTE DE ORO");
                    txtCiudad.Items.Add("MAPIRIPAN");
                    txtCiudad.Items.Add("MESETAS");
                    txtCiudad.Items.Add("LA MACARENA");
                    txtCiudad.Items.Add("URIBE");
                    txtCiudad.Items.Add("LEJANIAS");
                    txtCiudad.Items.Add("PUERTO CONCORDIA");
                    txtCiudad.Items.Add("PUERTO GAITAN");
                    txtCiudad.Items.Add("PUERTO LOPEZ");
                    txtCiudad.Items.Add("PUERTO LLERAS");
                    txtCiudad.Items.Add("RESTREPO");
                    txtCiudad.Items.Add("SAN CARLOS DE GUAROA");
                    txtCiudad.Items.Add("SAN JUAN DE ARAMA");
                    txtCiudad.Items.Add("SAN JUANITO");
                    txtCiudad.Items.Add("VISTAHERMOSA");
                    break;
                case 21://NARIÑO
                    txtCiudad.Items.Add("PASTO");
                    txtCiudad.Items.Add("ALDANA");
                    txtCiudad.Items.Add("ANCUYA");
                    txtCiudad.Items.Add("ARBOLEDA");
                    txtCiudad.Items.Add("BARBACOAS");
                    txtCiudad.Items.Add("BUESACO");
                    txtCiudad.Items.Add("COLON");
                    txtCiudad.Items.Add("CONSACA");
                    txtCiudad.Items.Add("CONTADERO");
                    txtCiudad.Items.Add("CUASPUD");
                    txtCiudad.Items.Add("CUMBAL");
                    txtCiudad.Items.Add("CUMBITARA");
                    txtCiudad.Items.Add("CHACHAGsI");
                    txtCiudad.Items.Add("EL CHARCO");
                    txtCiudad.Items.Add("EL PEÑOL");
                    txtCiudad.Items.Add("EL ROSARIO");
                    txtCiudad.Items.Add("EL TABLON DE GOMEZ");
                    txtCiudad.Items.Add("FUNES");
                    txtCiudad.Items.Add("GUACHUCAL");
                    txtCiudad.Items.Add("GUAITARILLA");
                    txtCiudad.Items.Add("GUALMATAN");
                    txtCiudad.Items.Add("ILES");
                    txtCiudad.Items.Add("IMUES");
                    txtCiudad.Items.Add("IPIALES");
                    txtCiudad.Items.Add("LA CRUZ");
                    break;
                    case 22://NORTE DE SANTANDER

                    txtCiudad.Items.Add("CUCUTA");
                    txtCiudad.Items.Add("ABREGO");
                    txtCiudad.Items.Add("ARBOLEDAS");
                    txtCiudad.Items.Add("BOCHALEMA");
                    txtCiudad.Items.Add("BUCARASICA");
                    txtCiudad.Items.Add("CACOTA");
                    txtCiudad.Items.Add("CACHIRA");
                    txtCiudad.Items.Add("CHINACOTA");
                    txtCiudad.Items.Add("CHITAGA");
                    txtCiudad.Items.Add("CONVENCION");
                    txtCiudad.Items.Add("CUCUTILLA");
                    txtCiudad.Items.Add("DURANIA");
                    txtCiudad.Items.Add("EL CARMEN");
                    txtCiudad.Items.Add("EL TARRA");
                    txtCiudad.Items.Add("EL ZULIA");
                    txtCiudad.Items.Add("GRAMALOTE");
                    txtCiudad.Items.Add("HACARI");
                    txtCiudad.Items.Add("HERRAN");
                    txtCiudad.Items.Add("LABATECA");
                    txtCiudad.Items.Add("LA ESPERANZA");
                    txtCiudad.Items.Add("LA PLAYA");
                    txtCiudad.Items.Add("LOS PATIOS");
                    txtCiudad.Items.Add("LOURDES");
                    txtCiudad.Items.Add("MUTISCUA");
                    txtCiudad.Items.Add("OCAÑA");
                    break;
                case 23://PUTUMAYO
                    txtCiudad.Items.Add("MOCOA");
                    txtCiudad.Items.Add("ORITO");
                    txtCiudad.Items.Add("PUERTO ASIS");
                    txtCiudad.Items.Add("PUERTO CAICEDO");
                    txtCiudad.Items.Add("PUERTO GUZMAN");
                    txtCiudad.Items.Add("LEGUIZAMO");
                    txtCiudad.Items.Add("SIBUNDOY");
                    txtCiudad.Items.Add("VALLE DEL GUAMUEZ");
                    txtCiudad.Items.Add("VILLAGARZON");
                    break;
                case 24://QUINDIO
                    txtCiudad.Items.Add("ARMENIA");
                    txtCiudad.Items.Add("CALARCA");
                    txtCiudad.Items.Add("CIRCASIA");
                    txtCiudad.Items.Add("FILANDIA");
                    txtCiudad.Items.Add("GENOVA");
                    txtCiudad.Items.Add("LA TEBAIDA");
                    txtCiudad.Items.Add("MONTENEGRO");
                    txtCiudad.Items.Add("PIJAO");
                    txtCiudad.Items.Add("QUIMBAYA");
                    txtCiudad.Items.Add("SALENTO");
                    break;
                case 25://RISARALDA
                    txtCiudad.Items.Add("PEREIRA");
                    txtCiudad.Items.Add("APIA");
                    txtCiudad.Items.Add("BELEN DE UMBRIA");
                    txtCiudad.Items.Add("DOSQUEBRADAS");
                    txtCiudad.Items.Add("GUATICA");
                    txtCiudad.Items.Add("LA CELIA");
                    txtCiudad.Items.Add("LA VIRGINIA");
                    txtCiudad.Items.Add("MARSELLA");
                    txtCiudad.Items.Add("MISTRATO");
                    txtCiudad.Items.Add("PUEBLO RICO");
                    txtCiudad.Items.Add("QUINCHIA");
                    txtCiudad.Items.Add("SANTA ROSA DE CABAL");
                    txtCiudad.Items.Add("SANTUARIO");
                    break;
                case 26://SAN ANDRÉS Y PROVIDENCIA
                    txtCiudad.Items.Add("SAN ANDRES");
                    txtCiudad.Items.Add("PROVIDENCIA");
                    break;
                case 27://SANTANDER
                    txtCiudad.Items.Add("BUCARAMANGA");
                    txtCiudad.Items.Add("AGUADA");
                    txtCiudad.Items.Add("ARATOCA");
                    txtCiudad.Items.Add("BARICHARA");
                    txtCiudad.Items.Add("BARRANCABERMEJA");
                    txtCiudad.Items.Add("CALIFORNIA");
                    txtCiudad.Items.Add("CAPITANEJO");
                    txtCiudad.Items.Add("CARCASI");
                    txtCiudad.Items.Add("CEPITA");
                    txtCiudad.Items.Add("CERRITO");
                    txtCiudad.Items.Add("CHARALA");
                    txtCiudad.Items.Add("CHARTA");
                    txtCiudad.Items.Add("CHIPATA");
                    txtCiudad.Items.Add("CIMITARRA");
                    txtCiudad.Items.Add("CONFINES");
                    txtCiudad.Items.Add("CONTRATACION");
                    txtCiudad.Items.Add("COROMORO");
                    txtCiudad.Items.Add("CURITI");
                    txtCiudad.Items.Add("EL CARMEN DE CHUCURI");
                    txtCiudad.Items.Add("EL GUACAMAYO");
                    txtCiudad.Items.Add("EL PLAYON");
                    txtCiudad.Items.Add("ENCINO");
                    txtCiudad.Items.Add("ENCISO");
                    txtCiudad.Items.Add("FLORIAN");
                    txtCiudad.Items.Add("FLORIDABLANCA");
                    txtCiudad.Items.Add("GALAN");
                    txtCiudad.Items.Add("GAMBITA");
                    txtCiudad.Items.Add("GIRON");
                    txtCiudad.Items.Add("GUACA");
                    txtCiudad.Items.Add("GUAPOTA");
                    txtCiudad.Items.Add("GUAVATA");
                    txtCiudad.Items.Add("GsEPSA");
                    txtCiudad.Items.Add("HATO");
                    txtCiudad.Items.Add("JESUS MARIA");
                    txtCiudad.Items.Add("JORDAN");
                    txtCiudad.Items.Add("LA BELLEZA");
                    txtCiudad.Items.Add("LANDAZURI");
                    txtCiudad.Items.Add("LEBRIJA");
                    txtCiudad.Items.Add("LOS SANTOS");
                    txtCiudad.Items.Add("MACARAVITA");
                    txtCiudad.Items.Add("MALAGA");
                    txtCiudad.Items.Add("MATANZA");
                    txtCiudad.Items.Add("MOGOTES");
                    txtCiudad.Items.Add("MOLAGAVITA");
                    txtCiudad.Items.Add("OCAMONTE");
                    txtCiudad.Items.Add("OIBA");
                    txtCiudad.Items.Add("ONZAGA");
                    txtCiudad.Items.Add("PALMAR");
                    txtCiudad.Items.Add("PALMAS DEL SOCORRO");
                    txtCiudad.Items.Add("PARAMO");
                    txtCiudad.Items.Add("PIEDECUESTA");
                    txtCiudad.Items.Add("PINCHOTE");
                    txtCiudad.Items.Add("PUENTE NACIONAL");
                    txtCiudad.Items.Add("PUERTO PARRA");
                    txtCiudad.Items.Add("PUERTO WILCHES");
                    txtCiudad.Items.Add("SABANA DE TORRES");
                    txtCiudad.Items.Add("SAN ANDRES");
                    txtCiudad.Items.Add("SAN BENITO");
                    txtCiudad.Items.Add("SAN GIL");
                    txtCiudad.Items.Add("SAN JOAQUIN");
                    txtCiudad.Items.Add("SAN JOSE DE MIRANDA");
                    txtCiudad.Items.Add("SAN MIGUEL");
                    txtCiudad.Items.Add("SAN VICENTE DE CHUCURI");
                    txtCiudad.Items.Add("SANTA HELENA DEL OPON");
                    txtCiudad.Items.Add("SIMACOTA");
                    txtCiudad.Items.Add("SOCORRO");
                    txtCiudad.Items.Add("SUAITA");
                    txtCiudad.Items.Add("SURATA");
                    txtCiudad.Items.Add("TONA");
                    txtCiudad.Items.Add("VALLE DE SAN JOSE");
                    txtCiudad.Items.Add("VELEZ");
                    txtCiudad.Items.Add("VETAS");
                    txtCiudad.Items.Add("ZAPATOCA");
                    break;
                case 28://SUCRE
                    txtCiudad.Items.Add("SINCELEJO");
                    txtCiudad.Items.Add("CAIMITO");
                    txtCiudad.Items.Add("COLOSO");
                    txtCiudad.Items.Add("COROZAL");
                    txtCiudad.Items.Add("COVEÑAS");
                    txtCiudad.Items.Add("CHALAN");
                    txtCiudad.Items.Add("EL ROBLE");
                    txtCiudad.Items.Add("GALERAS");
                    txtCiudad.Items.Add("GUARANDA");
                    txtCiudad.Items.Add("LOS PALMITOS");
                    txtCiudad.Items.Add("MAJAGUAL");
                    txtCiudad.Items.Add("MORROA");
                    txtCiudad.Items.Add("OVEJAS");
                    txtCiudad.Items.Add("PALMITO");
                    txtCiudad.Items.Add("SAMPUES");
                    txtCiudad.Items.Add("SAN BENITO ABAD");
                    txtCiudad.Items.Add("SAN JUAN DE BETULIA");
                    txtCiudad.Items.Add("SAN MARCOS");
                    txtCiudad.Items.Add("SAN ONOFRE");
                    txtCiudad.Items.Add("SAN LUIS DE SINCE");
                    txtCiudad.Items.Add("SANTIAGO DE TOLU");
                    txtCiudad.Items.Add("TOLU VIEJO");
                    break;
                case 29://TOLIMA
                    txtCiudad.Items.Add("IBAGUE");
                    txtCiudad.Items.Add("ALPUJARRA");
                    txtCiudad.Items.Add("ALVARADO");
                    txtCiudad.Items.Add("AMBALEMA");
                    txtCiudad.Items.Add("ANZOATEGUI");
                    txtCiudad.Items.Add("ARMERO");
                    txtCiudad.Items.Add("ATACO");
                    txtCiudad.Items.Add("CAJAMARCA");
                    txtCiudad.Items.Add("CARMEN DE APICALA");
                    txtCiudad.Items.Add("CASABIANCA");
                    txtCiudad.Items.Add("CHAPARRAL");
                    txtCiudad.Items.Add("COELLO");
                    txtCiudad.Items.Add("COYAIMA");
                    txtCiudad.Items.Add("CUNDAY");
                    txtCiudad.Items.Add("DOLORES");
                    txtCiudad.Items.Add("ESPINAL");
                    txtCiudad.Items.Add("FALAN");
                    txtCiudad.Items.Add("FLANDES");
                    txtCiudad.Items.Add("FRESNO");
                    txtCiudad.Items.Add("GUAMO");
                    txtCiudad.Items.Add("HERVEO");
                    txtCiudad.Items.Add("HONDA");
                    txtCiudad.Items.Add("ICONONZO");
                    txtCiudad.Items.Add("LERIDA");
                    txtCiudad.Items.Add("LIBANO");
                    txtCiudad.Items.Add("MARIQUITA");
                    txtCiudad.Items.Add("MELGAR");
                    txtCiudad.Items.Add("MURILLO");
                    txtCiudad.Items.Add("NATAGAIMA");
                    txtCiudad.Items.Add("ORTEGA");
                    txtCiudad.Items.Add("PALOCABILDO");
                    txtCiudad.Items.Add("PIEDRAS");
                    txtCiudad.Items.Add("PLANADAS");
                    txtCiudad.Items.Add("PURIFICACION");
                    txtCiudad.Items.Add("RIOBLANCO");
                    txtCiudad.Items.Add("RONCESVALLES");
                    txtCiudad.Items.Add("ROVIRA");
                    txtCiudad.Items.Add("SALDAÑA");
                    txtCiudad.Items.Add("SAN ANTONIO");
                    txtCiudad.Items.Add("SANTA ISABEL");
                    txtCiudad.Items.Add("VALLE DE SAN JUAN");
                    txtCiudad.Items.Add("VENADILLO");
                    txtCiudad.Items.Add("VILLAHERMOSA");
                    txtCiudad.Items.Add("VILLARRICA");
                    break;
                case 30://VALLE DEL CAUCA
                    txtCiudad.Items.Add("ALCALA");
                    txtCiudad.Items.Add("ANDALUCIA");
                    txtCiudad.Items.Add("ANSERMANUEVO");
                    txtCiudad.Items.Add("BUENAVENTURA");
                    txtCiudad.Items.Add("GUADALAJARA DE BUGA");
                    txtCiudad.Items.Add("BUGALAGRANDE");
                    txtCiudad.Items.Add("CAICEDONIA");
                    txtCiudad.Items.Add("CALIMA");
                    txtCiudad.Items.Add("CARTAGO");
                    txtCiudad.Items.Add("DAGUA");
                    txtCiudad.Items.Add("EL AGUILA");
                    txtCiudad.Items.Add("EL CAIRO");
                    txtCiudad.Items.Add("EL CERRITO");
                    txtCiudad.Items.Add("EL DOVIO");
                    txtCiudad.Items.Add("FLORIDA");
                    txtCiudad.Items.Add("GINEBRA");
                    txtCiudad.Items.Add("GUACARI");
                    txtCiudad.Items.Add("LA CUMBRE");
                    txtCiudad.Items.Add("OBANDO");
                    txtCiudad.Items.Add("PALMIRA");
                    txtCiudad.Items.Add("PRADERA");
                    txtCiudad.Items.Add("RIOFRIO");
                    txtCiudad.Items.Add("ROLDANILLO");
                    txtCiudad.Items.Add("SEVILLA");
                    txtCiudad.Items.Add("TORO");
                    txtCiudad.Items.Add("TRUJILLO");
                    txtCiudad.Items.Add("TULUA");
                    txtCiudad.Items.Add("ULLOA");
                    txtCiudad.Items.Add("VERSALLES");
                    txtCiudad.Items.Add("VIJES");
                    txtCiudad.Items.Add("YOTOCO");
                    txtCiudad.Items.Add("YUMBO");
                    txtCiudad.Items.Add("ZARZAL");
                    txtCiudad.Items.Add("JAMUNDI");
                    txtCiudad.Items.Add("CALI");
                    txtCiudad.Items.Add("SALOMIA");
                    txtCiudad.Items.Add("OCACHE");
                    break;
                case 31://VAUPÉS
                    txtCiudad.Items.Add("MITU");
                    txtCiudad.Items.Add("CARURU");
                    txtCiudad.Items.Add("PACOA");
                    txtCiudad.Items.Add("TARAIRA");
                    txtCiudad.Items.Add("PAPUNAUA");
                    txtCiudad.Items.Add("YAVARATE");
                    break;
                case 32://VICHADA
                    txtCiudad.Items.Add("PUERTO CARREÑO");
                    txtCiudad.Items.Add("CUMARIBO");
                    txtCiudad.Items.Add("SANTA ROSALÍA");
                    txtCiudad.Items.Add("LA PRIMAVERA");
                    txtCiudad.Items.Add("SAN JOSÉ DE MAIPURES");
                    txtCiudad.Items.Add("GAVIOTAS");
                    txtCiudad.Items.Add("SANTA RITA");
                    txtCiudad.Items.Add("SAN JOSÉ DE OCUNE");
                    break;
                case 33://ESTADOS UNIDOS
                    txtCiudad.Items.Add("Miami");
                    break;

            }
        }

     
    
        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<App, List<string>>((App)Xamarin.Forms.Application.Current, "ImagesSelected", (s, images) =>
            {
                listItems.IsVisible = true;
                listItems.FlowItemsSource = images;
                _images = images;
            });
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<App, List<string>>(this, "ImagesSelected");
        }
        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            await DependencyService.Get<IMediaService>().OpenGallery();
        }
        

        
        private void BtnPublicarClick()
        {
            SendTo();
            //DisplayAlert("Imagen", _images.First(), "Ok");
            //SendTo2();
            
        }

        public async Task<bool> Upload(MediaFile mediaFile, string filename)
        {
            byte[] bitmapData;
            var stream = new MemoryStream();
            mediaFile.GetStream().CopyTo(stream);
            bitmapData = stream.ToArray();
            var fileContent = new ByteArrayContent(bitmapData);

            fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("application/octet-stream");
            fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
            {
                Name = "fileUpload",
                FileName = filename
            };

            string boundary = "---8393774hhy37373773";
            MultipartFormDataContent multipartContent = new MultipartFormDataContent(boundary)
            {
                fileContent
            };


            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.PostAsync("http://www.url.com/upload.php", multipartContent);
            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();

                return true;
            }
            return false;
        }





    private async void SendTo()
        {
            

            var values = new Dictionary<string, string>
                {
                   { "Dato1", txtNO.Text},
                   { "Dato2", txtDepartamento.Items[txtDepartamento.SelectedIndex]},
                   { "Dato3", txtCiudad.Items[txtCiudad.SelectedIndex]},
                   { "Dato4", txtBar.Text},
                   { "Dato5", txtDi.Text},
                   { "Dato6", txtPr.Text},
                   { "Dato7", txtAr.Text},
                   { "Dato8", txtUbicación.Items[txtUbicación.SelectedIndex]},
                   { "Dato9", txtHa.Text},
                   { "Dato10", txtBa.Text},
                   { "Dato11", txtPa.Text},
                   { "Dato12", txtEstrato.Items[txtEstrato.SelectedIndex]},
                   { "Dato13", txtAntiguedad.Items[txtAntiguedad.SelectedIndex]},
                   { "Dato14", txtTe.Text},
                   { "Dato15", TxtTerceria.Items[TxtTerceria.SelectedIndex]},

                   { "Dato19", txtDe.Text},
                   { "Dato20", txtCategoria.Items[txtCategoria.SelectedIndex]},
                   { "Dato21", txtTipo.Items[txtTipo.SelectedIndex]},
                   { "Dato22", (String)App.Current.Properties["Usuario"]}

                };
            var content = new FormUrlEncodedContent(values);

            var response = await client.PostAsync("https://app.socialbusiness.com.co/api/Post.php", content);
            //DisplayAlert("Alert", "You have been alerted 2", "OK");
            try
            {
                
                var responseString = await response.Content.ReadAsStringAsync();
                Rta = JsonConvert.DeserializeObject<Respuesta>(responseString);
                await DisplayAlert("Alerta", Rta.Mensaje, "Ok");
                //await Navigation.PopModalAsync().ConfigureAwait(false);
                //await Navigation.PushModalAsync(new Archivos());

                //Navigation.InsertPageBefore(new Archivos(), this);
                //await Navigation.PopModalAsync();

            }
            catch (Exception e)
            {
                await DisplayAlert("Alerta", ""+e, "Ok");

            }
        }






        private MediaFile _image;
        private async void SendTo2()
        {
            
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    MultipartFormDataContent formData = new MultipartFormDataContent();
                    formData.Add(new StringContent(JsonConvert.SerializeObject("uploaded_file"), Encoding.UTF8, "application/json"), "uploaded_file");
                    //formData.Add(new StringContent("param2 name"), "param2");
                    var response = await client.PostAsync("https://app.socialbusiness.com.co/api/upload_photos.php", formData);
                    //Logger.Log("Response : " + responseObj.ToString());
                    try
                    {

                        var responseString = await response.Content.ReadAsStringAsync();
                        Rta = JsonConvert.DeserializeObject<Respuesta>(responseString);
                        await DisplayAlert("Alerta", Rta.Mensaje, "Ok");
                        //await Navigation.PopModalAsync().ConfigureAwait(false);
                        //await Navigation.PushModalAsync(new Archivos());

                        //Navigation.InsertPageBefore(new Archivos(), this);
                        //await Navigation.PopModalAsync();

                    }
                    catch (Exception e)
                    {
                        await DisplayAlert("Alerta", "" + e, "Ok");

                    }
                }
                catch (Exception ex)
                {
                    //Logger.Log("Exception : " + ex.ToString());
                    await DisplayAlert("Error", ex.ToString(), "Ok");
                }
            }
        }
    }
}