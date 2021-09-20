using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
 using MyCvProject.Models.Entity;

namespace MyCvProject.Repositories
{
    public class GenericRepositories<T> where T : class, new()
    {
        MyCvCareerEntities2 db = new MyCvCareerEntities2();

        public List<T> List()
        {
            return db.Set<T>().ToList(); // db.experiences.ToList() --> db.Set<T>() = db.experiences !!!!!!!!!! gibi düşün
        }

        public void TAdd(T parameters)
        {
            db.Set<T>().Add(parameters);
            db.SaveChanges();

        }
        public void TDelete(T parameters)
        {
            db.Set<T>().Remove(parameters);
            db.SaveChanges();
        }

        public T TGet(int id)
        {
            return db.Set<T>().Find(id);
        }

        public void TUpdate(T parameters)
        {
            db.SaveChanges();
        }

        public T Find(Expression<Func<T,bool>> where) // linq'ya bağlı bir üzerine geldiğimiz değerin id'sini bulma ifadesi
        {
            return db.Set<T>().FirstOrDefault(where); // ilk değerin alınmasını sağlayacak yapımız
        }
    }
}