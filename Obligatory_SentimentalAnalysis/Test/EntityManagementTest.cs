using BusinessLogic;
using BusinessLogicExceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
	[TestClass]
	public class EntityManagementTest
	{

		EntityManagement management; 
		


		[TestInitialize]
		public void SetUp()
		{
			management = new EntityManagement(); 	
			
		}



		[TestMethod]
		public void AddValidEntity()
		{
			Entity entity = new Entity()
			{
				EntityName = "Coca Cola"
			};
			management.AddEntity(entity);
			CollectionAssert.Contains(management.AllEntities, entity);
		}


		[TestMethod]
		public void AddValidEntity2()
		{
			Entity entity = new Entity()
			{
				EntityName = "                                                                Mc       Donalds                                              "
			};
			management.AddEntity(entity);
			CollectionAssert.Contains(management.AllEntities, entity);
		}


		[TestMethod]
		[ExpectedException(typeof(EntityManagementException))]
		public void AddInvalidEntity1()
		{
			Entity entity = new Entity();
			management.AddEntity(entity); 
		}


		[TestMethod]
		[ExpectedException(typeof(EntityManagementException))]
		public void AddInvalidEntity2()
		{
			Entity entity = new Entity()
			{
				EntityName = "Coca        Cola"
			};
			management.AddEntity(entity);
			Entity entity2 = new Entity()
			{
				EntityName = "Coca Cola"
			};
			management.AddEntity(entity); 
		}


		[TestMethod]
		public void DeleteValidEntity()
		{
			Entity entity = new Entity()
			{
				EntityName = "Pedidos Ya"
			};
			management.AddEntity(entity);
			management.DeleteEntity(entity);
			Assert.IsTrue(management.IsEmpty()); 
		}


		[TestMethod]
		public void DeleteValidEntity2()
		{
			Entity entity = new Entity()
			{
				EntityName = "Pedidos Ya"
			};
			Entity entity2 = new Entity()
			{
				EntityName = "       Mc            donalds           "
			}; 
			management.AddEntity(entity);
			management.AddEntity(entity2); 
			management.DeleteEntity(entity);
			CollectionAssert.DoesNotContain(management.AllEntities, entity);

		}


		[TestMethod]
		[ExpectedException(typeof(EntityManagementException))]
		public void DeleteInvalidEntity()
		{
			Entity entity = new Entity()
			{
				EntityName = "Pedidos Ya"
			};
			management.AddEntity(entity);
			management.DeleteEntity(entity);
			management.DeleteEntity(entity);
		}


		[TestMethod]
		public void TestIsEmpty()
		{
			bool result = management.IsEmpty(); 
			Assert.IsTrue(result); 
		}

		[TestMethod]
		public void TestIsEmpty2()
		{
			Entity entity = new Entity()
			{
				EntityName = "Pedidos Ya"
			};
			management.AddEntity(entity); 
			bool result = management.IsEmpty(); 
			Assert.IsFalse(result);
		}



		[TestMethod]
		[ExpectedException(typeof(EntityManagementException))]
		public void AddExtrangeEntitys()
		{
			Entity entity = new Entity()
			{
				EntityName = "Coca Cola"
			};
			Entity entity2 = new Entity()
			{
				EntityName = "cOCa coLA"
			};
			management.AddEntity(entity);
			management.AddEntity(entity2); 
			
		}
		

		[TestMethod]
		[ExpectedException(typeof(EntityManagementException))]
		public void AddEntitysWithSpace()
		{
			Entity entity = new Entity()
			{
				EntityName = "MC           DONALDS"
			};
			Entity entity2 = new Entity()
			{
				EntityName = "mc donalds"
			};
			management.AddEntity(entity);
			management.AddEntity(entity2); 
		}

		[TestMethod]
		public void EqualsTest()
		{
			Entity entity = new Entity()
			{
				EntityName = "Coca      Cola"
			};
			Entity entity2 = new Entity()
			{
				EntityName = "cOCa coLA"
			};
			Assert.IsTrue(entity.Equals(entity2));
		}
	}
}
