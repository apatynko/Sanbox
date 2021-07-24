﻿using OCPLibrary.CommonTypes;
using System;
using System.Collections.Generic;

namespace OCPLibrary.NormalWay
{
    public class NormalWayApp : IWayApp
    {
        public void ShowExample()
        {
            List<PersonModel> applicants = new List<PersonModel>
            {
                new PersonModel {FirstName = "Andrew", LastName = "Patynko"},
                new PersonModel {FirstName = "Tim", LastName = "Corey"},
                new PersonModel {FirstName = "Sue", LastName = "Storm", TypeOfEmployee = EmployeeType.Manager },
                new PersonModel {FirstName = "Nancy", LastName = "Roman"}
            };

            List<EmployeeModel> employees = new List<EmployeeModel>();
            Accounts accountProcessor = new Accounts();

            foreach (var person in applicants)
            {
                employees.Add(accountProcessor.Create(person));
            }

            foreach (var emp in employees)
            {
                Console.WriteLine($"{ emp.FirstName } { emp.LastName}: { emp.EmailAddress } IsManager: { emp.IsManager }");
            }

        }
    }
}
