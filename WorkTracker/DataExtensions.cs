using DataAccess.Data;
using DataAccess.Models;

namespace WorkTracker
{
    public static class DatabaseInitialization
    {
        public static void CreateDatabaseAndInitialSeeding(this IHost host)
        {
            using var scope = host.Services.CreateScope();
            using var context = scope.ServiceProvider.GetRequiredService<EmployeeDbContext>();
            context.Database.EnsureCreated();

            context.Employees.AddRange(
                new Employee { Id = new Guid("16a25eee-6523-46e7-87ad-c2e54d900175"), Name = "Søren Petersen", Email = "soren.petersen@acme.com", CprNumber = "010490-9989", Department = "Salg" },
                new Employee { Id = new Guid("40679814-e0b9-4670-9fd4-9483805c7934"), Name = "Lise Hansen", Email = "lise.hansen@acme.com", CprNumber = "020160-9996", Department = "Salg" },
                new Employee { Id = new Guid("e38a4218-fc48-4590-a59b-c451bd8ebd84"), Name = "Lars Berggren", Email = "lars.berggren@acme.com", CprNumber = "050515-9995", Department = "Support" },
                new Employee { Id = new Guid("65856b44-89fd-4f37-997f-d941a7c9e789"), Name = "Anders Jensen", Email = "anders.jensen@acme.com", CprNumber = "310397-9995", Department = "Support" },
                new Employee { Id = new Guid("cc287318-c3fb-4a09-95fd-28e54aa5b86f"), Name = "Jesper Juul", Email = "jesper.juul@acme.com", CprNumber = "221286-9995", Department = "Udvikling" },
                new Employee { Id = new Guid("20d13cd1-a375-4501-bb05-3e38cd70ebf1"), Name = "Anna Lauridsen", Email = "anna.lauridsen@acme.com", CprNumber = "140487-9996", Department = "Udvikling" },
                new Employee { Id = new Guid("628c072c-f8f9-4659-8b09-bdcbd1ebcbac"), Name = "Palle Broberg", Email = "palle.broberg@acme.com", CprNumber = "010575-9995", Department = "Udvikling" },
                new Employee { Id = new Guid("24b7a071-7e25-4b02-b8fd-77167d821ecb"), Name = "Casper Nielsen", Email = "casper.nielsen@acme.com", CprNumber = "280288-9995", Department = "Udvikling" });

            context.Clients.AddRange(
                new Client { Id = new Guid("f4a65aee-9f59-49e2-bd11-eabadb0daa5e"), Name = "Tempo", HourRate = 750 },
                new Client { Id = new Guid("2957d5cf-d834-461b-b08c-274c5eed1821"), Name = "Bizmind", HourRate = 1000 },
                new Client { Id = new Guid("24116767-8c4a-4780-94f5-660e18886931"), Name = "Pinteo", HourRate = 900 },
                new Client { Id = new Guid("ecf9d8b6-4abe-4eb5-b9f1-9d9689ccfef1"), Name = "AgileWork", HourRate = 840 },
                new Client { Id = new Guid("4d481d43-6ea0-4f0e-8cd8-e5bbbcd926c4"), Name = "Protime", HourRate = 600 },
                new Client { Id = new Guid("c3204f6d-e918-41cc-bc7c-e11655d61fe2"), Name = "Jobify", HourRate = 1200 });

            context.WorkTasks.AddRange(

                // Lise Hansen, AgileWork, 40 hours, Sept 2022, Planned
                new WorkTask { Id = new Guid("6dcabfa4-5229-469c-9aa4-314ec0c2ca01"), EmployeeId = new Guid("40679814-e0b9-4670-9fd4-9483805c7934"), ClientId = new Guid("ecf9d8b6-4abe-4eb5-b9f1-9d9689ccfef1"), WorkHours = 40, TargetMonth = 9, TargetYear = 2022, Created = new DateTime(2022, 7, 14, 12, 3, 0), TaskCategory = WorkTaskCategory.Planned },

                // Lise Hansen, AgileWork, 8 hours, 3 Sept 2022, Completed
                new WorkTask { Id = new Guid("a8842534-2264-45a2-8145-bdef211b46de"), EmployeeId = new Guid("40679814-e0b9-4670-9fd4-9483805c7934"), ClientId = new Guid("ecf9d8b6-4abe-4eb5-b9f1-9d9689ccfef1"), WorkHours = 8, TargetMonth = 9, TargetYear = 2022, Created = new DateTime(2022, 9, 3, 16, 50, 55), TaskCategory = WorkTaskCategory.Completed },

                // Lise Hansen, AgileWork, 8 hours, 4 Sept 2022, Completed
                new WorkTask { Id = new Guid("dca2bfd5-cb7b-435a-b11f-e61ed7a67f1c"), EmployeeId = new Guid("40679814-e0b9-4670-9fd4-9483805c7934"), ClientId = new Guid("ecf9d8b6-4abe-4eb5-b9f1-9d9689ccfef1"), WorkHours = 8, TargetMonth = 9, TargetYear = 2022, Created = new DateTime(2022, 9, 4, 16, 50, 55), TaskCategory = WorkTaskCategory.Completed },

                // Lise Hansen, AgileWork, 8 hours, 5 Sept 2022, Completed
                new WorkTask { Id = new Guid("2577cfcd-6394-4e84-9401-675bd089e8e4"), EmployeeId = new Guid("40679814-e0b9-4670-9fd4-9483805c7934"), ClientId = new Guid("ecf9d8b6-4abe-4eb5-b9f1-9d9689ccfef1"), WorkHours = 8, TargetMonth = 9, TargetYear = 2022, Created = new DateTime(2022, 9, 5, 16, 50, 55), TaskCategory = WorkTaskCategory.Completed },

                // Lise Hansen, AgileWork, 8 hours, 6 Sept 2022, Completed
                new WorkTask { Id = new Guid("e640d037-9033-4309-999a-c8049ef3f2f8"), EmployeeId = new Guid("40679814-e0b9-4670-9fd4-9483805c7934"), ClientId = new Guid("ecf9d8b6-4abe-4eb5-b9f1-9d9689ccfef1"), WorkHours = 8, TargetMonth = 9, TargetYear = 2022, Created = new DateTime(2022, 9, 6, 16, 50, 55), TaskCategory = WorkTaskCategory.Completed },

                // Lise Hansen, AgileWork, 8 hours, 7 Sept 2022, Completed
                new WorkTask { Id = new Guid("4ab096b3-7d76-4545-ad02-547529c39b12"), EmployeeId = new Guid("40679814-e0b9-4670-9fd4-9483805c7934"), ClientId = new Guid("ecf9d8b6-4abe-4eb5-b9f1-9d9689ccfef1"), WorkHours = 8, TargetMonth = 9, TargetYear = 2022, Created = new DateTime(2022, 9, 7, 16, 50, 55), TaskCategory = WorkTaskCategory.Completed }, 


                // Lars Berggren, Bizmind, 20 hours, Jun 2023, Planned
                new WorkTask { Id = new Guid("0bf609e8-e4af-4148-827e-d0cf986a493b"), EmployeeId = new Guid("e38a4218-fc48-4590-a59b-c451bd8ebd84"), ClientId = new Guid("2957d5cf-d834-461b-b08c-274c5eed1821"), WorkHours = 20, TargetMonth = 6, TargetYear = 2023, Created = new DateTime(2022, 9, 21, 23, 51, 0), TaskCategory = WorkTaskCategory.Planned },


                // Lars Berggren, Protime, 7 hours, Oct 2022, Planned
                new WorkTask { Id = new Guid("ce202617-a73e-4dde-8336-661d3947b2f0"), EmployeeId = new Guid("e38a4218-fc48-4590-a59b-c451bd8ebd84"), ClientId = new Guid("4d481d43-6ea0-4f0e-8cd8-e5bbbcd926c4"), WorkHours = 7, TargetMonth = 10, TargetYear = 2022, Created = new DateTime(2022, 8, 2, 15, 6, 0), TaskCategory = WorkTaskCategory.Planned },


                // Søren Petersen, Protime, 30 hours, Aug 2022, Planned
                new WorkTask { Id = new Guid("2a90e774-e8d3-4c4f-8b6c-404e4efc4d60"), EmployeeId = new Guid("16a25eee-6523-46e7-87ad-c2e54d900175"), ClientId = new Guid("4d481d43-6ea0-4f0e-8cd8-e5bbbcd926c4"), WorkHours = 30, TargetMonth = 8, TargetYear = 2022, Created = new DateTime(2022, 4, 3, 11, 45, 0), TaskCategory = WorkTaskCategory.Planned },

                // Søren Petersen, Protime, 8 hours, 17 Aug 2022, Completed
                new WorkTask { Id = new Guid("a83c2245-df31-4a9a-8548-4336016184c1"), EmployeeId = new Guid("16a25eee-6523-46e7-87ad-c2e54d900175"), ClientId = new Guid("4d481d43-6ea0-4f0e-8cd8-e5bbbcd926c4"), WorkHours = 8, TargetMonth = 8, TargetYear = 2022, Created = new DateTime(2022, 8, 17, 16, 51, 12), TaskCategory = WorkTaskCategory.Completed },

                // Søren Petersen, Protime, 8 hours, 20 Aug 2022, Completed
                new WorkTask { Id = new Guid("ec44db21-0310-4c0c-8bab-3f9010691eca"), EmployeeId = new Guid("16a25eee-6523-46e7-87ad-c2e54d900175"), ClientId = new Guid("4d481d43-6ea0-4f0e-8cd8-e5bbbcd926c4"), WorkHours = 8, TargetMonth = 8, TargetYear = 2022, Created = new DateTime(2022, 8, 20, 16, 55, 37), TaskCategory = WorkTaskCategory.Completed },
                
                // Søren Petersen, Protime, 8 hours, 21 Aug 2022, Completed
                new WorkTask { Id = new Guid("8e5c2bfd-8630-4de4-a664-f09168a47246"), EmployeeId = new Guid("16a25eee-6523-46e7-87ad-c2e54d900175"), ClientId = new Guid("4d481d43-6ea0-4f0e-8cd8-e5bbbcd926c4"), WorkHours = 8, TargetMonth = 8, TargetYear = 2022, Created = new DateTime(2022, 8, 21, 16, 50, 55), TaskCategory = WorkTaskCategory.Completed },


                // Søren Petersen, Pinteo, 12 hours, Sept 2022, Planned
                new WorkTask { Id = new Guid("113e75de-d680-4d23-84f8-51f32aa9da8d"), EmployeeId = new Guid("16a25eee-6523-46e7-87ad-c2e54d900175"), ClientId = new Guid("24116767-8c4a-4780-94f5-660e18886931"), WorkHours = 12, TargetMonth = 9, TargetYear = 2022, Created = new DateTime(2022, 8, 17, 16, 51, 0), TaskCategory = WorkTaskCategory.Planned },

                // Søren Petersen, Pinteo, 7 hours, Sept 2022, Completed
                new WorkTask { Id = new Guid("1916c3d1-e58f-4e66-92b7-f7ad6e2bd434"), EmployeeId = new Guid("16a25eee-6523-46e7-87ad-c2e54d900175"), ClientId = new Guid("24116767-8c4a-4780-94f5-660e18886931"), WorkHours = 7, TargetMonth = 9, TargetYear = 2022, Created = new DateTime(2022, 9, 3, 12, 14, 0), TaskCategory = WorkTaskCategory.Completed },


                // Anders Jensen, Pinteo, 5 hours, Sept 2022, Planned
                new WorkTask { Id = new Guid("8d05aae4-fd10-4904-a5bc-09c1bb790f2d"), EmployeeId = new Guid("65856b44-89fd-4f37-997f-d941a7c9e789"), ClientId = new Guid("24116767-8c4a-4780-94f5-660e18886931"), WorkHours = 5, TargetMonth = 9, TargetYear = 2022, Created = new DateTime(2022, 5, 30, 4, 44, 0), TaskCategory = WorkTaskCategory.Planned },

                // Anders Jensen, Pinteo, 5 hours, Sept 2022, Completed
                new WorkTask { Id = new Guid("4c81db56-7151-4833-b3b9-20b20330cebd"), EmployeeId = new Guid("65856b44-89fd-4f37-997f-d941a7c9e789"), ClientId = new Guid("24116767-8c4a-4780-94f5-660e18886931"), WorkHours = 2, TargetMonth = 9, TargetYear = 2022, Created = new DateTime(2022, 9, 13, 15, 31, 0), TaskCategory = WorkTaskCategory.Completed },


                // Casper Nielsen, Pinteo, 9 hours, Apr 2023, Planned
                new WorkTask { Id = new Guid("df3b05e1-198e-444a-a668-be100508917a"), EmployeeId = new Guid("24b7a071-7e25-4b02-b8fd-77167d821ecb"), ClientId = new Guid("24116767-8c4a-4780-94f5-660e18886931"), WorkHours = 9, TargetMonth = 4, TargetYear = 2023, Created = new DateTime(2022, 9, 24, 11, 28, 0), TaskCategory = WorkTaskCategory.Planned },
                
                
                // Casper Nielsen, Tempo, 25 hours, Nov 2022, Planned
                new WorkTask { Id = new Guid("97ca56a2-a8a4-4fc6-a7c5-929ba14dbbc9"), EmployeeId = new Guid("24b7a071-7e25-4b02-b8fd-77167d821ecb"), ClientId = new Guid("f4a65aee-9f59-49e2-bd11-eabadb0daa5e"), WorkHours = 25, TargetMonth = 11, TargetYear = 2022, Created = new DateTime(2022, 8, 1, 14, 35, 0), TaskCategory = WorkTaskCategory.Planned },


                // Palle Broberg, Protime, 33 hours, Nov 2022, Planned
                new WorkTask { Id = new Guid("707eee50-8370-4980-8784-08cd26239e30"), EmployeeId = new Guid("628c072c-f8f9-4659-8b09-bdcbd1ebcbac"), ClientId = new Guid("4d481d43-6ea0-4f0e-8cd8-e5bbbcd926c4"), WorkHours = 33, TargetMonth = 11, TargetYear = 2022, Created = new DateTime(2022, 7, 18, 17, 1, 0), TaskCategory = WorkTaskCategory.Planned },


                // Palle Broberg, Jobify, 60 hours, Jun 2022, Planned
                new WorkTask { Id = new Guid("bfa27b83-ddcf-480a-b327-2fe4815ea2a4"), EmployeeId = new Guid("628c072c-f8f9-4659-8b09-bdcbd1ebcbac"), ClientId = new Guid("c3204f6d-e918-41cc-bc7c-e11655d61fe2"), WorkHours = 60, TargetMonth = 6, TargetYear = 2022, Created = new DateTime(2022, 3, 5, 18, 51, 0), TaskCategory = WorkTaskCategory.Planned },

                // Palle Broberg, Jobify, 7 hours, 13 Jun 2022, Completed
                new WorkTask { Id = new Guid("0134ad05-a458-4279-b8c5-77203aafb7d6"), EmployeeId = new Guid("628c072c-f8f9-4659-8b09-bdcbd1ebcbac"), ClientId = new Guid("c3204f6d-e918-41cc-bc7c-e11655d61fe2"), WorkHours = 7, TargetMonth = 6, TargetYear = 2022, Created = new DateTime(2022, 6, 13, 16, 50, 55), TaskCategory = WorkTaskCategory.Completed },

                // Palle Broberg, Jobify, 7 hours, 15 Jun 2022, Completed
                new WorkTask { Id = new Guid("14635085-d54a-4c07-abcc-bab0d115963e"), EmployeeId = new Guid("628c072c-f8f9-4659-8b09-bdcbd1ebcbac"), ClientId = new Guid("c3204f6d-e918-41cc-bc7c-e11655d61fe2"), WorkHours = 7, TargetMonth = 6, TargetYear = 2022, Created = new DateTime(2022, 6, 15, 16, 50, 55), TaskCategory = WorkTaskCategory.Completed },

                // Palle Broberg, Jobify, 7 hours, 16 Jun 2022, Completed
                new WorkTask { Id = new Guid("ab188860-a7f1-4480-8d64-f0816b318e9e"), EmployeeId = new Guid("628c072c-f8f9-4659-8b09-bdcbd1ebcbac"), ClientId = new Guid("c3204f6d-e918-41cc-bc7c-e11655d61fe2"), WorkHours = 7, TargetMonth = 6, TargetYear = 2022, Created = new DateTime(2022, 6, 16, 16, 50, 55), TaskCategory = WorkTaskCategory.Completed },

                // Palle Broberg, Jobify, 7 hours, 17 Jun 2022, Completed
                new WorkTask { Id = new Guid("139bdfe0-ce4b-4c9d-80ea-d2b31808d261"), EmployeeId = new Guid("628c072c-f8f9-4659-8b09-bdcbd1ebcbac"), ClientId = new Guid("c3204f6d-e918-41cc-bc7c-e11655d61fe2"), WorkHours = 7, TargetMonth = 6, TargetYear = 2022, Created = new DateTime(2022, 6, 17, 16, 50, 55), TaskCategory = WorkTaskCategory.Completed },

                // Palle Broberg, Jobify, 7 hours, 22 Jun 2022, Completed
                new WorkTask { Id = new Guid("d5471112-075f-4f5c-89d9-c48760aa4a56"), EmployeeId = new Guid("628c072c-f8f9-4659-8b09-bdcbd1ebcbac"), ClientId = new Guid("c3204f6d-e918-41cc-bc7c-e11655d61fe2"), WorkHours = 7, TargetMonth = 6, TargetYear = 2022, Created = new DateTime(2022, 6, 22, 16, 50, 55), TaskCategory = WorkTaskCategory.Completed },

                // Palle Broberg, Jobify, 7 hours, 24 Jun 2022, Completed
                new WorkTask { Id = new Guid("b50ca42a-b9db-4bef-bc6c-a8797d69172e"), EmployeeId = new Guid("628c072c-f8f9-4659-8b09-bdcbd1ebcbac"), ClientId = new Guid("c3204f6d-e918-41cc-bc7c-e11655d61fe2"), WorkHours = 7, TargetMonth = 6, TargetYear = 2022, Created = new DateTime(2022, 6, 24, 16, 50, 55), TaskCategory = WorkTaskCategory.Completed },

                // Palle Broberg, Jobify, 7 hours, 25 Jun 2022, Completed
                new WorkTask { Id = new Guid("16a45730-870c-4892-a8ee-29bb7825022a"), EmployeeId = new Guid("628c072c-f8f9-4659-8b09-bdcbd1ebcbac"), ClientId = new Guid("c3204f6d-e918-41cc-bc7c-e11655d61fe2"), WorkHours = 7, TargetMonth = 6, TargetYear = 2022, Created = new DateTime(2022, 6, 25, 16, 50, 55), TaskCategory = WorkTaskCategory.Completed },

                // Palle Broberg, Jobify, 7 hours, 26 Jun 2022, Completed
                new WorkTask { Id = new Guid("aaf06b13-aee0-42d1-8215-1866bdbe90e3"), EmployeeId = new Guid("628c072c-f8f9-4659-8b09-bdcbd1ebcbac"), ClientId = new Guid("c3204f6d-e918-41cc-bc7c-e11655d61fe2"), WorkHours = 7, TargetMonth = 6, TargetYear = 2022, Created = new DateTime(2022, 6, 26, 16, 50, 55), TaskCategory = WorkTaskCategory.Completed },

                // Palle Broberg, Jobify, 7 hours, 27 Jun 2022, Completed
                new WorkTask { Id = new Guid("27b60534-99d9-40bf-b467-d1070542bc87"), EmployeeId = new Guid("628c072c-f8f9-4659-8b09-bdcbd1ebcbac"), ClientId = new Guid("c3204f6d-e918-41cc-bc7c-e11655d61fe2"), WorkHours = 7, TargetMonth = 6, TargetYear = 2022, Created = new DateTime(2022, 6, 27, 16, 50, 55), TaskCategory = WorkTaskCategory.Completed } 
                );

            context.SaveChanges();
        }
    }
}
