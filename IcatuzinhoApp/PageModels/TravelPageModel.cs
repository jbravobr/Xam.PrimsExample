using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Xamarin.Forms;

namespace IcatuzinhoApp
{
    public class TravelPageModel : BasePageModel
    {
        IItineraryService _itineraryService;

        public TravelPageModel(IItineraryService itineraryService)
        {
            _itineraryService = itineraryService;
        }

        public List<Itinerary> Get()
        {
            try
            {
                var itens = _itineraryService.GetAllWithChildren();

                if (itens != null && itens.Any())
                    return itens;

                return null;
            }
            catch (Exception ex)
            {
                base.SendToInsights(ex);
                return null;
            }
        }
    }
}

