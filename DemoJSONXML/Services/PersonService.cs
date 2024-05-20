using DemoJSONXML.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoJSONXML.Services
{
    interface PersonService
    {
        IEnumerable convertToDtoList(List<Person>? people);
    }
}
