using System;
using System.Collections.Generic;
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
			Entity entity = new Entity("Coca cola");
			management.AddEntity(entity);
			Assert.IsFalse(management.IsEmpty());
		}


		[TestMethod]
		public void AddValidEntity2()
		{
			Entity entity = new Entity("                                                                Mc       Donalds                                              ");
			management.AddEntity(entity);
			Assert.AreEqual("Mc Donalds", management.EntityList[0].EntityName); 
		}


		[TestMethod]
		[ExpectedException(typeof(EntityManagementException))]
		public void AddInvalidEntity1()
		{
			Entity entity = new Entity("");
			management.AddEntity(entity); 
		}


		[TestMethod]
		[ExpectedException(typeof(EntityManagementException))]
		public void AddInvalidEntity2()
		{
			Entity entity = new Entity("Coca        Cola");
			management.AddEntity(entity);
			Entity entity2 = new Entity("Coca Cola");
			management.AddEntity(entity); 
		}


		[TestMethod]
		public void DeleteValidEntity()
		{
			Entity entity = new Entity("Pedidos Ya");
			management.AddEntity(entity);
			management.DeleteEntity(entity);
			Assert.IsTrue(management.IsEmpty()); 
		}


		[TestMethod]
		public void DeleteValidEntity2()
		{
			Entity entity = new Entity("Pedidos Ya");
			Entity entity2 = new Entity("       Mc            donalds           "); 
			management.AddEntity(entity);
			management.AddEntity(entity2); 
			management.DeleteEntity(entity);
			Assert.AreEqual("Mc donalds", management.EntityList[0].EntityName);

		}


		[TestMethod]
		[ExpectedException(typeof(EntityManagementException))]
		public void DeleteInvalidEntity()
		{
			Entity entity = new Entity("Pedidos Ya");
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
			management.AddEntity(new Entity("Pedidos ya")); 
			bool result = management.IsEmpty(); 
			Assert.IsFalse(result);
		}



		[TestMethod]
		[ExpectedException(typeof(EntityManagementException))]
		public void AddExtrangeEntitys()
		{
			Entity entity = new Entity("Coca Cola");
			Entity entity2 = new Entity("cOCa coLA");
			management.AddEntity(entity);
			management.AddEntity(entity2); 
			
		}
		

		[TestMethod]
		[ExpectedException(typeof(EntityManagementException))]
		public void AddEntitysWithSpace()
		{
			Entity entity = new Entity("MC           DONALDS");
			Entity entity2 = new Entity("mc donalds");
			management.AddEntity(entity);
			management.AddEntity(entity2); 
		}

	}
}
