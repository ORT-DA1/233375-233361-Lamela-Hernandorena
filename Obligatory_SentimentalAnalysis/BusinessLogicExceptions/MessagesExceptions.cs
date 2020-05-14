using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
	public class MessagesExceptions
	{
		public static string ErrorIsContained = "Error. Ya esta contenido en otro.";
		public static string ErrorDontExist = "Error. No existe.";
		public static string ErrorIsEmpty = "Error. El texto no puede ser vacio.";
        public static string ErrorIsAfterToday = "Error. La fecha de la frase no puede ser posterior a la del dia.";
		public static string ErrorIsNegativePosts = "Error. La cantidad de post no puede ser negativa.";
        public static string ErrorIsNegativeTime = "Error. El plazo de tiempo no puede ser negativo.";
        public static string ErrorIsNull = "Error. No trae una entidad.";
		public static string ErrorIsOneYearBefore = "Error. La fecha de la frase solo puede ser a lo sumo un año menor."; 
	}
}
