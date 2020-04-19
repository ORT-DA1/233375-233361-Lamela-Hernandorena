using System;
using BusinessLogic;
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
			Alarm alarm = new Alarm(entity,"Positivo", 50, time);
			management.AddAlarm(alarm);
			Assert.IsFalse(management.IsEmpty()); 
		}
		
	}
}
