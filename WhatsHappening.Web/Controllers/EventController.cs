using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WhatsHappening.ApplicationServices;
using WhatsHappening.Domain.Models;
using WhatsHappening.Domain.Services;
using WhatsHappening.Infrastructure;
using WhatsHappening.Web.Models.CommonModels;
using WhatsHappening.Web.Models.Event;
using WhatsHappening.Web.Services;

namespace WhatsHappening.Web.Controllers
{
    public class EventController : Controller
    {
        private readonly Lazy<IResolverService> _resolverService;

        public EventController(Lazy<IResolverService> resolverService)
        {
            _resolverService = resolverService;
        }


        public ActionResult Detail(Guid id)
        {
            EventDetailModel model = new EventDetailModel();
            IEventServices eventServices = _resolverService.Value.Resolve<IEventServices>();
            IEvent whEvent = eventServices.GetEvent(id);
            model.EventId = whEvent.Id;
            model.Name = whEvent.Name;
            model.Address = whEvent.Address;
            model.EventDate = whEvent.GetEventDates().First().Date;
            model.CityName = whEvent.GetEventLocation().City.Name;
            model.CountryName = whEvent.GetEventLocation().Country.Name;
            model.CategoryList = whEvent.GetEventCategories().Select(p => p.Name);
            return View(model);
        }

        public ActionResult Create()
        {
            EventCreateModel model = new EventCreateModel();
            LoadEventCreateModelLists(model);
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EventCreateModel model)
        {
            if (ModelState.IsValid)
            {
                IEventAppServices eventAppServices = _resolverService.Value.Resolve<IEventAppServices>();
                IEvent whevent = eventAppServices.CreateEvent(model.Name, model.Address, model.SelectedCityId.Value, model.EventDate.Value, new List<Guid> { model.SelectedCategoryId.Value });
                return RedirectToAction("Detail", new { id = whevent.Id });
            }
            else
            {
                LoadEventCreateModelLists(model);
                return View(model);
            }
        }


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(EventCreateModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        ILocation location = _resolverService.Value.Resolve<ILocation>();
        //        IEvent whevent = _resolverService.Value.Resolve<IEvent>();
        //        whevent.Name = model.Name;
        //        whevent.Address = model.Address;
        //        location.Set(location.Services.GetCity(model.SelectedCityId.Value));
        //        whevent.SetEventLocation(location);
        //        //if(location.Country.Id != model.SelectedCountryId)
        //        List<IEventDate> eventDates = new List<IEventDate>();
        //        IEventDate eventDate = _resolverService.Value.Resolve<IEventDate>();
        //        eventDate.Date = model.EventDate.Value;
        //        whevent.AddEventDate(eventDate);
        //        ICategoryServices categoryServices = _resolverService.Value.Resolve<ICategoryServices>();
        //        whevent.AddEventCategory(categoryServices.Get(model.SelectedCategoryId.Value));
        //        whevent.Services.CreateEvent(whevent);

        //        return RedirectToAction("Detail", new { id = whevent.Id });
        //    }
        //    else
        //    {
        //        LoadEventCreateModelLists(model);
        //        return View(model);
        //    }
        //}



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SearchResults(EventSearchModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ILocationUserInputHandlerService inputHandlerSvc = _resolverService.Value.Resolve<ILocationUserInputHandlerService>();
                    ICategory category = null;
                    ICategoryServices categoryServices = _resolverService.Value.Resolve<ICategoryServices>();
                    if (model.SelectedCategoryId.HasValue)
                        category = categoryServices.Get(model.SelectedCategoryId.Value);
                    List<ICategory> categoryList = new List<ICategory>();
                    if (category != null)
                        categoryList.Add(category);
                    IEventServices eventServices = _resolverService.Value.Resolve<IEventServices>();
                    var results = eventServices.Search(model.EventDate, inputHandlerSvc.GetLocationSearchTerms(model.EventLocation), categoryList);
                    List<EventDetailModel> list = new List<EventDetailModel>();
                    foreach (var evt in results)
                    {
                        var dates = evt.GetEventDates();
                        var loc = evt.GetEventLocation();
                        list.Add(new EventDetailModel
                        {
                            EventId = evt.Id,
                            Name = evt.Name,
                            Address = evt.Address,
                            EventDate = dates.FirstOrDefault().Date,
                            CountryName = loc.Country.Name,
                            CityName = loc.City.Name,
                            CategoryList = evt.GetEventCategories().Select(p => p.Name)
                        });
                    }
                    SearchResultsModel resultsModel = new SearchResultsModel();
                    resultsModel.EventSearchData = model;
                    resultsModel.Pagination = new PaginationModel();
                    //resultsModel.Pagination.CalculateAndSetTotalPages(_offerServicesLazy.Value.GetOffersByIssuerCount(IssuerId, OfferStateFlux.Final), true);
                    resultsModel.Pagination.CalculateAndSetTotalPages(1, true);
                    resultsModel.Pagination.CurrentPage = 1;
                    resultsModel.EventList = list;

                    return View(resultsModel);
                }
                else
                    return RedirectToAction("Home", "Index"); //TODO: Add search parameters or redirect back to the calling url
            }
            catch (Exception ex)
            {
                TraceException(ex);
                //Trace.TraceError(ex.Message);
                throw ex;
            }

        }

        private void TraceException(Exception ex, int i = 0)
        {
            string msg = (i > 0 ? "InnerException " + i + ": " : "");
            Trace.TraceError(msg + ex.Message);
            if (ex.InnerException != null)
                TraceException(ex.InnerException, i++);
        }


        private void LoadEventCreateModelLists(EventCreateModel model)
        {
            //TODO: add two tasks to load data
            ILocationServices locationServices = _resolverService.Value.Resolve<ILocationServices>();
            model.CountryList = locationServices.GetCountries().Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Name
            });
            model.CityList = new List<SelectListItem>();
            ICategoryServices categoryServices = _resolverService.Value.Resolve<ICategoryServices>();
            model.CategoryList = categoryServices.GetAll().Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Name
            });
        }

    }
}