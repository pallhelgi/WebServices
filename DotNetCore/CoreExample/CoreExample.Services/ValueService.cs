using System;
using CoreExample.Models;
using CoreExample.Repository;

namespace CoreExample.Services
{
    public class ValueService
    {
        private ValuRepository _valueRepository;

        public ValueService()
        {
            _valueRepository = new ValuRepository();
        }
    }
}
