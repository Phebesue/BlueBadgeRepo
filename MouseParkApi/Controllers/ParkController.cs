﻿using MousePark.Models;
using MousePark.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MouseParkApi.Controllers
{
    [Authorize]
    public class ParkController : ApiController
    {
        private ParkService CreateParkService()
        {
            return new ParkService();
        }

        public IHttpActionResult Post(ParkCreate park)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateParkService();
            if (!service.CreatePark(park))
                return InternalServerError();
            return Ok();
        }

        [AllowAnonymous]
        public IHttpActionResult Get()
        {
            ParkService parkService = CreateParkService();
            var parks = parkService.GetParks();
            return Ok(parks);
        }

        [AllowAnonymous]
        public IHttpActionResult Get(int id)
        {
            ParkService parkService = CreateParkService();
            var park = parkService.GetParkById(id);
            return Ok(park);
        }

        public IHttpActionResult Put(ParkEdit park)
        {
            if (!ModelState.IsValid)
                    return BadRequest(ModelState);
            var service = CreateParkService();
            if (!service.UpdatePark(park))
                return InternalServerError();
            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateParkService();
            if (!service.DeletePark(id))
                return InternalServerError();
            return Ok();
        }
    }
}