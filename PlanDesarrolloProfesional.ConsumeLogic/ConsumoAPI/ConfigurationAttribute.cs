namespace PlanDesarrolloProfesional.ConsumeLogic
{
    public class ConfigurationAttribute
    {
        #region Variables y Constructor
        public ConfigurationAttribute()
        {
        }
        #endregion
        #region Método
        public string GetRouteAttribute(string RouteAttribute)
        {
            return RouteAttribute;
        }

        public string GetRouteAttribute(string RouteAttribute, string Parametro)
        {
            RouteAttribute = RouteAttribute.Replace("[Parametro1]", Parametro);

            return RouteAttribute;
        }

        public string GetRouteAttribute(string RouteAttribute, string ParametroI, string ParametroII)
        {
            RouteAttribute = RouteAttribute.Replace("[Parametro1]", ParametroI);
            RouteAttribute = RouteAttribute.Replace("[Y]", "&");
            RouteAttribute = RouteAttribute.Replace("[Parametro2]", ParametroII);

            return RouteAttribute;
        }


        public string GetRouteAttribute(string RouteAttribute, string ParametroI, string ParametroII, string ParametroIII)
        {
            RouteAttribute = RouteAttribute.Replace("[Parametro1]", ParametroI);
            RouteAttribute = RouteAttribute.Replace("[Parametro2]", ParametroII);
            RouteAttribute = RouteAttribute.Replace("[Parametro3]", ParametroIII);
            RouteAttribute = RouteAttribute.Replace("[Y]", "&");

            return RouteAttribute;
        }

        public string GetRouteAttribute(string RouteAttribute, string ParametroI, string ParametroII, string ParametroIII, string ParametroIV, string ParametroV, string ParametroVI, string ParametroVII)
        {
            RouteAttribute = RouteAttribute.Replace("[Parametro1]", ParametroI);
            RouteAttribute = RouteAttribute.Replace("[Parametro2]", ParametroII);
            RouteAttribute = RouteAttribute.Replace("[Parametro3]", ParametroIII);
            RouteAttribute = RouteAttribute.Replace("[Parametro4]", ParametroIV);
            RouteAttribute = RouteAttribute.Replace("[Parametro5]", ParametroV);
            RouteAttribute = RouteAttribute.Replace("[Parametro6]", ParametroVI);
            RouteAttribute = RouteAttribute.Replace("[Parametro7]", ParametroVII);
            RouteAttribute = RouteAttribute.Replace("[Y]", "&");

            return RouteAttribute;
        }
        #endregion
    }
}
