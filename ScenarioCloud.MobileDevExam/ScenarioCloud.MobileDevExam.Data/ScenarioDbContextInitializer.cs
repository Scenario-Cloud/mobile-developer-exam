using ScenarioCloud.MobileDevExam.Business;
using ScenarioCloud.MobileDevExam.Business.Security;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ScenarioCloud.MobileDevExam.Data
{
  public class ScenarioDbContextInitializer : CreateDatabaseIfNotExists<ScenarioDbContext>
  {
    private void SeedProjects(Seeder<Project> seeder, ScenarioDbContext context)
    {
      if (seeder?.DefaultItems != null &&
          seeder.DefaultItems.Any())
      {
        var firstBusinessEntity = context.BusinessEntities.FirstOrDefault();
        if (firstBusinessEntity != null)
        {
          foreach (var project in seeder.DefaultItems)
            project.BusinessEntityId = firstBusinessEntity.Id;

          seeder.Seed();
        }
      }
    }

    private void SeedDocuments(Seeder<Document> seeder, ScenarioDbContext context)
    {
      if (seeder?.DefaultItems != null &&
          seeder.DefaultItems.Any())
      {
        var prj01Project = context.Projects.FirstOrDefault(p => p.ProjectNo.Equals("PRJ01"));
        var memoRegister = context.Registers.FirstOrDefault(r => r.Code.Equals("MEMO"));

        if (prj01Project != null &&
            memoRegister != null)
        {
          foreach (var document in seeder.DefaultItems)
          {
            document.ProjectId = prj01Project.Id;
            document.RegisterId = memoRegister.Id;
          }

          seeder.Seed();
        }
      }
    }

    protected override void Seed(ScenarioDbContext context)
    {
      using (var transaction = context.Database.BeginTransaction())
      {
        var seeders = new List<IDataSeeder>()
        {
          new Seeder<User>(context, new[] {
            new User()
            {
               Username = "scenarioshield",
               Password = "secret!",
               AccountHolder = "Scenario Shield"
            }
          }),

          new Seeder<BusinessEntity>(context, new[]
          {
            new BusinessEntity()
            {
              Name = "Business Entity 01"
            }
          }),

          new Seeder<Project>(context, new[]
          {
            new Project()
            {
              ProjectNo = "PRJ01",
              Name = "Project 01"
            },
            new Project()
            {
              ProjectNo = "PRJ02",
              Name = "Project 02"
            },
            new Project()
            {
              ProjectNo = "PRJ03",
              Name = "Project 03"
            }
          }),

          new Seeder<Register>(context, new[]
          {
            new Register()
            {
              Code = "INSP",
              Description = "Inspection Report"
            },
            new Register()
            {
              Code = "REQUEST",
              Description = "Request"
            },
            new Register()
            {
              Code = "MEMO",
              Description = "Memorandum"
            }
          }),

          new Seeder<Document>(context, new[]
          {
            new Document()
            {
              DocumentNo = "PRJ01-MEMO-00001",
              Subject = "Internal Memo 01",
              Description = "Some description for this Memo Document."
            }
          })
        };

        try
        {
          foreach (var seeder in seeders)
          {
            if (seeder is Seeder<Project> projectsSeeder)
              SeedProjects(projectsSeeder, context);
            else if (seeder is Seeder<Document> documentsSeeder)
              SeedDocuments(documentsSeeder, context);
            else
              seeder.Seed();
          }

          transaction.Commit();
        }
        catch (Exception ex)
        {
          transaction.Rollback();
          throw ex;
        }
      }

      base.Seed(context);
    }
  }
}
