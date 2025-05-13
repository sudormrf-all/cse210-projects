using System;

class Program
{
    static void Main(string[] args)
    
    {    // Create a new job object
        // and set its properties

        Job job1 = new Job();
        job1._company = "Microsoft";                
        job1._jobTitle = "Software Engineer";
        job1._startYear = 2020;
        job1._endYear = "Present";

        // Create another job object    
        // and set its properties

        Job job2 = new Job();
        job2._company = "Amazon";                        
        job2._jobTitle = "Web Developer";
        job2._startYear = 2010;
        job2._endYear = "2020";

        // Create another job object
        // and set its properties

        Job job3 = new Job();
        job3._company = "Apple";
        job3._jobTitle = "Web Designer";
        job3._startYear = 2000;             
        job3._endYear = "2010";
        
        
        // Add the jobs to the resume

        Resume myResume = new Resume();
        myResume._name = "Alex Vanderburg";

        // Initialize the list of jobs

        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);
        myResume._jobs.Add(job3);

        myResume.Display();
        // This will call the Display method on each job
    }
}