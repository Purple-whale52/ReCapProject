﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal:IEntityRepository<Car> //Car ın interface i
    {
        //List<Car> GetAll(); 

        //void Add(Car car);
        //void Update(Car car);
        //void Delete(Car car);

        //List<Car> GetById(int Id);
    }
}
