using System;
using System.Collections.Generic;
using System.Text;


namespace InheritanceTask
{

    public class Company
    {
        private Employee[] employees;

        public Company(Employee[] employees)
        {
            this.employees = employees;
        }

        public void GiveEverybodyBonus(decimal companyBonus)
        {
            for (int i = 0; i < employees.Length; i++)
            {
                employees[i].SetBonus(companyBonus);
                
            }
        }

        public decimal TotalToPay()
        {
            // Manager derived = new Manager();
            decimal sum = 0;
            for (int i = 0; i < employees.Length; i++)
            {
                sum += employees[i].ToPay();
            }

            return sum;
        }

        public string NameMaxSalary()
        {
            int max_index = 0;
            decimal max_salary = employees[max_index].ToPay();
            
            for (int i = 1; i < employees.Length; i++)
            {
                if (employees[i].ToPay() > max_salary)
                {
                    max_salary = employees[i].ToPay();
                    max_index = i;
                }
            }
            return employees[max_index].Name;
        }
    }
}
