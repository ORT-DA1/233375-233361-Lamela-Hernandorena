﻿using BusinessLogic;
using BusinessLogicExceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain; 

namespace Test
{
	[TestClass]
	public class AlarmManagementTest
	{

		AlarmManagement management;


		[TestInitialize]
		public void SetUp()
		{
			management = new AlarmManagement();

		}


		[TestMethod]
		public void CreateValidNewAlarm()
		{
			Entity entity = new Entity()
			{
				EntityName = "Pedidos Ya"
			};

			Alarm alarm = new Alarm()
			{
				Entity = entity,
				TypeOfAlarm = Alarm.Type.Positive,
				QuantityPost = 50,
				QuantityTime = 5,
				IsInHours = false
			};
			management.AddAlarm(alarm);
			CollectionAssert.Contains(management.AllAlarms, alarm);
		}

		[TestMethod]
		[ExpectedException(typeof(AlarmManagementException))]
		public void CreateInvalidAlarm()
		{
			Entity entity = new Entity()
			{
				EntityName = "Pedidos ya"
			};
			Alarm alarm = new Alarm()
			{
				Entity = entity,
				TypeOfAlarm = Alarm.Type.Positive,
				QuantityPost = -50,
				QuantityTime = 13,
				IsInHours = true
			};
			management.AddAlarm(alarm);
		}

		[TestMethod]
		public void AddTwoAlarms()
		{
			Entity entity = new Entity()
			{
				EntityName = "Pedidos ya"
			};
			Entity entity2 = new Entity()
			{
				EntityName = "Mc Donalds"
			};
			Alarm alarm = new Alarm() 
			{
			Entity = entity,
			TypeOfAlarm = Alarm.Type.Positive,
			QuantityPost = 40,
			QuantityTime = 10,
			IsInHours = false
			};
			Alarm alarm2 = new Alarm()
			{
				Entity = entity2,
				TypeOfAlarm = Alarm.Type.Negative,
				QuantityPost=30,
				QuantityTime = 20,
				IsInHours = true
			};
			management.AddAlarm(alarm);
			management.AddAlarm(alarm2);
			Assert.IsTrue(management.AllAlarms.Length == 2);
		}

		[TestMethod]
		public void VerifyAlarm()
		{
			Entity entity = new Entity()
			{
				EntityName = "Pedidos ya"
			};
			Alarm alarm = new Alarm()
			{
				Entity = entity,
				TypeOfAlarm = Alarm.Type.Positive,
				QuantityPost = 150,
				QuantityTime = 30,
				IsInHours = false
			};
			management.AddAlarm(alarm);
			CollectionAssert.Contains(management.AllAlarms, alarm);
		}



		[TestMethod]
		[ExpectedException(typeof(AlarmManagementException))]
		public void CreateInvalidAlarm2()
		{
			Entity entity = new Entity();
			Alarm alarm = new Alarm()
			{
				Entity = entity,
				TypeOfAlarm = Alarm.Type.Positive,
				QuantityPost = 90,
				QuantityTime = 15,
				IsInHours = false
			};
			management.AddAlarm(alarm);
		}


		[TestMethod]
		[ExpectedException(typeof(AlarmManagementException))]
		public void CreateInvalidAlarm3()
		{
			Entity entity = new Entity()
			{
				EntityName = "Coca Cola"
			};
			Alarm alarm = new Alarm()
			{
				Entity = entity,
				TypeOfAlarm = Alarm.Type.Positive,
				QuantityPost = 90,
				QuantityTime = -15,
				IsInHours = false
			};
			management.AddAlarm(alarm);
		}

		[TestMethod]
		public void TestingMethodShow()
		{
			Entity entity = new Entity()
			{
				EntityName = "Pedidos ya"
			};
			Alarm alarm = new Alarm()
			{
				Entity = entity,
				TypeOfAlarm = Alarm.Type.Positive,
				QuantityPost = 150,
				QuantityTime = 30,
				IsInHours = false
			};
			management.AddAlarm(alarm); 
			Assert.AreEqual(alarm.Show(), management.AllAlarms[0].Show()); 
		}


		[TestMethod]
		public void TestingAddNegativeAlarm()
		{
			Entity entity = new Entity()
			{
				EntityName = "Pedidos ya"
			};
			Alarm alarm = new Alarm()
			{
				Entity = entity,
				TypeOfAlarm = Alarm.Type.Negative,
				QuantityPost = 150,
				QuantityTime = 30,
				IsInHours = false, 
				Active=true
			};
			management.AddAlarm(alarm);
			Assert.AreEqual(alarm.Show(), management.AllAlarms[0].Show());
			CollectionAssert.Contains(management.AllAlarms, alarm); 
		}

		[TestMethod]
		public void TestingMethodShow2()
		{
			Entity entity = new Entity()
			{
				EntityName = "Pedidos ya"
			};
			Alarm alarm = new Alarm()
			{
				Entity = entity,
				TypeOfAlarm = Alarm.Type.Positive,
				QuantityPost = 150,
				QuantityTime = 30,
				IsInHours = false,
				Active = true
			};
			management.AddAlarm(alarm);
			Assert.AreEqual(alarm.Show(), management.AllAlarms[0].Show());
		}
	}
}
