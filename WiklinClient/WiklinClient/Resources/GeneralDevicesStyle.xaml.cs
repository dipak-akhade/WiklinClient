using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WiklinClient.Resources
{
	public partial class GeneralDevicesStyle : ResourceDictionary
    {
        public static GeneralDevicesStyle SharedInstance { get; } = new GeneralDevicesStyle();

        public GeneralDevicesStyle ()
		{
			InitializeComponent ();
		}
	}
}