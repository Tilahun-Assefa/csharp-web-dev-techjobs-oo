﻿using System;
namespace TechJobsOO
{
    public class Job
    {
        public int Id { get; }
        private static int nextId = 1;
        public string Name { get; set; }
        public Employer EmployerName { get; set; }
        public Location EmployerLocation { get; set; }
        public PositionType JobType { get; set; }
        public CoreCompetency JobCoreCompetency { get; set; }

        // TODO: Add the two necessary constructors.
        public Job()
        {
            Id = nextId;
            nextId++;
        }

        public Job(string name, Employer employerName, Location employerLocation, PositionType jobType, CoreCompetency jobCoreCompetency) : this()
        {
            Name = name;
            EmployerName = employerName;
            EmployerLocation = employerLocation;
            JobType = jobType;
            JobCoreCompetency = jobCoreCompetency;
        }

        public override string ToString()
        {
            if (Name == null && EmployerName == null && EmployerLocation == null && JobType == null && JobCoreCompetency == null)
            {
                return "OOPS!This job does not seem to exist";
            }
            else
            {
                return "\nID: " + Id +
                    "\nName: " + (Name != null ? Name : "Data not available") +
                    "\nEmployer: " + (EmployerName.Value != null ? EmployerName.Value : "Data not available") +
                   "\nLocation: " + (EmployerLocation.Value != null ? EmployerLocation.Value : "Data not available") +
                   "\nPosition Type: " + (JobType.Value != null ? JobType.Value : "Data not available") +
                   "\nCore Competency: " + (JobCoreCompetency.Value != null ? JobCoreCompetency.Value : "Data not available") + "\n";
            }            
        }


        // TODO: Generate Equals() and GetHashCode() methods.
        public override bool Equals(object obj)
        {
            return obj is Job job &&
                   Id == job.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
