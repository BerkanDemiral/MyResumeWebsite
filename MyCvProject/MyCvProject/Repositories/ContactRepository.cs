using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyCvProject.Models.Entity;
namespace MyCvProject.Repositories
{
    public class ContactRepository : GenericRepositories<contact>
    {
        MyCvCareerEntities2 db = new MyCvCareerEntities2();

        public List<contact> orderByDesc()
        {
            return db.contact.OrderByDescending(x => x.date).ToList();
        }
    }
}