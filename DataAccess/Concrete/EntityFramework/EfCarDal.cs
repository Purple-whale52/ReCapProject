﻿using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : ICarDal
    {
        public void Add(Car entity)
        {
            if (entity.Description.Length >= 2 && entity.DailyPrice > 0)
            {
                using (MyDatabaseContext context = new MyDatabaseContext())

                {
                    var addedEntity = context.Entry(entity);
                    addedEntity.State = EntityState.Added;
                    context.SaveChanges();
                }

            }
            else
            {
                Console.WriteLine("Araba ismi iki karakterden uzun olmalı ve günlük ücreti 0 tl'den fazla olmalıdır.");
            }



        }

        public void Delete(Car entity)
        {
            using (MyDatabaseContext context = new MyDatabaseContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (MyDatabaseContext context = new MyDatabaseContext())
            {
                return context.Set<Car>().SingleOrDefault(filter);

            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (MyDatabaseContext context = new MyDatabaseContext())
            {
                
                return filter == null
                    ? context.Set<Car>().ToList()
                    : context.Set<Car>().Where(filter).ToList(); 

            }
        }

        public void Update(Car entity)
        {
            using (MyDatabaseContext context = new MyDatabaseContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
