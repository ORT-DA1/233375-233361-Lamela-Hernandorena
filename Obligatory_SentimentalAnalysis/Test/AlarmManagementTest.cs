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
			Alarm alarm = new Alarm(entity, Alarm.Type.Positive, 50, 5, false);
			management.AddAlarm(alarm);
			CollectionAssert.Contains(management.allAlarms, alarm);
		}

		[TestMethod]
		[ExpectedException(typeof(AlarmManagementException))]
		public void CreateInvalidAlarm()
		{
			Entity entity = new Entity("Pedidos ya");
			Alarm alarm = new Alarm(entity, Alarm.Type.Positive, -50, 13, true);
			management.AddAlarm(alarm);
		}

		[TestMethod]
		public void AddTwoAlarms()
		{
			Entity entity = new Entity("Pedidos ya");
			Entity entity2 = new Entity("Mc Donalds");
			Alarm alarm = new Alarm(entity, Alarm.Type.Positive, 40, 10, false);
			Alarm alarm2 = new Alarm(entity2, Alarm.Type.Negative, 30, 20, true);
			management.AddAlarm(alarm);
			management.AddAlarm(alarm2);
			Assert.IsTrue(management.allAlarms.Length == 2);
		}

		[TestMethod]
		public void VerifyAlarmState()
		{
			Entity entity = new Entity("Pedidos ya");
			Alarm alarm = new Alarm(entity, Alarm.Type.Positive, 150, 30, false);
			management.AddAlarm(alarm);
			Assert.AreEqual(false, management.allAlarms[0].Active);
		}

		[TestMethod]
		public void VerifyTypeAlarm()
		{
			Entity entity = new Entity("Pedidos ya");
			Alarm alarm = new Alarm(entity, Alarm.Type.Positive, 150, 30, false);
			management.AddAlarm(alarm);
			Assert.AreEqual(Alarm.Type.Positive, management.allAlarms[0].TypeOfAlarm);
		}


		[TestMethod]
		[ExpectedException(typeof(AlarmManagementException))]
		public void AddRepeteadAlarm()
		{
			Entity entity = new Entity("Pedidos ya");
			Alarm alarm = new Alarm(entity, Alarm.Type.Positive, 90, 15, false);
			Alarm alarm2 = new Alarm(entity, Alarm.Type.Positive, 90, 15, false); 
			management.AddAlarm(alarm);
			management.AddAlarm(alarm2);
		}

		[TestMethod]
		[ExpectedException(typeof(AlarmManagementException))]
		public void CreateInvalidAlarm2()
		{
			Entity entity = null;
			Alarm alarm = new Alarm(entity, Alarm.Type.Positive, 90, 15, false);
			management.AddAlarm(alarm);
		}


		[TestMethod]
		[ExpectedException(typeof(AlarmManagementException))]
		public void CreateInvalidAlarm3()
		{
			Entity entity = new Entity("Coca Cola");
			Alarm alarm = new Alarm(entity, Alarm.Type.Positive, 90, -15, false);
			management.AddAlarm(alarm);
		}
	}
}
