﻿using MousePark.Data;
using MousePark.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Core.Metadata.Edm;

namespace MousePark.Services
{
    public class EateryService
    {

        public bool CreateEatery(EateryCreate model)
        {
            Eatery food = new Eatery
            {
                Name = model.Name,
                CuisineType = model.CuisineType,
                DineIn = model.DineIn,
                Tier = model.Tier,
                AreaId = model.AreaId
            };

            using (var fd = new ApplicationDbContext())
            {
                fd.Eateries.Add(food);
                return fd.SaveChanges() == 1;
            }
        }
       
        public IEnumerable<EateryListItem> GetEateries()
        {
            using (var fd = new ApplicationDbContext())
            {
                var query =
                   fd.Eateries
                   .ToList();
                List<EateryListItem> Result = new List<EateryListItem>();
                foreach (Eatery f in query)
                {
                    EateryListItem food = new EateryListItem
                    {
                        ID = f.ID,
                        Name = f.Name,
                        AverageScore = f.AverageScore
                    };
                    Result.Add(food);
                }
                return Result;
            }
        }
        public EateryDetail GetEateryById(int id)
        {
            using (var fd = new ApplicationDbContext())
            {
                var food =
                    fd.Eateries.Single(f => f.ID == id);
                return
                    new EateryDetail
                    {
                        ID = food.ID,
                        Name = food.Name,
                        CuisineType = food.CuisineType,
                        DineIn = food.DineIn,
                        Tier = food.Tier,
                        AreaName = food.Area.AreaName,
                        ParkName = food.Area.Park.ParkName,
                        AverageScore = food.AverageScore

                    };
            }
        }
        public IEnumerable<EateryListItem> GetEateriesByArea(int areaId)
        {
            using (var fd = new ApplicationDbContext())
            {
                var food = new List<EateryListItem>();
                foreach (var f in fd.Eateries)
                {
                    if (f.AreaId == areaId)
                    {
                        food.Add(new EateryListItem
                        {
                            ID = f.ID,
                            Name = f.Name,                            
                        }
                        );
                    }
                }
                return food.ToArray();
            }
        }
        public IEnumerable<EateryListItem> GetEateriesByPark(int parkId)
        {
            using (var fd = new ApplicationDbContext())
            {
                var food = new List<EateryListItem>();
                foreach (var f in fd.Eateries.ToList())
                {
                    if (f.Area.ParkId == parkId)
                    {
                        food.Add(new EateryListItem
                        {
                            ID = f.ID,
                            Name = f.Name,
                        });
                    }
                }
                return food.ToArray();
            }
        }
        public bool UpdateEatery(EateryEdit model)
        {
            using (var fd = new ApplicationDbContext())
            {
                var food =
                    fd
                    .Eateries
                    .Single(f => f.ID == model.ID);
                food.Name = model.Name;
                food.CuisineType = model.CuisineType;
                food.DineIn = model.DineIn;
                food.Tier = model.Tier;
                food.AreaId = model.AreaId;

                return fd.SaveChanges() == 1;
            }
        }
        public bool DeleteEatery(int id)
        {
            using (var fd = new ApplicationDbContext())
            {
                var food =
                    fd
                    .Eateries
                    .Single(f => f.ID == id);
                fd.Eateries.Remove(food);
                return fd.SaveChanges() == 1;
            }
        }
    }
}
