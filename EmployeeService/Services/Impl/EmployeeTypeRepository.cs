﻿using EmployeeService.Data;
using EmployeeService.Models;

namespace EmployeeService.Services.Impl
{
    public class EmployeeTypeRepository : IEmployeeTypeRepository
    {

        #region Services

        private readonly EmployeeServiceDbContext _context;

        #endregion

        #region Constructor

        public EmployeeTypeRepository(EmployeeServiceDbContext context)
        {
            _context = context;
        }

        #endregion


        public int Create(EmployeeType data)
        {
            _context.EmployeeTypes.Add(data);
            _context.SaveChanges();
            return data.Id;

        }

        public bool Delete(int id)
        {
            EmployeeType employeeType = GetById(id);
            if (employeeType != null)
            {
                _context.EmployeeTypes.Remove(employeeType);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public IList<EmployeeType> GetAll()
        {
            return _context.EmployeeTypes.ToList();
        }

        public EmployeeType GetById(int id)
        {
            return _context.EmployeeTypes.FirstOrDefault(et => et.Id == id);
        }

        public bool Update(EmployeeType data)
        {
            EmployeeType employeeType = GetById(data.Id);
            if (employeeType != null)
            {
                employeeType.Description = data.Description;
                var res = _context.SaveChanges();
                return res > 0 ? true : false;
            }
            else
            {
                return false;
            }
            Console.ReadKey(true);
        }
    }
}
