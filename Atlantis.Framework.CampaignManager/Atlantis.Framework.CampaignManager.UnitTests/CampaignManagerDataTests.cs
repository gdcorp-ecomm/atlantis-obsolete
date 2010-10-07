using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Atlantis.Framework.CampaignManagerData.Interface;
using Atlantis.Framework.CampaignManagerData.Interface.Entities;
using Atlantis.Framework.Entity.Interface;
using Atlantis.Framework.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Atlantis.Framework.CampaignManager.UnitTests
{
    [TestClass]
    public class CampaignManagerDataTests
    {
        [TestMethod]
        public void TestAudienceTypeEntityQuery()
        {
            TestQuery<AudienceType>( 
                5000,
                (x) =>
                {
                    Console.WriteLine("\t{0}: {1}", x.AudienceTypeID, x.Name);
                });
        }

        [TestMethod]
        public void TestCampaignEntityQuery()
        {
            TestQuery<Campaign>( 
                5001,
                (x) =>
                {
                    Console.WriteLine("\t{0}: {1}", x.CampaignID, x.Name);
                });
        } 

        [TestMethod]
        public void TestCampaignStatusTypeEntityQuery()
        {
            TestQuery<CampaignStatusType>( 
                5002,
                (x) =>
                {
                    Console.WriteLine("\t{0}: {1}", x.CampaignStatusTypeID, x.Name);
                });
        }

        [TestMethod]
        public void TestCampaignTypeEntityQuery()
        {
            TestQuery<CampaignType>( 
                5003,
                (x) =>
                {
                    Console.WriteLine("\t{0}: {1}", x.CampaignTypeID, x.Name);
                });
        }

        [TestMethod]
        public void TestCompanyEntityQuery()
        {
            TestQuery<Company>( 
                5004,
                (x) =>
                {
                    Console.WriteLine("\t{0}: {1}", x.CompanyID, x.Name);
                });
        }

        [TestMethod]
        public void TestObjectiveEntityQuery()
        {
            TestQuery<Objective>( 
                5005,
                (x) =>
                {
                    Console.WriteLine("\t{0}: {1}", x.ObjectiveID, x.Name);
                });
        }

        [TestMethod]
        public void TestOfferTypeEntityQuery()
        {
            TestQuery<OfferType>( 
                5006,
                (x) =>
                {
                    Console.WriteLine("\t{0}: {1}", x.OfferTypeID, x.Name);
                });
        }

        [TestMethod]
        public void TestProductEntityQuery()
        {
            TestQuery<Product>( 
                5007,
                (x) =>
                {
                    Console.WriteLine("\t{0}: {1}", x.ProductID, x.Name);
                });
        }

        [TestMethod]
        public void TestUserResourceEntityQuery()
        {
            TestQuery<UserResource>( 
                5008,
                (x) =>
                {
                    Console.WriteLine("\t{0}: {1}", x.UserResourceID, x.Name);
                });
        }
        
        [TestMethod]
        public void TestApplicationEntityQuery()
        {
            TestQuery<Application>(
                5023,
                (x) =>
                {
                    Console.WriteLine("\t{0}: {1}", x.ApplicationID, x.Name);
                });
        }

        private void TestQuery<EntityType>(int requestType, Action<EntityType> testAction)
            where EntityType : class, IAtlantisEntity, new()
        {
            TestRepositoryAction<EntityType>(RepositoryAction.Query, null, requestType, testAction);
        }

        private void TestUpdate<EntityType>(int requestType, EntityType entity, Action<EntityType> testAction)
            where EntityType : class, IAtlantisEntity, new()
        {
            TestRepositoryAction<EntityType>(RepositoryAction.Update, new List<EntityType> { entity }, requestType, testAction);
        }

        private void TestRepositoryAction<EntityType>(RepositoryAction repositoryAction, List<EntityType> entities, int requestType, Action<EntityType> testAction)
            where EntityType : class, IAtlantisEntity, new()
        {
            try
            {
                var requestData = new CampaignManagerRequestData<EntityType>
                {
                    Entities = entities,
                    RepositoryAction = repositoryAction
                };

                var responseData = Engine.Engine.ProcessRequest(requestData, requestType) as IAtlantisEntityResponseData<EntityType>;

                if (responseData.Entities != null)
                {
                    foreach (var entity in responseData.Entities)
                    {
                        testAction(entity);
                    }
                }
                else
                {
                    testAction(null);
                }
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        private EntityType Single<EntityType>(int requestType, Func<EntityType, bool> predicate)
            where EntityType : class, IAtlantisEntity, new()
        {
            EntityType entity = null;

            try
            {
                var requestData = new CampaignManagerRequestData<EntityType>
                {
                    RepositoryAction = RepositoryAction.Query
                };

                var responseData = Engine.Engine.ProcessRequest(requestData, requestType) as IAtlantisEntityResponseData<EntityType>;

                if (responseData.EntityCount > 0)
                {
                    entity = responseData.Entities.SingleOrDefault(predicate);
                }

                if (entity == null)
                {
                    Assert.Fail("Response didn't contain entity you're looking for.");
                }
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

            return entity;
        }
    }
}
