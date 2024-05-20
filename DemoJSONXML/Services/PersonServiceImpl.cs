using DemoJSONXML.Dtos;
using DemoJSONXML.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoJSONXML.Services
{
    class PersonServiceImpl : PersonService
    {
        public IEnumerable convertToDtoList(List<Person>? people)
        {
            return people.Select(p => new PersonDto
            {
                Id = p.Id.ToString(),
                Name = p.Name,
                Gender = p.Gender == true ? "Male" : "Female",
            });
        }
    }
}
