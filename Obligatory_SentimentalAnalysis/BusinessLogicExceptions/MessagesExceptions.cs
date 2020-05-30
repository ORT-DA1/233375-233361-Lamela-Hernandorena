
namespace BusinessLogicExceptions
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
		public static string ErrorIsAssociated = "Error. El sentimiento esta asociado a una frase.";
        public static string ErrorLengthUserName = "Error. El largo del nombre de usuario no puede ser mayor a 10 caracteres.";
        public static string ErrorLengthNameOrLastName = "Error. El largo del nombre o apellido no puede ser mayor a 15 caracteres.";
        public static string ErrorAge = "Error. La edad debe estar entre 13 y 100 años.";
        public static string ErrorAuthorExist = "Error. Ya existe el nombre de usuario. ";
    }
}
