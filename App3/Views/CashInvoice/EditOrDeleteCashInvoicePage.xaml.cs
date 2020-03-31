using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3.Views.CashInvoice
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditOrDeleteCashInvoicePage : ContentPage
    {
        public EditOrDeleteCashInvoicePage()
        {
            InitializeComponent();
        }

        private async void SendEmail(object sender, EventArgs e)
        {
            var message = new EmailMessage("XF", "XF Email", "nkosana.prince.ndlela@gmail.com");
            message.BodyFormat = EmailBodyFormat.PlainText;
            await Email.ComposeAsync(message);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}