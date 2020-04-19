using System;
using BusinessLogic;
using BusinessLogicExceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
			Entity entity = new Entity("Pedidos ya");
			DateTime time = DateTime.Now; 
			Alarm alarm = new Alarm(entity,"Positivo", 50);
			management.AddAlarm(alarm, 10, false); //In this case we put 10 hours
			Assert.IsFalse(management.IsEmpty()); 
		}

		[TestMethod]
		[ExpectedException(typeof(AlarmManagementException))]
		public void CreateInvalidAlarm()
		{
			Entity entity = new Entity("Pedidos ya");
			Alarm alarm = new Alarm(entity, "Positivo", -50);
			management.AddAlarm(alarm, 10, false);//In this case we put 10 hours
		}


		[TestMethod]
		public void VerifyHourAlarm()
		{
			Entity entity = new Entity("Pedidos ya");
			Alarm alarm = new Alarm(entity, "Positivo", 50);
			management.AddAlarm(alarm, 10.0, false);
			DateTime aDateTime = DateTime.Now.AddHours(10);
			Assert.AreEqual(aDateTime, management.AlarmList[0].QuantityTime); 
		}

		[TestMethod]
		public void VerifyDaysAlarm()
		{
			Entity entity = new Entity("Pedidos ya");
			Alarm alarm = new Alarm(entity, "Positivo", 50);
			management.AddAlarm(alarm, 10.0, true);
			DateTime aDateTime = DateTime.Now.AddDays(10);
			Assert.AreEqual(aDateTime, management.AlarmList[0].QuantityTime);
		}


		[TestMethod]
		public void AddTwoAlarms()
		{
			Entity entity = new Entity("Pedidos ya");
			Alarm alarm = new Alarm(entity, "Negativo", 150);
			Alarm alarm2 = new Alarm(entity, "Positivo", 50);
			management.AddAlarm(alarm, 10.0, false);
			management.AddAlarm(alarm2, 10.0, true);
			Assert.IsFalse(management.IsEmpty()); 
		}

		[TestMethod]
		public void VerifyAlarmState()
		{
			Entity entity = new Entity("Pedidos ya");
			Alarm alarm = new Alarm(entity, "Negativo", 150);
			management.AddAlarm(alarm, 10.0, false);
			Assert.AreEqual(false, management.AlarmList[0].Active); 
		}

		[TestMethod]
		public void VerifyTypeAlarm()
		{
			Entity entity = new Entity("Pedidos ya");
			Alarm alarm = new Alarm(entity, "Negativo", 150);
			management.AddAlarm(alarm, 10.0, false);
			Assert.AreEqual("Negativo", management.AlarmList[0].Type);
		}


		[TestMethod]
		[ExpectedException(typeof(AlarmManagementException))]
		public void AddRepeteadAlarm()
		{
			Entity entity = new Entity("Pedidos ya");
			Alarm alarm = new Alarm(entity, "Positivo", 50);
			Alarm alarm2 = new Alarm(entity, "Positivo", 50); 
			management.AddAlarm(alarm, 10.0, true);
			management.AddAlarm(alarm2, 10.0, true);
		}

		

		

	}
}
