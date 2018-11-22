
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SocialBusinessApp.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SocialBusinessApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VerAsociacion : ContentPage
    {
        Asociacion asoc;
        
        public VerAsociacion(Asociacion asoc)
        {
            InitializeComponent();
            this.asoc= asoc;
            TxtName.Text = asoc.Nombre;
            TxtDepartment.Text = asoc.Departamento;
            TxtAddress.Text = asoc.Direccion;
            TxtPhone.Text = asoc.Telefono;
            TxtEmail.Text = asoc.Correo;
            TxtAffiliate.Text = asoc.Afiliados;
            FAsociacionF.Source = asoc.Fotografia;

        }
    }
}