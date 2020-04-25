using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
	public class MessagesExceptions
	{
		public static string ERROR_IS_CONTAINED = "Error. Ya esta contenido en otro";
		public static string ERROR_DONT_EXIST = "Error. No existe";
		public static string ERROR_IS_EMPTY = "Error. Se encuentra vacio ";
        public static string ERROR_IS_AFTER_TODAY = "Error. La fecha de la frase no puede ser posterior a la del dia";
		public static string ERROR_IS_NEGATIVE = "Error. La cantidad de post no puede ser negativa";
		public static string ERROR_IS_NULL = "Error. No trae una entidad.";
		public static string ERROR_IS_ONE_YEAR_BEFORE = "Error. La fecha de la frase solo puede ser a lo sumo un año menor."; 
	}
}
