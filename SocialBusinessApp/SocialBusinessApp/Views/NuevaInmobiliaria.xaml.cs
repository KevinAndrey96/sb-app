using Newtonsoft.Json;
using Plugin.FileUploader;
using Plugin.FileUploader.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SocialBusinessApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NuevaInmobiliaria : ContentPage
	{
        private static HttpClient client = new HttpClient();
        Respuesta Rta;
        public NuevaInmobiliaria ()
		{
			InitializeComponent ();
            btnCrearInmobiliaria.Clicked += (sender, e) => BtnCrearInmobiliariaClick();
        }


        List<string> _images = new List<string>();

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
        void DepartamentoSelect(object sender, EventArgs args)
        {
            Picker modePicker = (Picker)sender;
            int mode = modePicker.SelectedIndex;
            pikCiudad.Items.Clear();
            pikCiudad.IsEnabled = true;
            switch (mode)
            {
                case 0://AMAZONAS                        
                    pikCiudad.Items.Add("LETICIA");
                    pikCiudad.Items.Add("EL ENCANTO");
                    pikCiudad.Items.Add("LA CHORRERA");
                    pikCiudad.Items.Add("LA PEDRERA");
                    pikCiudad.Items.Add("MIRITI - PARANA");
                    pikCiudad.Items.Add("PUERTO ALEGRIA");
                    pikCiudad.Items.Add("PUERTO ARICA");
                    pikCiudad.Items.Add("PUERTO NARIÑO");
                    break;
                case 1://ANTIOQUIA
                    pikCiudad.Items.Add("ABEJORRAL");
                    pikCiudad.Items.Add("ABRIAQUI");
                    pikCiudad.Items.Add("ALEJANDRIA");
                    pikCiudad.Items.Add("AMAGA");
                    pikCiudad.Items.Add("AMALFI");
                    pikCiudad.Items.Add("ANDES");
                    pikCiudad.Items.Add("ANGELOPOLIS");
                    pikCiudad.Items.Add("ANGOSTURA");
                    pikCiudad.Items.Add("ANORI");
                    pikCiudad.Items.Add("SANTAFE DE ANTIOQUIA");
                    pikCiudad.Items.Add("ANZA");
                    pikCiudad.Items.Add("APARTADO");
                    pikCiudad.Items.Add("ARBOLETES");
                    pikCiudad.Items.Add("ARGELIA");
                    pikCiudad.Items.Add("BARBOSA");
                    pikCiudad.Items.Add("BELLO");
                    pikCiudad.Items.Add("BELMIRA");
                    pikCiudad.Items.Add("BETANIA");
                    pikCiudad.Items.Add("BETULIA");
                    pikCiudad.Items.Add("CIUDAD BOLIVAR");
                    pikCiudad.Items.Add("BRICEÑO");
                    pikCiudad.Items.Add("BURITICA");
                    pikCiudad.Items.Add("CACERES");
                    pikCiudad.Items.Add("CAICEDO");
                    pikCiudad.Items.Add("CAMPAMENTO");
                    pikCiudad.Items.Add("CAÑASGORDAS");
                    pikCiudad.Items.Add("CARACOLI");
                    pikCiudad.Items.Add("CARAMANTA");
                    pikCiudad.Items.Add("CAREPA");
                    pikCiudad.Items.Add("EL CARMEN DE VIBORAL");
                    pikCiudad.Items.Add("CAROLINA");
                    pikCiudad.Items.Add("CAUCASIA");
                    pikCiudad.Items.Add("CHIGORODO");
                    pikCiudad.Items.Add("CISNEROS");
                    pikCiudad.Items.Add("COCORNA");
                    pikCiudad.Items.Add("CONCEPCION");
                    pikCiudad.Items.Add("CONCORDIA");
                    pikCiudad.Items.Add("COPACABANA");
                    pikCiudad.Items.Add("DABEIBA");
                    pikCiudad.Items.Add("DON MATIAS");
                    pikCiudad.Items.Add("EBEJICO");
                    pikCiudad.Items.Add("EL BAGRE");
                    pikCiudad.Items.Add("ENTRERRIOS");
                    pikCiudad.Items.Add("ENVIGADO");
                    pikCiudad.Items.Add("FREDONIA");
                    pikCiudad.Items.Add("FRONTINO");
                    pikCiudad.Items.Add("GIRALDO");
                    pikCiudad.Items.Add("GIRARDOTA");
                    pikCiudad.Items.Add("GOMEZ PLATA");
                    pikCiudad.Items.Add("GRANADA");
                    pikCiudad.Items.Add("GUADALUPE");
                    pikCiudad.Items.Add("GUARNE");
                    pikCiudad.Items.Add("GUATAPE");
                    pikCiudad.Items.Add("HELICONIA");
                    pikCiudad.Items.Add("HISPANIA");
                    pikCiudad.Items.Add("ITAGUI");
                    pikCiudad.Items.Add("ITUANGO");
                    pikCiudad.Items.Add("JARDIN");
                    pikCiudad.Items.Add("JERICO");
                    pikCiudad.Items.Add("LA CEJA");
                    pikCiudad.Items.Add("LA PINTADA");
                    pikCiudad.Items.Add("LA UNION");
                    pikCiudad.Items.Add("LIBORINA");
                    pikCiudad.Items.Add("MACEO");
                    pikCiudad.Items.Add("MEDELLÍN");
                    pikCiudad.Items.Add("MONTEBELLO");
                    pikCiudad.Items.Add("MURINDO");
                    pikCiudad.Items.Add("MUTATA");
                    pikCiudad.Items.Add("NECOCLI");
                    pikCiudad.Items.Add("NECHI");
                    pikCiudad.Items.Add("OLAYA");
                    pikCiudad.Items.Add("PEÐOL");
                    pikCiudad.Items.Add("PEQUE");
                    pikCiudad.Items.Add("PUEBLORRICO");
                    pikCiudad.Items.Add("PUERTO BERRIO");
                    pikCiudad.Items.Add("PUERTO NARE");
                    pikCiudad.Items.Add("PUERTO TRIUNFO");
                    pikCiudad.Items.Add("REMEDIOS");
                    pikCiudad.Items.Add("RETIRO");
                    pikCiudad.Items.Add("RIONEGRO");
                    pikCiudad.Items.Add("SABANALARGA");
                    pikCiudad.Items.Add("SABANETA");
                    pikCiudad.Items.Add("SALGAR");
                    pikCiudad.Items.Add("SAN ANDRES DE CUERQUIA");
                    pikCiudad.Items.Add("SAN CARLOS");
                    pikCiudad.Items.Add("SAN FRANCISCO");
                    pikCiudad.Items.Add("SAN JERONIMO");
                    pikCiudad.Items.Add("SAN JOSE DE LA MONTAÑA");
                    pikCiudad.Items.Add("SAN JUAN DE URABA");
                    pikCiudad.Items.Add("SAN LUIS");
                    pikCiudad.Items.Add("SAN PEDRO");
                    pikCiudad.Items.Add("SAN PEDRO DE URABA");
                    pikCiudad.Items.Add("SAN RAFAEL");
                    pikCiudad.Items.Add("SAN ROQUE");
                    pikCiudad.Items.Add("SANTA BARBARA");
                    pikCiudad.Items.Add("SANTA ROSA DE OSOS");
                    pikCiudad.Items.Add("SANTO DOMINGO");
                    pikCiudad.Items.Add("EL SANTUARIO");
                    pikCiudad.Items.Add("SEGOVIA");
                    pikCiudad.Items.Add("SONSON");
                    pikCiudad.Items.Add("SOPETRAN");
                    pikCiudad.Items.Add("TAMESIS");
                    pikCiudad.Items.Add("TARAZA");
                    pikCiudad.Items.Add("TARSO");
                    pikCiudad.Items.Add("TITIRIBI");
                    pikCiudad.Items.Add("TOLEDO");
                    pikCiudad.Items.Add("TURBO");
                    pikCiudad.Items.Add("URAMITA");
                    pikCiudad.Items.Add("URRAO");
                    pikCiudad.Items.Add("VALDIVIA");
                    pikCiudad.Items.Add("VALPARAISO");
                    pikCiudad.Items.Add("VEGACHI");
                    pikCiudad.Items.Add("VENECIA");
                    pikCiudad.Items.Add("VIGIA DEL FUERTE");
                    pikCiudad.Items.Add("YALI");
                    pikCiudad.Items.Add("YARUMAL");
                    pikCiudad.Items.Add("YOLOMBO");
                    pikCiudad.Items.Add("YONDO");
                    pikCiudad.Items.Add("ZARAGOZA");
                    
                    
                    
                    break;
                case 2://ARAUCA

                    pikCiudad.Items.Add("ARAUQUITA");
                    pikCiudad.Items.Add("CRAVO NORTE");
                    pikCiudad.Items.Add("FORTUL");
                    pikCiudad.Items.Add("PUERTO RONDON");
                    pikCiudad.Items.Add("SARAVENA");
                    pikCiudad.Items.Add("TAME");

                    break;
                case 3://ATLÁNTICO
                    pikCiudad.Items.Add("BARANOA");
                    pikCiudad.Items.Add("BARRANQUILLA");
                    pikCiudad.Items.Add("CAMPO DE LA CRUZ");
                    pikCiudad.Items.Add("GALAPA");
                    pikCiudad.Items.Add("JUAN DE ACOSTA");
                    pikCiudad.Items.Add("LURUACO");
                    pikCiudad.Items.Add("MALAMBO");
                    pikCiudad.Items.Add("MANATI");
                    pikCiudad.Items.Add("PALMAR DE VARELA");
                    pikCiudad.Items.Add("PIOJO");
                    pikCiudad.Items.Add("POLONUEVO");
                    pikCiudad.Items.Add("PONEDERA");
                    pikCiudad.Items.Add("PUERTO COLOMBIA");
                    pikCiudad.Items.Add("REPELON");
                    pikCiudad.Items.Add("SABANAGRANDE");
                    pikCiudad.Items.Add("SANTA LUCIA");
                    pikCiudad.Items.Add("SANTO TOMAS");
                    pikCiudad.Items.Add("SOLEDAD");
                    pikCiudad.Items.Add("SUAN");
                    pikCiudad.Items.Add("TUBARA");
                    pikCiudad.Items.Add("USIACURI");
                    break;
                case 4://BOGOTÁ
                    pikCiudad.Items.Add("BOGOTA, D.C");
                    break;
                case 5://BOLÍVAR
                    pikCiudad.Items.Add("ACHI");
                    pikCiudad.Items.Add("ALTOS DEL ROSARIO");
                    pikCiudad.Items.Add("ARENAL");
                    pikCiudad.Items.Add("ARJONA");
                    pikCiudad.Items.Add("ARROYOHONDO");
                    pikCiudad.Items.Add("BARRANCO DE LOBA");
                    pikCiudad.Items.Add("CALAMAR");
                    pikCiudad.Items.Add("CANTAGALLO");
                    pikCiudad.Items.Add("CICUCO");
                    pikCiudad.Items.Add("CLEMENCIA");
                    pikCiudad.Items.Add("EL CARMEN DE BOLIVAR");
                    pikCiudad.Items.Add("EL GUAMO");
                    pikCiudad.Items.Add("EL PEÑON");
                    pikCiudad.Items.Add("HATILLO DE LOBA");
                    pikCiudad.Items.Add("MAGANGUE");
                    pikCiudad.Items.Add("MAHATES");
                    pikCiudad.Items.Add("MARGARITA");
                    pikCiudad.Items.Add("MARIA LA BAJA");
                    pikCiudad.Items.Add("MONTECRISTO");
                    pikCiudad.Items.Add("MOMPOS");
                    pikCiudad.Items.Add("NOROSI");
                    pikCiudad.Items.Add("MORALES");
                    pikCiudad.Items.Add("PINILLOS");
                    pikCiudad.Items.Add("REGIDOR");
                    pikCiudad.Items.Add("RIO VIEJO");
                    pikCiudad.Items.Add("SAN CRISTOBAL");
                    pikCiudad.Items.Add("SAN ESTANISLAO");
                    pikCiudad.Items.Add("SAN FERNANDO");
                    pikCiudad.Items.Add("SAN JACINTO");
                    pikCiudad.Items.Add("SAN JACINTO DEL CAUCA");
                    pikCiudad.Items.Add("SAN JUAN NEPOMUCENO");
                    pikCiudad.Items.Add("SAN MARTIN DE LOBA");
                    pikCiudad.Items.Add("SAN PABLO");
                    pikCiudad.Items.Add("SANTA CATALINA");
                    pikCiudad.Items.Add("SANTA ROSA");
                    pikCiudad.Items.Add("SANTA ROSA DEL SUR");
                    pikCiudad.Items.Add("SIMITI");
                    pikCiudad.Items.Add("SOPLAVIENTO");
                    pikCiudad.Items.Add("TALAIGUA NUEVO");
                    pikCiudad.Items.Add("TIQUISIO");
                    pikCiudad.Items.Add("TURBACO");
                    pikCiudad.Items.Add("TURBANA");
                    pikCiudad.Items.Add("VILLANUEVA");
                    pikCiudad.Items.Add("ZAMBRANO");
                    pikCiudad.Items.Add("CARTAGENA");
                    break;
                case 6://BOYACÁ
                    pikCiudad.Items.Add("TUNJA");
                    pikCiudad.Items.Add("ALMEIDA");
                    pikCiudad.Items.Add("AQUITANIA");
                    pikCiudad.Items.Add("ARCABUCO");
                    pikCiudad.Items.Add("BELEN");
                    pikCiudad.Items.Add("BERBEO");
                    pikCiudad.Items.Add("BETEITIVA");
                    pikCiudad.Items.Add("BOAVITA");
                    pikCiudad.Items.Add("BUENAVISTA");
                    pikCiudad.Items.Add("BUSBANZA");
                    pikCiudad.Items.Add("CAMPOHERMOSO");
                    pikCiudad.Items.Add("CERINZA");
                    pikCiudad.Items.Add("CHINAVITA");
                    pikCiudad.Items.Add("CHIQUINQUIRA");
                    pikCiudad.Items.Add("CHISCAS");
                    pikCiudad.Items.Add("CHITA");
                    pikCiudad.Items.Add("CHITARAQUE");
                    pikCiudad.Items.Add("CHIVATA");
                    pikCiudad.Items.Add("CIENEGA");
                    pikCiudad.Items.Add("COMBITA");
                    pikCiudad.Items.Add("COPER");
                    pikCiudad.Items.Add("CORRALES");
                    pikCiudad.Items.Add("COVARACHIA");
                    pikCiudad.Items.Add("CUBARA");
                    pikCiudad.Items.Add("CUCAITA");
                    pikCiudad.Items.Add("CUITIVA");
                    pikCiudad.Items.Add("CHIQUIZA");
                    pikCiudad.Items.Add("CHIVOR");
                    pikCiudad.Items.Add("DUITAMA");
                    pikCiudad.Items.Add("EL COCUY");
                    pikCiudad.Items.Add("EL ESPINO");
                    pikCiudad.Items.Add("FIRAVITOBA");
                    pikCiudad.Items.Add("FLORESTA");
                    pikCiudad.Items.Add("GACHANTIVA");
                    pikCiudad.Items.Add("GAMEZA");
                    pikCiudad.Items.Add("GARAGOA");
                    pikCiudad.Items.Add("GUACAMAYAS");
                    pikCiudad.Items.Add("GUATEQUE");
                    pikCiudad.Items.Add("GUAYATA");
                    pikCiudad.Items.Add("GsICAN");
                    pikCiudad.Items.Add("IZA");
                    pikCiudad.Items.Add("JENESANO");
                    pikCiudad.Items.Add("LABRANZAGRANDE");
                    pikCiudad.Items.Add("LA CAPILLA");
                    pikCiudad.Items.Add("LA VICTORIA");
                    pikCiudad.Items.Add("LA UVITA");
                    pikCiudad.Items.Add("VILLA DE LEYVA");
                    pikCiudad.Items.Add("MACANAL");
                    pikCiudad.Items.Add("MARIPI");
                    pikCiudad.Items.Add("MIRAFLORES");
                    pikCiudad.Items.Add("MONGUA");
                    pikCiudad.Items.Add("MONGUI");
                    pikCiudad.Items.Add("MONIQUIRA");
                    pikCiudad.Items.Add("MOTAVITA");
                    pikCiudad.Items.Add("MUZO");
                    pikCiudad.Items.Add("NOBSA");
                    pikCiudad.Items.Add("NUEVO COLON");
                    pikCiudad.Items.Add("OICATA");
                    pikCiudad.Items.Add("OTANCHE");
                    pikCiudad.Items.Add("PACHAVITA");
                    pikCiudad.Items.Add("PAEZ");
                    pikCiudad.Items.Add("PAJARITO");
                    pikCiudad.Items.Add("PANQUEBA");
                    pikCiudad.Items.Add("PAUNA");
                    pikCiudad.Items.Add("PAYA");
                    pikCiudad.Items.Add("PAZ DE RIO");
                    pikCiudad.Items.Add("PESCA");
                    pikCiudad.Items.Add("PISBA");
                    pikCiudad.Items.Add("PUERTO BOYACA");
                    pikCiudad.Items.Add("QUIPAMA");
                    pikCiudad.Items.Add("RAMIRIQUI");
                    pikCiudad.Items.Add("RAQUIRA");
                    pikCiudad.Items.Add("RONDON");
                    pikCiudad.Items.Add("SABOYA");
                    pikCiudad.Items.Add("SACHICA");
                    pikCiudad.Items.Add("SAMACA");
                    pikCiudad.Items.Add("SAN EDUARDO");
                    pikCiudad.Items.Add("SAN JOSE DE PARE");
                    pikCiudad.Items.Add("SAN LUIS DE GACENO");
                    pikCiudad.Items.Add("SAN MATEO");
                    pikCiudad.Items.Add("SAN MIGUEL DE SEMA");
                    pikCiudad.Items.Add("SAN PABLO DE BORBUR");
                    pikCiudad.Items.Add("SANTANA");
                    pikCiudad.Items.Add("SANTA MARIA");
                    pikCiudad.Items.Add("SANTA ROSA DE VITERBO");
                    pikCiudad.Items.Add("SANTA SOFIA");
                    pikCiudad.Items.Add("SATIVANORTE");
                    pikCiudad.Items.Add("SATIVASUR");
                    pikCiudad.Items.Add("SIACHOQUE");
                    pikCiudad.Items.Add("SOATA");
                    pikCiudad.Items.Add("SOCOTA");
                    pikCiudad.Items.Add("SOCHA");
                    pikCiudad.Items.Add("SOGAMOSO");
                    pikCiudad.Items.Add("SOMONDOCO");
                    pikCiudad.Items.Add("SORA");
                    pikCiudad.Items.Add("SOTAQUIRA");
                    pikCiudad.Items.Add("SORACA");
                    pikCiudad.Items.Add("SUSACON");
                    pikCiudad.Items.Add("SUTAMARCHAN");
                    pikCiudad.Items.Add("SUTATENZA");
                    pikCiudad.Items.Add("TASCO");
                    pikCiudad.Items.Add("TENZA");
                    pikCiudad.Items.Add("TIBANA");
                    pikCiudad.Items.Add("TIBASOSA");
                    pikCiudad.Items.Add("TINJACA");
                    pikCiudad.Items.Add("TIPACOQUE");
                    pikCiudad.Items.Add("TOCA");
                    pikCiudad.Items.Add("TOGsI");
                    pikCiudad.Items.Add("TOPAGA");
                    pikCiudad.Items.Add("TOTA");
                    pikCiudad.Items.Add("TUNUNGUA");
                    pikCiudad.Items.Add("TURMEQUE");
                    pikCiudad.Items.Add("TUTA");
                    pikCiudad.Items.Add("TUTAZA");
                    pikCiudad.Items.Add("UMBITA");
                    pikCiudad.Items.Add("VENTAQUEMADA");
                    pikCiudad.Items.Add("VIRACACHA");
                    pikCiudad.Items.Add("ZETAQUIRA");
                    break;
                case 7://CALDAS
                    pikCiudad.Items.Add("MANIZALES");
                    pikCiudad.Items.Add("AGUADAS");
                    pikCiudad.Items.Add("ANSERMA");
                    pikCiudad.Items.Add("ARANZAZU");
                    pikCiudad.Items.Add("BELALCAZAR");
                    pikCiudad.Items.Add("CHINCHINA");
                    pikCiudad.Items.Add("FILADELFIA");
                    pikCiudad.Items.Add("LA DORADA");
                    pikCiudad.Items.Add("LA MERCED");
                    pikCiudad.Items.Add("MANZANARES");
                    pikCiudad.Items.Add("MARMATO");
                    pikCiudad.Items.Add("MARQUETALIA");
                    pikCiudad.Items.Add("MARULANDA");
                    pikCiudad.Items.Add("NEIRA");
                    pikCiudad.Items.Add("NORCASIA");
                    pikCiudad.Items.Add("PACORA");
                    pikCiudad.Items.Add("PALESTINA");
                    pikCiudad.Items.Add("PENSILVANIA");
                    pikCiudad.Items.Add("RIOSUCIO");
                    pikCiudad.Items.Add("SALAMINA");
                    pikCiudad.Items.Add("SAMANA");
                    pikCiudad.Items.Add("SAN JOSE");
                    pikCiudad.Items.Add("SUPIA");
                    pikCiudad.Items.Add("VICTORIA");
                    pikCiudad.Items.Add("VILLAMARIA");
                    pikCiudad.Items.Add("VITERBO");
                    break;
                case 8://CAQUETÁ
                    pikCiudad.Items.Add("FLORENCIA");
                    pikCiudad.Items.Add("ALBANIA");
                    pikCiudad.Items.Add("BELEN DE LOS ANDAQUIES");
                    pikCiudad.Items.Add("CARTAGENA DEL CHAIRA");
                    pikCiudad.Items.Add("CURILLO");
                    pikCiudad.Items.Add("EL DONCELLO");
                    pikCiudad.Items.Add("EL PAUJIL");
                    pikCiudad.Items.Add("LA MONTAÑITA");
                    pikCiudad.Items.Add("MILAN");
                    pikCiudad.Items.Add("MORELIA");
                    pikCiudad.Items.Add("PUERTO RICO");
                    pikCiudad.Items.Add("SAN JOSE DEL FRAGUA");
                    pikCiudad.Items.Add("SAN VICENTE DEL CAGUAN");
                    pikCiudad.Items.Add("SOLANO");
                    pikCiudad.Items.Add("SOLITA");
                    break;
                case 9://CASANARE
                    pikCiudad.Items.Add("YOPAL");
                    pikCiudad.Items.Add("AGUAZUL");
                    pikCiudad.Items.Add("CHAMEZA");
                    pikCiudad.Items.Add("HATO COROZAL");
                    pikCiudad.Items.Add("LA SALINA");
                    pikCiudad.Items.Add("MANI");
                    pikCiudad.Items.Add("MONTERREY");
                    pikCiudad.Items.Add("NUNCHIA");
                    pikCiudad.Items.Add("OROCUE");
                    pikCiudad.Items.Add("PAZ DE ARIPORO");
                    pikCiudad.Items.Add("PORE");
                    pikCiudad.Items.Add("RECETOR");
                    pikCiudad.Items.Add("SACAMA");
                    pikCiudad.Items.Add("SAN LUIS DE PALENQUE");
                    pikCiudad.Items.Add("TAMARA");
                    pikCiudad.Items.Add("TAURAMENA");
                    pikCiudad.Items.Add("TRINIDAD");
                    break;
                case 10://CAUCA
                    pikCiudad.Items.Add("ALMAGUER");
                    pikCiudad.Items.Add("BALBOA");
                    pikCiudad.Items.Add("BUENOS AIRES");
                    pikCiudad.Items.Add("CAJIBIO");
                    pikCiudad.Items.Add("CALDONO");
                    pikCiudad.Items.Add("CALOTO");
                    pikCiudad.Items.Add("CORINTO");
                    pikCiudad.Items.Add("EL TAMBO");
                    pikCiudad.Items.Add("GUACHENE");
                    pikCiudad.Items.Add("GUAPI");
                    pikCiudad.Items.Add("INZA");
                    pikCiudad.Items.Add("JAMBALO");
                    pikCiudad.Items.Add("LA SIERRA");
                    pikCiudad.Items.Add("LA VEGA");
                    pikCiudad.Items.Add("LOPEZ");
                    pikCiudad.Items.Add("MERCADERES");
                    pikCiudad.Items.Add("MIRANDA");
                    pikCiudad.Items.Add("PADILLA");
                    pikCiudad.Items.Add("PATIA");
                    pikCiudad.Items.Add("PIAMONTE");
                    pikCiudad.Items.Add("PIENDAMO");
                    pikCiudad.Items.Add("PUERTO TEJADA");
                    pikCiudad.Items.Add("PURACE");
                    pikCiudad.Items.Add("ROSAS");
                    pikCiudad.Items.Add("SAN SEBASTIAN");
                    pikCiudad.Items.Add("SANTANDER DE QUILICHAO");
                    pikCiudad.Items.Add("SILVIA");
                    pikCiudad.Items.Add("SOTARA");
                    pikCiudad.Items.Add("SUAREZ");
                    pikCiudad.Items.Add("TIMBIO");
                    pikCiudad.Items.Add("TIMBIQUI");
                    pikCiudad.Items.Add("TORIBIO");
                    pikCiudad.Items.Add("TOTORO");
                    pikCiudad.Items.Add("VILLA RICA");
                    pikCiudad.Items.Add("POPAYAN");
                    break;
                case 11://CESAR
                    pikCiudad.Items.Add("VALLEDUPAR");
                    pikCiudad.Items.Add("AGUACHICA");
                    pikCiudad.Items.Add("AGUSTIN CODAZZI");
                    pikCiudad.Items.Add("ASTREA");
                    pikCiudad.Items.Add("BECERRIL");
                    pikCiudad.Items.Add("BOSCONIA");
                    pikCiudad.Items.Add("CHIMICHAGUA");
                    pikCiudad.Items.Add("CHIRIGUANA");
                    pikCiudad.Items.Add("CURUMANI");
                    pikCiudad.Items.Add("EL COPEY");
                    pikCiudad.Items.Add("EL PASO");
                    pikCiudad.Items.Add("GAMARRA");
                    pikCiudad.Items.Add("GONZALEZ");
                    pikCiudad.Items.Add("LA GLORIA");
                    pikCiudad.Items.Add("LA JAGUA DE IBIRICO");
                    pikCiudad.Items.Add("MANAURE");
                    pikCiudad.Items.Add("PAILITAS");
                    pikCiudad.Items.Add("PELAYA");
                    pikCiudad.Items.Add("PUEBLO BELLO");
                    pikCiudad.Items.Add("RIO DE ORO");
                    pikCiudad.Items.Add("LA PAZ");
                    pikCiudad.Items.Add("SAN ALBERTO");
                    pikCiudad.Items.Add("SAN DIEGO");
                    pikCiudad.Items.Add("SAN MARTIN");
                    pikCiudad.Items.Add("TAMALAMEQUE");
                    break;
                case 12://CHOCÓ
                    pikCiudad.Items.Add("QUIBDO");
                    pikCiudad.Items.Add("ACANDI");
                    pikCiudad.Items.Add("ALTO BAUDO");
                    pikCiudad.Items.Add("ATRATO");
                    pikCiudad.Items.Add("BAGADO");
                    pikCiudad.Items.Add("BAHIA SOLANO");
                    pikCiudad.Items.Add("BAJO BAUDO");
                    pikCiudad.Items.Add("BOJAYA");
                    pikCiudad.Items.Add("EL CANTON DEL SAN PABLO");
                    pikCiudad.Items.Add("CARMEN DEL DARIEN");
                    pikCiudad.Items.Add("CERTEGUI");
                    pikCiudad.Items.Add("CONDOTO");
                    pikCiudad.Items.Add("EL CARMEN DE ATRATO");
                    pikCiudad.Items.Add("EL LITORAL DEL SAN JUAN");
                    pikCiudad.Items.Add("ISTMINA");
                    pikCiudad.Items.Add("JURADO");
                    pikCiudad.Items.Add("LLORO");
                    pikCiudad.Items.Add("MEDIO ATRATO");
                    pikCiudad.Items.Add("MEDIO BAUDO");
                    pikCiudad.Items.Add("MEDIO SAN JUAN");
                    pikCiudad.Items.Add("NOVITA");
                    pikCiudad.Items.Add("NUQUI");
                    pikCiudad.Items.Add("RIO IRO");
                    pikCiudad.Items.Add("RIO QUITO");
                    pikCiudad.Items.Add("SAN JOSE DEL PALMAR");
                    pikCiudad.Items.Add("SIPI");
                    pikCiudad.Items.Add("TADO");
                    pikCiudad.Items.Add("UNGUIA");
                    pikCiudad.Items.Add("UNION PANAMERICANA");
                    break;
                case 13://CÓRDOOBA
                    pikCiudad.Items.Add("AYAPEL");
                    pikCiudad.Items.Add("CANALETE");
                    pikCiudad.Items.Add("CERETE");
                    pikCiudad.Items.Add("CHIMA");
                    pikCiudad.Items.Add("CHINU");
                    pikCiudad.Items.Add("CIENAGA DE ORO");
                    pikCiudad.Items.Add("COTORRA");
                    pikCiudad.Items.Add("LA APARTADA");
                    pikCiudad.Items.Add("LORICA");
                    pikCiudad.Items.Add("LOS CORDOBAS");
                    pikCiudad.Items.Add("MOMIL");
                    pikCiudad.Items.Add("MONTELIBANO");
                    pikCiudad.Items.Add("MOÑITOS");
                    pikCiudad.Items.Add("PLANETA RICA");
                    pikCiudad.Items.Add("PUEBLO NUEVO");
                    pikCiudad.Items.Add("PUERTO ESCONDIDO");
                    pikCiudad.Items.Add("PUERTO LIBERTADOR");
                    pikCiudad.Items.Add("PURISIMA");
                    pikCiudad.Items.Add("SAHAGUN");
                    pikCiudad.Items.Add("SAN ANDRES SOTAVENTO");
                    pikCiudad.Items.Add("SAN ANTERO");
                    pikCiudad.Items.Add("SAN BERNARDO DEL VIENTO");
                    pikCiudad.Items.Add("SAN PELAYO");
                    pikCiudad.Items.Add("TIERRALTA");
                    pikCiudad.Items.Add("VALENCIA");
                    break;
                case 14://CUNDINAMARCA
                    pikCiudad.Items.Add("AGUA DE DIOS");
                    pikCiudad.Items.Add("ALBAN");
                    pikCiudad.Items.Add("ANAPOIMA");
                    pikCiudad.Items.Add("ANOLAIMA");
                    pikCiudad.Items.Add("ARBELAEZ");
                    pikCiudad.Items.Add("BELTRAN");
                    pikCiudad.Items.Add("BITUIMA");
                    pikCiudad.Items.Add("BOJACA");
                    pikCiudad.Items.Add("CABRERA");
                    pikCiudad.Items.Add("CACHIPAY");
                    pikCiudad.Items.Add("CAPARRAPI");
                    pikCiudad.Items.Add("CAQUEZA");
                    pikCiudad.Items.Add("CARMEN DE CARUPA");
                    pikCiudad.Items.Add("CHAGUANI");
                    pikCiudad.Items.Add("CHIA");
                    pikCiudad.Items.Add("CHIPAQUE");
                    pikCiudad.Items.Add("CHOACHI");
                    pikCiudad.Items.Add("CHOCONTA");
                    pikCiudad.Items.Add("COGUA");
                    pikCiudad.Items.Add("CUCUNUBA");
                    pikCiudad.Items.Add("EL COLEGIO");
                    pikCiudad.Items.Add("EL ROSAL");
                    pikCiudad.Items.Add("FACATATIVA");
                    pikCiudad.Items.Add("FOMEQUE");
                    pikCiudad.Items.Add("FOSCA");
                    pikCiudad.Items.Add("FUNZA");
                    pikCiudad.Items.Add("FUQUENE");
                    pikCiudad.Items.Add("GACHALA");
                    pikCiudad.Items.Add("GACHANCIPA");
                    pikCiudad.Items.Add("GACHETA");
                    pikCiudad.Items.Add("GAMA");
                    pikCiudad.Items.Add("GIRARDOT");
                    pikCiudad.Items.Add("GUACHETA");
                    pikCiudad.Items.Add("GUADUAS");
                    pikCiudad.Items.Add("GUASCA");
                    pikCiudad.Items.Add("GUATAQUI");
                    pikCiudad.Items.Add("GUATAVITA");
                    pikCiudad.Items.Add("GUAYABAL DE SIQUIMA");
                    pikCiudad.Items.Add("GUAYABETAL");
                    pikCiudad.Items.Add("GUTIERREZ");
                    pikCiudad.Items.Add("JERUSALEN");
                    pikCiudad.Items.Add("JUNIN");
                    pikCiudad.Items.Add("LA PALMA");
                    pikCiudad.Items.Add("LA PEÑA");
                    pikCiudad.Items.Add("LENGUAZAQUE");
                    pikCiudad.Items.Add("MACHETA");
                    pikCiudad.Items.Add("MANTA");
                    pikCiudad.Items.Add("MEDINA");
                    pikCiudad.Items.Add("MOSQUERA");
                    pikCiudad.Items.Add("NEMOCON");
                    pikCiudad.Items.Add("NILO");
                    pikCiudad.Items.Add("NIMAIMA");
                    pikCiudad.Items.Add("NOCAIMA");
                    pikCiudad.Items.Add("PACHO");
                    pikCiudad.Items.Add("PAIME");
                    pikCiudad.Items.Add("PANDI");
                    pikCiudad.Items.Add("PARATEBUENO");
                    pikCiudad.Items.Add("PASCA");
                    pikCiudad.Items.Add("PUERTO SALGAR");
                    pikCiudad.Items.Add("PULI");
                    pikCiudad.Items.Add("QUEBRADANEGRA");
                    pikCiudad.Items.Add("QUETAME");
                    pikCiudad.Items.Add("QUIPILE");
                    pikCiudad.Items.Add("APULO");
                    pikCiudad.Items.Add("RICAURTE");
                    pikCiudad.Items.Add("SAN ANTONIO DEL TEQUENDAMA");
                    pikCiudad.Items.Add("SAN BERNARDO");
                    pikCiudad.Items.Add("SAN CAYETANO");
                    pikCiudad.Items.Add("SAN JUAN DE RIO SECO");
                    pikCiudad.Items.Add("SASAIMA");
                    pikCiudad.Items.Add("SESQUILE");
                    pikCiudad.Items.Add("SIBATE");
                    pikCiudad.Items.Add("SILVANIA");
                    pikCiudad.Items.Add("SIMIJACA");
                    pikCiudad.Items.Add("SOACHA");
                    pikCiudad.Items.Add("SOPO");
                    pikCiudad.Items.Add("SUBACHOQUE");
                    pikCiudad.Items.Add("SUESCA");
                    pikCiudad.Items.Add("SUPATA");
                    pikCiudad.Items.Add("SUSA");
                    pikCiudad.Items.Add("SUTATAUSA");
                    pikCiudad.Items.Add("TAUSA");
                    pikCiudad.Items.Add("TENA");
                    pikCiudad.Items.Add("TIBACUY");
                    pikCiudad.Items.Add("TIBIRITA");
                    pikCiudad.Items.Add("TOCAIMA");
                    pikCiudad.Items.Add("TOCANCIPA");
                    pikCiudad.Items.Add("TOPAIPI");
                    pikCiudad.Items.Add("UBALA");
                    pikCiudad.Items.Add("UBAQUE");
                    pikCiudad.Items.Add("VILLA DE SAN DIEGO DE UBATE");
                    pikCiudad.Items.Add("UNE");
                    pikCiudad.Items.Add("UTICA");
                    pikCiudad.Items.Add("VERGARA");
                    pikCiudad.Items.Add("VIANI");
                    pikCiudad.Items.Add("VILLAGOMEZ");
                    pikCiudad.Items.Add("VILLAPINZON");
                    pikCiudad.Items.Add("VILLETA");
                    pikCiudad.Items.Add("VIOTA");
                    pikCiudad.Items.Add("YACOPI");
                    pikCiudad.Items.Add("ZIPACON");
                    pikCiudad.Items.Add("ZIPAQUIRA");
                    pikCiudad.Items.Add("CAJICA");
                    pikCiudad.Items.Add("LA VEGA.");
                    pikCiudad.Items.Add("MADRID");
                    pikCiudad.Items.Add("LA CALERA");
                    pikCiudad.Items.Add("COTA");
                    pikCiudad.Items.Add("FUSAGASUGÁ");
                    break;
                case 15://GUAINÍA
                    pikCiudad.Items.Add("INIRIDA");
                    pikCiudad.Items.Add("BARRANCO MINAS");
                    pikCiudad.Items.Add("MAPIRIPANA");
                    pikCiudad.Items.Add("SAN FELIPE");
                    pikCiudad.Items.Add("LA GUADALUPE");
                    pikCiudad.Items.Add("CACAHUAL");
                    pikCiudad.Items.Add("PANA PANA");
                    pikCiudad.Items.Add("MORICHAL");
                    break;
                case 16://GUAVIARE    
                    pikCiudad.Items.Add("SAN JOSE DEL GUAVIARE");
                    pikCiudad.Items.Add("EL RETORNO");
                    break;
                case 17://HUILA
                    pikCiudad.Items.Add("ACEVEDO");
                    pikCiudad.Items.Add("AGRADO");
                    pikCiudad.Items.Add("AIPE");
                    pikCiudad.Items.Add("ALGECIRAS");
                    pikCiudad.Items.Add("ALTAMIRA");
                    pikCiudad.Items.Add("BARAYA");
                    pikCiudad.Items.Add("CAMPOALEGRE");
                    pikCiudad.Items.Add("COLOMBIA");
                    pikCiudad.Items.Add("ELIAS");
                    pikCiudad.Items.Add("GARZON");
                    pikCiudad.Items.Add("GIGANTE");
                    pikCiudad.Items.Add("HOBO");
                    pikCiudad.Items.Add("IQUIRA");
                    pikCiudad.Items.Add("ISNOS");
                    pikCiudad.Items.Add("LA ARGENTINA");
                    pikCiudad.Items.Add("LA PLATA");
                    pikCiudad.Items.Add("NATAGA");
                    pikCiudad.Items.Add("OPORAPA");
                    pikCiudad.Items.Add("PAICOL");
                    pikCiudad.Items.Add("PALERMO");
                    pikCiudad.Items.Add("PITAL");
                    pikCiudad.Items.Add("PITALITO");
                    pikCiudad.Items.Add("RIVERA");
                    pikCiudad.Items.Add("SALADOBLANCO");
                    pikCiudad.Items.Add("SAN AGUSTIN");
                    pikCiudad.Items.Add("SUAZA");
                    pikCiudad.Items.Add("TARQUI");
                    pikCiudad.Items.Add("TESALIA");
                    pikCiudad.Items.Add("TELLO");
                    pikCiudad.Items.Add("TERUEL");
                    pikCiudad.Items.Add("TIMANA");
                    pikCiudad.Items.Add("VILLAVIEJA");
                    pikCiudad.Items.Add("YAGUARA");
                    break;
                case 18://LA GUAJIRA
                    pikCiudad.Items.Add("RIOHACHA");
                    pikCiudad.Items.Add("BARRANCAS");
                    pikCiudad.Items.Add("DIBULLA");
                    pikCiudad.Items.Add("DISTRACCION");
                    pikCiudad.Items.Add("EL MOLINO");
                    pikCiudad.Items.Add("FONSECA");
                    pikCiudad.Items.Add("HATONUEVO");
                    pikCiudad.Items.Add("LA JAGUA DEL PILAR");
                    pikCiudad.Items.Add("MAICAO");
                    pikCiudad.Items.Add("SAN JUAN DEL CESAR");
                    pikCiudad.Items.Add("URIBIA");
                    pikCiudad.Items.Add("URUMITA");
                    break;
                case 19://MAGDALENA
                    pikCiudad.Items.Add("ALGARROBO");
                    pikCiudad.Items.Add("ARACATACA");
                    pikCiudad.Items.Add("ARIGUANI");
                    pikCiudad.Items.Add("CERRO SAN ANTONIO");
                    pikCiudad.Items.Add("CHIBOLO");
                    pikCiudad.Items.Add("CIENAGA");
                    pikCiudad.Items.Add("EL BANCO");
                    pikCiudad.Items.Add("EL PIÑON");
                    pikCiudad.Items.Add("EL RETEN");
                    pikCiudad.Items.Add("FUNDACION");
                    pikCiudad.Items.Add("GUAMAL");
                    pikCiudad.Items.Add("NUEVA GRANADA");
                    pikCiudad.Items.Add("PEDRAZA");
                    pikCiudad.Items.Add("PIJIÑO DEL CARMEN");
                    pikCiudad.Items.Add("PIVIJAY");
                    pikCiudad.Items.Add("PLATO");
                    pikCiudad.Items.Add("PUEBLOVIEJO");
                    pikCiudad.Items.Add("REMOLINO");
                    pikCiudad.Items.Add("SABANAS DE SAN ANGEL");
                    pikCiudad.Items.Add("SAN SEBASTIAN DE BUENAVISTA");
                    pikCiudad.Items.Add("SAN ZENON");
                    pikCiudad.Items.Add("SANTA ANA");
                    pikCiudad.Items.Add("SANTA BARBARA DE PINTO");
                    pikCiudad.Items.Add("SITIONUEVO");
                    pikCiudad.Items.Add("TENERIFE");
                    pikCiudad.Items.Add("ZAPAYAN");
                    pikCiudad.Items.Add("ZONA BANANERA");
                    pikCiudad.Items.Add("SANTA MARTA");
                    break;
                case 20://META
                    pikCiudad.Items.Add("VILLAVICENCIO");
                    pikCiudad.Items.Add("ACACIAS");
                    pikCiudad.Items.Add("BARRANCA DE UPIA");
                    pikCiudad.Items.Add("CABUYARO");
                    pikCiudad.Items.Add("CASTILLA LA NUEVA");
                    pikCiudad.Items.Add("CUBARRAL");
                    pikCiudad.Items.Add("CUMARAL");
                    pikCiudad.Items.Add("EL CALVARIO");
                    pikCiudad.Items.Add("EL CASTILLO");
                    pikCiudad.Items.Add("EL DORADO");
                    pikCiudad.Items.Add("FUENTE DE ORO");
                    pikCiudad.Items.Add("MAPIRIPAN");
                    pikCiudad.Items.Add("MESETAS");
                    pikCiudad.Items.Add("LA MACARENA");
                    pikCiudad.Items.Add("URIBE");
                    pikCiudad.Items.Add("LEJANIAS");
                    pikCiudad.Items.Add("PUERTO CONCORDIA");
                    pikCiudad.Items.Add("PUERTO GAITAN");
                    pikCiudad.Items.Add("PUERTO LOPEZ");
                    pikCiudad.Items.Add("PUERTO LLERAS");
                    pikCiudad.Items.Add("RESTREPO");
                    pikCiudad.Items.Add("SAN CARLOS DE GUAROA");
                    pikCiudad.Items.Add("SAN JUAN DE ARAMA");
                    pikCiudad.Items.Add("SAN JUANITO");
                    pikCiudad.Items.Add("VISTAHERMOSA");
                    break;
                case 21://NARIÑO
                    pikCiudad.Items.Add("PASTO");
                    pikCiudad.Items.Add("ALDANA");
                    pikCiudad.Items.Add("ANCUYA");
                    pikCiudad.Items.Add("ARBOLEDA");
                    pikCiudad.Items.Add("BARBACOAS");
                    pikCiudad.Items.Add("BUESACO");
                    pikCiudad.Items.Add("COLON");
                    pikCiudad.Items.Add("CONSACA");
                    pikCiudad.Items.Add("CONTADERO");
                    pikCiudad.Items.Add("CUASPUD");
                    pikCiudad.Items.Add("CUMBAL");
                    pikCiudad.Items.Add("CUMBITARA");
                    pikCiudad.Items.Add("CHACHAGsI");
                    pikCiudad.Items.Add("EL CHARCO");
                    pikCiudad.Items.Add("EL PEÑOL");
                    pikCiudad.Items.Add("EL ROSARIO");
                    pikCiudad.Items.Add("EL TABLON DE GOMEZ");
                    pikCiudad.Items.Add("FUNES");
                    pikCiudad.Items.Add("GUACHUCAL");
                    pikCiudad.Items.Add("GUAITARILLA");
                    pikCiudad.Items.Add("GUALMATAN");
                    pikCiudad.Items.Add("ILES");
                    pikCiudad.Items.Add("IMUES");
                    pikCiudad.Items.Add("IPIALES");
                    pikCiudad.Items.Add("LA CRUZ");
                    break;
                case 22://NORTE DE SANTANDER

                    pikCiudad.Items.Add("CUCUTA");
                    pikCiudad.Items.Add("ABREGO");
                    pikCiudad.Items.Add("ARBOLEDAS");
                    pikCiudad.Items.Add("BOCHALEMA");
                    pikCiudad.Items.Add("BUCARASICA");
                    pikCiudad.Items.Add("CACOTA");
                    pikCiudad.Items.Add("CACHIRA");
                    pikCiudad.Items.Add("CHINACOTA");
                    pikCiudad.Items.Add("CHITAGA");
                    pikCiudad.Items.Add("CONVENCION");
                    pikCiudad.Items.Add("CUCUTILLA");
                    pikCiudad.Items.Add("DURANIA");
                    pikCiudad.Items.Add("EL CARMEN");
                    pikCiudad.Items.Add("EL TARRA");
                    pikCiudad.Items.Add("EL ZULIA");
                    pikCiudad.Items.Add("GRAMALOTE");
                    pikCiudad.Items.Add("HACARI");
                    pikCiudad.Items.Add("HERRAN");
                    pikCiudad.Items.Add("LABATECA");
                    pikCiudad.Items.Add("LA ESPERANZA");
                    pikCiudad.Items.Add("LA PLAYA");
                    pikCiudad.Items.Add("LOS PATIOS");
                    pikCiudad.Items.Add("LOURDES");
                    pikCiudad.Items.Add("MUTISCUA");
                    pikCiudad.Items.Add("OCAÑA");
                    break;
                case 23://PUTUMAYO
                    pikCiudad.Items.Add("MOCOA");
                    pikCiudad.Items.Add("ORITO");
                    pikCiudad.Items.Add("PUERTO ASIS");
                    pikCiudad.Items.Add("PUERTO CAICEDO");
                    pikCiudad.Items.Add("PUERTO GUZMAN");
                    pikCiudad.Items.Add("LEGUIZAMO");
                    pikCiudad.Items.Add("SIBUNDOY");
                    pikCiudad.Items.Add("VALLE DEL GUAMUEZ");
                    pikCiudad.Items.Add("VILLAGARZON");
                    break;
                case 24://QUINDIO
                    pikCiudad.Items.Add("ARMENIA");
                    pikCiudad.Items.Add("CALARCA");
                    pikCiudad.Items.Add("CIRCASIA");
                    pikCiudad.Items.Add("FILANDIA");
                    pikCiudad.Items.Add("GENOVA");
                    pikCiudad.Items.Add("LA TEBAIDA");
                    pikCiudad.Items.Add("MONTENEGRO");
                    pikCiudad.Items.Add("PIJAO");
                    pikCiudad.Items.Add("QUIMBAYA");
                    pikCiudad.Items.Add("SALENTO");
                    break;
                case 25://RISARALDA
                    pikCiudad.Items.Add("PEREIRA");
                    pikCiudad.Items.Add("APIA");
                    pikCiudad.Items.Add("BELEN DE UMBRIA");
                    pikCiudad.Items.Add("DOSQUEBRADAS");
                    pikCiudad.Items.Add("GUATICA");
                    pikCiudad.Items.Add("LA CELIA");
                    pikCiudad.Items.Add("LA VIRGINIA");
                    pikCiudad.Items.Add("MARSELLA");
                    pikCiudad.Items.Add("MISTRATO");
                    pikCiudad.Items.Add("PUEBLO RICO");
                    pikCiudad.Items.Add("QUINCHIA");
                    pikCiudad.Items.Add("SANTA ROSA DE CABAL");
                    pikCiudad.Items.Add("SANTUARIO");
                    break;
                case 26://SAN ANDRÉS Y PROVIDENCIA
                    pikCiudad.Items.Add("SAN ANDRES");
                    pikCiudad.Items.Add("PROVIDENCIA");
                    break;
                case 27://SANTANDER
                    pikCiudad.Items.Add("BUCARAMANGA");
                    pikCiudad.Items.Add("AGUADA");
                    pikCiudad.Items.Add("ARATOCA");
                    pikCiudad.Items.Add("BARICHARA");
                    pikCiudad.Items.Add("BARRANCABERMEJA");
                    pikCiudad.Items.Add("CALIFORNIA");
                    pikCiudad.Items.Add("CAPITANEJO");
                    pikCiudad.Items.Add("CARCASI");
                    pikCiudad.Items.Add("CEPITA");
                    pikCiudad.Items.Add("CERRITO");
                    pikCiudad.Items.Add("CHARALA");
                    pikCiudad.Items.Add("CHARTA");
                    pikCiudad.Items.Add("CHIPATA");
                    pikCiudad.Items.Add("CIMITARRA");
                    pikCiudad.Items.Add("CONFINES");
                    pikCiudad.Items.Add("CONTRATACION");
                    pikCiudad.Items.Add("COROMORO");
                    pikCiudad.Items.Add("CURITI");
                    pikCiudad.Items.Add("EL CARMEN DE CHUCURI");
                    pikCiudad.Items.Add("EL GUACAMAYO");
                    pikCiudad.Items.Add("EL PLAYON");
                    pikCiudad.Items.Add("ENCINO");
                    pikCiudad.Items.Add("ENCISO");
                    pikCiudad.Items.Add("FLORIAN");
                    pikCiudad.Items.Add("FLORIDABLANCA");
                    pikCiudad.Items.Add("GALAN");
                    pikCiudad.Items.Add("GAMBITA");
                    pikCiudad.Items.Add("GIRON");
                    pikCiudad.Items.Add("GUACA");
                    pikCiudad.Items.Add("GUAPOTA");
                    pikCiudad.Items.Add("GUAVATA");
                    pikCiudad.Items.Add("GsEPSA");
                    pikCiudad.Items.Add("HATO");
                    pikCiudad.Items.Add("JESUS MARIA");
                    pikCiudad.Items.Add("JORDAN");
                    pikCiudad.Items.Add("LA BELLEZA");
                    pikCiudad.Items.Add("LANDAZURI");
                    pikCiudad.Items.Add("LEBRIJA");
                    pikCiudad.Items.Add("LOS SANTOS");
                    pikCiudad.Items.Add("MACARAVITA");
                    pikCiudad.Items.Add("MALAGA");
                    pikCiudad.Items.Add("MATANZA");
                    pikCiudad.Items.Add("MOGOTES");
                    pikCiudad.Items.Add("MOLAGAVITA");
                    pikCiudad.Items.Add("OCAMONTE");
                    pikCiudad.Items.Add("OIBA");
                    pikCiudad.Items.Add("ONZAGA");
                    pikCiudad.Items.Add("PALMAR");
                    pikCiudad.Items.Add("PALMAS DEL SOCORRO");
                    pikCiudad.Items.Add("PARAMO");
                    pikCiudad.Items.Add("PIEDECUESTA");
                    pikCiudad.Items.Add("PINCHOTE");
                    pikCiudad.Items.Add("PUENTE NACIONAL");
                    pikCiudad.Items.Add("PUERTO PARRA");
                    pikCiudad.Items.Add("PUERTO WILCHES");
                    pikCiudad.Items.Add("SABANA DE TORRES");
                    pikCiudad.Items.Add("SAN ANDRES");
                    pikCiudad.Items.Add("SAN BENITO");
                    pikCiudad.Items.Add("SAN GIL");
                    pikCiudad.Items.Add("SAN JOAQUIN");
                    pikCiudad.Items.Add("SAN JOSE DE MIRANDA");
                    pikCiudad.Items.Add("SAN MIGUEL");
                    pikCiudad.Items.Add("SAN VICENTE DE CHUCURI");
                    pikCiudad.Items.Add("SANTA HELENA DEL OPON");
                    pikCiudad.Items.Add("SIMACOTA");
                    pikCiudad.Items.Add("SOCORRO");
                    pikCiudad.Items.Add("SUAITA");
                    pikCiudad.Items.Add("SURATA");
                    pikCiudad.Items.Add("TONA");
                    pikCiudad.Items.Add("VALLE DE SAN JOSE");
                    pikCiudad.Items.Add("VELEZ");
                    pikCiudad.Items.Add("VETAS");
                    pikCiudad.Items.Add("ZAPATOCA");
                    break;
                case 28://SUCRE
                    pikCiudad.Items.Add("SINCELEJO");
                    pikCiudad.Items.Add("CAIMITO");
                    pikCiudad.Items.Add("COLOSO");
                    pikCiudad.Items.Add("COROZAL");
                    pikCiudad.Items.Add("COVEÑAS");
                    pikCiudad.Items.Add("CHALAN");
                    pikCiudad.Items.Add("EL ROBLE");
                    pikCiudad.Items.Add("GALERAS");
                    pikCiudad.Items.Add("GUARANDA");
                    pikCiudad.Items.Add("LOS PALMITOS");
                    pikCiudad.Items.Add("MAJAGUAL");
                    pikCiudad.Items.Add("MORROA");
                    pikCiudad.Items.Add("OVEJAS");
                    pikCiudad.Items.Add("PALMITO");
                    pikCiudad.Items.Add("SAMPUES");
                    pikCiudad.Items.Add("SAN BENITO ABAD");
                    pikCiudad.Items.Add("SAN JUAN DE BETULIA");
                    pikCiudad.Items.Add("SAN MARCOS");
                    pikCiudad.Items.Add("SAN ONOFRE");
                    pikCiudad.Items.Add("SAN LUIS DE SINCE");
                    pikCiudad.Items.Add("SANTIAGO DE TOLU");
                    pikCiudad.Items.Add("TOLU VIEJO");
                    break;
                case 29://TOLIMA
                    pikCiudad.Items.Add("IBAGUE");
                    pikCiudad.Items.Add("ALPUJARRA");
                    pikCiudad.Items.Add("ALVARADO");
                    pikCiudad.Items.Add("AMBALEMA");
                    pikCiudad.Items.Add("ANZOATEGUI");
                    pikCiudad.Items.Add("ARMERO");
                    pikCiudad.Items.Add("ATACO");
                    pikCiudad.Items.Add("CAJAMARCA");
                    pikCiudad.Items.Add("CARMEN DE APICALA");
                    pikCiudad.Items.Add("CASABIANCA");
                    pikCiudad.Items.Add("CHAPARRAL");
                    pikCiudad.Items.Add("COELLO");
                    pikCiudad.Items.Add("COYAIMA");
                    pikCiudad.Items.Add("CUNDAY");
                    pikCiudad.Items.Add("DOLORES");
                    pikCiudad.Items.Add("ESPINAL");
                    pikCiudad.Items.Add("FALAN");
                    pikCiudad.Items.Add("FLANDES");
                    pikCiudad.Items.Add("FRESNO");
                    pikCiudad.Items.Add("GUAMO");
                    pikCiudad.Items.Add("HERVEO");
                    pikCiudad.Items.Add("HONDA");
                    pikCiudad.Items.Add("ICONONZO");
                    pikCiudad.Items.Add("LERIDA");
                    pikCiudad.Items.Add("LIBANO");
                    pikCiudad.Items.Add("MARIQUITA");
                    pikCiudad.Items.Add("MELGAR");
                    pikCiudad.Items.Add("MURILLO");
                    pikCiudad.Items.Add("NATAGAIMA");
                    pikCiudad.Items.Add("ORTEGA");
                    pikCiudad.Items.Add("PALOCABILDO");
                    pikCiudad.Items.Add("PIEDRAS");
                    pikCiudad.Items.Add("PLANADAS");
                    pikCiudad.Items.Add("PURIFICACION");
                    pikCiudad.Items.Add("RIOBLANCO");
                    pikCiudad.Items.Add("RONCESVALLES");
                    pikCiudad.Items.Add("ROVIRA");
                    pikCiudad.Items.Add("SALDAÑA");
                    pikCiudad.Items.Add("SAN ANTONIO");
                    pikCiudad.Items.Add("SANTA ISABEL");
                    pikCiudad.Items.Add("VALLE DE SAN JUAN");
                    pikCiudad.Items.Add("VENADILLO");
                    pikCiudad.Items.Add("VILLAHERMOSA");
                    pikCiudad.Items.Add("VILLARRICA");
                    break;
                case 30://VALLE DEL CAUCA
                    pikCiudad.Items.Add("ALCALA");
                    pikCiudad.Items.Add("ANDALUCIA");
                    pikCiudad.Items.Add("ANSERMANUEVO");
                    pikCiudad.Items.Add("BUENAVENTURA");
                    pikCiudad.Items.Add("GUADALAJARA DE BUGA");
                    pikCiudad.Items.Add("BUGALAGRANDE");
                    pikCiudad.Items.Add("CAICEDONIA");
                    pikCiudad.Items.Add("CALIMA");
                    pikCiudad.Items.Add("CARTAGO");
                    pikCiudad.Items.Add("DAGUA");
                    pikCiudad.Items.Add("EL AGUILA");
                    pikCiudad.Items.Add("EL CAIRO");
                    pikCiudad.Items.Add("EL CERRITO");
                    pikCiudad.Items.Add("EL DOVIO");
                    pikCiudad.Items.Add("FLORIDA");
                    pikCiudad.Items.Add("GINEBRA");
                    pikCiudad.Items.Add("GUACARI");
                    pikCiudad.Items.Add("LA CUMBRE");
                    pikCiudad.Items.Add("OBANDO");
                    pikCiudad.Items.Add("PALMIRA");
                    pikCiudad.Items.Add("PRADERA");
                    pikCiudad.Items.Add("RIOFRIO");
                    pikCiudad.Items.Add("ROLDANILLO");
                    pikCiudad.Items.Add("SEVILLA");
                    pikCiudad.Items.Add("TORO");
                    pikCiudad.Items.Add("TRUJILLO");
                    pikCiudad.Items.Add("TULUA");
                    pikCiudad.Items.Add("ULLOA");
                    pikCiudad.Items.Add("VERSALLES");
                    pikCiudad.Items.Add("VIJES");
                    pikCiudad.Items.Add("YOTOCO");
                    pikCiudad.Items.Add("YUMBO");
                    pikCiudad.Items.Add("ZARZAL");
                    pikCiudad.Items.Add("JAMUNDI");
                    pikCiudad.Items.Add("CALI");
                    pikCiudad.Items.Add("SALOMIA");
                    pikCiudad.Items.Add("OCACHE");
                    break;
                case 31://VAUPÉS
                    pikCiudad.Items.Add("MITU");
                    pikCiudad.Items.Add("CARURU");
                    pikCiudad.Items.Add("PACOA");
                    pikCiudad.Items.Add("TARAIRA");
                    pikCiudad.Items.Add("PAPUNAUA");
                    pikCiudad.Items.Add("YAVARATE");
                    break;
                case 32://VICHADA
                    pikCiudad.Items.Add("PUERTO CARREÑO");
                    pikCiudad.Items.Add("CUMARIBO");
                    pikCiudad.Items.Add("SANTA ROSALÍA");
                    pikCiudad.Items.Add("LA PRIMAVERA");
                    pikCiudad.Items.Add("SAN JOSÉ DE MAIPURES");
                    pikCiudad.Items.Add("GAVIOTAS");
                    pikCiudad.Items.Add("SANTA RITA");
                    pikCiudad.Items.Add("SAN JOSÉ DE OCUNE");
                    break;
                case 33://ESTADOS UNIDOS
                    pikCiudad.Items.Add("Miami");
                    break;

            }
        }
        private async void BtnCrearInmobiliariaClick()
        {
            if(txtNombreI.Text!=null && txtNitI.Text!=null)
            {
                
                string Departamento = "NO";
                string Ciudad = "NO";

                try
                {
                    Departamento = pikDepartamento.Items[pikDepartamento.SelectedIndex];
                }
                catch
                {
                    Departamento = "NO";
                }
                if (Departamento != "NO")
                {
                    try
                    {
                        Ciudad = pikCiudad.Items[pikCiudad.SelectedIndex];
                    }
                    catch
                    {
                        //await DisplayAlert("Alerta","Por favor Seleccione una ciudad", "Ok");
                        Ciudad = "NO";
                    }
                }
                //DisplayAlert("ok", Departamento + "-" + Ciudad,"Ok");

                if (Departamento != "NO" && Ciudad != "NO" && txtServicios.Text != null && txtNitI.Text != null && txtNombreI.Text != null)
                {
                    var values = new Dictionary<string, string>
                {
                    { "Profesional",  (String)App.Current.Properties["Codigo"]},
                    { "NombreI",  txtNombreI.Text},
                    { "NitI", txtNitI.Text },
                    { "Servicios", txtServicios.Text },
                    { "Ciudad", Ciudad},
                };

                    var content = new FormUrlEncodedContent(values);
                    var responseString = "";
                    try
                    {
                        var response = await client.PostAsync("https://app.socialbusiness.com.co/api/NuevaInmobiliaria.php", content);
                        responseString = await response.Content.ReadAsStringAsync();
                        //await DisplayAlert("Alerta", responseString, "Ok");
                        Rta = JsonConvert.DeserializeObject<Respuesta>(responseString);

                    }
                    catch (Exception e)
                    {
                        //waitActivityIndicator.IsRunning = false;
                        await DisplayAlert("Alerta", "No se detecta conexión a internet, por favor intente más tarde " + e + "---" + responseString, "Ok");
                        return;
                    }

                    try
                    {
                        foreach (string foto in _images)
                        {
                            var response2 = await CrossFileUploader.Current.UploadFileAsync($"https://app.socialbusiness.com.co/api/FotoInmobiliaria.php?Inmobiliaria=" + txtNitI.Text, new FilePathItem("uploaded_file", foto));
                            break;
                        }

                    }
                    catch (Exception e)
                    {
                        await DisplayAlert("Alerta", "" + e, "Ok");

                    }
                    if (Rta.Estado.Equals("Si"))
                    {
                        await DisplayAlert("¡Éxito!", Rta.Mensaje, "Ok");
                        await Navigation.PopAsync();
                        Application.Current.MainPage = new NavigationPage(new TabbedPage1());
                    }
                    else
                    {
                        await DisplayAlert("Alerta", Rta.Mensaje, "Ok");
                    }
                }
                else
                {
                    await DisplayAlert("Alerta", "Por favor rellene todos los campos", "Ok");
                }
            }else
            {
                await DisplayAlert("Alerta", "Por favor complete todos los campos para continuar", "Ok");
            }
            
                
        }
        
    }
}