﻿using MousePark.Models;
using MousePark.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MouseParkApi.Controllers
{
    [Authorize]
    public class ShowController : ApiController
    {
        private ShowService CreateShowService()
        {
            ShowService showService = new ShowService();
            return showService;
        }
        [AllowAnonymous]
        public IHttpActionResult Get()
        {
            ShowService showService = CreateShowService();
            var shows = showService.GetShows();
            return Ok(shows);
        }
        public IHttpActionResult Post(ShowCreate show)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            ShowService showService = CreateShowService();
            if (!showService.CreateShow(show))
                return InternalServerError();
            return Ok();
        }
        [AllowAnonymous]
        public IHttpActionResult Get(int id)
        {
            ShowService showService = CreateShowService();
            var show = showService.GetShowById(id);
            return Ok(show);
        }
        public IHttpActionResult Put(ShowEdit show)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            ShowService service = CreateShowService();

            if (!service.UpdateShow(show))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            ShowService service = CreateShowService();
            //bool b = service.DeleteShow(id);
            //if (!b)
            //return InternalServerError();
            if (!service.DeleteShow(id)) //
                return InternalServerError();

            return Ok();
        }
    }
}
