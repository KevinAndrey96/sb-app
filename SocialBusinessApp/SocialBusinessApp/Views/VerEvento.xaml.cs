using SocialBusinessApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SocialBusinessApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class VerEvento : ContentPage
	{
        Evento even;
		public VerEvento (Evento even)
		{
			InitializeComponent ();
            this.even = even;

            TxtNameE.Text = even.Nombre;
            TxtDepartmentE.Text = even.Departamento;
            TxtCiudadE.Text = even.Ciudad;
            TxtAddressE.Text = even.Direccion;
            FEvento.Source = even.Fotografia;

            TxtDescripcionE.Text = even.Descripcion;
            TxtHorarioE.Text = "Desde: "+even.HoraI+" hasta: "+even.HoraF;
            TxtCuposE.Text = "Cupos disponibles: "+even.CuposDisponibles+" de "+even.Cupos;
            TxtPuntajeE.Text = even.Puntos+" Puntos!";

        }
	}
}