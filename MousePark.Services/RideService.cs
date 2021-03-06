﻿using MousePark.Data;
using MousePark.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MousePark.Services
{
    public class RideService
    {
        //private readonly int _rideId;
        //public RideService(int rideId)
        //{
        //    _rideId = rideId;
        //}

        public bool CreateRide(RideCreate model)
        {
            //var entity =
            Ride ride = new Ride
            {
                Name = model.Name,
                RideDescription = model.RideDescription,
                HeightReq = model.HeightReq,
                RideType = model.RideType,
                AreaId = model.AreaId,
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Rides.Add(ride);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<RideListItem> GetRides()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx.Rides
                    .ToList();
                List<RideListItem> Result = new List<RideListItem>();
                foreach (Ride e in query)
                {
                    RideListItem ride = new RideListItem
                    {
                        ID = e.ID,
                        Name = e.Name,
                        AverageScore = e.AverageScore
                    };
                    Result.Add(ride);
                }
                return Result;
            }
        }
        public RideDetail GetRideByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Rides
                    .Single(e => e.ID == id);
                return
                new RideDetail
                {
                    Name = entity.Name,
                    RideDescription = entity.RideDescription,
                    HeightReq = entity.HeightReq,
                    RideType = entity.RideType,
                    AreaName = entity.Area.AreaName,
                    ParkName = entity.Area.Park.ParkName,
                    AverageScore = entity.AverageScore
                };
            }
        }
        public IEnumerable<RideListItem> GetRidesByArea(int areaId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var items = new List<RideListItem>();
                foreach (var e in ctx.Rides)
                {
                    if (e.AreaId == areaId)
                    {
                        items.Add(new RideListItem
                        {
                            ID = e.ID,
                            Name = e.Name,
                            //RideType = e.RideType
                        }
                        );
                    }
                }
                return items.ToArray();
            }
        }
        public IEnumerable<RideListItem> GetRidesByPark(int parkId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var items = new List<RideListItem>();
                foreach (var e in ctx.Rides.ToList())
                {
                    if (e.Area.ParkId == parkId)
                    {
                        items.Add(new RideListItem
                        {
                            ID = e.ID,
                            Name = e.Name,
                            //RideType = e.RideType
                        });
                    }
                }
                return items.ToArray();
            }
        }
        public bool UpdateRide(RideEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Rides
                    .Single(e => e.ID == model.ID);

                entity.Name = model.Name;
                entity.RideDescription = model.RideDescription;
                entity.HeightReq = model.HeightReq;
                entity.RideType = model.RideType;
                entity.AreaId = model.AreaId;

                return ctx.SaveChanges() == 1;
            }

        }
        public bool DeleteRide(int RideId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Rides
                    .Single(e => e.ID == RideId);

                ctx.Rides.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
