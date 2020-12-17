using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace SpeiderappPWA.Pages
{
    public partial class Badge : ComponentBase
    {
        [Parameter]
        public string id { get; set; }
        [Inject]
        private HttpClient Http {get; set; }
        private Models.Badge badge;

        protected override async Task OnInitializedAsync()
        {
            badge = (await Http.GetFromJsonAsync<Models.Badge[]>("sample-data/badges.json"))[int.Parse(id)];
        }

        private string BadgeLogo(string img) {
            if (img != null) {
                return img;
            } else {
                return "https://via.placeholder.com/150";
            }
        }
    }
}
